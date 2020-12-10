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
            this.SuspendLayout();
            // 
            // btnRunProject
            // 
            this.btnRunProject.Location = new System.Drawing.Point(138, 373);
            this.btnRunProject.Name = "btnRunProject";
            this.btnRunProject.Size = new System.Drawing.Size(115, 29);
            this.btnRunProject.TabIndex = 1;
            this.btnRunProject.Text = "Open File";
            this.btnRunProject.UseVisualStyleBackColor = true;
            this.btnRunProject.Click += new System.EventHandler(this.BtnRunProject_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(241, 355);
            this.listBox1.TabIndex = 2;
            // 
            // btnAddProj
            // 
            this.btnAddProj.Location = new System.Drawing.Point(12, 373);
            this.btnAddProj.Name = "btnAddProj";
            this.btnAddProj.Size = new System.Drawing.Size(120, 30);
            this.btnAddProj.TabIndex = 3;
            this.btnAddProj.Text = "Add File";
            this.btnAddProj.UseVisualStyleBackColor = true;
            this.btnAddProj.Click += new System.EventHandler(this.BtnAddProj_Click);
            // 
            // btnErrorChange
            // 
            this.btnErrorChange.Location = new System.Drawing.Point(138, 409);
            this.btnErrorChange.Name = "btnErrorChange";
            this.btnErrorChange.Size = new System.Drawing.Size(115, 39);
            this.btnErrorChange.TabIndex = 4;
            this.btnErrorChange.Text = "Change Error Output";
            this.btnErrorChange.UseVisualStyleBackColor = true;
            this.btnErrorChange.Click += new System.EventHandler(this.BtnErrorChange_Click);
            // 
            // btnRecheck
            // 
            this.btnRecheck.Location = new System.Drawing.Point(12, 409);
            this.btnRecheck.Name = "btnRecheck";
            this.btnRecheck.Size = new System.Drawing.Size(120, 39);
            this.btnRecheck.TabIndex = 5;
            this.btnRecheck.Text = "Rerun Startup Checks";
            this.btnRecheck.UseVisualStyleBackColor = true;
            this.btnRecheck.Click += new System.EventHandler(this.BtnRecheck_Click);
            // 
            // btnGit
            // 
            this.btnGit.Location = new System.Drawing.Point(12, 454);
            this.btnGit.Name = "btnGit";
            this.btnGit.Size = new System.Drawing.Size(120, 30);
            this.btnGit.TabIndex = 6;
            this.btnGit.Text = "Clone From Github";
            this.btnGit.UseVisualStyleBackColor = true;
            this.btnGit.Click += new System.EventHandler(this.BtnGit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(138, 454);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save List of Files";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 508);
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

        }

        #endregion
        private System.Windows.Forms.Button btnRunProject;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnAddProj;
        private System.Windows.Forms.Button btnErrorChange;
        private System.Windows.Forms.Button btnRecheck;
        private System.Windows.Forms.Button btnGit;
        private System.Windows.Forms.Button btnSave;
    }
}

