using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AppMonitor
{
    public partial class SearchForm : Form
    {
        private FileSearchEngine _engine = new FileSearchEngine();
        private string _outputFolder = "";

        public SearchForm()
        {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object? sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    _outputFolder = fbd.SelectedPath;
                    lblFolder.Text = "Folder: " + _outputFolder;
                }
            }
        }

        private async void btnStart_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_outputFolder))
            {
                MessageBox.Show("Please select an output folder first!");
                return;
            }

            var words = txtWords.Text.Split(new[] { '\r', '\n', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (words.Count == 0)
            {
                MessageBox.Show("Please enter forbidden words!");
                return;
            }

            progressBar1.Style = ProgressBarStyle.Marquee;
            var progress = new Progress<int>(v => { });

            try
            {
                await _engine.StartSearchAsync(words, _outputFolder, progress);

                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 100;
                MessageBox.Show("Search completed! Check the output folder for results.");
            }
            catch (OperationCanceledException)
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 0;
                MessageBox.Show("Search was stopped.");
            }
        }

        private void btnPause_Click(object? sender, EventArgs e) => _engine.Pause();

        private void btnResume_Click(object? sender, EventArgs e) => _engine.Resume();

        private void btnStop_Click(object? sender, EventArgs e) => _engine.Stop();
    }
}