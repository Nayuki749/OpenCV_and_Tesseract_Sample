using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OpenCV_and_Tesseract_sample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// File Open
        /// </summary>
        /// <returns>File Path</returns>
        private string FileSelect()
        {
            // Get the path of your own executable.
            string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string GetFileName = "";
            // Create an instance of OpenFileDialog class.
            OpenFileDialog ofd = new OpenFileDialog();

            // specify the starting file name
            // First, specify the character string displayed in "file name"
            ofd.FileName = "";
            // specify the folder to be displayed first
            // If not specified (empty string), the current directory is displayed
            ofd.InitialDirectory = appPath;
            // Specify the options displayed in "File type"
            // if not specified, all files will be displayed
            ofd.Filter = "bmpファイル(*.bmp)|*.bmp|jpegファイル(*.jpg;*.jpeg)|*.jpg;*.jpeg|すべてのファイル(*.*)|*.*";
            // Specify the first choice in [Files of type]
            ofd.FilterIndex = 3;
            // Set title
            ofd.Title = "開くファイルを選択してください";
            // Restore current directory before closing dialog box
            ofd.RestoreDirectory = true;
            // display a warning when the name of a file that does not exist is specified
            // It is True by default, so it is not necessary to specify
            //ofd.CheckFileExists = true;
            // display a warning when a nonexistent path is specified
            // It is True by default, so it is not necessary to specify
            //ofd.CheckPathExists = true;

            //show dialog
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Store in variable the selected filename when the OK button is clicked
                GetFileName = ofd.FileName;
            }

            return GetFileName;
        }

        private string FileSave()
        {
            // Get the path of your own executable.
            string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string GetFileName = "";

            //Create an instance of SaveFileDialog class
            SaveFileDialog sfd = new SaveFileDialog();

            // specify the starting file name
            // First, specify the character string displayed in "file name"
            sfd.FileName = "";
            //Specify the folder displayed first
            sfd.InitialDirectory = appPath;
            //Specify the options displayed in "Files of type"
            //If not specified (empty string), the current directory is displayed
            sfd.Filter = "bmpファイル(*.bmp)|*.bmp|jpegファイル(*.jpg;*.jpeg)|*.jpg;*.jpeg|すべてのファイル(*.*)|*.*";
            //Specify the first selected in "Files of type"
            sfd.FilterIndex = 2;
            //Set title
            sfd.Title = "保存先のファイルを選択してください";
            //Restore current directory before closing dialog box
            sfd.RestoreDirectory = true;
            // warn when a file name that already exists is specified
            // It is True by default, so it is not necessary to specify
            //sfd.OverwritePrompt = true;
            // display a warning when a nonexistent path is specified
            // It is True by default, so it is not necessary to specify
            //sfd.CheckPathExists = true;

            //show dialog
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //Store in variable the selected filename when the OK button is clicked
                GetFileName = sfd.FileName;
            }
            return GetFileName;
        }

        /// <summary>
        ///  FileSelect_button_Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileSelect_button_Click(object sender, EventArgs e)
        {
            ImageFiletextBox.Text = FileSelect();
        }

        /// <summary>
        /// Template_Image_Select_button_Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Template_Image_Select_button_Click(object sender, EventArgs e)
        {
            TemplateImagetextBox.Text = FileSelect();
        }

        /// <summary>
        /// Character_recognition_target_Select_button_Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Character_recognition_target_Select_button_Click(object sender, EventArgs e)
        {
            Character_recognition_ImagetextBox.Text = FileSelect();
        }

        /// <summary>
        /// Preview_button_Clic Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Preview_button_Click(object sender, EventArgs e)
        {
            if(ImageFiletextBox.Text == "")
            {
                MessageBox.Show("ファイルが選択されていません。", "Image File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string FileExt = Path.GetExtension(ImageFiletextBox.Text);
                if(FileExt == ".bmp" || FileExt == ".jpeg" || FileExt == ".jpg")
                {
                    using (OpenCvSharp_Sample CVS = new OpenCvSharp_Sample())
                    {
                        CVS.Image_View(ImageFiletextBox.Text);
                    }
                }
                else
                {
                    MessageBox.Show("画像ファイルが選択されていません。", "Select File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Matching_button_Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Matching_button_Click(object sender, EventArgs e)
        {
            if (ImageFiletextBox.Text == "")
            {
                MessageBox.Show("画像ファイルが選択されていません。", "Image File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (TemplateImagetextBox.Text == "")
                {
                    MessageBox.Show("テンプレートファイルが選択されていません。", "Template Image File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string ImageFileExt = Path.GetExtension(ImageFiletextBox.Text);
                string TemplateFileExt = Path.GetExtension(TemplateImagetextBox.Text);


                if (ImageFileExt == ".bmp" || ImageFileExt == ".jpeg" || ImageFileExt == ".jpg")
                {
                    if(TemplateFileExt == ".bmp" || TemplateFileExt ==".jpeg"||TemplateFileExt == ".jpg")
                    {
                        using (OpenCvSharp_Sample CVS = new OpenCvSharp_Sample())
                        {
                            CVS.Template_Matching(ImageFiletextBox.Text, TemplateImagetextBox.Text);
                        }
                    }
                    else
                    {
                        MessageBox.Show("テンプレート用画像ファイルが選択されていません。", "Select File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("画像ファイルが選択されていません。", "Select File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Matching_Image_Save_button_Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Matching_Image_Save_button_Click(object sender, EventArgs e)
        {
            string save_file_name = FileSave();
            if (save_file_name == "")
            {
                MessageBox.Show("保存するファイル名が指定されていません。", "File to save is not specified", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ImageFiletextBox.Text == "")
                {
                    MessageBox.Show("画像ファイルが選択されていません。", "Image File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (TemplateImagetextBox.Text == "")
                    {
                        MessageBox.Show("テンプレートファイルが選択されていません。", "Template Image File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    string ImageFileExt = Path.GetExtension(ImageFiletextBox.Text);
                    string TemplateFileExt = Path.GetExtension(TemplateImagetextBox.Text);
                    string SaveFileExt = Path.GetExtension(save_file_name);

                    if (SaveFileExt == ".bmp" || SaveFileExt == ".jpeg" || SaveFileExt == ".jpg")
                    {
                        if (ImageFileExt == ".bmp" || ImageFileExt == ".jpeg" || ImageFileExt == ".jpg")
                        {
                            if (TemplateFileExt == ".bmp" || TemplateFileExt == ".jpeg" || TemplateFileExt == ".jpg")
                            {
                                using (OpenCvSharp_Sample CVS = new OpenCvSharp_Sample())
                                {
                                    CVS.Template_Matching_and_Save(ImageFiletextBox.Text, TemplateImagetextBox.Text, save_file_name);
                                }
                            }
                            else
                            {
                                MessageBox.Show("テンプレート用画像ファイルが選択されていません。", "Select File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("画像ファイルが選択されていません。", "Select File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("保存する画像ファイルが選択されていません。", "Select File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Character_recognition_button_Clic Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Character_recognition_button_Click(object sender, EventArgs e)
        {
            if (Character_recognition_ImagetextBox.Text == "")
            {
                MessageBox.Show("ファイルが選択されていません。", "Image File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string FileExt = Path.GetExtension(Character_recognition_ImagetextBox.Text);
                if (FileExt == ".bmp" || FileExt == ".jpeg" || FileExt == ".jpg")
                {
                    using (Tesseract_OCR_Sample TOCR = new Tesseract_OCR_Sample())
                    {
                        ResultrichTextBox.Text = TOCR.Character_recognition(Character_recognition_ImagetextBox.Text);
                    }
                }
                else
                {
                    MessageBox.Show("画像ファイルが選択されていません。", "Select File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
