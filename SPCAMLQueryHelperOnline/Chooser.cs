using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Microsoft.SharePoint;
//using Microsoft.SharePoint.Utilities;
//using Microsoft.SharePoint.Administration;
using System.Configuration;

namespace SPCAMLQueryHelperOnline
{
    public partial class Chooser : Form
    {

        private Form1 form1;

        public enum AppMode
        {
            UseSOM = 0, // keep it for compat, but don't use it
            UseWSDef,
            UseWSCreds,
            UseWSOffice365
        }

        public AppMode appMode { get; set; }

        public string credUsername { get; set; }
        public string credPassword { get; set; }
        public string credDomain { get; set; }

        /// <summary>
        /// </summary>
        public Chooser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        private void Chooser_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            txtUsername.KeyPress += new KeyPressEventHandler(txtUsername_KeyPress);
            txtPassword.KeyPress += new KeyPressEventHandler(txtPassword_KeyPress);

            // set default
            appMode = AppMode.UseWSDef;

            // load session information
            var sessionObject = Form1.GetRecentSessionInfo();

            if (sessionObject != null)
            {
                credUsername = sessionObject.txtUsername;
                credPassword = sessionObject.txtPassword;
                credDomain = sessionObject.txtDomain;

                if (sessionObject.appMode == "0")
                    appMode = AppMode.UseWSDef;
                else if (sessionObject.appMode == "1")
                    appMode = AppMode.UseWSDef;
                else if (sessionObject.appMode == "2")
                    appMode = AppMode.UseWSCreds;
                else if (sessionObject.appMode == "3")
                    appMode = AppMode.UseWSOffice365;

            }

            rbUseSOM.Checked = false;
            rbUseWSImpers.Checked = false;
            rbUseWSCustCreds.Checked = false;
            rbUseWSOffice365.Checked = false;

            if (appMode == AppMode.UseSOM)
                rbUseWSCustCreds.Checked = true;
            else if (appMode == AppMode.UseWSCreds)
                rbUseWSCustCreds.Checked = true;
            else if (appMode == AppMode.UseWSDef)
                rbUseWSImpers.Checked = true;
            else if (appMode == AppMode.UseWSOffice365)
                rbUseWSOffice365.Checked = true;

            txtUsername.Text = credUsername;
            txtPassword.Text = credPassword;
            txtDomain.Text = credDomain;
        }

        /// <summary>
        /// </summary>
        void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Enter)
            {
                btnSubmit_Click(null, null);
            }
        }

        /// <summary>
        /// </summary>
        void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Enter)
            {
                btnSubmit_Click(null, null);
            }
        }

        /// <summary>
        /// </summary>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if ((rbUseWSCustCreds.Checked || rbUseWSOffice365.Checked) &&
                (GenUtil.IsNull(txtUsername.Text) || GenUtil.IsNull(txtPassword.Text)))
            {
                MessageBox.Show("Username and Password are required.", "ERROR");
                return;
            }

            if (rbUseSOM.Checked)
                appMode = AppMode.UseWSCreds;
            else if (rbUseWSCustCreds.Checked)
                appMode = AppMode.UseWSCreds;
            else if (rbUseWSImpers.Checked)
                appMode = AppMode.UseWSDef;
            else if (rbUseWSOffice365.Checked)
                appMode = AppMode.UseWSOffice365;

            credUsername = GenUtil.SafeTrim(txtUsername.Text);
            credPassword = GenUtil.SafeTrim(txtPassword.Text);
            credDomain = GenUtil.SafeTrim(txtDomain.Text);

            if (form1 == null)
            {
                form1 = new Form1();
                form1.StartPosition = FormStartPosition.CenterScreen;
                form1.formChooser = this;
            }

            form1.ShowHideListViews(rbUseSOM.Checked);

            this.Hide();
            form1.Show();
            form1.Activate();
        }

        /// <summary>
        /// </summary>
        private void rbUseSOM_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.BackColor = System.Drawing.SystemColors.ActiveBorder;
            txtUsername.ReadOnly = true;
            txtUsername.Enabled = false;

            txtPassword.BackColor = System.Drawing.SystemColors.ActiveBorder;
            txtPassword.ReadOnly = true;
            txtPassword.Enabled = false;

            txtDomain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            txtDomain.ReadOnly = true;
            txtDomain.Enabled = false;
        }

        /// <summary>
        /// </summary>
        private void rbUseWSImpers_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.BackColor = System.Drawing.SystemColors.ActiveBorder;
            txtUsername.ReadOnly = true;
            txtUsername.Enabled = false;

            txtPassword.BackColor = System.Drawing.SystemColors.ActiveBorder;
            txtPassword.ReadOnly = true;
            txtPassword.Enabled = false;

            txtDomain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            txtDomain.ReadOnly = true;
            txtDomain.Enabled = false;
        }

        /// <summary>
        /// </summary>
        private void rbUseWSCustCreds_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.BackColor = System.Drawing.SystemColors.Window;
            txtUsername.ReadOnly = false;
            txtUsername.Enabled = true;

            txtPassword.BackColor = System.Drawing.SystemColors.Window;
            txtPassword.ReadOnly = false;
            txtPassword.Enabled = true;

            txtDomain.BackColor = System.Drawing.SystemColors.Window;
            txtDomain.ReadOnly = false;
            txtDomain.Enabled = true;
        }

        private void rbUseWSOffice365_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.BackColor = System.Drawing.SystemColors.Window;
            txtUsername.ReadOnly = false;
            txtUsername.Enabled = true;

            txtPassword.BackColor = System.Drawing.SystemColors.Window;
            txtPassword.ReadOnly = false;
            txtPassword.Enabled = true;

            txtDomain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            txtDomain.ReadOnly = true;
            txtDomain.Enabled = false;
        }

    }

}
