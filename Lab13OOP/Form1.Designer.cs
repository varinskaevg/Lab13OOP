namespace Lab13OOP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxDrives = new ListBox();
            listBoxContent = new ListBox();
            textBoxPath = new TextBox();
            buttonApplyFilter = new Button();
            labelProperties = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBoxDirectoryFilter = new ComboBox();
            textBoxFileFilter = new TextBox();
            pictureBoxImage = new PictureBox();
            richTextBoxContent = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            SuspendLayout();
            // 
            // listBoxDrives
            // 
            listBoxDrives.FormattingEnabled = true;
            listBoxDrives.Location = new Point(12, 12);
            listBoxDrives.Name = "listBoxDrives";
            listBoxDrives.Size = new Size(150, 104);
            listBoxDrives.TabIndex = 0;
            listBoxDrives.SelectedIndexChanged += listBoxDrives_SelectedIndexChanged;
            // 
            // listBoxContent
            // 
            listBoxContent.FormattingEnabled = true;
            listBoxContent.Location = new Point(192, 12);
            listBoxContent.Name = "listBoxContent";
            listBoxContent.Size = new Size(296, 104);
            listBoxContent.TabIndex = 1;
            listBoxContent.SelectedIndexChanged += listBoxContent_SelectedIndexChanged;
            // 
            // textBoxPath
            // 
            textBoxPath.Location = new Point(581, 12);
            textBoxPath.Name = "textBoxPath";
            textBoxPath.Size = new Size(385, 27);
            textBoxPath.TabIndex = 2;
            // 
            // buttonApplyFilter
            // 
            buttonApplyFilter.Location = new Point(386, 148);
            buttonApplyFilter.Name = "buttonApplyFilter";
            buttonApplyFilter.Size = new Size(121, 40);
            buttonApplyFilter.TabIndex = 5;
            buttonApplyFilter.Text = "Пошук";
            buttonApplyFilter.UseVisualStyleBackColor = true;
            buttonApplyFilter.Click += buttonApplyFilter_Click;
            // 
            // labelProperties
            // 
            labelProperties.AutoSize = true;
            labelProperties.Location = new Point(581, 64);
            labelProperties.Name = "labelProperties";
            labelProperties.Size = new Size(50, 20);
            labelProperties.TabIndex = 6;
            labelProperties.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 137);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 7;
            label1.Text = "Фільт списків";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 177);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 8;
            label2.Text = "Фільт каталогів";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(515, 12);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 9;
            label3.Text = "Шлях";
            // 
            // comboBoxDirectoryFilter
            // 
            comboBoxDirectoryFilter.FormattingEnabled = true;
            comboBoxDirectoryFilter.Location = new Point(130, 177);
            comboBoxDirectoryFilter.Name = "comboBoxDirectoryFilter";
            comboBoxDirectoryFilter.Size = new Size(250, 28);
            comboBoxDirectoryFilter.TabIndex = 11;
            // 
            // textBoxFileFilter
            // 
            textBoxFileFilter.Location = new Point(130, 137);
            textBoxFileFilter.Name = "textBoxFileFilter";
            textBoxFileFilter.Size = new Size(250, 27);
            textBoxFileFilter.TabIndex = 12;
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Location = new Point(25, 233);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(536, 316);
            pictureBoxImage.TabIndex = 13;
            pictureBoxImage.TabStop = false;
            // 
            // richTextBoxContent
            // 
            richTextBoxContent.Location = new Point(581, 233);
            richTextBoxContent.Name = "richTextBoxContent";
            richTextBoxContent.Size = new Size(543, 316);
            richTextBoxContent.TabIndex = 14;
            richTextBoxContent.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1136, 561);
            Controls.Add(richTextBoxContent);
            Controls.Add(pictureBoxImage);
            Controls.Add(textBoxFileFilter);
            Controls.Add(comboBoxDirectoryFilter);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelProperties);
            Controls.Add(buttonApplyFilter);
            Controls.Add(textBoxPath);
            Controls.Add(listBoxContent);
            Controls.Add(listBoxDrives);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxDrives;
        private ListBox listBoxContent;
        private TextBox textBoxPath;
        private Button buttonApplyFilter;
        private Label labelProperties;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBoxDirectoryFilter;
        private TextBox textBoxFileFilter;
        private PictureBox pictureBoxImage;
        private RichTextBox richTextBoxContent;
    }
}
