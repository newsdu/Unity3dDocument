namespace newsdu.Unity3dDocument
{
    partial class OptionForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtbox_unity3dPath = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtbox_webBrowserPath = new System.Windows.Forms.TextBox();
			this.btn_webBrowserPath = new System.Windows.Forms.Button();
			this.txtbox_googlePrefix = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btn_unity3dPath = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtbox_naverPrefix = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Unity3d";
			// 
			// txtbox_unity3dPath
			// 
			this.txtbox_unity3dPath.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.txtbox_unity3dPath.ForeColor = System.Drawing.SystemColors.Control;
			this.txtbox_unity3dPath.Location = new System.Drawing.Point(88, 20);
			this.txtbox_unity3dPath.Name = "txtbox_unity3dPath";
			this.txtbox_unity3dPath.ReadOnly = true;
			this.txtbox_unity3dPath.Size = new System.Drawing.Size(376, 21);
			this.txtbox_unity3dPath.TabIndex = 1;
			this.txtbox_unity3dPath.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 12);
			this.label2.TabIndex = 0;
			this.label2.Text = "WebBrowser";
			// 
			// txtbox_webBrowserPath
			// 
			this.txtbox_webBrowserPath.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.txtbox_webBrowserPath.ForeColor = System.Drawing.SystemColors.Control;
			this.txtbox_webBrowserPath.Location = new System.Drawing.Point(88, 47);
			this.txtbox_webBrowserPath.Name = "txtbox_webBrowserPath";
			this.txtbox_webBrowserPath.ReadOnly = true;
			this.txtbox_webBrowserPath.Size = new System.Drawing.Size(376, 21);
			this.txtbox_webBrowserPath.TabIndex = 1;
			this.txtbox_webBrowserPath.TabStop = false;
			// 
			// btn_webBrowserPath
			// 
			this.btn_webBrowserPath.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_webBrowserPath.Location = new System.Drawing.Point(470, 47);
			this.btn_webBrowserPath.Name = "btn_webBrowserPath";
			this.btn_webBrowserPath.Size = new System.Drawing.Size(25, 23);
			this.btn_webBrowserPath.TabIndex = 2;
			this.btn_webBrowserPath.Text = "...";
			this.btn_webBrowserPath.UseVisualStyleBackColor = true;
			this.btn_webBrowserPath.Click += new System.EventHandler(this.btn_webBrowserPath_Click);
			// 
			// txtbox_googlePrefix
			// 
			this.txtbox_googlePrefix.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.txtbox_googlePrefix.ForeColor = System.Drawing.SystemColors.Control;
			this.txtbox_googlePrefix.Location = new System.Drawing.Point(88, 20);
			this.txtbox_googlePrefix.Name = "txtbox_googlePrefix";
			this.txtbox_googlePrefix.Size = new System.Drawing.Size(326, 21);
			this.txtbox_googlePrefix.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 12);
			this.label3.TabIndex = 0;
			this.label3.Text = "Google";
			// 
			// btn_unity3dPath
			// 
			this.btn_unity3dPath.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_unity3dPath.Location = new System.Drawing.Point(470, 20);
			this.btn_unity3dPath.Name = "btn_unity3dPath";
			this.btn_unity3dPath.Size = new System.Drawing.Size(25, 23);
			this.btn_unity3dPath.TabIndex = 1;
			this.btn_unity3dPath.Text = "...";
			this.btn_unity3dPath.UseVisualStyleBackColor = true;
			this.btn_unity3dPath.Click += new System.EventHandler(this.btn_unity3dPath_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btn_ok.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_ok.Location = new System.Drawing.Point(438, 111);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(76, 35);
			this.btn_ok.TabIndex = 5;
			this.btn_ok.Text = "OK";
			this.btn_ok.UseVisualStyleBackColor = true;
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btn_cancel.Location = new System.Drawing.Point(438, 152);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(76, 34);
			this.btn_cancel.TabIndex = 6;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 50);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 12);
			this.label4.TabIndex = 0;
			this.label4.Text = "Naver";
			// 
			// txtbox_naverPrefix
			// 
			this.txtbox_naverPrefix.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.txtbox_naverPrefix.ForeColor = System.Drawing.SystemColors.Control;
			this.txtbox_naverPrefix.Location = new System.Drawing.Point(88, 47);
			this.txtbox_naverPrefix.Name = "txtbox_naverPrefix";
			this.txtbox_naverPrefix.Size = new System.Drawing.Size(326, 21);
			this.txtbox_naverPrefix.TabIndex = 4;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn_webBrowserPath);
			this.groupBox1.Controls.Add(this.btn_unity3dPath);
			this.groupBox1.Controls.Add(this.txtbox_unity3dPath);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtbox_webBrowserPath);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(501, 83);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Path Setting";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtbox_googlePrefix);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.txtbox_naverPrefix);
			this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
			this.groupBox2.Location = new System.Drawing.Point(12, 105);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(420, 81);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Prefix Setting";
			// 
			// OptionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(526, 199);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.ForeColor = System.Drawing.SystemColors.Control;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "OptionForm";
			this.Text = "Unity3d Document Option";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbox_unity3dPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbox_webBrowserPath;
        private System.Windows.Forms.Button btn_webBrowserPath;
        private System.Windows.Forms.TextBox txtbox_googlePrefix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_unity3dPath;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtbox_naverPrefix;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
    }
}