using RfrmLib.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace RfrmUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

            var inputFullFilename = Path.Combine(Folders[0], __inputFilename);
            var tramsformFullFilename = Path.Combine(Folders[0], __transformFilename);
            var outputFullFilename = Path.Combine(Folders[1], __outputFilename);


            //AddItemController aiController = new AddItemController();
            //var result = aiController.Handle(inputFullFilename, tramsformFullFilename, outputFullFilename,
            //    "Lena|Ivanova|1234.5|april");

        }

        private void ButtonIn_Click(object sender, RoutedEventArgs e)
        {
            //var dialog = new FolderBrowserDialog
            //{
            //    SelectedPath = Folders[0]
            //};
            //if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            //if (Folders[0] != dialog.SelectedPath)
            //{
            //    ClearLists();
            //    Folders[0] = dialog.SelectedPath;
            //    UpdateWatcher(Folders[0]);
            //}
        }

        private void ButtonOut_Click(object sender, RoutedEventArgs e)
        {
            //var dialog = new FolderBrowserDialog
            //{
            //    SelectedPath = Folders[1]
            //};
            //if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            //if (Folders[1] != dialog.SelectedPath)
            //{
            //    Folders[1] = dialog.SelectedPath;
            //}
        }

        private void ProcessingMainFlow(string inputFullFilename, string tramsformFullFilename, string outputFullFilename)
        {
            MainFlowController controller = new MainFlowController();
            Report = new ObservableCollection<string>(
                controller.Handle(inputFullFilename, tramsformFullFilename, outputFullFilename));
        }

        private void ProcessingAddItemFlow(string inputFullFilename, string tramsformFullFilename, string outputFullFilename, string item)
        {
            AddItemController controller = new AddItemController();
            Report = new ObservableCollection<string>(
                controller.Handle(inputFullFilename, tramsformFullFilename, outputFullFilename, item));
        }
    }
}
