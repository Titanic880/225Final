namespace _225_Final_Project.Resources
{
    partial class GitClone
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
            this.tbLink = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblLink = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbLink
            // 
            this.tbLink.Location = new System.Drawing.Point(34, 39);
            this.tbLink.Name = "tbLink";
            this.tbLink.Size = new System.Drawing.Size(154, 20);
            this.tbLink.TabIndex = 0;
            this.tbLink.Text = "https://github.com/";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(34, 65);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(154, 36);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Clone Repository!";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(56, 23);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(111, 13);
            this.lblLink.TabIndex = 3;
            this.lblLink.Text = "Git Repository to copy";
            // 
            // GitClone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 129);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tbLink);
            this.Name = "GitClone";
            this.Text = "GitClone";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLink;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblLink;
    }
}