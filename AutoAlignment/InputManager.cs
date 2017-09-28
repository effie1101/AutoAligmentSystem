using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace AutoAlignment
{
    public class InputManager
    {
        private string _markImageFile;
        private Mat _markImage;
        private double _bondpadCenterX; 
        private double _bondpadCenterY; 
        private double _probe2CCDX; 
        private double _probe2CCDY; 
        private double _probe2CCDSita; 

        /// <summary>
        /// imported file of mark image
        /// </summary>
        public string MarkImageFile
        {
            get
            {
                return _markImageFile;
            }

            set
            {
                _markImageFile = value;
            }
        }

        /// <summary>
        /// Bitmap of mark image
        /// </summary>
        public Mat MarkImage
        {
            get
            {
                return _markImage;
            }

            set
            {
                _markImage = value;
            }
        }

        /// <summary>
        /// bondpad中心相对mark中心的水平位移
        /// </summary>
        public double BondpadCenterX
        {
            get
            {
                return _bondpadCenterX;
            }

            set
            {
                _bondpadCenterX = value;
            }
        }

        /// <summary>
        /// bondpad中心相对mark中心的垂直位移
        /// </summary>
        public double BondpadCenterY
        {
            get
            {
                return _bondpadCenterY;
            }

            set
            {
                _bondpadCenterY = value;
            }
        }

        /// <summary>
        /// 探针,斑马条等contact pad与CCD中心距离的水平位移
        /// </summary>
        public double Probe2CCDX
        {
            get
            {
                return _probe2CCDX;
            }

            set
            {
                _probe2CCDX = value;
            }
        }

        /// <summary>
        /// 探针,斑马条等contact pad与CCD中心距离的垂直位移
        /// </summary>
        public double Probe2CCDY
        {
            get
            {
                return _probe2CCDY;
            }

            set
            {
                _probe2CCDY = value;
            }
        }

        /// <summary>
        /// 探针,斑马条等contact pad与CCD中心的水平夹角
        /// </summary>
        public double Probe2CCDSita
        {
            get
            {
                return _probe2CCDSita;
            }

            set
            {
                _probe2CCDSita = value;
            }
        }


    }
}
