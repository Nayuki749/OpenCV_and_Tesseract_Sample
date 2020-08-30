using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using Tesseract;

namespace OpenCV_and_Tesseract_sample
{
    class Tesseract_OCR_Sample:IDisposable
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
        public Tesseract_OCR_Sample()
        {

        }
        /// <summary>
        /// デストラクタ
        /// </summary>
        ~Tesseract_OCR_Sample()
        {
            //アンマネージリソースの解放
            this.Dispose(false);
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Dispose
        /// シールクラスの場合ははprivateメソッドとする
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
            //マネージリソースおよびアンマネージリソースの解放
            this.Dispose(true);

            //ガベコレから、このオブジェクトのデストラクタを対象外とする
            GC.SuppressFinalize(this);
        }

        #endregion

        public string Character_recognition(string Character_recognition_Image_File)
        {
            //Language (in Japanese, it's "jpn")
            string lang = "eng";

            //Path to language file
            string dataDirPath = System.AppDomain.CurrentDomain.BaseDirectory + @"tesseract-ocr\tessdata";

            return Character_recognition_Process(Character_recognition_Image_File, dataDirPath, lang); ;
        }

        /// <summary>
        /// Charactor Recognition Proccess
        /// </summary>
        /// <param name="imgPath"></param>
        /// <param name="dataDirPath"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        private static string Character_recognition_Process(string imgPath, string dataDirPath, string lang)
        {
            if (!System.IO.File.Exists(imgPath))
            {
                //Console.Error.WriteLine("画像のパスに画像が見つかりませんでした");
                return "画像のパスに画像が見つかりませんでした";
            }

            //Reading language learning data
            string traindedDataPath = System.IO.Path.Combine(dataDirPath, lang + ".traineddata");
            if (!System.IO.File.Exists(traindedDataPath))
            {
                //Console.Error.WriteLine(lang + ".traineddataがみつかりませんでした");
                return lang + ".traineddataがみつかりませんでした";
            }

            // Character recognition
            using (TesseractEngine tesseract = new Tesseract.TesseractEngine(dataDirPath, lang))
            {
                // Import an image file
                var img = new System.Drawing.Bitmap(imgPath);

                // Specifying a character
                tesseract.SetVariable("tessedit_char_whitelist", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz.,");
                // PERFORM OCR
                Tesseract.Page page = tesseract.Process(img);
                //Console.WriteLine(page.GetText());

                return page.GetText();
            }
        }
    }
}
