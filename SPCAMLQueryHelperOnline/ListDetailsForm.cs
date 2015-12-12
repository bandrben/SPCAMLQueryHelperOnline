using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPCAMLQueryHelperOnline
{
    public partial class ListDetailsForm : Form
    {

        public string siteUrl { get; set; }
        //public string webID { get; set; }
        //public string webName { get; set; }
        public string listID { get; set; }
        public string listName { get; set; }

        public Form1 parentForm { get; set; }

        /// <summary>
        /// </summary>
        public ListDetailsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        private void ListDetailsForm_Load(object sender, EventArgs e)
        {
            tbListInfo.Text = "";

            if (parentForm.formChooser.appMode != Chooser.AppMode.UseSOM)
            {
                var loader = new WebServiceWork.LoadListInfo()
                {
                    siteUrl = siteUrl,
                    //webName = webName,
                    listName = listName,
                    tbListInfo = tbListInfo,
                    parentForm = parentForm
                };

                loader.DoWork();

                return;
            }

        }

    }
}
