namespace OpenCV_and_Tesseract_sample
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ImageFiletextBox = new System.Windows.Forms.TextBox();
            this.FileSelect_button = new System.Windows.Forms.Button();
            this.Template_Image_Select_button = new System.Windows.Forms.Button();
            this.TemplateImagetextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Preview_button = new System.Windows.Forms.Button();
            this.Matching_button = new System.Windows.Forms.Button();
            this.Matching_Image_Save_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Character_recognition_ImagetextBox = new System.Windows.Forms.TextBox();
            this.Character_recognition_target_Select_button = new System.Windows.Forms.Button();
            this.Character_recognition_button = new System.Windows.Forms.Button();
            this.ResultrichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "画像ファイル";
            // 
            // ImageFiletextBox
            // 
            this.ImageFiletextBox.Location = new System.Drawing.Point(23, 37);
            this.ImageFiletextBox.Name = "ImageFiletextBox";
            this.ImageFiletextBox.Size = new System.Drawing.Size(249, 19);
            this.ImageFiletextBox.TabIndex = 1;
            // 
            // FileSelect_button
            // 
            this.FileSelect_button.Location = new System.Drawing.Point(287, 35);
            this.FileSelect_button.Name = "FileSelect_button";
            this.FileSelect_button.Size = new System.Drawing.Size(44, 23);
            this.FileSelect_button.TabIndex = 2;
            this.FileSelect_button.Text = "参照";
            this.FileSelect_button.UseVisualStyleBackColor = true;
            this.FileSelect_button.Click += new System.EventHandler(this.FileSelect_button_Click);
            // 
            // Template_Image_Select_button
            // 
            this.Template_Image_Select_button.Location = new System.Drawing.Point(287, 79);
            this.Template_Image_Select_button.Name = "Template_Image_Select_button";
            this.Template_Image_Select_button.Size = new System.Drawing.Size(44, 23);
            this.Template_Image_Select_button.TabIndex = 5;
            this.Template_Image_Select_button.Text = "参照";
            this.Template_Image_Select_button.UseVisualStyleBackColor = true;
            this.Template_Image_Select_button.Click += new System.EventHandler(this.Template_Image_Select_button_Click);
            // 
            // TemplateImagetextBox
            // 
            this.TemplateImagetextBox.Location = new System.Drawing.Point(23, 81);
            this.TemplateImagetextBox.Name = "TemplateImagetextBox";
            this.TemplateImagetextBox.Size = new System.Drawing.Size(249, 19);
            this.TemplateImagetextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "テンプレートマッチング用 テンプレート画像";
            // 
            // Preview_button
            // 
            this.Preview_button.Location = new System.Drawing.Point(23, 116);
            this.Preview_button.Name = "Preview_button";
            this.Preview_button.Size = new System.Drawing.Size(118, 23);
            this.Preview_button.TabIndex = 6;
            this.Preview_button.Text = "画像ファイルプレビュー";
            this.Preview_button.UseVisualStyleBackColor = true;
            this.Preview_button.Click += new System.EventHandler(this.Preview_button_Click);
            // 
            // Matching_button
            // 
            this.Matching_button.Location = new System.Drawing.Point(147, 116);
            this.Matching_button.Name = "Matching_button";
            this.Matching_button.Size = new System.Drawing.Size(111, 23);
            this.Matching_button.TabIndex = 7;
            this.Matching_button.Text = "テンプレートマッチング";
            this.Matching_button.UseVisualStyleBackColor = true;
            this.Matching_button.Click += new System.EventHandler(this.Matching_button_Click);
            // 
            // Matching_Image_Save_button
            // 
            this.Matching_Image_Save_button.Location = new System.Drawing.Point(23, 145);
            this.Matching_Image_Save_button.Name = "Matching_Image_Save_button";
            this.Matching_Image_Save_button.Size = new System.Drawing.Size(118, 23);
            this.Matching_Image_Save_button.TabIndex = 8;
            this.Matching_Image_Save_button.Text = "マッチング部分を保存";
            this.Matching_Image_Save_button.UseVisualStyleBackColor = true;
            this.Matching_Image_Save_button.Click += new System.EventHandler(this.Matching_Image_Save_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "文字識別対象画像";
            // 
            // Character_recognition_ImagetextBox
            // 
            this.Character_recognition_ImagetextBox.Location = new System.Drawing.Point(23, 208);
            this.Character_recognition_ImagetextBox.Name = "Character_recognition_ImagetextBox";
            this.Character_recognition_ImagetextBox.Size = new System.Drawing.Size(249, 19);
            this.Character_recognition_ImagetextBox.TabIndex = 10;
            // 
            // Character_recognition_target_Select_button
            // 
            this.Character_recognition_target_Select_button.Location = new System.Drawing.Point(287, 206);
            this.Character_recognition_target_Select_button.Name = "Character_recognition_target_Select_button";
            this.Character_recognition_target_Select_button.Size = new System.Drawing.Size(44, 23);
            this.Character_recognition_target_Select_button.TabIndex = 11;
            this.Character_recognition_target_Select_button.Text = "参照";
            this.Character_recognition_target_Select_button.UseVisualStyleBackColor = true;
            this.Character_recognition_target_Select_button.Click += new System.EventHandler(this.Character_recognition_target_Select_button_Click);
            // 
            // Character_recognition_button
            // 
            this.Character_recognition_button.Location = new System.Drawing.Point(23, 233);
            this.Character_recognition_button.Name = "Character_recognition_button";
            this.Character_recognition_button.Size = new System.Drawing.Size(75, 23);
            this.Character_recognition_button.TabIndex = 12;
            this.Character_recognition_button.Text = "文字認識";
            this.Character_recognition_button.UseVisualStyleBackColor = true;
            this.Character_recognition_button.Click += new System.EventHandler(this.Character_recognition_button_Click);
            // 
            // ResultrichTextBox
            // 
            this.ResultrichTextBox.Location = new System.Drawing.Point(12, 273);
            this.ResultrichTextBox.Name = "ResultrichTextBox";
            this.ResultrichTextBox.Size = new System.Drawing.Size(330, 165);
            this.ResultrichTextBox.TabIndex = 13;
            this.ResultrichTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 450);
            this.Controls.Add(this.ResultrichTextBox);
            this.Controls.Add(this.Character_recognition_button);
            this.Controls.Add(this.Character_recognition_target_Select_button);
            this.Controls.Add(this.Character_recognition_ImagetextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Matching_Image_Save_button);
            this.Controls.Add(this.Matching_button);
            this.Controls.Add(this.Preview_button);
            this.Controls.Add(this.Template_Image_Select_button);
            this.Controls.Add(this.TemplateImagetextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FileSelect_button);
            this.Controls.Add(this.ImageFiletextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "OpenCV and Tesseract Sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ImageFiletextBox;
        private System.Windows.Forms.Button FileSelect_button;
        private System.Windows.Forms.Button Template_Image_Select_button;
        private System.Windows.Forms.TextBox TemplateImagetextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Preview_button;
        private System.Windows.Forms.Button Matching_button;
        private System.Windows.Forms.Button Matching_Image_Save_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Character_recognition_ImagetextBox;
        private System.Windows.Forms.Button Character_recognition_target_Select_button;
        private System.Windows.Forms.Button Character_recognition_button;
        private System.Windows.Forms.RichTextBox ResultrichTextBox;
    }
}

