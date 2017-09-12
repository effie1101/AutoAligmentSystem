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

namespace MarkLocation
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //perform image processing and detect mark
        public void PerformMarkDetection()
        {
            if (String.IsNullOrEmpty(txtFileName.Text)) return;

            //设定待检测的闭环矩形的最小面积
            int minContourArea =  2000;

            this.OutputMsg("======================================",Color.Lime);
            //load image from file
            Mat orignalImg = CvInvoke.Imread(this.txtFileName.Text,ImreadModes.AnyColor);
            this.OutputMsg("\n********* Loading Image **********", Color.WhiteSmoke);
            this.OutputMsg(string.Format("\t Image File: {0}", this.txtFileName.Text), Color.Aqua);
            //display image in imagebox
            this.imgboxOriginal.Image = orignalImg;

            this.OutputMsg("\n********* Processing Image **********", Color.WhiteSmoke);

            Mat cutImg = CutImage(orignalImg.ToImage<Bgr, byte>(), 450, 350, 400, 300).ToUMat().GetMat(AccessType.Fast);
            //CvInvoke.Imshow("Cut Image", cutImg);
            cutImg.Save("cutImg.png"); 

            //Convert the image to grayscale and filter out the noise
            Mat uimage = new Mat();
            Mat binaryImg = new Mat();

            CvInvoke.CvtColor(cutImg, uimage, ColorConversion.Bgr2Gray);

            //use image pyr to remove noise
            UMat pyrDown = new UMat();
            CvInvoke.PyrDown(uimage, pyrDown);
            CvInvoke.PyrUp(pyrDown, uimage);

            //convert to binary image 
            CvInvoke.Threshold(uimage, binaryImg, 100, 255, ThresholdType.BinaryInv);
            //CvInvoke.Imshow("Binary Image", binaryImg);
            binaryImg.Save("BinaryImg.png");

            #region Canny and edge detection

            Stopwatch watch = Stopwatch.StartNew();
            double cannyThreshold = 200.0;

            watch.Reset();
                watch.Start();
                double cannyThresholdLinking = 120.0;
                UMat cannyEdges = new UMat();
                CvInvoke.Canny(uimage, cannyEdges, cannyThreshold, cannyThresholdLinking);
                //CvInvoke.Imshow("cannyEdges", cannyEdges);
                cannyEdges.Save("cannyEdges.png");
                this.imgboxBinary.Image = cannyEdges;

                LineSegment2D[] lines = CvInvoke.HoughLinesP(
                   cannyEdges,
                   1, //Distance resolution in pixel-related units
                   Math.PI / 45.0, //Angle resolution measured in radians.
                   20, //threshold
                   30, //min Line width
                   10); //gap between lines

                watch.Stop();
                this.OutputMsg(String.Format("\t Canny & Hough lines - {0} ms; ", watch.ElapsedMilliseconds), Color.Aqua);
            #endregion 

                #region Find rectangles
                watch.Reset();
                watch.Start();
                List<RotatedRect> boxList = new List<RotatedRect>(); //a box is a rotated rectangle
                List<VectorOfPoint> contourList = new List<VectorOfPoint>();

                using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                {
                    CvInvoke.FindContours(cannyEdges, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                    int count = contours.Size;
                    for (int i = 0; i < count; i++)
                    {
                        using (VectorOfPoint contour = contours[i])
                        using (VectorOfPoint approxContour = new VectorOfPoint())
                        {
                            CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                            if (CvInvoke.ContourArea(approxContour, false) > minContourArea) //only consider contours with area greater than 250
                            {
                                if (approxContour.Size == 6) //The contour has 4 vertices.
                                {
                                    #region determine if all the angles in the contour are within [80, 100] degree
                                    bool isRectangle = true;
                                    Point[] pts = approxContour.ToArray();
                                    LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                                    for (int j = 0; j < edges.Length; j++)
                                    {
                                        double angle = Math.Abs(
                                           edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                                        if (angle < 80 || angle > 100)
                                        {
                                            isRectangle = false;
                                            break;
                                        }
                                    }
                                    #endregion

                                    if (isRectangle)
                                    {
                                        boxList.Add(CvInvoke.MinAreaRect(approxContour));
                                        contourList.Add(approxContour);
                                    }
                                }
                            }
                        }
                    }
                }

                watch.Stop();
                this.OutputMsg(String.Format("\t Finding Rectangles - {0} ms; ", watch.ElapsedMilliseconds), Color.Aqua);
                #endregion

                #region draw rectangles

                this.OutputMsg("\n********* Calculating mark center and angle *********", Color.WhiteSmoke);

                Mat triangleRectangleImage = cutImg;
                //triangleRectangleImage.SetTo(new MCvScalar(0));

                //foreach (RotatedRect box in boxList)
                //{
                //    CvInvoke.Polylines(cutImg, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.Red).MCvScalar, 2);
                //}
                PointF markCenter = new PointF();
                double markAngle = 0;

                if (boxList.Count > 0)
                {
                    CvInvoke.Polylines(triangleRectangleImage, Array.ConvertAll(boxList[0].GetVertices(), Point.Round), true, new Bgr(Color.Red).MCvScalar, 2);
                    CvInvoke.DrawContours(triangleRectangleImage, contourList[0], -1, new Bgr(Color.DarkOrange).MCvScalar);
                    markCenter = boxList[0].Center;
                    markAngle = Math.Round(boxList[0].Angle, 3);
                    // CvInvoke.PutText(triangleRectangleImage, string.Format("Center: [{0},{1}]\nAngle: {2}", markCenter.X, markCenter.Y, markAngle), markCenter, FontFace.HersheyPlain, 1.0, new Bgr(Color.DarkOrange).MCvScalar);
                }

                this.OutputMsg(String.Format("\tMark center: {0}\n\tMark angle: {1}", markCenter, markAngle), Color.Gold);


                this.imgboxDetectedRec.Image = triangleRectangleImage;
                #endregion
        }

        private void OutputMsg(string msg,Color foreColor)
        {15
            this.txtOutput.SelectionColor = foreColor;
            this.txtOutput.AppendText(msg + "\r\n");
        }

        public Image<Bgr, byte> CutImage(Image<Bgr, byte> sourceImg, int startX, int startY, int width, int height)
        {
            Image<Bgr, byte> outputImg = new Image<Bgr, byte>(width, height);
            int x = sourceImg.Width - width;
            int y = sourceImg.Height - height;
            System.Drawing.Size roiSize = new Size(width, height);//image size that needs to be cutted out
            //IntPtr dst = CvInvoke.cvCreateImage(roiSize, Emgu.CV.CvEnum.IplDepth.IplDepth_8U, 3);
            System.Drawing.Rectangle rect = new Rectangle(startX, startY, width, height);
            CvInvoke.cvSetImageROI(sourceImg.Ptr, rect);
            CvInvoke.cvCopy(sourceImg.Ptr, outputImg.Ptr, IntPtr.Zero);
            return outputImg;
        }

        #region Events
        
        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            PerformMarkDetection();
        }

        //open image file
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK || result == System.Windows.Forms.DialogResult.Yes)
            {
                txtFileName.Text = openFileDialog.FileName;
            }
        }

        
        #endregion

    }
}
