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
    public partial class FieldDetailsForm : Form
    {

        public string siteUrl { get; set; }
        //public string webID { get; set; }
        //public string webName { get; set; }
        public string listID { get; set; }
        public string listName { get; set; }
        public Guid fieldId { get; set; }

        public Form1 parentForm { get; set; }

        /// <summary>
        /// </summary>
        public FieldDetailsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        private void FieldDetailsForm_Load(object sender, EventArgs e)
        {
            tbFieldInfo.Text = "";

            if (parentForm.formChooser.appMode != Chooser.AppMode.UseSOM)
            {
                var loader = new WebServiceWork.LoadListFieldInfo()
                {
                    siteUrl = siteUrl,
                    //siteName = webName,
                    listName = listName,
                    fieldId = fieldId,
                    tbFieldInfo = tbFieldInfo,
                    parentForm = parentForm
                };

                loader.DoWork();

                return;
            }

        }

    }

}
