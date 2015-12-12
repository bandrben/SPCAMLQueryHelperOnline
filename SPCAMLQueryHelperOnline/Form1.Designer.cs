namespace SPCAMLQueryHelperOnline
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tvLists = new System.Windows.Forms.TreeView();
            this.txtSiteUrl = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gvFields = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnOpenListDetails = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtListID = new System.Windows.Forms.TextBox();
            this.txtListName = new System.Windows.Forms.TextBox();
            this.btnExportFieldInfo = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tpQuery = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lnkbtnAddCamlExample = new System.Windows.Forms.LinkLabel();
            this.ddlCamlExamples = new System.Windows.Forms.ComboBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.tpViewFields = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.txtViewFields = new System.Windows.Forms.TextBox();
            this.tpViewAttributes = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.txtViewAttributes = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ddlListViews = new System.Windows.Forms.ComboBox();
            this.btnExportCode = new System.Windows.Forms.Button();
            this.lnkToggleFieldsName = new System.Windows.Forms.LinkLabel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtRowLimit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tvFields = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnExportResults = new System.Windows.Forms.Button();
            this.gvResults = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblListName = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeAppModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lnkbtnOpenListViews = new System.Windows.Forms.LinkLabel();
            this.picLogoNormal = new System.Windows.Forms.PictureBox();
            this.picLogoWait = new System.Windows.Forms.PictureBox();
            this.txtHoverText = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFields)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tpQuery.SuspendLayout();
            this.tpViewFields.SuspendLayout();
            this.tpViewAttributes.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoWait)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 801);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(842, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "test";
            // 
            // tvLists
            // 
            this.tvLists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvLists.BackColor = System.Drawing.Color.Azure;
            this.tvLists.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvLists.Location = new System.Drawing.Point(12, 53);
            this.tvLists.Name = "tvLists";
            this.tvLists.Size = new System.Drawing.Size(186, 651);
            this.tvLists.TabIndex = 99;
            // 
            // txtSiteUrl
            // 
            this.txtSiteUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSiteUrl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSiteUrl.Location = new System.Drawing.Point(271, 28);
            this.txtSiteUrl.Name = "txtSiteUrl";
            this.txtSiteUrl.Size = new System.Drawing.Size(297, 22);
            this.txtSiteUrl.TabIndex = 1;
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.BackColor = System.Drawing.SystemColors.Info;
            this.txtStatus.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(12, 710);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtStatus.Size = new System.Drawing.Size(650, 88);
            this.txtStatus.TabIndex = 99;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLoad.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(574, 27);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "LOAD";
            this.toolTip1.SetToolTip(this.btnLoad, "Load Sites and Lists");
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(201, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 99;
            this.label1.Text = "Site URL:";
            // 
            // gvFields
            // 
            this.gvFields.AllowUserToAddRows = false;
            this.gvFields.AllowUserToDeleteRows = false;
            this.gvFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFields.Location = new System.Drawing.Point(6, 63);
            this.gvFields.Name = "gvFields";
            this.gvFields.ReadOnly = true;
            this.gvFields.ShowCellToolTips = false;
            this.gvFields.ShowEditingIcon = false;
            this.gvFields.Size = new System.Drawing.Size(610, 488);
            this.gvFields.TabIndex = 99;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(204, 92);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(630, 612);
            this.tabControl1.TabIndex = 99;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.btnOpenListDetails);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtListID);
            this.tabPage1.Controls.Add(this.txtListName);
            this.tabPage1.Controls.Add(this.btnExportFieldInfo);
            this.tabPage1.Controls.Add(this.gvFields);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(622, 586);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "List Info";
            // 
            // btnOpenListDetails
            // 
            this.btnOpenListDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenListDetails.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOpenListDetails.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenListDetails.ForeColor = System.Drawing.Color.White;
            this.btnOpenListDetails.Location = new System.Drawing.Point(6, 557);
            this.btnOpenListDetails.Name = "btnOpenListDetails";
            this.btnOpenListDetails.Size = new System.Drawing.Size(170, 23);
            this.btnOpenListDetails.TabIndex = 104;
            this.btnOpenListDetails.Text = "MORE LIST DETAIL";
            this.toolTip1.SetToolTip(this.btnOpenListDetails, "Load additional list details.");
            this.btnOpenListDetails.UseVisualStyleBackColor = false;
            this.btnOpenListDetails.Click += new System.EventHandler(this.btnOpenListDetails_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 103;
            this.label9.Text = "List ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 101;
            this.label7.Text = "List Name:";
            // 
            // txtListID
            // 
            this.txtListID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtListID.BackColor = System.Drawing.Color.White;
            this.txtListID.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtListID.Location = new System.Drawing.Point(76, 36);
            this.txtListID.Name = "txtListID";
            this.txtListID.Size = new System.Drawing.Size(540, 21);
            this.txtListID.TabIndex = 102;
            // 
            // txtListName
            // 
            this.txtListName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtListName.BackColor = System.Drawing.Color.White;
            this.txtListName.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtListName.Location = new System.Drawing.Point(76, 9);
            this.txtListName.Name = "txtListName";
            this.txtListName.Size = new System.Drawing.Size(540, 21);
            this.txtListName.TabIndex = 101;
            // 
            // btnExportFieldInfo
            // 
            this.btnExportFieldInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportFieldInfo.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExportFieldInfo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportFieldInfo.ForeColor = System.Drawing.Color.White;
            this.btnExportFieldInfo.Location = new System.Drawing.Point(541, 557);
            this.btnExportFieldInfo.Name = "btnExportFieldInfo";
            this.btnExportFieldInfo.Size = new System.Drawing.Size(75, 23);
            this.btnExportFieldInfo.TabIndex = 99;
            this.btnExportFieldInfo.Text = "EXPORT";
            this.toolTip1.SetToolTip(this.btnExportFieldInfo, "Export fields to CSV");
            this.btnExportFieldInfo.UseVisualStyleBackColor = false;
            this.btnExportFieldInfo.Click += new System.EventHandler(this.btnExportFieldInfo_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.ddlListViews);
            this.tabPage2.Controls.Add(this.btnExportCode);
            this.tabPage2.Controls.Add(this.lnkToggleFieldsName);
            this.tabPage2.Controls.Add(this.btnSearch);
            this.tabPage2.Controls.Add(this.txtRowLimit);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.tvFields);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(622, 586);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Query Helper";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tpQuery);
            this.tabControl2.Controls.Add(this.tpViewFields);
            this.tabControl2.Controls.Add(this.tpViewAttributes);
            this.tabControl2.Location = new System.Drawing.Point(3, 142);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(613, 409);
            this.tabControl2.TabIndex = 107;
            // 
            // tpQuery
            // 
            this.tpQuery.BackColor = System.Drawing.SystemColors.Control;
            this.tpQuery.Controls.Add(this.label3);
            this.tpQuery.Controls.Add(this.lnkbtnAddCamlExample);
            this.tpQuery.Controls.Add(this.ddlCamlExamples);
            this.tpQuery.Controls.Add(this.txtQuery);
            this.tpQuery.Location = new System.Drawing.Point(4, 22);
            this.tpQuery.Name = "tpQuery";
            this.tpQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuery.Size = new System.Drawing.Size(605, 383);
            this.tpQuery.TabIndex = 0;
            this.tpQuery.Text = "Query";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "Query: (required, enter CAML)";
            // 
            // lnkbtnAddCamlExample
            // 
            this.lnkbtnAddCamlExample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkbtnAddCamlExample.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkbtnAddCamlExample.Location = new System.Drawing.Point(566, 9);
            this.lnkbtnAddCamlExample.Name = "lnkbtnAddCamlExample";
            this.lnkbtnAddCamlExample.Size = new System.Drawing.Size(32, 13);
            this.lnkbtnAddCamlExample.TabIndex = 106;
            this.lnkbtnAddCamlExample.TabStop = true;
            this.lnkbtnAddCamlExample.Text = "Add";
            this.lnkbtnAddCamlExample.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkbtnAddCamlExample.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkbtnAddCamlExample_LinkClicked);
            // 
            // ddlCamlExamples
            // 
            this.ddlCamlExamples.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCamlExamples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCamlExamples.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCamlExamples.FormattingEnabled = true;
            this.ddlCamlExamples.Location = new System.Drawing.Point(247, 6);
            this.ddlCamlExamples.MaxDropDownItems = 50;
            this.ddlCamlExamples.Name = "ddlCamlExamples";
            this.ddlCamlExamples.Size = new System.Drawing.Size(313, 21);
            this.ddlCamlExamples.TabIndex = 105;
            // 
            // txtQuery
            // 
            this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuery.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuery.Location = new System.Drawing.Point(9, 31);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQuery.Size = new System.Drawing.Size(589, 345);
            this.txtQuery.TabIndex = 10;
            this.txtQuery.WordWrap = false;
            // 
            // tpViewFields
            // 
            this.tpViewFields.BackColor = System.Drawing.SystemColors.Control;
            this.tpViewFields.Controls.Add(this.label4);
            this.tpViewFields.Controls.Add(this.txtViewFields);
            this.tpViewFields.Location = new System.Drawing.Point(4, 22);
            this.tpViewFields.Name = "tpViewFields";
            this.tpViewFields.Padding = new System.Windows.Forms.Padding(3);
            this.tpViewFields.Size = new System.Drawing.Size(605, 383);
            this.tpViewFields.TabIndex = 1;
            this.tpViewFields.Text = "View Fields";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "View Fields: (optional, enter CAML)";
            // 
            // txtViewFields
            // 
            this.txtViewFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtViewFields.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtViewFields.Location = new System.Drawing.Point(9, 26);
            this.txtViewFields.Multiline = true;
            this.txtViewFields.Name = "txtViewFields";
            this.txtViewFields.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtViewFields.Size = new System.Drawing.Size(590, 351);
            this.txtViewFields.TabIndex = 11;
            this.txtViewFields.WordWrap = false;
            // 
            // tpViewAttributes
            // 
            this.tpViewAttributes.BackColor = System.Drawing.SystemColors.Control;
            this.tpViewAttributes.Controls.Add(this.label10);
            this.tpViewAttributes.Controls.Add(this.txtViewAttributes);
            this.tpViewAttributes.Location = new System.Drawing.Point(4, 22);
            this.tpViewAttributes.Name = "tpViewAttributes";
            this.tpViewAttributes.Size = new System.Drawing.Size(605, 383);
            this.tpViewAttributes.TabIndex = 2;
            this.tpViewAttributes.Text = "View Attributes";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(297, 13);
            this.label10.TabIndex = 101;
            this.label10.Text = "View Attributes: (optional, ex. Scope=\"Recursive\")";
            // 
            // txtViewAttributes
            // 
            this.txtViewAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtViewAttributes.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtViewAttributes.Location = new System.Drawing.Point(9, 26);
            this.txtViewAttributes.Multiline = true;
            this.txtViewAttributes.Name = "txtViewAttributes";
            this.txtViewAttributes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtViewAttributes.Size = new System.Drawing.Size(589, 351);
            this.txtViewAttributes.TabIndex = 12;
            this.txtViewAttributes.WordWrap = false;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(155, 562);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 104;
            this.label11.Text = "Views:";
            // 
            // ddlListViews
            // 
            this.ddlListViews.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlListViews.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlListViews.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlListViews.FormattingEnabled = true;
            this.ddlListViews.Location = new System.Drawing.Point(201, 559);
            this.ddlListViews.MaxDropDownItems = 50;
            this.ddlListViews.Name = "ddlListViews";
            this.ddlListViews.Size = new System.Drawing.Size(192, 21);
            this.ddlListViews.TabIndex = 103;
            // 
            // btnExportCode
            // 
            this.btnExportCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportCode.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExportCode.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCode.ForeColor = System.Drawing.Color.White;
            this.btnExportCode.Location = new System.Drawing.Point(417, 557);
            this.btnExportCode.Name = "btnExportCode";
            this.btnExportCode.Size = new System.Drawing.Size(110, 23);
            this.btnExportCode.TabIndex = 14;
            this.btnExportCode.Text = "COPY CODE";
            this.toolTip1.SetToolTip(this.btnExportCode, "Export CAML to C#");
            this.btnExportCode.UseVisualStyleBackColor = false;
            this.btnExportCode.Click += new System.EventHandler(this.btnExportCode_Click);
            // 
            // lnkToggleFieldsName
            // 
            this.lnkToggleFieldsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkToggleFieldsName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkToggleFieldsName.Location = new System.Drawing.Point(469, 9);
            this.lnkToggleFieldsName.Name = "lnkToggleFieldsName";
            this.lnkToggleFieldsName.Size = new System.Drawing.Size(150, 13);
            this.lnkToggleFieldsName.TabIndex = 99;
            this.lnkToggleFieldsName.TabStop = true;
            this.lnkToggleFieldsName.Text = "toggle";
            this.lnkToggleFieldsName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkToggleFieldsName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkToggleFieldsName_LinkClicked);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(533, 557);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(83, 23);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "SEARCH";
            this.toolTip1.SetToolTip(this.btnSearch, "Execute Search");
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtRowLimit
            // 
            this.txtRowLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRowLimit.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRowLimit.Location = new System.Drawing.Point(74, 559);
            this.txtRowLimit.Name = "txtRowLimit";
            this.txtRowLimit.Size = new System.Drawing.Size(72, 21);
            this.txtRowLimit.TabIndex = 13;
            this.txtRowLimit.Text = "0";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 562);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Row Limit:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 13);
            this.label2.TabIndex = 99;
            this.label2.Text = "Fields: (drag to textboxes below)";
            // 
            // tvFields
            // 
            this.tvFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvFields.BackColor = System.Drawing.Color.Azure;
            this.tvFields.Font = new System.Drawing.Font("Verdana", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvFields.Location = new System.Drawing.Point(3, 26);
            this.tvFields.Name = "tvFields";
            this.tvFields.Size = new System.Drawing.Size(613, 110);
            this.tvFields.TabIndex = 9;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.btnExportResults);
            this.tabPage3.Controls.Add(this.gvResults);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(622, 586);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Results";
            // 
            // btnExportResults
            // 
            this.btnExportResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportResults.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExportResults.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportResults.ForeColor = System.Drawing.Color.White;
            this.btnExportResults.Location = new System.Drawing.Point(541, 560);
            this.btnExportResults.Name = "btnExportResults";
            this.btnExportResults.Size = new System.Drawing.Size(75, 23);
            this.btnExportResults.TabIndex = 99;
            this.btnExportResults.Text = "EXPORT";
            this.toolTip1.SetToolTip(this.btnExportResults, "Export results to CSV");
            this.btnExportResults.UseVisualStyleBackColor = false;
            this.btnExportResults.Click += new System.EventHandler(this.btnExportResults_Click);
            // 
            // gvResults
            // 
            this.gvResults.AllowUserToAddRows = false;
            this.gvResults.AllowUserToDeleteRows = false;
            this.gvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResults.Location = new System.Drawing.Point(6, 6);
            this.gvResults.Name = "gvResults";
            this.gvResults.ReadOnly = true;
            this.gvResults.Size = new System.Drawing.Size(610, 548);
            this.gvResults.TabIndex = 99;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 14);
            this.label6.TabIndex = 99;
            this.label6.Text = "Lists:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(201, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 16);
            this.label8.TabIndex = 99;
            this.label8.Text = "Selected List:";
            // 
            // lblListName
            // 
            this.lblListName.AutoSize = true;
            this.lblListName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListName.Location = new System.Drawing.Point(306, 56);
            this.lblListName.Name = "lblListName";
            this.lblListName.Size = new System.Drawing.Size(72, 16);
            this.lblListName.TabIndex = 99;
            this.lblListName.Text = "listName";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(842, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeAppModeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // changeAppModeToolStripMenuItem
            // 
            this.changeAppModeToolStripMenuItem.Name = "changeAppModeToolStripMenuItem";
            this.changeAppModeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.changeAppModeToolStripMenuItem.Text = "Change App Mode";
            this.changeAppModeToolStripMenuItem.Click += new System.EventHandler(this.changeAppModeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lnkbtnOpenListViews
            // 
            this.lnkbtnOpenListViews.AutoSize = true;
            this.lnkbtnOpenListViews.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkbtnOpenListViews.Location = new System.Drawing.Point(201, 73);
            this.lnkbtnOpenListViews.Name = "lnkbtnOpenListViews";
            this.lnkbtnOpenListViews.Size = new System.Drawing.Size(97, 13);
            this.lnkbtnOpenListViews.TabIndex = 100;
            this.lnkbtnOpenListViews.TabStop = true;
            this.lnkbtnOpenListViews.Text = "Open List Views";
            this.lnkbtnOpenListViews.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkbtnOpenListViews.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkbtnOpenListViews_LinkClicked);
            // 
            // picLogoNormal
            // 
            this.picLogoNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogoNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogoNormal.Image = ((System.Drawing.Image)(resources.GetObject("picLogoNormal.Image")));
            this.picLogoNormal.InitialImage = null;
            this.picLogoNormal.Location = new System.Drawing.Point(782, 27);
            this.picLogoNormal.Name = "picLogoNormal";
            this.picLogoNormal.Size = new System.Drawing.Size(52, 70);
            this.picLogoNormal.TabIndex = 101;
            this.picLogoNormal.TabStop = false;
            // 
            // picLogoWait
            // 
            this.picLogoWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogoWait.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogoWait.Image = ((System.Drawing.Image)(resources.GetObject("picLogoWait.Image")));
            this.picLogoWait.Location = new System.Drawing.Point(782, 27);
            this.picLogoWait.Name = "picLogoWait";
            this.picLogoWait.Size = new System.Drawing.Size(52, 70);
            this.picLogoWait.TabIndex = 102;
            this.picLogoWait.TabStop = false;
            // 
            // txtHoverText
            // 
            this.txtHoverText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoverText.BackColor = System.Drawing.Color.Azure;
            this.txtHoverText.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoverText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtHoverText.Location = new System.Drawing.Point(668, 710);
            this.txtHoverText.Multiline = true;
            this.txtHoverText.Name = "txtHoverText";
            this.txtHoverText.Size = new System.Drawing.Size(166, 88);
            this.txtHoverText.TabIndex = 103;
            this.txtHoverText.Text = "Welcome...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(842, 823);
            this.Controls.Add(this.txtHoverText);
            this.Controls.Add(this.picLogoWait);
            this.Controls.Add(this.picLogoNormal);
            this.Controls.Add(this.lnkbtnOpenListViews);
            this.Controls.Add(this.lblListName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtSiteUrl);
            this.Controls.Add(this.tvLists);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(850, 850);
            this.Name = "Form1";
            this.Text = "SP CAML Query Helper Online";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFields)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tpQuery.ResumeLayout(false);
            this.tpQuery.PerformLayout();
            this.tpViewFields.ResumeLayout(false);
            this.tpViewFields.PerformLayout();
            this.tpViewAttributes.ResumeLayout(false);
            this.tpViewAttributes.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TreeView tvLists;
        private System.Windows.Forms.TextBox txtSiteUrl;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvFields;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView tvFields;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtRowLimit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtViewFields;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView gvResults;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblListName;
        private System.Windows.Forms.LinkLabel lnkToggleFieldsName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnExportFieldInfo;
        private System.Windows.Forms.Button btnExportResults;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.LinkLabel lnkbtnOpenListViews;
        private System.Windows.Forms.Button btnExportCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtListID;
        private System.Windows.Forms.TextBox txtListName;
        private System.Windows.Forms.PictureBox picLogoNormal;
        private System.Windows.Forms.TextBox txtViewAttributes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ddlListViews;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ddlCamlExamples;
        private System.Windows.Forms.LinkLabel lnkbtnAddCamlExample;
        private System.Windows.Forms.ToolStripMenuItem changeAppModeToolStripMenuItem;
        private System.Windows.Forms.PictureBox picLogoWait;
        private System.Windows.Forms.TextBox txtHoverText;
        private System.Windows.Forms.Button btnOpenListDetails;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tpQuery;
        private System.Windows.Forms.TabPage tpViewFields;
        private System.Windows.Forms.TabPage tpViewAttributes;
    }
}

