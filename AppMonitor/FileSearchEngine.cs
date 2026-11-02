using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AppMonitor
{
    public class FileSearchEngine
    {
        private CancellationTokenSource? _cts;
        private ManualResetEventSlim? _pauseEvent;
        private ConcurrentDictionary<string, int>? _wordStats;
        private ConcurrentBag<string>? _foundFilesInfo;

        public async Task StartSearchAsync(List<string> forbiddenWords, string outputFolder, IProgress<int> progress)
        {
            _cts = new CancellationTokenSource();
            _pauseEvent = new ManualResetEventSlim(true);
            _wordStats = new ConcurrentDictionary<string, int>();
            _foundFilesInfo = new ConcurrentBag<string>();

            var drives = DriveInfo.GetDrives().Where(d => d.IsReady).ToList();

            await Task.Run(() =>
            {
                foreach (var drive in drives)
                {
                    SearchInDirectory(drive.RootDirectory.FullName, forbiddenWords, outputFolder, progress);
                }
                GenerateReport(outputFolder);
            }, _cts.Token);
        }

        private void SearchInDirectory(string dir, List<string> words, string outFolder, IProgress<int> progress)
        {
            try
            {
                _cts?.Token.ThrowIfCancellationRequested();
                _pauseEvent?.Wait(_cts.Token);

                foreach (var file in Directory.GetFiles(dir, "*.txt"))
                {
                    ProcessFile(file, words, outFolder);
                    progress.Report(1);
                }

                foreach (var subDir in Directory.GetDirectories(dir))
                {
                    SearchInDirectory(subDir, words, outFolder, progress);
                }
            }
            catch (UnauthorizedAccessException) { }
            catch (Exception) { }
        }

        private void ProcessFile(string filePath, List<string> words, string outFolder)
        {
            try
            {
                string content = File.ReadAllText(filePath);
                bool found = false;
                int totalReplacements = 0;

                foreach (var word in words)
                {
                    if (content.Contains(word, StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                        int count = Regex.Matches(content, Regex.Escape(word), RegexOptions.IgnoreCase).Count;
                        totalReplacements += count;
                        _wordStats?.AddOrUpdate(word, count, (k, v) => v + count);

                        content = Regex.Replace(content, Regex.Escape(word), "*******", RegexOptions.IgnoreCase);
                    }
                }

                if (found)
                {
                    FileInfo fi = new FileInfo(filePath);
                    _foundFilesInfo?.Add($"File: {filePath} | Size: {fi.Length} bytes | Replacements: {totalReplacements}");

                    string fileName = Path.GetFileName(filePath);
                    string newPath = Path.Combine(outFolder, fileName);
                    string maskedPath = Path.Combine(outFolder, "masked_" + fileName);

                    File.Copy(filePath, newPath, true);
                    File.WriteAllText(maskedPath, content);
                }
            }
            catch (Exception) { }
        }

        public void Pause() => _pauseEvent?.Reset();
        public void Resume() => _pauseEvent?.Set();
        public void Stop()
        {
            _cts?.Cancel();
            _pauseEvent?.Set();
        }

        private void GenerateReport(string outFolder)
        {
            if (_wordStats == null || !_wordStats.Any()) return;

            string reportPath = Path.Combine(outFolder, "report.txt");
            var reportContent = new List<string> { "--- SEARCH REPORT ---", "" };

            reportContent.Add("FOUND FILES:");
            if (_foundFilesInfo != null)
            {
                reportContent.AddRange(_foundFilesInfo);
            }

            reportContent.Add("");
            reportContent.Add("TOP 10 FORBIDDEN WORDS:");
            var topWords = _wordStats.OrderByDescending(x => x.Value).Take(10);
            foreach (var stat in topWords)
            {
                reportContent.Add($"- {stat.Key}: {stat.Value} times");
            }

            File.WriteAllLines(reportPath, reportContent);
        }
    }
}