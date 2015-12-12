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
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Threading;
using System.Configuration;

namespace SPCAMLQueryHelperOnline
{
    public partial class Form1 : Form
    {

        public TextBox _txtQuery
        {
            get
            {
                return txtQuery;
            }
        }

        public TextBox _txtViewFields
        {
            get
            {
                return txtViewFields;
            }
        }

        /// <summary>
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        protected override void OnClosing(CancelEventArgs e)
        {
            SaveCurrentSessionInfo();

            if (aboutBox1 != null)
                aboutBox1.Close();

            if (vdf != null)
                vdf.Close();

            if (ldf != null)
                ldf.Close();

            if (fdf != null)
                fdf.Close();

            base.OnClosing(e);

            formChooser.Close();
        }

        /// <summary>
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            picLogoWait.Visible = false;
            picLogoWait.Refresh();

            UseRecentSessionInfo();

            {
                // init ddls
                ddlCamlExamples.Items.Clear();

                foreach (object key in CamlExamples.GetCamlExamples(formChooser.appMode != Chooser.AppMode.UseSOM).Keys)
                {
                    ddlCamlExamples.Items.Add(key.ToString());
                }
            }

            {
                // init textboxes
                lblListName.Text = "";

                toolStripStatusLabel1.Text = "";

                txtSiteUrl.Text = GenUtil.IsNull(txtSiteUrl.Text) ? "http://localhost" : txtSiteUrl.Text;

                txtQuery.Text = GenUtil.IsNull(txtQuery.Text)
                                    ? CamlExamples.GetCamlExamples(formChooser.appMode != Chooser.AppMode.UseSOM)["Replace with: Simple Where 4"].ToString()
                                    : txtQuery.Text;

                txtViewFields.Text = GenUtil.IsNull(txtViewFields.Text)
                                         ? @"<FieldRef Name=""Title"" />"
                                         : txtViewFields.Text;

                txtViewAttributes.Text = GenUtil.IsNull(txtViewAttributes.Text)
                                             ? "Scope=\"Recursive\""
                                             : txtViewAttributes.Text;
            }

            {
                // init mouse hover tips
                tvLists.MouseHover += new EventHandler(tvLists_MouseHover);
                tvFields.MouseHover += new EventHandler(tvFields_MouseHover);
                btnExportCode.MouseHover += new EventHandler(btnExportXML_MouseHover);
                txtSiteUrl.MouseHover += new EventHandler(txtSiteUrl_MouseHover);
                txtQuery.MouseHover += new EventHandler(txtQuery_MouseHover);
                gvFields.MouseHover += new EventHandler(gvFields_MouseHover);
            }

            {
                lnkToggleFieldsName.Text = text_show_internalnames;
                tvLists.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(tvLists_NodeMouseDoubleClick);
                tvFields.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(tvFields_NodeMouseDoubleClick);
            }

            {
                txtSiteUrl.KeyPress += new KeyPressEventHandler(txtSiteUrl_KeyPress);
            }

            {
                // init drag drop events
                tvFields.ItemDrag += new ItemDragEventHandler(tvFields_ItemDrag);

                txtViewFields.AllowDrop = true;
                txtViewFields.DragEnter += new DragEventHandler(txtViewFields_DragEnter);
                txtViewFields.DragDrop += new DragEventHandler(txtViewFields_DragDrop);

                txtQuery.AllowDrop = true;
                txtQuery.DragEnter += new DragEventHandler(txtQuery_DragEnter);
                txtQuery.DragDrop += new DragEventHandler(txtQuery_DragDrop);
            }

            {
                gvFields.CellDoubleClick += new DataGridViewCellEventHandler(gvFields_CellDoubleClick);
            }

            {
                picLogoNormal.Click += new EventHandler(pictureBox1_Click);
            }

            btnOpenListDetails.Visible = false;

        }

        /// <summary>
        /// </summary>
        void gvFields_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Guid fieldId;

            try
            {
                fieldId = new Guid(gvFields.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: see status window below for details.", "ERROR");
                var msg = "Error retrieving field ID from gridview: " + ex.Message;
                GenUtil.LogIt(txtStatus, msg);
                return;
            }



            if (fdf != null)
            {
                fdf.Close();
            }

            fdf = new FieldDetailsForm();

            fdf.siteUrl = txtSiteUrl.Text.Trim(); // "http://localhost/"
            //fdf.webID = selListNode.Parent.Name; // "/"
            //fdf.webName = selListNode.Parent.Text; // "Root"
            fdf.listID = selListNode.Name; // "guid"
            fdf.listName = selListNode.Text; // "States"
            fdf.fieldId = fieldId;

            fdf.parentForm = this;

            fdf.Show();

        }

