using RfrmLib.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace RfrmUI
{
    public partial class MainWindow : Window
    {
        private const string __errorItem = "All Item fields must be filled in!";
        private const string __inputDir = "_inputdata";
        private const string __outputDir = "_outputdata";
        private const string __inputFilename = "data1.xml";
        private const string __transformFilename = "transform.xslt";
        private const string __outputFilename = "employees.xml";

        public ObservableCollection<string> Folders { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Report{ get; set; } = new ObservableCollection<string>();

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

        private void UpdateInvoke(IEnumerable<string> report)
        {
            Dispatcher.Invoke(() =>
            {
                Report.Clear();
                foreach (var entry in report)
                    Report.Add(entry);
            });
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

        private bool IsItemTBsNotEmpty() =>
            NameTB.Text.Length > 0 && SurnameTB.Text.Length > 0 && AmountTB.Text.Length > 0 && MountTB.Text.Length > 0;
    }
}
