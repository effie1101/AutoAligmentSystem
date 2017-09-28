using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;


namespace AutoAlignment
{
    public class EventsController
    {

        /// <summary>
        ///  open file on disk and get bitmap from this image file
        /// </summary>
        /// <returns>bitmap image of  mark</returns>
        public Mat GetBitmapFromFile()
        {
            Mat img;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            openFileDialog.Filter = " (*.jpg,*.png,*.jpeg,*.bmp,*.gif)| *.jgp; *.png; *.jpeg; *.bmp";
            if (result == System.Windows.Forms.DialogResult.OK || result == System.Windows.Forms.DialogResult.Yes)
            {
                img = CvInvoke.Imread(openFileDialog.FileName, ImreadModes.AnyColor);
            }
            else
            {
                img = null;
            }
            return img;
        }



    }
}
