using Microsoft.SharePoint.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SPCAMLQueryHelperOnline.WebServiceWork
{

    public class SharedStuff
    {

        public static CookieContainer GetAuthCookies(Uri webUri, string userName, string password)
        {
            var securePassword = new SecureString();
            foreach (var c in password) { securePassword.AppendChar(c); }
            var credentials = new SharePointOnlineCredentials(userName, securePassword);
            var authCookie = credentials.GetAuthenticationCookie(webUri);
            var cookieContainer = new CookieContainer();
            cookieContainer.SetCookies(webUri, authCookie);
            return cookieContainer;
        }

    }

    /// <summary>
    /// </summary>
    public class ExecuteQuery
    {

        public string siteUrl { get; set; }
        //public string webName { get; set; }
        public string listName { get; set; }

        public Form1 parentForm { get; set; }

        public TextBox txtQuery { get; set; }
        public TextBox txtViewAttributes { get; set; }
        public TextBox txtViewFields { get; set; }
        public TextBox txtRowLimit { get; set; }
        public DataGridView gvResults { get; set; }
        public TabControl tabControl1 { get; set; }

        public ToolStripStatusLabel toolStripStatusLabel1 { get; set; }
        public StatusStrip statusStrip1 { get; set; }
        public PictureBox picLogoWait { get; set; }
        public TextBox txtStatus { get; set; }
        public Button btnSearch { get; set; }

        /// <summary>
        /// </summary>
        public void DoWork()
        {
            Thread th = new Thread(new ThreadStart(this.Worker));
            th.Start();
        }

        /// <summary>
        /// </summary>
        private void Worker()
        {
            Exception retErr = null;
            DataTable dt = null;

            try
            {
                SPWSLists.Lists proxy = new SPCAMLQueryHelperOnline.SPWSLists.Lists();

                if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSDef)
                {
                    proxy.UseDefaultCredentials = true;
                }
                else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSCreds)
                {
                    proxy.UseDefaultCredentials = false;
                    proxy.Credentials = new System.Net.NetworkCredential(parentForm.formChooser.credUsername, parentForm.formChooser.credPassword, parentForm.formChooser.credDomain);
                }
                else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSOffice365)
                {
                    proxy.CookieContainer = SharedStuff.GetAuthCookies(new Uri(siteUrl), parentForm.formChooser.credUsername, parentForm.formChooser.credPassword);
                }

                proxy.Url = GenUtil.CombineUrls(siteUrl, XMLConsts.AsmxSuffix_Lists);

                var strQuery = GenUtil.RemoveWhiteSpace(txtQuery.Text);
                strQuery = GenUtil.WrapWSQuery(strQuery);

                //
                StringReader rdrQuery = new StringReader(strQuery);
                XElement xQuery = XElement.Load(rdrQuery);

                //
                string rowLimit = (GenUtil.SafeToNum(txtRowLimit.Text) == 0 ? "" : GenUtil.SafeToNum(txtRowLimit.Text).ToString());

                //
                string webID = "";

                //
                StringReader rdrQueryOptions = null;
                if (GenUtil.IsNull(txtViewAttributes.Text))
                    rdrQueryOptions = new StringReader("<QueryOptions><IncludeMandatoryColumns>FALSE</IncludeMandatoryColumns></QueryOptions>");
                else
                    rdrQueryOptions = new StringReader(string.Format("<QueryOptions><IncludeMandatoryColumns>FALSE</IncludeMandatoryColumns><ViewAttributes {0} /></QueryOptions>", 
                        GenUtil.RemoveWhiteSpace(txtViewAttributes.Text.Trim())));
                XElement xQueryOptions = XElement.Load(rdrQueryOptions);

                //
                XElement xViewFields = null;
                if (GenUtil.IsNull(txtViewFields.Text))
                    xViewFields = new XElement("ViewFields");
                else
                {
                    StringReader rdrViewFields = new StringReader(string.Format("<ViewFields>{0}</ViewFields>",
                        GenUtil.RemoveWhiteSpace(txtViewFields.Text.Trim())));
                    xViewFields = XElement.Load(rdrViewFields);
                }

                //
                string viewName = "";

                //
                XElement results = proxy.GetListItems(
                    listName,
                    viewName,
                    xQuery.GetXmlNode(),
                    xViewFields.GetXmlNode(),
                    rowLimit,
                    xQueryOptions.GetXmlNode(),
                    webID).GetXElement();


                //
                dt = new DataTable();

                foreach (XElement xRow in results.Descendants(XMLConsts.z + "row"))
                {
                    foreach (XAttribute xAttr in xRow.Attributes())
                    {
                        string colName = xAttr.Name.ToString();

                        if (!dt.Columns.Contains(xAttr.Name.ToString()))
                            dt.Columns.Add(xAttr.Name.ToString(), typeof(string));
                    }
                }

                foreach (XElement xRow in results.Descendants(XMLConsts.z + "row"))
                {
                    DataRow dr = dt.NewRow();

                    foreach (XAttribute xAttr in xRow.Attributes())
                    {
                        string colName = xAttr.Name.ToString();
                        string colVal = xAttr.Value;

                        dr[colName] = colVal;
                    }

                    dt.Rows.Add(dr);
                }


            }
            catch (Exception ex)
            {
                retErr = ex;
            }




            // update gui
            parentForm.Invoke(new MethodInvoker(() =>
            {


                if (retErr != null)
                {
                    GenUtil.LogIt(txtStatus, retErr.ToString());
                }
                else
                {
                    GenUtil.LogIt(txtStatus, string.Format("Found {0} Record(s).", dt.Rows.Count));
                    
                    gvResults.DataSource = dt;

                    if (dt.Rows.Count > 0)
                        tabControl1.SelectTab(2);
                }


                // finish action
                btnSearch.Enabled = true;
                toolStripStatusLabel1.Text = "";
                statusStrip1.Refresh();
                picLogoWait.Visible = false;
                picLogoWait.Refresh();

            }));

        }

    }

    /// <summary>
    /// </summary>
    public class ListViewDetailLoader
    {

        public string siteUrl { get; set; }
        //public string webName { get; set; }
        public string listName { get; set; }

        public CustXMLView cXmlView { get; set; }

        public TextBox txtViewSchema { get; set; }

        public Form1 parentForm { get; set; }


        /// <summary>
        /// </summary>
        public void DoWork()
        {
            Thread th = new Thread(new ThreadStart(this.Worker));
            th.Start();
        }


        /// <summary>
        /// </summary>
        private void Worker()
        {
            // configure view web service
            string xmlView = null;
            Exception retErr = null;

            try
            {
                SPWSViews.Views proxy = new SPCAMLQueryHelperOnline.SPWSViews.Views();

                if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSDef)
                {
                    proxy.UseDefaultCredentials = true;
                }
                else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSCreds)
                {
                    proxy.UseDefaultCredentials = false;
                    proxy.Credentials = new System.Net.NetworkCredential(parentForm.formChooser.credUsername, parentForm.formChooser.credPassword, parentForm.formChooser.credDomain);
                }
                else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSOffice365)
                {
                    proxy.CookieContainer = SharedStuff.GetAuthCookies(new Uri(siteUrl), parentForm.formChooser.credUsername, parentForm.formChooser.credPassword);
                }

                proxy.Url = GenUtil.CombineUrls(siteUrl, XMLConsts.AsmxSuffix_Views);

                XElement xView = proxy.GetView(listName, cXmlView.Name).GetXElement();

                xmlView = xView.ToStringAlignAttributes();

            }
            catch (Exception ex)
            {
                retErr = ex;
            }



            // update gui
            parentForm.Invoke(new MethodInvoker(() =>
            {
                txtViewSchema.Text = "";

                if (retErr != null)
                {
                    txtViewSchema.Text = "ERROR: " + retErr.ToString();
                }
                else
                {
                    txtViewSchema.Text = xmlView;
                }

            }));

        }

    }

    /// <summary>
    /// </summary>
    public class LoadListViews
    {

        public string siteUrl { get; set; }
        //public string webName { get; set; }
        public string listName { get; set; }

        public ListBox lstViews { get; set; }
        public Hashtable htViews { get; set; }

        public Form1 parentForm { get; set; }


        /// <summary>
        /// </summary>
        public void DoWork()
        {
            Thread th = new Thread(new ThreadStart(this.Worker));
            th.Start();
        }


        /// <summary>
        /// </summary>
        private void Worker()
        {
            // configure view web service
            List<CustXMLView> lstCustXmlViews = new List<CustXMLView>();
            Exception retErr = null;

            try
            {
                SPWSViews.Views proxy = new SPCAMLQueryHelperOnline.SPWSViews.Views();

                if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSDef)
                {
                    proxy.UseDefaultCredentials = true;
                }
                else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSCreds)
                {
                    proxy.UseDefaultCredentials = false;
                    proxy.Credentials = new System.Net.NetworkCredential(parentForm.formChooser.credUsername, parentForm.formChooser.credPassword, parentForm.formChooser.credDomain);
                }
                else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSOffice365)
                {
                    proxy.CookieContainer = SharedStuff.GetAuthCookies(new Uri(siteUrl), parentForm.formChooser.credUsername, parentForm.formChooser.credPassword);
                }

                proxy.Url = GenUtil.CombineUrls(siteUrl, XMLConsts.AsmxSuffix_Views);

                XElement xViews = proxy.GetViewCollection(listName).GetXElement();

                foreach (XElement xView in xViews.Elements(XMLConsts.s + "View"))
                {
                    lstCustXmlViews.Add(new CustXMLView()
                    {
                        DefaultView = GenUtil.SafeToBool(GenUtil.GetXElemAttrAsString(xView, "DefaultView")),
                        DisplayName = GenUtil.GetXElemAttrAsString(xView, "DisplayName"),
                        Name = GenUtil.GetXElemAttrAsString(xView, "Name"),
                        Url = GenUtil.GetXElemAttrAsString(xView, "Url")
                    });
                }

            }
            catch (Exception ex)
            {
                retErr = ex;
            }



            // update gui
            parentForm.Invoke(new MethodInvoker(() =>
            {

                lstViews.Items.Clear();
                htViews.Clear();

                if (retErr != null)
                {
                }
                else
                {
                    foreach (CustXMLView cXmlView in lstCustXmlViews)
                    {
                        htViews.Add(cXmlView.DisplayName, cXmlView);
                        lstViews.Items.Add(cXmlView.DisplayName);
                    }
                }

            }));

        }

    }

    /// <summary>
    /// </summary>
    public class LoadListInfo
    {
        public string siteUrl { get; set; }
        //public string webName { get; set; }
        public string listName { get; set; }
        public TextBox tbListInfo { get; set; }
        public Form1 parentForm { get; set; }

        /// <summary>
        /// </summary>
        public void DoWork()
        {
            Thread th = new Thread(new ThreadStart(this.Worker));
            th.Start();
        }

        /// <summary>
        /// </summary>
        private void Worker()
        {
            // configure list web service
            Exception retErr = null;

            var dictAttrs = new Dictionary<string, string>();
            var lstContentTypes = new List<string>();

            try
            {
                var proxy = new SPCAMLQueryHelperOnline.SPWSLists.Lists();

                if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSDef)
                {
                    proxy.UseDefaultCredentials = true;
                }
                else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSCreds)
                {
                    proxy.UseDefaultCredentials = false;
                    proxy.Credentials = new System.Net.NetworkCredential(parentForm.formChooser.credUsername, parentForm.formChooser.credPassword, parentForm.formChooser.credDomain);
                }
                else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSOffice365)
                {
                    proxy.CookieContainer = SharedStuff.GetAuthCookies(new Uri(siteUrl), parentForm.formChooser.credUsername, parentForm.formChooser.credPassword);
                }

                proxy.Url = GenUtil.CombineUrls(siteUrl, XMLConsts.AsmxSuffix_Lists);

                XElement xList = proxy.GetList(listName).GetXElement();

                foreach (XAttribute att in xList.Attributes())
                {
                    if (!dictAttrs.ContainsKey(att.Name.LocalName))
                    {
                        dictAttrs.Add(att.Name.LocalName, GenUtil.SafeTrim(att.Value));
                    }
                }

                XElement xContType = proxy.GetListContentTypes(listName, "0x").GetXElement();

                foreach(var el in xContType.Elements(XMLConsts.s + "ContentType"))
                {
                    var lstAttrs = new List<string>();

                    foreach (var attr in el.Attributes())
                    {
                        lstAttrs.Add(string.Concat(attr.Name, "=", attr.Value));
                    }

                    lstContentTypes.Add(string.Join("; ", lstAttrs.ToArray()));
                }

            }
            catch (Exception ex)
            {
                retErr = ex;
            }

            // update gui
            parentForm.Invoke(new MethodInvoker(() =>
            {
                if (retErr != null)
                {
                    WriteToTb("ERROR", retErr.ToString());
                }
                else
                {
                    var keys = dictAttrs.Keys.OrderBy(x => x.Trim().ToLower());
                    foreach (string key in keys)
                    {
                        WriteToTb(key, dictAttrs[key]);
                    }

                    WriteToTb();
                    WriteToTb("CONTENTTYPES", "");
                    foreach (string contentType in lstContentTypes)
                    {
                        WriteToTb("-ContentType", contentType);
                    }

                }
            }));

        }

        void WriteToTb()
        {
            tbListInfo.Text += Environment.NewLine;
        }

        void WriteToTb(string s1, object o1)
        {
            tbListInfo.Text += string.Format("{0}: {1}{2}", GenUtil.SafeTrim(s1), GenUtil.SafeTrim(o1), Environment.NewLine);
        }

    }

    /// <summary>
    /// </summary>
    public class LoadListFieldInfo
    {
        public string siteUrl { get; set; }
        //public string siteName { get; set; }
        public string listName { get; set; }
        public TextBox tbFieldInfo { get; set; }
        public string fieldName { get; set; }
        public string fieldInternalName { get; set; }
        public Guid fieldId { get; set; }

        public Form1 parentForm { get; set; }

        /// <summary>
        /// </summary>
        public void DoWork()
        {
            Thread th = new Thread(new ThreadStart(this.Worker));
            th.Start();
        }

        /// <summary>
        /// </summary>
        private void Worker()
        {
            // configure list web service

            // update gui
            parentForm.Invoke(new MethodInvoker(() =>
            {
                try
                {
                    SPWSLists.Lists proxy = new SPCAMLQueryHelperOnline.SPWSLists.Lists();

                    if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSDef)
                    {
                        proxy.UseDefaultCredentials = true;
                    }
                    else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSCreds)
                    {
                        proxy.UseDefaultCredentials = false;
                        proxy.Credentials = new System.Net.NetworkCredential(parentForm.formChooser.credUsername, parentForm.formChooser.credPassword, parentForm.formChooser.credDomain);
                    }
                    else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSOffice365)
                    {
                        proxy.CookieContainer = SharedStuff.GetAuthCookies(new Uri(siteUrl), parentForm.formChooser.credUsername, parentForm.formChooser.credPassword);
                    }

                    proxy.Url = GenUtil.CombineUrls(siteUrl, XMLConsts.AsmxSuffix_Lists);

                    XElement xList = proxy.GetList(listName).GetXElement();

                    var lst = new List<string>();

                    foreach (XElement xField in xList.Descendants(XMLConsts.s + "Field"))
                    {
                        var attr = xField.Attribute("ID");

                        if (attr != null)
                        {
                            var tmp = Regex.Replace(GenUtil.SafeTrim(attr.Value), "[^a-zA-Z0-9]", "");
                            var tmp2 = Regex.Replace(fieldId.ToString().Trim().ToLower(), "[^a-zA-Z0-9]", "");

                            if (tmp == tmp2)
                            {
                                foreach (var attr2 in xField.Attributes())
                                {
                                    lst.Add(attr2.Name.LocalName + ": " + GenUtil.SafeTrim(attr2.Value));
                                }

                                break;
                            }
                        }
                    }

                    foreach (string s in lst.OrderBy(x => x))
                    {
                        WriteToTb(s);
                    }

                }
                catch (Exception ex)
                {
                    WriteToTb("ERROR", ex.ToString());
                }
            }));

        }

        void WriteToTb()
        {
            tbFieldInfo.Text += Environment.NewLine;
        }

        void WriteToTb(string s)
        {
            tbFieldInfo.Text += string.Concat(s, Environment.NewLine);
        }

        void WriteToTb(string s1, object o1)
        {
            tbFieldInfo.Text += string.Format("{0}: {1}{2}", GenUtil.SafeTrim(s1), GenUtil.SafeTrim(o1), Environment.NewLine);
        }

    }

    /// <summary>
    /// </summary>
    public class ListDetailLoader
    {

        public string url { get; set; }

        //public string siteName { get; set; }
        public string listName { get; set; }

        public ComboBox ddlListViews { get; set; }
        public TreeView tvFields { get; set; }
        public LinkLabel lnkToggleFieldsName { get; set; }
        public string text_show_internalnames { get; set; }
        public DataGridView gvFields { get; set; }

        public Form1 parentForm { get; set; }

        public ToolStripStatusLabel toolStripStatusLabel1 { get; set; }
        public StatusStrip statusStrip1 { get; set; }
        public PictureBox picLogoWait { get; set; }
        public TextBox txtStatus { get; set; }

        public Button btnOpenListDetails { get; set; }

        /// <summary>
        /// </summary>
        public void DoWork()
        {
            Thread th = new Thread(new ThreadStart(this.Worker));
            th.Start();
        }

        /// <summary>
        /// </summary>
        private void Worker()
        {
            // configure view web service
            List<CustXMLView> lstViews = new List<CustXMLView>();
            List<CustXMLField> lstFields = new List<CustXMLField>();

            Exception retErr = null;

            try
            {
                SPWSViews.Views proxyViews = new SPCAMLQueryHelperOnline.SPWSViews.Views();

                if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSDef)
                {
                    proxyViews.UseDefaultCredentials = true;
                }
                else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSCreds)
                {
                    proxyViews.UseDefaultCredentials = false;
                    proxyViews.Credentials = new System.Net.NetworkCredential(parentForm.formChooser.credUsername, parentForm.formChooser.credPassword, parentForm.formChooser.credDomain);
                }
                else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSOffice365)
                {
                    proxyViews.CookieContainer = SharedStuff.GetAuthCookies(new Uri(url), parentForm.formChooser.credUsername, parentForm.formChooser.credPassword);
                }

                proxyViews.Url = GenUtil.CombineUrls(url, XMLConsts.AsmxSuffix_Views);

                // configure list web service
                SPWSLists.Lists proxyLists = new SPCAMLQueryHelperOnline.SPWSLists.Lists();

                if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSDef)
                {
                    proxyLists.UseDefaultCredentials = true;
                }
                else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSCreds)
                {
                    proxyLists.UseDefaultCredentials = false;
                    proxyLists.Credentials = new System.Net.NetworkCredential(parentForm.formChooser.credUsername, parentForm.formChooser.credPassword, parentForm.formChooser.credDomain);
                }
                else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSOffice365)
                {
                    proxyLists.CookieContainer = SharedStuff.GetAuthCookies(new Uri(url), parentForm.formChooser.credUsername, parentForm.formChooser.credPassword);
                }

                proxyLists.Url = GenUtil.CombineUrls(url, XMLConsts.AsmxSuffix_Lists);

                // get list views
                XElement xViews = proxyViews.GetViewCollection(listName).GetXElement();

                foreach (XElement xView in xViews.Elements(XMLConsts.s + "View"))
                {
                    lstViews.Add(new CustXMLView()
                    {
                        DefaultView = GenUtil.SafeToBool(GenUtil.GetXElemAttrAsString(xView, "DefaultView")),
                        DisplayName = GenUtil.GetXElemAttrAsString(xView, "DisplayName"),
                        Name = GenUtil.GetXElemAttrAsString(xView, "Name"),
                        Url = GenUtil.GetXElemAttrAsString(xView, "Url")
                    });
                }

                // get list fields
                XElement xList = proxyLists.GetList(listName).GetXElement();

                foreach (XElement xField in xList.Descendants(XMLConsts.s + "Field"))
                {
                    CustXMLField cXmlField = new CustXMLField();

                    cXmlField.DisplayName = GenUtil.GetXElemAttrAsString(xField, "DisplayName");
                    cXmlField.ID = GenUtil.GetXElemAttrAsString(xField, "ID");
                    cXmlField.Name = GenUtil.GetXElemAttrAsString(xField, "Name");
                    cXmlField.Required = GenUtil.SafeToBool(GenUtil.GetXElemAttrAsString(xField, "Required"));
                    cXmlField.Type = GenUtil.GetXElemAttrAsString(xField, "Type");

                    if (!GenUtil.IsNull(cXmlField.ID))
                        lstFields.Add(cXmlField);
                }

            }
            catch (Exception ex)
            {
                retErr = ex;
            }




            // update gui
            parentForm.Invoke(new MethodInvoker(() =>
            {

                ddlListViews.Items.Clear();
                tvFields.Nodes.Clear();
                btnOpenListDetails.Visible = false;


                if (retErr != null)
                {
                    GenUtil.LogIt(txtStatus, retErr.ToString());
                }
                else
                {
                    GenUtil.LogIt(txtStatus, "OK");


                    // render list views
                    ddlListViews.Items.Insert(0, "None");
                    ddlListViews.SelectedIndex = 0;

                    foreach (CustXMLView v in lstViews)
                        ddlListViews.Items.Add(v.DisplayName);


                    // render list fields
                    DataTable dt = new DataTable();

                    dt.Columns.Add("Id", typeof(string));
                    dt.Columns.Add("InternalName", typeof(string));
                    dt.Columns.Add("Required", typeof(string));
                    dt.Columns.Add("Title", typeof(string));
                    dt.Columns.Add("TypeAsString", typeof(string));

                    foreach (CustXMLField cXmlField in lstFields)
                    {
                        DataRow dr = dt.NewRow();

                        dr["Id"] = cXmlField.ID;
                        dr["InternalName"] = cXmlField.Name;
                        dr["Required"] = cXmlField.Required.ToString();
                        dr["Title"] = cXmlField.DisplayName;
                        dr["TypeAsString"] = cXmlField.Type;

                        dt.Rows.Add(dr);


                        TreeNode tn = new TreeNode();

                        if (lnkToggleFieldsName.Text == text_show_internalnames)
                            tn.Text = string.Format("{0} [{1}]", cXmlField.DisplayName, cXmlField.Name);
                        else
                            tn.Text = string.Format("{0} [{1}]", cXmlField.Name, cXmlField.DisplayName);

                        tn.Name = cXmlField.Name;

                        tvFields.Nodes.Add(tn);
                    }


                    DataView dv = new DataView(dt);
                    dv.Sort = "Title";
                    gvFields.DataSource = dv;


                    if (tvFields.Nodes.Count > 0)
                    {
                        tvFields.Sort();
                        tvFields.SelectedNode = tvFields.Nodes[0];
                    }

                }

                btnOpenListDetails.Visible = true;

                // finish action
                toolStripStatusLabel1.Text = "";
                statusStrip1.Refresh();

                picLogoWait.Visible = false;
                picLogoWait.Refresh();

            }));

        }

    }

    /// <summary>
    /// </summary>
    public class LoadSitesAndLists
    {

        public string url { get; set; }

        public TreeView tvLists { get; set; }

        public Form1 parentForm { get; set; }

        public Button btnLoad { get; set; }
        public ToolStripStatusLabel toolStripStatusLabel1 { get; set; }
        public StatusStrip statusStrip1 { get; set; }
        public PictureBox picLogoWait { get; set; }
        public TextBox txtStatus { get; set; }

        public string selWebTitle { get; set; }
        public Guid selWebId { get; set; }

        /// <summary>
        /// </summary>
        public void DoWork()
        {
            Thread th = new Thread(new ThreadStart(this.Worker));
            th.Start();
        }

        /// <summary>
        /// </summary>
        private void Worker()
        {
            selWebId = Guid.NewGuid();
            selWebTitle = string.Empty;
            var lst = new List<CustXMLList>();
            Exception retErr = null;

            try
            {
                SPWSLists.Lists proxy = new SPCAMLQueryHelperOnline.SPWSLists.Lists();

                if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSDef)
                {
                    proxy.UseDefaultCredentials = true;
                }
                else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSCreds)
                {
                    proxy.UseDefaultCredentials = false;
                    proxy.Credentials = new System.Net.NetworkCredential(parentForm.formChooser.credUsername, parentForm.formChooser.credPassword, parentForm.formChooser.credDomain);
                }
                else if (parentForm.formChooser.appMode == Chooser.AppMode.UseWSOffice365)
                {
                    proxy.CookieContainer = SharedStuff.GetAuthCookies(new Uri(url), parentForm.formChooser.credUsername, parentForm.formChooser.credPassword);
                }

                proxy.Url = GenUtil.CombineUrls(url, XMLConsts.AsmxSuffix_Lists);

                XElement xLists = proxy.GetListCollection().GetXElement();

                foreach (XElement xList in xLists.Elements(XMLConsts.s + "List"))
                {
                    CustXMLList cXmlList = new CustXMLList()
                    {
                        DefaultViewUrl = GenUtil.GetXElemAttrAsString(xList, "DefaultViewUrl"),
                        ID = GenUtil.GetXElemAttrAsString(xList, "ID"),
                        Hidden = GenUtil.SafeToBool(GenUtil.GetXElemAttrAsString(xList, "Hidden")),
                        Name = GenUtil.GetXElemAttrAsString(xList, "Name"),
                        Title = GenUtil.GetXElemAttrAsString(xList, "Title"),
                        WebFullUrl = GenUtil.GetXElemAttrAsString(xList, "WebFullUrl"),
                        WebId = GenUtil.GetXElemAttrAsString(xList, "WebId")
                    };

                    if (!cXmlList.Hidden)
                        lst.Add(cXmlList);
                }

            }
            catch(Exception ex)
            {
                retErr = ex;
            }


            // update gui
            parentForm.Invoke(new MethodInvoker(() =>
            {
                tvLists.Nodes.Clear();

                if (retErr != null)
                {
                    GenUtil.LogIt(txtStatus, retErr.ToString());
                }
                else
                {
                    GenUtil.LogIt(txtStatus, "OK");

                    foreach (CustXMLList l in lst)
                        tvLists.Nodes.Add(l.ID, (l.Hidden ? l.Title + " [HIDDEN]" : l.Title));
                }

                // finish action
                btnLoad.Enabled = true;

                toolStripStatusLabel1.Text = "";
                statusStrip1.Refresh();

                picLogoWait.Visible = false;
                picLogoWait.Refresh();

            }));

        }

    }
}
