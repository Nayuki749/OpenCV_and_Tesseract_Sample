using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace OpenCV_and_Tesseract_sample
{
    class Image_Processing
    {
        /// <summary>
        /// Constractor
        /// </summary>
        public Image_Processing()
        {

        }

        /// <summary>
        /// Glay Scale Processing
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Bitmap GlayScale(string fileName)
        {
            Bitmap bitmap = new Bitmap(fileName);
            int w = bitmap.Width;
            int h = bitmap.Height;
            byte[,] data = new byte[w, h];

            // bitmapクラスの画像pixel値を配列に挿入
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    // グレイスケール変換処理
                    data[j, i] = (byte)((bitmap.GetPixel(j, i).R + bitmap.GetPixel(j, i).B + bitmap.GetPixel(j, i).G) / 3);
                    bitmap.SetPixel(j, i, Color.FromArgb(data[j, i], data[j, i], data[j, i]));
                }
            }
            return bitmap;
        }

        /// <summary>
        /// Change image brightness
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="bright"></param>
        /// <returns></returns>
        public Bitmap BrightnessChange(string fileName,int bright)
        {
            Bitmap bitmap = new Bitmap(fileName);
            // 画像データの幅と高さを取得
            int w = bitmap.Width;
            int h = bitmap.Height;
            byte[,] data = new byte[w, h];
            byte[,] brightdata = new byte[w, h];

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    // bmpのデータを取得
                    data[j, i] = (byte)((bitmap.GetPixel(j, i).R + bitmap.GetPixel(j, i).B + bitmap.GetPixel(j, i).G) / 3);

                    // 明るさ変更処理
                    if ((int)data[j, i] + bright >= 256)
                    {
                        brightdata[j, i] = 255;
                    }
                    else if ((int)data[j, i] + bright < 0)
                    {
                        brightdata[j, i] = 0;
                    }
                    else
                    {
                        brightdata[j, i] = (byte)(data[j, i] + bright);
                    }
                    // bmpに設定
                    bitmap.SetPixel(j, i, Color.FromArgb(brightdata[j, i], brightdata[j, i], brightdata[j, i]));
                }
            }
            return bitmap;
        }

        /// <summary>
        /// Negative/positive conversion
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public Bitmap ReverseColor(string fileName)
        {
            Bitmap bitmap = new Bitmap(fileName);

            // 縦横サイズを配列から読み取り
            int w = bitmap.Width;
            int h = bitmap.Height;
            // 出力画像用の配列
            byte[,] src = new byte[w, h];
            byte[,] dst = new byte[w, h];

            // ネガポジ反転処理
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    src[j, i] = (byte)((bitmap.GetPixel(j, i).R + bitmap.GetPixel(j, i).B + bitmap.GetPixel(j, i).G) / 3);
                    dst[j, i] = DoubleToByte(255 - src[j, i]);
                    bitmap.SetPixel(j, i, Color.FromArgb(dst[j, i], dst[j, i], dst[j, i]));
                }
            }
            return bitmap;
        }

        /// <summary>
        /// doubleをbyteに変換
        /// </summary>
        /// <param name="num"></param>ss
        /// <returns></returns>
        private static byte DoubleToByte(double num)
        {
            if (num > 255.0) return 255;
            else if (num < 0) return 0;
            else return (byte)num;
        }

        public Bitmap TowValues(string fileName, float threshold)
        {
            Bitmap bitmap = new Bitmap(fileName);
            Color color;

            // 縦横サイズを配列から読み取り
            int w = bitmap.Width;
            int h = bitmap.Height;

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    color = bitmap.GetPixel(j,i);
                   if(color.GetBrightness() > threshold)
                    {
                        bitmap.SetPixel(j, i, Color.Black);
                    }
                    else
                    {
                        bitmap.SetPixel(j, i, Color.White);
                    }
                }
            }
            return bitmap;
        }

        /// <summary>
        /// MedianFIlter
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Bitmap MedianFilter(string fileName)
        {
            Bitmap bitmap = new Bitmap(fileName);
            byte[,] data = LoadByteImage(bitmap);
            // フィルタ処理
            byte[,] filterdata = MedianFiltering(data);

            return SaveByteImage(filterdata);
        }

        /// <summary>
        /// メディアンフィルターをかける
        /// </summary>
        static byte[,] MedianFiltering(byte[,] inputdata)
        {
            try
            {
                // マスクサイズ
                const int maskSize = 3;
                // 画像サイズ取得
                int xsize = inputdata.GetLength(0);
                int ysize = inputdata.GetLength(1);

                // 処理後の画像配列
                byte[,] filterdata = new byte[xsize, ysize];
                // 9近傍を入れる配列
                byte[] mask = new byte[maskSize * maskSize];

                // メディアンフィルタ
                for (int i = 0; i < ysize; i++)
                {
                    for (int j = 0; j < xsize; j++)
                    {
                        int length = 0;
                        for (int k = -maskSize / 2; k <= maskSize / 2; k++)
                        {
                            for (int n = -maskSize / 2; n <= maskSize / 2; n++)
                            {
                                if (j + n >= 0 && j + n < xsize && i + k >= 0 && i + k < ysize)
                                {
                                    mask[length] = inputdata[j + n, i + k];
                                    length++;
                                }
                            }
                        }
                        // 中央値を探す
                        filterdata[j, i] = GetMedian(mask, length);
                    }
                }
                return filterdata;
            }
            catch
            {
                Console.WriteLine(
                    "メディアンフィルタ処理が実行できません。");
                return null;
            }
        }

        /// <summary>
        /// 中央値を取得
        /// </summary>
        static byte GetMedian(byte[] mask, int length)
        {
            Array.Sort(mask);
            Array.Reverse(mask);

            return mask[length / 2];
        }

        /// <summary>
        /// 画像配列をbmpに書き出す
        /// </summary>
        private void SaveByteImage(byte[,] data, string filename)
        {
            try
            {
                // 縦横サイズを配列から読み取り
                int xsize = data.GetLength(0);
                int ysize = data.GetLength(1);

                Bitmap bitmap = new Bitmap(xsize, ysize);

                // bitmapクラスのSetPixelでbitmapオブジェクトに
                // ピクセル値をセット
                for (int i = 0; i < ysize; i++)
                {
                    for (int j = 0; j < xsize; j++)
                    {
                        bitmap.SetPixel(j, i,  Color.FromArgb(data[j, i], data[j, i], data[j, i]));
                    }
                }

                // 画像の保存
                bitmap.Save(filename, ImageFormat.Bmp);
            }
            catch
            {
                Console.WriteLine("ファイルが書き込めません。");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private Bitmap SaveByteImage(byte[,] data)
        {
            try
            {
                // 縦横サイズを配列から読み取り
                int xsize = data.GetLength(0);
                int ysize = data.GetLength(1);

                Bitmap bitmap = new Bitmap(xsize, ysize);

                // bitmapクラスのSetPixelでbitmapオブジェクトに
                // ピクセル値をセット
                for (int i = 0; i < ysize; i++)
                {
                    for (int j = 0; j < xsize; j++)
                    {
                        bitmap.SetPixel(j, i, Color.FromArgb(data[j, i], data[j, i], data[j, i]));
                    }
                }

                return bitmap;
            }
            catch
            {
                Console.WriteLine("ファイルが書き込めません。");
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static byte[,] LoadByteImage(string filename)
        {
            try
            {
                Bitmap bitmap = new Bitmap(filename);
                byte[,] data = new byte[bitmap.Width, bitmap.Height];

                // bitmapクラスの画像ピクセル値を配列に挿入
                for (int i = 0; i < bitmap.Height; i++)
                {
                    for (int j = 0; j < bitmap.Width; j++)
                    {
                        // ここではグレイスケールに変換して格納
                        data[j, i] =
                            (byte)(
                                (bitmap.GetPixel(j, i).R +
                                bitmap.GetPixel(j, i).B +
                                bitmap.GetPixel(j, i).G) / 3
                                );
                    }
                }
                return data;
            }
            catch
            {
                Console.WriteLine("ファイルが読めません。");
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static byte[,] LoadByteImage(Bitmap bitmap)
        {
            try
            {
                byte[,] data = new byte[bitmap.Width, bitmap.Height];

                // bitmapクラスの画像ピクセル値を配列に挿入
                for (int i = 0; i < bitmap.Height; i++)
                {
                    for (int j = 0; j < bitmap.Width; j++)
                    {
                        // ここではグレイスケールに変換して格納
                        data[j, i] =
                            (byte)(
                                (bitmap.GetPixel(j, i).R +
                                bitmap.GetPixel(j, i).B +
                                bitmap.GetPixel(j, i).G) / 3
                                );
                    }
                }
                return data;
            }
            catch
            {
                Console.WriteLine("ファイルが読めません。");
                return null;
            }
        }
    }
}
