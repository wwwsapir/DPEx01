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
            this.ButtonShowLikedPages = new System.Windows.Forms.Button();
            this.ListBoxLikedPages = new System.Windows.Forms.ListBox();
            this.LabelLikedPages = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxDaysToInactive = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonShowLikedPages
            // 
            this.ButtonShowLikedPages.Location = new System.Drawing.Point(13, 13);
            this.ButtonShowLikedPages.Name = "ButtonShowLikedPages";
            this.ButtonShowLikedPages.Size = new System.Drawing.Size(169, 23);
            this.ButtonShowLikedPages.TabIndex = 0;
            this.ButtonShowLikedPages.Text = "Show My Inactive Liked Pages";
            this.ButtonShowLikedPages.UseVisualStyleBackColor = true;
            this.ButtonShowLikedPages.Click += new System.EventHandler(this.button1_Click);
            // 
            // ListBoxLikedPages
            // 
            this.ListBoxLikedPages.FormattingEnabled = true;
            this.ListBoxLikedPages.Location = new System.Drawing.Point(12, 80);
            this.ListBoxLikedPages.Name = "ListBoxLikedPages";
            this.ListBoxLikedPages.Size = new System.Drawing.Size(397, 342);
            this.ListBoxLikedPages.TabIndex = 1;
            // 
            // LabelLikedPages
            // 
            this.LabelLikedPages.AutoSize = true;
            this.LabelLikedPages.Location = new System.Drawing.Point(10, 64);
            this.LabelLikedPages.Name = "LabelLikedPages";
            this.LabelLikedPages.Size = new System.Drawing.Size(316, 13);
            this.LabelLikedPages.TabIndex = 2;
            this.LabelLikedPages.Text = "Press the button to view the inactive pages you like on facebook.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "A page will be counted as inactive if there aren\'t posts within the last";
            // 
            // TextBoxDaysToInactive
            // 
            this.TextBoxDaysToInactive.Location = new System.Drawing.Point(342, 40);
            this.TextBoxDaysToInactive.Name = "TextBoxDaysToInactive";
            this.TextBoxDaysToInactive.Size = new System.Drawing.Size(21, 20);
            this.TextBoxDaysToInactive.TabIndex = 4;
            this.TextBoxDaysToInactive.Text = "7";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "days.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 429);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxDaysToInactive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelLikedPages);
            this.Controls.Add(this.ListBoxLikedPages);
            this.Controls.Add(this.ButtonShowLikedPages);
            this.Name = "MainForm";
            this.Text = "s";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonShowLikedPages;
        private System.Windows.Forms.ListBox ListBoxLikedPages;
        private System.Windows.Forms.Label LabelLikedPages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxDaysToInactive;
        private System.Windows.Forms.Label label2;
    }
}

