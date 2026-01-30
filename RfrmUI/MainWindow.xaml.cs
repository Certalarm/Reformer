using RfrmLib.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;

namespace RfrmUI
{
    public partial class MainWindow : Window
    {
        private const string __errorItem = "All Item fields must be filled in!";
        private const string __explorerName = "explorer.exe";
        private const string __inputDir = "_inputdata";
        private const string __outputDir = "_outputdata";
        private const string __inputFilename = "data1.xml";
        private const string __transformFilename = "transform.xslt";
        private const string __outputFilename = "employees.xml";

        public ObservableCollection<string> Folders { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Report { get; set; } = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            var appFullDir = AppDomain.CurrentDomain.BaseDirectory;
            var inputFullDir = Path.Combine(appFullDir, __inputDir);
            var outputFullDir = Path.Combine(appFullDir, __outputDir);

            Folders.Add(inputFullDir);
            Folders.Add(outputFullDir);
            ReportLW.ItemsSource = Report;
        }

        private void Button_ChangeInputFolder_Click(object sender, RoutedEventArgs e)
        {
            ChangeFolder(0);
        }

        private void Button_ChangeOutputFolder_Click(object sender, RoutedEventArgs e)
        {
            ChangeFolder(1);
        }

        private void Button_OpenInputData_Click(object sender, RoutedEventArgs e)
        {
            StartProcess(__explorerName, Folders[0]);
        }

        private void Button_OpenOutputData_Click(object sender, RoutedEventArgs e)
        {
            StartProcess(__explorerName, Folders[1]);
        }

        private void Button_MainFlow_Clock(object sender, RoutedEventArgs e)
        {
            var inputFullFilename = Path.Combine(Folders[0], __inputFilename);
            var transformFullFilename = Path.Combine(Folders[0], __transformFilename);
            var outputFullFilename = Path.Combine(Folders[1], __outputFilename);
            ProcessingMainFlow(inputFullFilename, transformFullFilename, outputFullFilename);
        }

        private void Button_AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (IsItemTBsNotEmpty())
            {
                var inputFullFilename = Path.Combine(Folders[0], __inputFilename);
                var transformFullFilename = Path.Combine(Folders[0], __transformFilename);
                var outputFullFilename = Path.Combine(Folders[1], __outputFilename);
                var item = $"{NameTB.Text}|{SurnameTB.Text}|{AmountTB.Text}|{MountTB.Text}";
                ProcessingAddItemFlow(inputFullFilename, transformFullFilename, outputFullFilename, item);
            }
            else
            {
                UpdateInvoke([__errorItem]);
            }
        }

        private void ProcessingMainFlow(string inputFullFilename, string tramsformFullFilename, string outputFullFilename)
        {
            MainFlowController controller = new MainFlowController();
            UpdateInvoke(controller.Handle(inputFullFilename, tramsformFullFilename, outputFullFilename));
        }

        private void ProcessingAddItemFlow(string inputFullFilename, string tramsformFullFilename, string outputFullFilename, string item)
        {
            AddItemController controller = new AddItemController();
            UpdateInvoke(controller.Handle(inputFullFilename, tramsformFullFilename, outputFullFilename, item));
        }

        private void UpdateInvoke(IEnumerable<string> report)
        {
            Dispatcher.Invoke(() =>
            {
                Report.Clear();
                foreach (var entry in report)
                    Report.Add(entry);
            });
        }

        private static void StartProcess(string processName, string args)
        {
            using Process proc = new();
            proc.StartInfo.FileName = processName;
            proc.StartInfo.Arguments = args;
            proc.Start();
        }

        private bool IsItemTBsNotEmpty() =>
            NameTB.Text.Length > 0 && SurnameTB.Text.Length > 0 && AmountTB.Text.Length > 0 && MountTB.Text.Length > 0;

        private void ChangeFolder(int folderIndex)
        {
            var dialog = new FolderBrowserDialog
            {
                SelectedPath = Folders[folderIndex]
            };
            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (Folders[folderIndex] != dialog.SelectedPath)
                Folders[folderIndex] = dialog.SelectedPath;
        }
    }
}
