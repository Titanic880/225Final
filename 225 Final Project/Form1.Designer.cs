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
            this.btnTestDB = new System.Windows.Forms.Button();
            this.btnRunProject = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnAddProj = new System.Windows.Forms.Button();
            this.btnErrorChage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestDB
            // 
            this.btnTestDB.Location = new System.Drawing.Point(205, 320);
            this.btnTestDB.Name = "btnTestDB";
            this.btnTestDB.Size = new System.Drawing.Size(75, 47);
            this.btnTestDB.TabIndex = 0;
            this.btnTestDB.Text = "Test Database";
            this.btnTestDB.UseVisualStyleBackColor = true;
            this.btnTestDB.Click += new System.EventHandler(this.BtnTestDB_Click);
            // 
            // btnRunProject
            // 
            this.btnRunProject.Location = new System.Drawing.Point(193, 373);
            this.btnRunProject.Name = "btnRunProject";
            this.btnRunProject.Size = new System.Drawing.Size(75, 47);
            this.btnRunProject.TabIndex = 1;
            this.btnRunProject.Text = "Open Project";
            this.btnRunProject.UseVisualStyleBackColor = true;
            this.btnRunProject.Click += new System.EventHandler(this.BtnRunProject_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 355);
            this.listBox1.TabIndex = 2;
            // 
            // btnAddProj
            // 
            this.btnAddProj.Location = new System.Drawing.Point(12, 373);
            this.btnAddProj.Name = "btnAddProj";
            this.btnAddProj.Size = new System.Drawing.Size(120, 30);
            this.btnAddProj.TabIndex = 3;
            this.btnAddProj.Text = "Add Project";
            this.btnAddProj.UseVisualStyleBackColor = true;
            this.btnAddProj.Click += new System.EventHandler(this.BtnAddProj_Click);
            // 
            // btnErrorChage
            // 
            this.btnErrorChage.Location = new System.Drawing.Point(713, 394);
            this.btnErrorChage.Name = "btnErrorChage";
            this.btnErrorChage.Size = new System.Drawing.Size(75, 44);
            this.btnErrorChage.TabIndex = 4;
            this.btnErrorChage.Text = "Change Error Output";
            this.btnErrorChage.UseVisualStyleBackColor = true;
            this.btnErrorChage.Click += new System.EventHandler(this.BtnErrorChage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnErrorChage);
            this.Controls.Add(this.btnAddProj);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnRunProject);
            this.Controls.Add(this.btnTestDB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestDB;
        private System.Windows.Forms.Button btnRunProject;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnAddProj;
        private System.Windows.Forms.Button btnErrorChage;
    }
}

