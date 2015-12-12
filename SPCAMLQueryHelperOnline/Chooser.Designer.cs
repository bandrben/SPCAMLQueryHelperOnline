namespace SPCAMLQueryHelperOnline
{
    partial class Chooser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chooser));
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.rbUseSOM = new System.Windows.Forms.RadioButton();
            this.rbUseWSImpers = new System.Windows.Forms.RadioButton();
            this.rbUseWSCustCreds = new System.Windows.Forms.RadioButton();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.lblDomain = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.rbUseWSOffice365 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(148, 334);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 23);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(61, 261);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username:";
            // 
            // rbUseSOM
            // 
            this.rbUseSOM.AutoSize = true;
            this.rbUseSOM.Location = new System.Drawing.Point(72, 143);
            this.rbUseSOM.Name = "rbUseSOM";
            this.rbUseSOM.Size = new System.Drawing.Size(165, 17);
            this.rbUseSOM.TabIndex = 0;
            this.rbUseSOM.Text = "Use SharePoint Object Model";
            this.rbUseSOM.UseVisualStyleBackColor = true;
            this.rbUseSOM.Visible = false;
            this.rbUseSOM.CheckedChanged += new System.EventHandler(this.rbUseSOM_CheckedChanged);
            // 
            // rbUseWSImpers
            // 
            this.rbUseWSImpers.AutoSize = true;
            this.rbUseWSImpers.Checked = true;
            this.rbUseWSImpers.Location = new System.Drawing.Point(72, 166);
            this.rbUseWSImpers.Name = "rbUseWSImpers";
            this.rbUseWSImpers.Size = new System.Drawing.Size(243, 17);
            this.rbUseWSImpers.TabIndex = 1;
            this.rbUseWSImpers.TabStop = true;
            this.rbUseWSImpers.Text = "Use Web Services (Impersonate Current User)";
            this.rbUseWSImpers.UseVisualStyleBackColor = true;
            this.rbUseWSImpers.CheckedChanged += new System.EventHandler(this.rbUseWSImpers_CheckedChanged);
            // 
            // rbUseWSCustCreds
            // 
            this.rbUseWSCustCreds.AutoSize = true;
            this.rbUseWSCustCreds.Location = new System.Drawing.Point(72, 189);
            this.rbUseWSCustCreds.Name = "rbUseWSCustCreds";
            this.rbUseWSCustCreds.Size = new System.Drawing.Size(232, 17);
            this.rbUseWSCustCreds.TabIndex = 2;
            this.rbUseWSCustCreds.Text = "Use Web Services (Use Permissions Below)";
            this.rbUseWSCustCreds.UseVisualStyleBackColor = true;
            this.rbUseWSCustCreds.CheckedChanged += new System.EventHandler(this.rbUseWSCustCreds_CheckedChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtUsername.Location = new System.Drawing.Point(125, 256);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(191, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtPassword.Location = new System.Drawing.Point(125, 282);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(191, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(61, 287);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password:";
            // 
            // txtDomain
            // 
            this.txtDomain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtDomain.Location = new System.Drawing.Point(125, 308);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(191, 20);
            this.txtDomain.TabIndex = 5;
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Location = new System.Drawing.Point(61, 313);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(46, 13);
            this.lblDomain.TabIndex = 9;
            this.lblDomain.Text = "Domain:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(384, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 94);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(384, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // rbUseWSOffice365
            // 
            this.rbUseWSOffice365.AutoSize = true;
            this.rbUseWSOffice365.Location = new System.Drawing.Point(72, 212);
            this.rbUseWSOffice365.Name = "rbUseWSOffice365";
            this.rbUseWSOffice365.Size = new System.Drawing.Size(172, 17);
            this.rbUseWSOffice365.TabIndex = 14;
            this.rbUseWSOffice365.Text = "Use Web Services (Office 365)";
            this.rbUseWSOffice365.UseVisualStyleBackColor = true;
            this.rbUseWSOffice365.CheckedChanged += new System.EventHandler(this.rbUseWSOffice365_CheckedChanged);
            // 
            // Chooser
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(384, 378);
            this.ControlBox = false;
            this.Controls.Add(this.rbUseWSOffice365);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.lblDomain);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.rbUseWSCustCreds);
            this.Controls.Add(this.rbUseWSImpers);
            this.Controls.Add(this.rbUseSOM);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnSubmit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Chooser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SP CAML Query Helper Online";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Chooser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.RadioButton rbUseSOM;
        private System.Windows.Forms.RadioButton rbUseWSImpers;
        private System.Windows.Forms.RadioButton rbUseWSCustCreds;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RadioButton rbUseWSOffice365;
    }
}