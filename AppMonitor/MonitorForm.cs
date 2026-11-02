using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace AppMonitor
{
    public partial class MonitorForm : Form
    {
        private List<string> _forbiddenProcesses = new List<string>();
        private string _jsonPath = "forbidden.json";
        private string _logPath = "activity_log.txt";

        public MonitorForm()
        {
            InitializeComponent();
            LoadForbiddenList();

            timer1.Interval = 3000;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        // Этот метод решает главную красную ошибку CS0103. 
        // Конструктор форм ищет его, поэтому мы оставляем его здесь пустым.
        private void MonitorForm_Load(object? sender, EventArgs e)
        {
        }

        // Добавлен знак '?' к object? sender для решения CS8622
        private void Timer1_Tick(object? sender, EventArgs e)
        {
            var processes = Process.GetProcesses();

            listBoxActive.Items.Clear();
            foreach (var p in processes.OrderBy(p => p.ProcessName))
            {
                listBoxActive.Items.Add(p.ProcessName);

                if (_forbiddenProcesses.Contains(p.ProcessName.ToLower()))
                {
                    try
                    {
                        p.Kill();
                        LogAction(p.ProcessName, "Closed");
                    }
                    catch (Exception) { /* Handle system processes with restricted access */ }
                }
            }
        }

        private void LoadForbiddenList()
        {
            if (File.Exists(_jsonPath))
            {
                string json = File.ReadAllText(_jsonPath);
                _forbiddenProcesses = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
                UpdateForbiddenListBox();
            }
        }

        private void SaveForbiddenList()
        {
            string json = JsonSerializer.Serialize(_forbiddenProcesses);
            File.WriteAllText(_jsonPath, json);
        }

        private void btnAddForbidden_Click(object? sender, EventArgs e)
        {
            string newApp = txtForbiddenName.Text.ToLower().Trim();
            if (!string.IsNullOrEmpty(newApp) && !_forbiddenProcesses.Contains(newApp))
            {
                _forbiddenProcesses.Add(newApp);
                SaveForbiddenList();
                UpdateForbiddenListBox();
            }
        }

        private void LogAction(string appName, string action)
        {
            string logEntry = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss} | {appName} | {action}{Environment.NewLine}";
            File.AppendAllText(_logPath, logEntry);
        }

        private void btnOpenLog_Click(object? sender, EventArgs e)
        {
            if (File.Exists(_logPath))
            {
                Process.Start(new ProcessStartInfo { FileName = _logPath, UseShellExecute = true });
            }
        }

        private void btnStartProcess_Click(object? sender, EventArgs e)
        {
            try
            {
                Process.Start(txtProcessPath.Text);
                LogAction(txtProcessPath.Text, "Started");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Launch error: " + ex.Message);
            }
        }

        private void btnKillSelected_Click(object? sender, EventArgs e)
        {
            if (listBoxActive.SelectedItem != null)
            {
                // Использование ?. и ?? решает предупреждения CS8600, CS8602 и CS8604
                string pName = listBoxActive.SelectedItem?.ToString() ?? "Unknown";
                var processes = Process.GetProcessesByName(pName);
                foreach (var p in processes)
                {
                    p.Kill();
                    LogAction(pName, "Closed (Manual)");
                }
            }
        }

        private void UpdateForbiddenListBox()
        {
            // Опционально для визуального обновления списка запрещенных программ, если есть второй ListBox
        }
    }
}