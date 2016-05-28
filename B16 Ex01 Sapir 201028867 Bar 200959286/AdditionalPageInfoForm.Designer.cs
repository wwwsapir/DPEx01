namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    partial class AdditionalPageInfoForm
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
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label likesCountLabel;
            System.Windows.Forms.Label uRLLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label categoryLabel;
            this.pageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pageDescriptionText = new System.Windows.Forms.TextBox();
            this.imageNormalPictureBox1 = new System.Windows.Forms.PictureBox();
            this.likesCountLabel3 = new System.Windows.Forms.Label();
            this.uRLLinkLabel1 = new System.Windows.Forms.LinkLabel();
            this.nameLabel1 = new System.Windows.Forms.Label();
            this.categoryLabel1 = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            likesCountLabel = new System.Windows.Forms.Label();
            uRLLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            categoryLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageNormalPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(260, 81);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(63, 13);
            descriptionLabel.TabIndex = 3;
            descriptionLabel.Text = "Description:";
            // 
            // likesCountLabel
            // 
            likesCountLabel.AutoSize = true;
            likesCountLabel.Location = new System.Drawing.Point(260, 61);
            likesCountLabel.Name = "likesCountLabel";
            likesCountLabel.Size = new System.Drawing.Size(66, 13);
            likesCountLabel.TabIndex = 7;
            likesCountLabel.Text = "Likes Count:";
            // 
            // uRLLabel
            // 
            uRLLabel.AutoSize = true;
            uRLLabel.Location = new System.Drawing.Point(257, 38);
            uRLLabel.Name = "uRLLabel";
            uRLLabel.Size = new System.Drawing.Size(32, 13);
            uRLLabel.TabIndex = 15;
            uRLLabel.Text = "URL:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(18, 12);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 30;
            nameLabel.Text = "Name:";
            // 
            // pageBindingSource
            // 
            this.pageBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Page);
            // 
            // pageDescriptionText
            // 
            this.pageDescriptionText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pageBindingSource, "Description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pageDescriptionText.Location = new System.Drawing.Point(260, 100);
            this.pageDescriptionText.Multiline = true;
            this.pageDescriptionText.Name = "pageDescriptionText";
            this.pageDescriptionText.ReadOnly = true;
            this.pageDescriptionText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pageDescriptionText.Size = new System.Drawing.Size(278, 125);
            this.pageDescriptionText.TabIndex = 19;
            // 
            // imageNormalPictureBox1
            // 
            this.imageNormalPictureBox1.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.pageBindingSource, "ImageNormal", true));
            this.imageNormalPictureBox1.Location = new System.Drawing.Point(12, 28);
            this.imageNormalPictureBox1.Name = "imageNormalPictureBox1";
            this.imageNormalPictureBox1.Size = new System.Drawing.Size(228, 197);
            this.imageNormalPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageNormalPictureBox1.TabIndex = 21;
            this.imageNormalPictureBox1.TabStop = false;
            // 
            // likesCountLabel3
            // 
            this.likesCountLabel3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pageBindingSource, "LikesCount", true));
            this.likesCountLabel3.Location = new System.Drawing.Point(332, 61);
            this.likesCountLabel3.Name = "likesCountLabel3";
            this.likesCountLabel3.Size = new System.Drawing.Size(104, 23);
            this.likesCountLabel3.TabIndex = 23;
            this.likesCountLabel3.Text = "label1";
            // 
            // uRLLinkLabel1
            // 
            this.uRLLinkLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pageBindingSource, "URL", true));
            this.uRLLinkLabel1.Location = new System.Drawing.Point(295, 38);
            this.uRLLinkLabel1.Name = "uRLLinkLabel1";
            this.uRLLinkLabel1.Size = new System.Drawing.Size(243, 23);
            this.uRLLinkLabel1.TabIndex = 27;
            this.uRLLinkLabel1.TabStop = true;
            this.uRLLinkLabel1.Text = "linkLabel1";
            // 
            // nameLabel1
            // 
            this.nameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pageBindingSource, "Name", true));
            this.nameLabel1.Location = new System.Drawing.Point(62, 9);
            this.nameLabel1.Name = "nameLabel1";
            this.nameLabel1.Size = new System.Drawing.Size(186, 23);
            this.nameLabel1.TabIndex = 31;
            this.nameLabel1.Text = "label1";
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new System.Drawing.Point(260, 12);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new System.Drawing.Size(52, 13);
            categoryLabel.TabIndex = 31;
            categoryLabel.Text = "Category:";
            // 
            // categoryLabel1
            // 
            this.categoryLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pageBindingSource, "Category", true));
            this.categoryLabel1.Location = new System.Drawing.Point(318, 12);
            this.categoryLabel1.Name = "categoryLabel1";
            this.categoryLabel1.Size = new System.Drawing.Size(149, 23);
            this.categoryLabel1.TabIndex = 32;
            this.categoryLabel1.Text = "label1";
            // 
            // AdditionalPageInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 239);
            this.Controls.Add(categoryLabel);
            this.Controls.Add(this.categoryLabel1);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameLabel1);
            this.Controls.Add(this.pageDescriptionText);
            this.Controls.Add(this.imageNormalPictureBox1);
            this.Controls.Add(this.likesCountLabel3);
            this.Controls.Add(this.uRLLinkLabel1);
            this.Controls.Add(uRLLabel);
            this.Controls.Add(likesCountLabel);
            this.Controls.Add(descriptionLabel);
            this.Name = "AdditionalPageInfoForm";
            this.Text = "Additional Page Info";
            ((System.ComponentModel.ISupportInitialize)(this.pageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageNormalPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource pageBindingSource;
        private System.Windows.Forms.TextBox pageDescriptionText;
        private System.Windows.Forms.PictureBox imageNormalPictureBox1;
        private System.Windows.Forms.Label likesCountLabel3;
        private System.Windows.Forms.LinkLabel uRLLinkLabel1;
        private System.Windows.Forms.Label nameLabel1;
        private System.Windows.Forms.Label categoryLabel1;
    }
}