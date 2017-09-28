using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;


namespace AutoAlignment
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitSystem();
            InitializeEvents();
        }

        private AutoAlignment.InputManager _inputManager;
        private AutoAlignment.OutputManager _outputManager;
        private AutoAlignment.EventsController _eventsController;

        private void InitSystem()
        {
            this._inputManager = new InputManager();
            this._outputManager = new OutputManager();
            this._eventsController = new EventsController();
        }


        /// <summary>
        /// 按钮事件
        /// </summary>
        private void InitializeEvents()
        {
            this.btnOpenImgFileU.Click += delegate
            {
                this._inputManager.MarkImage = this._eventsController.GetBitmapFromFile();
                this.imgMark.Source = BitmapSourceConvert.ToBitmapSource(this._inputManager.MarkImage);

            };
        }

    }//Class
}//Namespace
