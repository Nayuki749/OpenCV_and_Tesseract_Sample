using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.IO;
using System.Windows.Forms;



namespace OpenCV_and_Tesseract_sample
{
    public class OpenCvSharp_Sample : IDisposable
    {

        #region Dispose member

        /// <summary>
        /// Disposeされたかどうか
        /// </summary>
        private bool disposed;

        /// <summary>
        /// アンマネージリソースを管理しているクラスUnamnaged 
        /// </summary>
        //private Unamnaged m_unmanaged;

        /// <summary>
        /// アンマネージリソースへのネイティブポインタ
        /// </summary>
        //private IntPtr m_pUnmanaged;

        #endregion

        #region constractor and decstractor
        /// <summary>
        /// Constructor
        /// </summary>
        public OpenCvSharp_Sample()
        {

        }
        /// <summary>
        /// Dextractor
        /// </summary>
        ~OpenCvSharp_Sample()
        {
            //Releasing unmanaged resources
            this.Dispose(false);
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Dispose
        /// In the case of a sealed class, it is a private method.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            lock (this)
            {
                if (this.disposed)
                {
                    //既に呼びだしずみであるならばなんもしない
                    return;
                }

                this.disposed = true;
                //Comment out because you are not using unmanaged code
                if (disposing)
                {
                    // マネージリソースの解放
                    //this.m_unmanaged.Dispose();
                    //this.m_unmanaged = null;
                }

                // アンマネージリソースの解放
                //if (this.m_pUnmanaged != IntPtr.Zero)
                //{
                //    PtrFree(this.m_pUnmanaged);
                //    this.m_pUnmanaged = IntPtr.Zero;
                //}
            }
        }
        #endregion

        #region IDisposable メンバ

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            //Releasing Managed and Unmanaged Resources
            this.Dispose(true);

            //Remove destructors for this object from garbage collectors
            GC.SuppressFinalize(this);
        }

        #endregion

        /// <summary>
        /// Image View
        /// </summary>
        /// <param name="_image_File">View Image File Path</param>
        public void Image_View(string _image_File)
        {
            using (Mat image = new Mat(_image_File))
            {
                Cv2.ImShow("show image", image);
            }
        }

        /// <summary>
        /// template matching
        /// </summary>
        /// <param name="Image_FIle"></param>
        /// <param name="Template_Image_File"></param>
        public void Template_Matching(string Image_FIle,string Template_Image_File)
        {
            // Image and template image to search for
            using (Mat image = new Mat(Image_FIle))
            using (Mat temp = new Mat(Template_Image_File))

            // Image for template matching
            using (Mat result = new Mat())
            {
                // Template Match
                Cv2.MatchTemplate(image, temp, result, TemplateMatchModes.CCoeffNormed);

                // Find out where pixels have the greatest/minimum similarity
                OpenCvSharp.Point minloc, maxloc;
                double minval, maxval;
                Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);

                // Judged by threshold
                var threshold = 0.9;
                if (maxval >= threshold)
                {
                    // Red frame at most found location
                    Rect rect = new Rect(maxloc.X, maxloc.Y, temp.Width, temp.Height);
                    Cv2.Rectangle(image, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);

                    // Display a picture in a window
                    Cv2.ImShow("template1_show", image);
                }
                else
                {
                    // Not Found
                    MessageBox.Show("見つかりませんでした");
                }
            }
        }

        /// <summary>
        /// Save template matching results as an image
        /// </summary>
        /// <param name="Image_FIle"></param>
        /// <param name="Template_Image_File"></param>
        /// <param name="SaveFile"></param>
        public void Template_Matching_and_Save(string Image_FIle, string Template_Image_File,string SaveFile)
        {
            // Image and template image to search for
            using (Mat image = new Mat(Image_FIle))
            using (Mat temp = new Mat(Template_Image_File))
            using (Mat result = new Mat())
            {

                // Image for template matching
                Cv2.MatchTemplate(image, temp, result, TemplateMatchModes.CCoeffNormed);

                // Find out where pixels have the greatest/minimum similarity
                OpenCvSharp.Point minloc, maxloc;
                double minval, maxval;
                Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);

                // Judged by threshold
                var threshold = 0.9;
                if (maxval >= threshold)
                {
                    // Cut the match part
                    Mat clipedMat = image.Clone(new OpenCvSharp.Rect(maxloc.X, maxloc.Y, temp.Width, temp.Height));
                    Cv2.ImWrite(SaveFile, clipedMat);
                }
                else
                {
                    // Not Found
                    MessageBox.Show("見つかりませんでした");
                }
            }
        }
    }
}
