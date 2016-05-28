namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    partial class AdditionalPageInfoFormHebrew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label categoryLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label likesCountLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label uRLLabel;
            this.pageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryLabel1 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.imageNormalPictureBox = new System.Windows.Forms.PictureBox();
            this.likesCountLabel1 = new System.Windows.Forms.Label();
            this.nameLabel1 = new System.Windows.Forms.Label();
            this.uRLLinkLabel = new System.Windows.Forms.LinkLabel();
            categoryLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            likesCountLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            uRLLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageNormalPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new System.Drawing.Point(241, 15);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            categoryLabel.Size = new System.Drawing.Size(53, 13);
            categoryLabel.TabIndex = 1;
            categoryLabel.Text = "קטגוריה:";
            categoryLabel.UseMnemonic = false;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(243, 85);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            descriptionLabel.Size = new System.Drawing.Size(41, 13);
            descriptionLabel.TabIndex = 3;
            descriptionLabel.Text = "תיאור:";
            // 
            // likesCountLabel
            // 
            likesCountLabel.AutoSize = true;
            likesCountLabel.Location = new System.Drawing.Point(241, 64);
            likesCountLabel.Name = "likesCountLabel";
            likesCountLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            likesCountLabel.Size = new System.Drawing.Size(76, 13);
            likesCountLabel.TabIndex = 7;
            likesCountLabel.Text = "מספר לייקים:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(12, 10);
            nameLabel.Name = "nameLabel";
            nameLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            nameLabel.Size = new System.Drawing.Size(26, 13);
            nameLabel.TabIndex = 9;
            nameLabel.Text = "שם:";
            // 
            // uRLLabel
            // 
            uRLLabel.AutoSize = true;
            uRLLabel.Location = new System.Drawing.Point(241, 39);
            uRLLabel.Name = "uRLLabel";
            uRLLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            uRLLabel.Size = new System.Drawing.Size(43, 13);
            uRLLabel.TabIndex = 11;
            uRLLabel.Text = "כתובת:";
            // 
            // pageBindingSource
            // 
            this.pageBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Page);
            // 
            // categoryLabel1
            // 
            this.categoryLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pageBindingSource, "Category", true));
            this.categoryLabel1.Location = new System.Drawing.Point(300, 15);
            this.categoryLabel1.Name = "categoryLabel1";
            this.categoryLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.categoryLabel1.Size = new System.Drawing.Size(123, 23);
            this.categoryLabel1.TabIndex = 2;
            this.categoryLabel1.Text = "label1";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pageBindingSource, "Description", true));
            this.descriptionTextBox.Location = new System.Drawing.Point(244, 106);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(254, 112);
            this.descriptionTextBox.TabIndex = 4;
            // 
            // imageNormalPictureBox
            // 
            this.imageNormalPictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.pageBindingSource, "ImageNormal", true));
            this.imageNormalPictureBox.Location = new System.Drawing.Point(12, 31);
            this.imageNormalPictureBox.Name = "imageNormalPictureBox";
            this.imageNormalPictureBox.Size = new System.Drawing.Size(207, 187);
            this.imageNormalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageNormalPictureBox.TabIndex = 6;
            this.imageNormalPictureBox.TabStop = false;
            // 
            // likesCountLabel1
            // 
            this.likesCountLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pageBindingSource, "LikesCount", true));
            this.likesCountLabel1.Location = new System.Drawing.Point(323, 64);
            this.likesCountLabel1.Name = "likesCountLabel1";
            this.likesCountLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.likesCountLabel1.Size = new System.Drawing.Size(100, 23);
            this.likesCountLabel1.TabIndex = 8;
            this.likesCountLabel1.Text = "label1";
            // 
            // nameLabel1
            // 
            this.nameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pageBindingSource, "Name", true));
            this.nameLabel1.Location = new System.Drawing.Point(44, 10);
            this.nameLabel1.Name = "nameLabel1";
            this.nameLabel1.Size = new System.Drawing.Size(191, 18);
            this.nameLabel1.TabIndex = 10;
            this.nameLabel1.Text = "label1";
            // 
            // uRLLinkLabel
            // 
            this.uRLLinkLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pageBindingSource, "URL", true));
            this.uRLLinkLabel.Location = new System.Drawing.Point(283, 39);
            this.uRLLinkLabel.Name = "uRLLinkLabel";
            this.uRLLinkLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uRLLinkLabel.Size = new System.Drawing.Size(215, 23);
            this.uRLLinkLabel.TabIndex = 12;
            this.uRLLinkLabel.TabStop = true;
            this.uRLLinkLabel.Text = "linkLabel1";
            // 
            // AdditionalPageInfoFormHebrew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 229);
            this.Controls.Add(categoryLabel);
            this.Controls.Add(this.categoryLabel1);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.imageNormalPictureBox);
            this.Controls.Add(likesCountLabel);
            this.Controls.Add(this.likesCountLabel1);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameLabel1);
            this.Controls.Add(uRLLabel);
            this.Controls.Add(this.uRLLinkLabel);
            this.Name = "AdditionalPageInfoFormHebrew";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "פרטים נוספים על העמוד";
            ((System.ComponentModel.ISupportInitialize)(this.pageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageNormalPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource pageBindingSource;
        private System.Windows.Forms.Label categoryLabel1;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.PictureBox imageNormalPictureBox;
        private System.Windows.Forms.Label likesCountLabel1;
        private System.Windows.Forms.Label nameLabel1;
        private System.Windows.Forms.LinkLabel uRLLinkLabel;
    }
}