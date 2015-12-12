using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Microsoft.SharePoint;
//using Microsoft.SharePoint.Utilities;
//using Microsoft.SharePoint.Administration;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace SPCAMLQueryHelperOnline
{
    public partial class ViewDetailsForm : Form
    {

        public string siteUrl { get; set; }
        //public string webID { get; set; }
        //public string webName { get; set; }
        public string listID { get; set; }
        public string listName { get; set; }


        public Form1 parentForm { get; set; }


        public ViewDetailsForm()
        {
            InitializeComponent();
        }


        private Hashtable htViews = new Hashtable();


        /// <summary>
        /// Form Load
        /// </summary>
        private void ViewDetailsForm_Load(object sender, EventArgs e)
        {
            lstViews.DoubleClick += new EventHandler(lstViews_DoubleClick);

            txtViewSchema.Text = "Double Click a view above to load its schema.";


            if (parentForm.formChooser.appMode != Chooser.AppMode.UseSOM)
            {
                var loader = new WebServiceWork.LoadListViews()
                {
                    siteUrl = siteUrl,
                    //webName = webName,
                    listName = listName,
                    lstViews = lstViews,
                    htViews = htViews,
                    parentForm = parentForm
                };

                loader.DoWork();

                return;
            }

        }
               

        /// <summary>
        /// View selected
        /// </summary>
        void lstViews_DoubleClick(object sender, EventArgs e)
        {
            LoadView();
        }


        /// <summary>
        /// Load selected view
        /// </summary>
        private void LoadView()
        {
            if (lstViews.SelectedItem == null)
                return;


            if (parentForm.formChooser.appMode != Chooser.AppMode.UseSOM)
            {
                WebServiceWork.ListViewDetailLoader loader = new WebServiceWork.ListViewDetailLoader()
                {
                    siteUrl = siteUrl,
                    //webName = webName,
                    listName = listName,
                    cXmlView = (CustXMLView)htViews[lstViews.SelectedItem.ToString()],
                    txtViewSchema = txtViewSchema,
                    parentForm = parentForm
                };

                loader.DoWork();

                return;
            }
            
        }

    }

}
