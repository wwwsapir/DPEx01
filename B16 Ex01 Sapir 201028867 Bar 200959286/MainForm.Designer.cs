namespace B16_Ex01_Sapir_201028867_Bar_200959286
{
    partial class MainForm
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
            this.buttonShowLikedPages = new System.Windows.Forms.Button();
            this.listBoxLikedPages = new System.Windows.Forms.ListBox();
            this.pageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelLikedPages = new System.Windows.Forms.Label();
            this.textBoxDaysToInactive = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxProfilePicture = new System.Windows.Forms.PictureBox();
            this.buttonProfilePicture = new System.Windows.Forms.Button();
            this.buttonPrevPicture = new System.Windows.Forms.Button();
            this.buttonNextPicture = new System.Windows.Forms.Button();
            this.labelProfilePictureDate = new System.Windows.Forms.Label();
            this.buttonEditImage = new System.Windows.Forms.Button();
            this.buttonAdditionalPageInfo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonInactive = new System.Windows.Forms.RadioButton();
            this.radioButtonLikes = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFilterLikes = new System.Windows.Forms.TextBox();
            this.radioButtonEnglish = new System.Windows.Forms.RadioButton();
            this.radioButtonHebrew = new System.Windows.Forms.RadioButton();
            this.buttonRed = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonYellow = new System.Windows.Forms.Button();
            this.buttonGreen = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonShowLikedPages
            // 
            this.buttonShowLikedPages.Location = new System.Drawing.Point(559, 157);
            this.buttonShowLikedPages.Name = "buttonShowLikedPages";
            this.buttonShowLikedPages.Size = new System.Drawing.Size(169, 22);
            this.buttonShowLikedPages.TabIndex = 0;
            this.buttonShowLikedPages.Text = "Show My Filtered Liked Pages";
            this.buttonShowLikedPages.UseVisualStyleBackColor = true;
            this.buttonShowLikedPages.Click += new System.EventHandler(this.buttonButtonShowLikedPages_Click);
            // 
            // listBoxLikedPages
            // 
            this.listBoxLikedPages.DataSource = this.pageBindingSource;
            this.listBoxLikedPages.DisplayMember = "Name";
            this.listBoxLikedPages.FormattingEnabled = true;
            this.listBoxLikedPages.Location = new System.Drawing.Point(239, 40);
            this.listBoxLikedPages.Name = "listBoxLikedPages";
            this.listBoxLikedPages.Size = new System.Drawing.Size(314, 225);
            this.listBoxLikedPages.TabIndex = 1;
            // 
            // pageBindingSource
            // 
            this.pageBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.Page);
            // 
            // labelLikedPages
            // 
            this.labelLikedPages.AutoSize = true;
            this.labelLikedPages.Location = new System.Drawing.Point(236, 19);
            this.labelLikedPages.Name = "labelLikedPages";
            this.labelLikedPages.Size = new System.Drawing.Size(300, 13);
            this.labelLikedPages.TabIndex = 2;
            this.labelLikedPages.Text = "Choose a filter to view the filtered pages you like on facebook.";
            // 
            // textBoxDaysToInactive
            // 
            this.textBoxDaysToInactive.Location = new System.Drawing.Point(638, 59);
            this.textBoxDaysToInactive.Name = "textBoxDaysToInactive";
            this.textBoxDaysToInactive.Size = new System.Drawing.Size(21, 20);
            this.textBoxDaysToInactive.TabIndex = 4;
            this.textBoxDaysToInactive.Text = "7";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(661, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "days or more,";
            // 
            // pictureBoxProfilePicture
            // 
            this.pictureBoxProfilePicture.Location = new System.Drawing.Point(23, 65);
            this.pictureBoxProfilePicture.Name = "pictureBoxProfilePicture";
            this.pictureBoxProfilePicture.Size = new System.Drawing.Size(187, 166);
            this.pictureBoxProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProfilePicture.TabIndex = 6;
            this.pictureBoxProfilePicture.TabStop = false;
            // 
            // buttonProfilePicture
            // 
            this.buttonProfilePicture.Location = new System.Drawing.Point(23, 14);
            this.buttonProfilePicture.Name = "buttonProfilePicture";
            this.buttonProfilePicture.Size = new System.Drawing.Size(156, 23);
            this.buttonProfilePicture.TabIndex = 8;
            this.buttonProfilePicture.Text = "Show My Profile Picture";
            this.buttonProfilePicture.UseVisualStyleBackColor = true;
            this.buttonProfilePicture.Click += new System.EventHandler(this.buttonProfilePicture_Click);
            // 
            // buttonPrevPicture
            // 
            this.buttonPrevPicture.Location = new System.Drawing.Point(24, 237);
            this.buttonPrevPicture.Name = "buttonPrevPicture";
            this.buttonPrevPicture.Size = new System.Drawing.Size(56, 23);
            this.buttonPrevPicture.TabIndex = 9;
            this.buttonPrevPicture.Text = "<";
            this.buttonPrevPicture.UseVisualStyleBackColor = true;
            this.buttonPrevPicture.Click += new System.EventHandler(this.buttonPrevPicture_Click);
            // 
            // buttonNextPicture
            // 
            this.buttonNextPicture.Location = new System.Drawing.Point(154, 237);
            this.buttonNextPicture.Name = "buttonNextPicture";
            this.buttonNextPicture.Size = new System.Drawing.Size(56, 23);
            this.buttonNextPicture.TabIndex = 10;
            this.buttonNextPicture.Text = ">";
            this.buttonNextPicture.UseVisualStyleBackColor = true;
            this.buttonNextPicture.Click += new System.EventHandler(this.buttonNextPicture_Click);
            // 
            // labelProfilePictureDate
            // 
            this.labelProfilePictureDate.AutoSize = true;
            this.labelProfilePictureDate.Location = new System.Drawing.Point(24, 46);
            this.labelProfilePictureDate.Name = "labelProfilePictureDate";
            this.labelProfilePictureDate.Size = new System.Drawing.Size(104, 13);
            this.labelProfilePictureDate.TabIndex = 11;
            this.labelProfilePictureDate.Text = "Latest Profile Picture";
            // 
            // buttonEditImage
            // 
            this.buttonEditImage.Location = new System.Drawing.Point(86, 237);
            this.buttonEditImage.Name = "buttonEditImage";
            this.buttonEditImage.Size = new System.Drawing.Size(62, 23);
            this.buttonEditImage.TabIndex = 12;
            this.buttonEditImage.Text = "Edit Image";
            this.buttonEditImage.UseVisualStyleBackColor = true;
            this.buttonEditImage.Click += new System.EventHandler(this.buttonEditImage_Click);
            // 
            // buttonAdditionalPageInfo
            // 
            this.buttonAdditionalPageInfo.Location = new System.Drawing.Point(558, 185);
            this.buttonAdditionalPageInfo.Name = "buttonAdditionalPageInfo";
            this.buttonAdditionalPageInfo.Size = new System.Drawing.Size(170, 22);
            this.buttonAdditionalPageInfo.TabIndex = 13;
            this.buttonAdditionalPageInfo.Text = "Additional Page Info";
            this.buttonAdditionalPageInfo.UseVisualStyleBackColor = true;
            this.buttonAdditionalPageInfo.Click += new System.EventHandler(this.buttonAdditionalPageInfo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(559, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Hide Pages:";
            // 
            // radioButtonInactive
            // 
            this.radioButtonInactive.AutoSize = true;
            this.radioButtonInactive.Checked = true;
            this.radioButtonInactive.Location = new System.Drawing.Point(559, 60);
            this.radioButtonInactive.Name = "radioButtonInactive";
            this.radioButtonInactive.Size = new System.Drawing.Size(78, 17);
            this.radioButtonInactive.TabIndex = 15;
            this.radioButtonInactive.TabStop = true;
            this.radioButtonInactive.Text = "Inactive for";
            this.radioButtonInactive.UseVisualStyleBackColor = true;
            // 
            // radioButtonLikes
            // 
            this.radioButtonLikes.AutoSize = true;
            this.radioButtonLikes.Location = new System.Drawing.Point(559, 85);
            this.radioButtonLikes.Name = "radioButtonLikes";
            this.radioButtonLikes.Size = new System.Drawing.Size(97, 17);
            this.radioButtonLikes.TabIndex = 18;
            this.radioButtonLikes.Text = "With more than";
            this.radioButtonLikes.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(689, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "likes.";
            // 
            // textBoxFilterLikes
            // 
            this.textBoxFilterLikes.Location = new System.Drawing.Point(656, 84);
            this.textBoxFilterLikes.Name = "textBoxFilterLikes";
            this.textBoxFilterLikes.Size = new System.Drawing.Size(31, 20);
            this.textBoxFilterLikes.TabIndex = 16;
            this.textBoxFilterLikes.Text = "50";
            // 
            // radioButtonEnglish
            // 
            this.radioButtonEnglish.AutoSize = true;
            this.radioButtonEnglish.Location = new System.Drawing.Point(559, 110);
            this.radioButtonEnglish.Name = "radioButtonEnglish";
            this.radioButtonEnglish.Size = new System.Drawing.Size(71, 17);
            this.radioButtonEnglish.TabIndex = 19;
            this.radioButtonEnglish.Text = "In English";
            this.radioButtonEnglish.UseVisualStyleBackColor = true;
            // 
            // radioButtonHebrew
            // 
            this.radioButtonHebrew.AutoSize = true;
            this.radioButtonHebrew.Location = new System.Drawing.Point(559, 134);
            this.radioButtonHebrew.Name = "radioButtonHebrew";
            this.radioButtonHebrew.Size = new System.Drawing.Size(74, 17);
            this.radioButtonHebrew.TabIndex = 20;
            this.radioButtonHebrew.Text = "In Hebrew";
            this.radioButtonHebrew.UseVisualStyleBackColor = true;
            // 
            // buttonRed
            // 
            this.buttonRed.Location = new System.Drawing.Point(559, 241);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(36, 23);
            this.buttonRed.TabIndex = 21;
            this.buttonRed.Text = "Red";
            this.buttonRed.UseVisualStyleBackColor = true;
            this.buttonRed.Click += new System.EventHandler(this.buttonRed_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(559, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Form Color Scheme:";
            // 
            // buttonYellow
            // 
            this.buttonYellow.Location = new System.Drawing.Point(685, 241);
            this.buttonYellow.Name = "buttonYellow";
            this.buttonYellow.Size = new System.Drawing.Size(46, 23);
            this.buttonYellow.TabIndex = 23;
            this.buttonYellow.Text = "Yellow";
            this.buttonYellow.UseVisualStyleBackColor = true;
            this.buttonYellow.Click += new System.EventHandler(this.buttonYellow_Click);
            // 
            // buttonGreen
            // 
            this.buttonGreen.Location = new System.Drawing.Point(636, 241);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(47, 23);
            this.buttonGreen.TabIndex = 24;
            this.buttonGreen.Text = "Green";
            this.buttonGreen.UseVisualStyleBackColor = true;
            this.buttonGreen.Click += new System.EventHandler(this.buttonGreen_Click);
            // 
            // buttonBlue
            // 
            this.buttonBlue.Location = new System.Drawing.Point(597, 241);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(36, 23);
            this.buttonBlue.TabIndex = 25;
            this.buttonBlue.Text = "Blue";
            this.buttonBlue.UseVisualStyleBackColor = true;
            this.buttonBlue.Click += new System.EventHandler(this.buttonBlue_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 276);
            this.Controls.Add(this.buttonBlue);
            this.Controls.Add(this.buttonGreen);
            this.Controls.Add(this.buttonYellow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonRed);
            this.Controls.Add(this.radioButtonHebrew);
            this.Controls.Add(this.radioButtonEnglish);
            this.Controls.Add(this.radioButtonLikes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFilterLikes);
            this.Controls.Add(this.radioButtonInactive);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonAdditionalPageInfo);
            this.Controls.Add(this.buttonEditImage);
            this.Controls.Add(this.labelProfilePictureDate);
            this.Controls.Add(this.buttonNextPicture);
            this.Controls.Add(this.buttonPrevPicture);
            this.Controls.Add(this.buttonProfilePicture);
            this.Controls.Add(this.pictureBoxProfilePicture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDaysToInactive);
            this.Controls.Add(this.labelLikedPages);
            this.Controls.Add(this.listBoxLikedPages);
            this.Controls.Add(this.buttonShowLikedPages);
            this.Name = "MainForm";
            this.Text = "Facebook Form Application";
            ((System.ComponentModel.ISupportInitialize)(this.pageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonShowLikedPages;
        private System.Windows.Forms.ListBox listBoxLikedPages;
        private System.Windows.Forms.Label labelLikedPages;
        private System.Windows.Forms.TextBox textBoxDaysToInactive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxProfilePicture;
        private System.Windows.Forms.Button buttonProfilePicture;
        private System.Windows.Forms.Button buttonPrevPicture;
        private System.Windows.Forms.Button buttonNextPicture;
        private System.Windows.Forms.Label labelProfilePictureDate;
        private System.Windows.Forms.Button buttonEditImage;
        private System.Windows.Forms.Button buttonAdditionalPageInfo;
        private System.Windows.Forms.BindingSource pageBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonInactive;
        private System.Windows.Forms.RadioButton radioButtonLikes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFilterLikes;
        private System.Windows.Forms.RadioButton radioButtonEnglish;
        private System.Windows.Forms.RadioButton radioButtonHebrew;
        private System.Windows.Forms.Button buttonRed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonYellow;
        private System.Windows.Forms.Button buttonGreen;
        private System.Windows.Forms.Button buttonBlue;
    }
}

