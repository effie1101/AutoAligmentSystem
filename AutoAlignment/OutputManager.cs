using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAlignment
{
    public class OutputManager
    {
        #region final alignment output
        private double _alignmentX;
        private double _alignmentY;
        private double _alignmentSita;
        private Bitmap _markLocatedImg;

        #endregion

        #region CCD Calibration Output

        #endregion

        #region CCDs Adjustment Output
        private double _lower2UpperX;
        private double _lower2UpperY;
        private double _lower2UpperSita;
        private double _probeHeadSita;
        #endregion

        /// <summary>
        /// 测头于X轴需要调整的距离
        /// </summary>
        public double AlignmentX
        {
            get
            {
                return _alignmentX;
            }

            set
            {
                _alignmentX = value;
            }
        }

        /// <summary>
        /// 测头于Y轴需要调整的距离
        /// </summary>
        public double AlignmentY
        {
            get
            {
                return _alignmentY;
            }

            set
            {
                _alignmentY = value;
            }
        }

        /// <summary>
        /// 测头于Sita轴需要调整的转角
        /// </summary>
        public double AlignmentSita
        {
            get
            {
                return _alignmentSita;
            }

            set
            {
                _alignmentSita = value;
            }
        }

        /// <summary>
        /// 下CCD相对于上CCD的水平X位移
        /// </summary>
        public double Lower2upperX
        {
            get
            {
                return _lower2UpperX;
            }

            set
            {
                _lower2UpperX = value;
            }
        }

        /// <summary>
        /// 下CCD相对于上CCD的Y方向位移
        /// </summary>
        public double Lower2UpperY
        {
            get
            {
                return _lower2UpperY;
            }

            set
            {
                _lower2UpperY = value;
            }
        }

        /// <summary>
        /// 下CCD相对于上CCD的水平夹角
        /// </summary>
        public double Lower2UpperSita
        {
            get
            {
                return _lower2UpperSita;
            }

            set
            {
                _lower2UpperSita = value;
            }
        }

        /// <summary>
        /// 测头模块的水平偏移转角
        /// </summary>
        public double ProbeHeadSita
        {
            get
            {
                return _probeHeadSita;
            }

            set
            {
                _probeHeadSita = value;
            }
        }

        /// <summary>
        /// 识别并标示出mark轮廓的图像
        /// </summary>
        public Bitmap MarkLocatedImg
        {
            get
            {
                return _markLocatedImg;
            }

            set
            {
                _markLocatedImg = value;
            }
        }
    }
}