        /// <summary>
        /// </summary>
        void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.bandrsolutions.com/?utm_source=SPCAMLQueryHelper&utm_medium=application&utm_campaign=SPCAMLQueryHelper");
        }

        /// <summary>
        /// </summary>
        void txtSiteUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Enter)
            {
                btnLoad_Click(null, null);
            }
        }

        #region "Session Related"

        /// <summary>
        /// </summary>
        private void SaveCurrentSessionInfo()
        {
            if (GenUtil.SafeToBool(ConfigurationManager.AppSettings["disableSession"]))
                return;

            StreamWriter sw = null;

            try
            {
                string iniPath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(new char[] { '\\' }) + "\\" + "session.ini";
                sw = new StreamWriter(iniPath, false);

                var sso = new SessionObject();
                sso.txtQuery = GenUtil.NormalizeEol(txtQuery.Text);
                sso.txtRowLimit = GenUtil.SafeTrim(txtRowLimit.Text);
                sso.txtSiteUrl = GenUtil.SafeTrim(txtSiteUrl.Text);
                sso.txtViewAttributes = GenUtil.NormalizeEol(txtViewAttributes.Text);
                sso.txtViewFields = GenUtil.NormalizeEol(txtViewFields.Text);

                sso.txtUsername = formChooser.credUsername;
                sso.txtPassword = formChooser.credPassword;
                sso.txtDomain = formChooser.credDomain;

                sso.appMode = ((int)formChooser.appMode).ToString();

                var xml = XmlSerialization.Serialize(sso);

                sw.Write(xml);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sw != null) sw.Dispose();
            }
        }

        /// <summary>
        /// </summary>
        static public SessionObject GetRecentSessionInfo()
        {
            StreamReader sr = null;
            SessionObject sessionObject = new SessionObject();

            if (GenUtil.SafeToBool(ConfigurationManager.AppSettings["disableSession"]))
                return sessionObject;

            try
            {
                string iniPath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(new char[] { '\\' }) + "\\" + "session.ini";

                var fi = new FileInfo(iniPath);

                if (fi.Exists)
                {
                    sr = new StreamReader(iniPath);
                    var content = sr.ReadToEnd();
                    sessionObject = XmlSerialization.Deserialize<SessionObject>(content);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sr != null) sr.Dispose();
            }

            return sessionObject;
        }

        /// <summary>
        /// </summary>
        private void UseRecentSessionInfo()
        {
            var sessionObj = GetRecentSessionInfo();

            if (sessionObj != null)
            {
                txtQuery.Text = GenUtil.NormalizeEol(sessionObj.txtQuery);
                txtRowLimit.Text = sessionObj.txtRowLimit;
                txtSiteUrl.Text = sessionObj.txtSiteUrl;
                txtViewAttributes.Text = GenUtil.NormalizeEol(sessionObj.txtViewAttributes);
                txtViewFields.Text = GenUtil.NormalizeEol(sessionObj.txtViewFields);
            }
        }

        #endregion

        #region "DragDrop"

        /// <summary>
        /// </summary>
        void txtQuery_DragDrop(object sender, DragEventArgs e)
        {
            txtQuery.Text += Environment.NewLine + string.Format("<FieldRef Name=\"{0}\" />", e.Data.GetData(DataFormats.Text).ToString());
        }

        /// <summary>
        /// </summary>
        void txtQuery_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// </summary>
        void tvFields_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (tvFields.SelectedNode != null)
                tvFields.DoDragDrop(((TreeNode)e.Item).Name, DragDropEffects.Copy | DragDropEffects.Move);
        }

        /// <summary>
        /// </summary>
        void txtViewFields_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// </summary>
        void txtViewFields_DragDrop(object sender, DragEventArgs e)
        {
            txtViewFields.Text += Environment.NewLine + string.Format("<FieldRef Name=\"{0}\" />", e.Data.GetData(DataFormats.Text).ToString());
        }

        #endregion

        #region "ToolTips"

        void bgWorkerFlashToolTipColor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtHoverText.BackColor = Color.Azure;
        }

        void bgWorkerFlashToolTipColor_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
        }

        BackgroundWorker bgWorkerFlashToolTipColor;

        void FlashToolTipBox()
        {
            txtHoverText.BackColor = Color.LightBlue;
            bgWorkerFlashToolTipColor = new BackgroundWorker();
            bgWorkerFlashToolTipColor.DoWork += new DoWorkEventHandler(bgWorkerFlashToolTipColor_DoWork);
            bgWorkerFlashToolTipColor.RunWorkerAsync();
            bgWorkerFlashToolTipColor.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorkerFlashToolTipColor_RunWorkerCompleted);
        }

        /// <summary>
        /// </summary>
        void txtQuery_MouseHover(object sender, EventArgs e)
        {
            txtHoverText.Text = "The Query should be wrapped with \"<Query>\" element only when using Web Services, never when using SOM.";
            FlashToolTipBox();
        }

        /// <summary>
        /// </summary>
        void txtSiteUrl_MouseHover(object sender, EventArgs e)
        {
            txtHoverText.Text = "Enter site url (without list and page names, ex. http://localhost, http://localhost/sites/intranet).";
            FlashToolTipBox();
        }

        /// <summary>
        /// </summary>
        void tvLists_MouseHover(object sender, EventArgs e)
        {
            txtHoverText.Text = "Double click the list to load its fields and to select it for querying.";
            FlashToolTipBox();
        }

        /// <summary>
        /// </summary>
        void btnExportXML_MouseHover(object sender, EventArgs e)
        {
            txtHoverText.Text = "Export the current Query and View Fields XML to C# code in string format.";
            FlashToolTipBox();
        }

        /// <summary>
        /// </summary>
        void tvFields_MouseHover(object sender, EventArgs e)
        {
            txtHoverText.Text = "Double click the field to copy the internalname to the clipboard, or Drag the node to the textbox.";
            FlashToolTipBox();
        }

        /// <summary>
        /// </summary>
        void gvFields_MouseHover(object sender, EventArgs e)
        {
            txtHoverText.Text = "Double click the field in the grid to load detailed SPField information.";
            FlashToolTipBox();
        }

        string oldStatusText = "";

        #endregion

        /// <summary>
        /// Load spsite, fill tree with all spwebs in spsite, and all splists in each spweb.
        /// </summary>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;

            toolStripStatusLabel1.Text = "Running...";
            statusStrip1.Refresh();

            picLogoWait.Visible = true;
            picLogoWait.Refresh();



            if (formChooser.appMode != Chooser.AppMode.UseSOM)
            {
                var loader = new WebServiceWork.LoadSitesAndLists()
                {
                    parentForm = this,
                    url = txtSiteUrl.Text,
                    tvLists = tvLists,
                    btnLoad = btnLoad,
                    toolStripStatusLabel1 = toolStripStatusLabel1,
                    statusStrip1 = statusStrip1,
                    picLogoWait = picLogoWait,
                    txtStatus = txtStatus,
                    selWebId = selWebId,
                    selWebTitle = selWebTitle
                };

                loader.DoWork();

                return;
            }

        }

        public string selWebTitle { get; set; }
        public Guid selWebId { get; set; }

        public TreeNode selListNode = null;

        public string text_show_titles = "Sort by Titles";
        public string text_show_internalnames = "Sort by InternalNames";

        /// <summary>
        /// Load Selected List (SPFields and List Summary Info)
        /// </summary>
        void tvLists_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode clickedNode = null;

            if (e == null)
                clickedNode = selListNode;
            else
                clickedNode = e.Node;

            if (clickedNode == null)
                return;

            selListNode = clickedNode;


            string listID = clickedNode.Name;
            string listTitle = clickedNode.Text;

            //string webID = clickedNode.Parent.Name;
            //string webName = clickedNode.Parent.Text;

            lblListName.Text = string.Format("{0}", listTitle);

            txtListID.Text = listID;
            txtListName.Text = listTitle;


            toolStripStatusLabel1.Text = "Running...";
            statusStrip1.Refresh();

            picLogoWait.Visible = true;
            picLogoWait.Refresh();
            


            if (formChooser.appMode != Chooser.AppMode.UseSOM)
            {
                WebServiceWork.ListDetailLoader loader = new WebServiceWork.ListDetailLoader()
                {
                    url = txtSiteUrl.Text,
                    //siteName = selWebTitle,
                    listName = listTitle,
                    ddlListViews = ddlListViews,
                    tvFields = tvFields,
                    lnkToggleFieldsName = lnkToggleFieldsName,
                    text_show_internalnames = text_show_internalnames,
                    gvFields = gvFields,
                    parentForm = this,
                    toolStripStatusLabel1 = toolStripStatusLabel1,
                    statusStrip1 = statusStrip1,
                    picLogoWait = picLogoWait,
                    txtStatus = txtStatus, 
                    btnOpenListDetails = btnOpenListDetails
                };

                loader.DoWork();

                return;
            }

        }

        /// <summary>
        /// Copy spfield internalname from treeview node to clipboard.
        /// </summary>
        void tvFields_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Clipboard.SetText(string.Format("<FieldRef Name=\"{0}\" />", e.Node.Name));
        }

        /// <summary>
        /// Execute Search
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (selListNode == null)
                return;


            string listID = selListNode.Name;
            string listTitle = selListNode.Text;

            //string webID = selListNode.Parent.Name;
            //string webName = selListNode.Parent.Text;


            btnSearch.Enabled = false;

            toolStripStatusLabel1.Text = "Running...";
            statusStrip1.Refresh();

            picLogoWait.Visible = true;
            picLogoWait.Refresh();
            


            if (formChooser.appMode != Chooser.AppMode.UseSOM)
            {
                WebServiceWork.ExecuteQuery loader = new WebServiceWork.ExecuteQuery()
                {
                    siteUrl = txtSiteUrl.Text.Trim(),
                    //webName = webName,
                    listName = listTitle,
                    parentForm = this,

                    txtQuery = txtQuery,
                    txtViewAttributes = txtViewAttributes,
                    txtViewFields = txtViewFields,
                    txtRowLimit = txtRowLimit,
                    gvResults = gvResults,
                    tabControl1 = tabControl1,

                    toolStripStatusLabel1 = toolStripStatusLabel1,
                    statusStrip1 = statusStrip1,
                    picLogoWait = picLogoWait,
                    txtStatus = txtStatus,
                    btnSearch = btnSearch
                };

                loader.DoWork();

                return;
            }

        }

        /// <summary>
        /// </summary>
        private void lnkToggleFieldsName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (selListNode == null)
                return;

            if (lnkToggleFieldsName.Text == text_show_internalnames)
                lnkToggleFieldsName.Text = text_show_titles;
            else
                lnkToggleFieldsName.Text = text_show_internalnames;

            tvLists_NodeMouseDoubleClick(null, null);
        }

        #region "Exporting"

        /// <summary>
        /// </summary>
        private void ExportGrid(DataGridView gv, string type)
        {
            var saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            saveFileDialog1.Filter = "Csv file (*.csv)|*.csv|All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.FileName = "export.csv";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                toolStripStatusLabel1.Text = "Running...";
                statusStrip1.Refresh();

                picLogoWait.Visible = true;
                picLogoWait.Refresh();


                System.IO.StreamWriter streamWriter = null;

                try
                {
                    streamWriter = new System.IO.StreamWriter(saveFileDialog1.FileName);

                    string strHeader = "";

                    for (int i = 0; i < gv.Columns.Count; i++)
                    {
                        string curval = GenUtil.SafeTrim(gv.Columns[i].HeaderText);

                        if (curval.Contains(",") && !curval.StartsWith("\""))
                            strHeader += "\"" + curval + "\"" + ",";
                        else
                            strHeader += curval + ",";
                    }

                    streamWriter.WriteLine(strHeader);


                    for (int m = 0; m < gv.Rows.Count; m++)
                    {
                        string strRowValue = "";

                        for (int n = 0; n < gv.Columns.Count; n++)
                        {
                            string curval = GenUtil.SafeTrim(gv.Rows[m].Cells[n].Value);

                            if (curval.Contains(",") && !curval.StartsWith("\""))
                                strRowValue += "\"" + curval.Replace("\"", "'") + "\"" + ",";
                            else
                                strRowValue += curval.Replace("\"", "'") + ",";
                        }

                        streamWriter.WriteLine(strRowValue);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: see status window below for details.", "ERROR");
                    GenUtil.LogIt(txtStatus, string.Format("ERROR: cannot export to CSV: {0}", ex.ToString()));
                }
                finally
                {
                    if (streamWriter != null)
                        streamWriter.Close();
                }

                toolStripStatusLabel1.Text = oldStatusText;
                statusStrip1.Refresh();
                picLogoWait.Visible = false;
                picLogoWait.Refresh();

            } 

        }

        /// <summary>
        /// </summary>
        private void btnExportFieldInfo_Click(object sender, EventArgs e)
        {
            ExportGrid(gvFields, "fields");
        }

        /// <summary>
        /// </summary>
        private void btnExportResults_Click(object sender, EventArgs e)
        {
            ExportGrid(gvResults, "results");
        }

        /// <summary>
        /// </summary>
        private void btnExportCode_Click(object sender, EventArgs e)
        {
            string q = GenUtil.SafeTrim(txtQuery.Text);
            q = q.Replace("\"", "\"\"");
            q = Regex.Replace(q, "( ){2,}", " ");
            q = GenUtil.RemoveWhiteSpace(q);
            q = Regex.Replace(q, "> <", "><");
            if (formChooser.appMode != Chooser.AppMode.UseSOM)
            {
                q = GenUtil.WrapWSQuery(q);
            }

            string v = GenUtil.SafeTrim(txtViewFields.Text);
            v = v.Replace("\"", "\"\"");
            v = Regex.Replace(v, "( ){2,}", " ");
            v = GenUtil.RemoveWhiteSpace(v);
            v = Regex.Replace(v, "> <", "><");

            string va = GenUtil.SafeTrim(txtViewAttributes.Text);
            va = va.Replace("\"", "\"\"");
            va = Regex.Replace(va, "( ){2,}", " ");
            va = GenUtil.RemoveWhiteSpace(va);
            va = Regex.Replace(va, "> <", "><");

            string rl = GenUtil.SafeToNum(txtRowLimit.Text).ToString();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("string sQuery = @\"{0}\";", q));
            sb.AppendLine(string.Format("string sViewFields = @\"{0}\";", v));
            sb.AppendLine(string.Format("string sViewAttrs = @\"{0}\";", va));
            sb.AppendLine(string.Format("uint iRowLimit = {0};", rl));
            sb.AppendLine();

            sb.AppendLine("var oQuery = new SPQuery();");
            sb.AppendLine("oQuery.Query = sQuery;");
            sb.AppendLine("oQuery.ViewFields = sViewFields;");
            sb.AppendLine("oQuery.ViewAttributes = sViewAttrs;");
            sb.AppendLine("oQuery.RowLimit = iRowLimit;");
            sb.AppendLine();
            sb.AppendLine("SPListItemCollection collListItems = oList.GetItems(oQuery);");
            sb.AppendLine();
            sb.AppendLine("foreach (SPListItem oListItem in collListItems)");
            sb.AppendLine("{");
            sb.AppendLine("}");

            Clipboard.SetText(sb.ToString());

            MessageBox.Show("Generated C# Code Copied to Clipboard.");
        }

        #endregion

        #region "Other Forms"

        /// <summary>
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aboutBox1 != null)
                aboutBox1.Close();

            aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }

        private AboutBox1 aboutBox1 = null;

        private ViewDetailsForm vdf = null;
        private ListDetailsForm ldf = null;
        private FieldDetailsForm fdf = null;

        /// <summary>
        /// </summary>
        private void lnkbtnOpenListViews_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (selListNode == null)
                return;

            if (vdf != null)
                vdf.Close();

            vdf = new ViewDetailsForm();

            vdf.siteUrl = txtSiteUrl.Text.Trim(); // "http://localhost/"
            //vdf.webID = selListNode.Parent.Name; // "/"
            //vdf.webName = selListNode.Parent.Text; // "Root"
            vdf.listID = selListNode.Name; // "guid"
            vdf.listName = selListNode.Text; // "States"
            //vdf.Text = "Views for List: " + selListNode.Text;

            vdf.parentForm = this;

            vdf.Show();
        }

        /// <summary>
        /// </summary>
        private void btnOpenListDetails_Click(object sender, EventArgs e)
        {
            if (ldf != null)
            {
                ldf.Close();
            }

            ldf = new ListDetailsForm();

            ldf.siteUrl = txtSiteUrl.Text.Trim(); // "http://localhost/"
            //ldf.webID = selListNode.Parent.Name; // "/"
            //ldf.webName = selListNode.Parent.Text; // "Root"
            ldf.listID = selListNode.Name; // "guid"
            ldf.listName = selListNode.Text; // "States"

            ldf.parentForm = this;

            ldf.Show();
        }

        #endregion

        /// <summary>
        /// </summary>
        private void lnkbtnAddCamlExample_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ddlCamlExamples.SelectedItem == null || GenUtil.IsNull(ddlCamlExamples.SelectedItem))
                return;

            txtQuery.Text = CamlExamples.GetCamlExamples(formChooser.appMode != Chooser.AppMode.UseSOM)[ddlCamlExamples.SelectedItem.ToString()].ToString();
            txtQuery.Refresh();
        }

        #region FormChooser

        /// <summary>
        /// </summary>
        public void ShowHideListViews(bool show)
        {
            ddlListViews.Visible = show;
            label11.Visible = show;
        }

        /// <summary>
        /// </summary>
        private void CreateFormChooser()
        {
            formChooser.StartPosition = FormStartPosition.Manual;
            formChooser.Location = new Point(this.Location.X + 300, this.Location.Y + 260);

            formChooser.Show();
            formChooser.Activate();
        }

        /// <summary>
        /// </summary>
        private void changeAppModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormChooser();
        }

        public Chooser formChooser;

        #endregion
      
    }
}
