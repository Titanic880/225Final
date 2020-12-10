namespace _225_Final_Project
{
    partial class Form1
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
            this.btnRunProject = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnAddProj = new System.Windows.Forms.Button();
            this.btnErrorChange = new System.Windows.Forms.Button();
            this.btnRecheck = new System.Windows.Forms.Button();
            this.btnGit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblSaveTo = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRunProject
            // 
            this.btnRunProject.Location = new System.Drawing.Point(9, 422);
            this.btnRunProject.Name = "btnRunProject";
            this.btnRunProject.Size = new System.Drawing.Size(249, 30);
            this.btnRunProject.TabIndex = 3;
            this.btnRunProject.Text = "Open File";
            this.btnRunProject.UseVisualStyleBackColor = true;
            this.btnRunProject.Click += new System.EventHandler(this.BtnRunProject_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(249, 355);
            this.listBox1.TabIndex = 0;
            // 
            // btnAddProj
            // 
            this.btnAddProj.Location = new System.Drawing.Point(9, 386);
            this.btnAddProj.Name = "btnAddProj";
            this.btnAddProj.Size = new System.Drawing.Size(120, 30);
            this.btnAddProj.TabIndex = 1;
            this.btnAddProj.Text = "Add File";
            this.btnAddProj.UseVisualStyleBackColor = true;
            this.btnAddProj.Click += new System.EventHandler(this.BtnAddProj_Click);
            // 
            // btnErrorChange
            // 
            this.btnErrorChange.Location = new System.Drawing.Point(138, 458);
            this.btnErrorChange.Name = "btnErrorChange";
            this.btnErrorChange.Size = new System.Drawing.Size(120, 30);
            this.btnErrorChange.TabIndex = 5;
            this.btnErrorChange.Text = "Change Error Output";
            this.btnErrorChange.UseVisualStyleBackColor = true;
            this.btnErrorChange.Click += new System.EventHandler(this.BtnErrorChange_Click);
            // 
            // btnRecheck
            // 
            this.btnRecheck.Location = new System.Drawing.Point(9, 458);
            this.btnRecheck.Name = "btnRecheck";
            this.btnRecheck.Size = new System.Drawing.Size(120, 30);
            this.btnRecheck.TabIndex = 4;
            this.btnRecheck.Text = "Rerun Startup Checks";
            this.btnRecheck.UseVisualStyleBackColor = true;
            this.btnRecheck.Click += new System.EventHandler(this.BtnRecheck_Click);
            // 
            // btnGit
            // 
            this.btnGit.Location = new System.Drawing.Point(9, 494);
            this.btnGit.Name = "btnGit";
            this.btnGit.Size = new System.Drawing.Size(120, 30);
            this.btnGit.TabIndex = 6;
            this.btnGit.Text = "Clone From Github";
            this.btnGit.UseVisualStyleBackColor = true;
            this.btnGit.Click += new System.EventHandler(this.BtnGit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(138, 494);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save List of Files";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(9, 530);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(249, 30);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(138, 386);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(120, 30);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove File";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // lblSaveTo
            // 
            this.lblSaveTo.AutoSize = true;
            this.lblSaveTo.Location = new System.Drawing.Point(79, 9);
            this.lblSaveTo.Name = "lblSaveTo";
            this.lblSaveTo.Size = new System.Drawing.Size(62, 13);
            this.lblSaveTo.TabIndex = 11;
            this.lblSaveTo.Text = "Saving To: ";
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Location = new System.Drawing.Point(138, 9);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(23, 13);
            this.lblSave.TabIndex = 10;
            this.lblSave.Text = "File";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 572);
            this.Controls.Add(this.lblSave);
            this.Controls.Add(this.lblSaveTo);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGit);
            this.Controls.Add(this.btnErrorChange);
            this.Controls.Add(this.btnAddProj);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnRunProject);
            this.Controls.Add(this.btnRecheck);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRunProject;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnAddProj;
        private System.Windows.Forms.Button btnErrorChange;
        private System.Windows.Forms.Button btnRecheck;
        private System.Windows.Forms.Button btnGit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblSaveTo;
        private System.Windows.Forms.Label lblSave;
    }
}

