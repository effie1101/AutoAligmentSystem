using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Diagnostics;
using Emgu.CV.Util;

namespace AutoAligmentSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            EventActions();
        }

        //原始图像
        private Mat _originalImg; 

        public void PerformMarkDetection()
        {
            if (String.IsNullOrEmpty(txtFileName.Text)) return;
            this._originalImg = CvInvoke.Imread(this.txtFileName.Text, ImreadModes.AnyColor);

        }

        #region Event Actions
        private void EventActions()
        {
            //导入图片
            this.btnOpenFile.Click += delegate
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                DialogResult result = openFileDialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK || result == System.Windows.Forms.DialogResult.Yes)
                {
                    txtFileName.Text = openFileDialog.FileName;
                }
            };

            //执行图像处理
            this.txtFileName.TextChanged += delegate
            {
                PerformMarkDetection();
            };
        }
        #endregion


    }// class frmMain : Form
}//namespace AutoAligmentSystem
