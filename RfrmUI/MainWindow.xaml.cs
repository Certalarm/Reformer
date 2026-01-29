using System;
using System.Collections.Generic;
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
using RfrmLib.Controllers;

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


        public MainWindow()
        {
            InitializeComponent();

            var appFullDir = AppDomain.CurrentDomain.BaseDirectory;
            var inputFullDir = Path.Combine(appFullDir, __inputDir);
            var outputFullDir = Path.Combine(appFullDir, __outputDir);
            var inputFullFilename = Path.Combine(inputFullDir, __inputFilename);
            var tramsformFullFilename = Path.Combine(inputFullDir, __transformFilename);
            var outputFullFilename = Path.Combine(outputFullDir, __outputFilename);

            MainFlowController controller = new MainFlowController();
            var result = controller.Handle(inputFullFilename, tramsformFullFilename, outputFullFilename);

            var tmp = "";
        }

        //private string GetFullInputDir()
        //{

        //}
    }
}
