namespace EAS_MD
{
    partial class frmEAS
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "14.1 (Exchange 2013)",
            "14.1"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "14.1 (Exchange 2010 SP1)",
            "14.1"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "14.0 (Exchange 2010 RTM)",
            "14.0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "12.1 (Exchange 2007 SP1)",
            "12.1"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "12.0 (Exchange 2007 RTM)",
            "12.0"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEAS));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.grpBoxOutput = new System.Windows.Forms.GroupBox();
            this.chkWBXML = new System.Windows.Forms.CheckBox();
            this.chkWordWrapMain = new System.Windows.Forms.CheckBox();
            this.chkBase64 = new System.Windows.Forms.CheckBox();
            this.chkHex = new System.Windows.Forms.CheckBox();
            this.chkBinary = new System.Windows.Forms.CheckBox();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.grpBoxASVer = new System.Windows.Forms.GroupBox();
            this.lstASVersions = new System.Windows.Forms.ListView();
            this.grpBoxActions = new System.Windows.Forms.GroupBox();
            this.btnRemoteWipe = new System.Windows.Forms.Button();
            this.btnBasicTest = new System.Windows.Forms.Button();
            this.btnFullTest = new System.Windows.Forms.Button();
            this.grpBoxConParams = new System.Windows.Forms.GroupBox();
            this.lblClientCertPassword = new System.Windows.Forms.Label();
            this.txtClientCertPassword = new System.Windows.Forms.TextBox();
            this.txtClientCertPath = new System.Windows.Forms.TextBox();
            this.chkUseClientCert = new System.Windows.Forms.CheckBox();
            this.lblSAInfo = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblDomain = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.lblServerAddress = new System.Windows.Forms.Label();
            this.chkUseSSL = new System.Windows.Forms.CheckBox();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.grpBoxDevParams = new System.Windows.Forms.GroupBox();
            this.lblDeviceId = new System.Windows.Forms.Label();
            this.txtUserAgent = new System.Windows.Forms.TextBox();
            this.lblDeviceType = new System.Windows.Forms.Label();
            this.txtDeviceType = new System.Windows.Forms.TextBox();
            this.lblUserAgent = new System.Windows.Forms.Label();
            this.txtDeviceId = new System.Windows.Forms.TextBox();
            this.grpBoxDevProps = new System.Windows.Forms.GroupBox();
            this.chkFakeSecPol = new System.Windows.Forms.CheckBox();
            this.chkProvisionable = new System.Windows.Forms.CheckBox();
            this.chkTrustAllCerts = new System.Windows.Forms.CheckBox();
            this.tabDevInfo = new System.Windows.Forms.TabPage();
            this.grpBoxDevInfo = new System.Windows.Forms.GroupBox();
            this.txtDevInf = new System.Windows.Forms.TextBox();
            this.txtDevOSLang = new System.Windows.Forms.TextBox();
            this.txtDevUA = new System.Windows.Forms.TextBox();
            this.txtDevMO = new System.Windows.Forms.TextBox();
            this.txtDevPhoneNr = new System.Windows.Forms.TextBox();
            this.txtDevOS = new System.Windows.Forms.TextBox();
            this.txtDevFriendly = new System.Windows.Forms.TextBox();
            this.txtDevIMEI = new System.Windows.Forms.TextBox();
            this.txtDevModel = new System.Windows.Forms.TextBox();
            this.lblDevUA = new System.Windows.Forms.Label();
            this.lblDevMO = new System.Windows.Forms.Label();
            this.lblDevPhoneNr = new System.Windows.Forms.Label();
            this.lblDevOSLang = new System.Windows.Forms.Label();
            this.lblDevOS = new System.Windows.Forms.Label();
            this.lblDevFriendly = new System.Windows.Forms.Label();
            this.lblDevIMEI = new System.Windows.Forms.Label();
            this.lblDevMod = new System.Windows.Forms.Label();
            this.tabAutodiscover = new System.Windows.Forms.TabPage();
            this.grpBoxAutodiscoverOutput = new System.Windows.Forms.GroupBox();
            this.txtAutodiscoverOutput = new System.Windows.Forms.TextBox();
            this.grpBoxAutodiscoverTests = new System.Windows.Forms.GroupBox();
            this.chkAutodiscoverTest3 = new System.Windows.Forms.CheckBox();
            this.chkAutodiscoverTest2 = new System.Windows.Forms.CheckBox();
            this.chkAutodiscoverTest1 = new System.Windows.Forms.CheckBox();
            this.chkAutodiscoverTest0 = new System.Windows.Forms.CheckBox();
            this.grpBoxAutodiscoverCredentials = new System.Windows.Forms.GroupBox();
            this.chkTrustCertsAutodiscover = new System.Windows.Forms.CheckBox();
            this.btnClearAutodiscoverOutput = new System.Windows.Forms.Button();
            this.btnAutodiscoverRunTests = new System.Windows.Forms.Button();
            this.txtAutodiscoverInf = new System.Windows.Forms.TextBox();
            this.lblAutodiscoverUsername = new System.Windows.Forms.Label();
            this.lblAutodiscoverDomain = new System.Windows.Forms.Label();
            this.txtAutodiscoverUsername = new System.Windows.Forms.TextBox();
            this.txtAutodiscoverDomain = new System.Windows.Forms.TextBox();
            this.txtAutodiscoverPassword = new System.Windows.Forms.TextBox();
            this.txtAutodiscoverEmailAddress = new System.Windows.Forms.TextBox();
            this.lblAutodiscoverPassword = new System.Windows.Forms.Label();
            this.lblAutodiscoverEmailAddress = new System.Windows.Forms.Label();
            this.tabWBXML = new System.Windows.Forms.TabPage();
            this.grpBoxWBXML = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxCmd = new System.Windows.Forms.ComboBox();
            this.txtWbxmlInf = new System.Windows.Forms.TextBox();
            this.lblWbxmlInput = new System.Windows.Forms.Label();
            this.btnClearWbxml = new System.Windows.Forms.Button();
            this.btnExecuteWbxml = new System.Windows.Forms.Button();
            this.txtWbxmlInput = new System.Windows.Forms.TextBox();
            this.lblWbxmlOutput = new System.Windows.Forms.Label();
            this.txtWbxmlOutput = new System.Windows.Forms.TextBox();
            this.tabCerts = new System.Windows.Forms.TabPage();
            this.grpBoxCertChain = new System.Windows.Forms.GroupBox();
            this.txtCertInf = new System.Windows.Forms.TextBox();
            this.btnClearCertChain = new System.Windows.Forms.Button();
            this.lblCertChain = new System.Windows.Forms.Label();
            this.txtCertList = new System.Windows.Forms.TextBox();
            this.txtServerAddressSSL = new System.Windows.Forms.TextBox();
            this.btnGetChain = new System.Windows.Forms.Button();
            this.tabIRM = new System.Windows.Forms.TabPage();
            this.grpBoxIRM = new System.Windows.Forms.GroupBox();
            this.chkWordWrapIRM = new System.Windows.Forms.CheckBox();
            this.btnClearIRMOutput = new System.Windows.Forms.Button();
            this.txtIRMOutput = new System.Windows.Forms.TextBox();
            this.btnIRMGetPol = new System.Windows.Forms.Button();
            this.lblIRMInfo = new System.Windows.Forms.Label();
            this.tabBase64 = new System.Windows.Forms.TabPage();
            this.grpBoxBase64 = new System.Windows.Forms.GroupBox();
            this.txtBase64Inf = new System.Windows.Forms.TextBox();
            this.lblConvertSource = new System.Windows.Forms.Label();
            this.btnBase64Decode = new System.Windows.Forms.Button();
            this.btnBase64Encode = new System.Windows.Forms.Button();
            this.txtConvertSource = new System.Windows.Forms.TextBox();
            this.lblConvertDest = new System.Windows.Forms.Label();
            this.txtConvertDest = new System.Windows.Forms.TextBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.grpBoxAbout = new System.Windows.Forms.GroupBox();
            this.lnkLblGit = new System.Windows.Forms.LinkLabel();
            this.txtAboutSource = new System.Windows.Forms.TextBox();
            this.lblAboutCopyright = new System.Windows.Forms.Label();
            this.lnkLblAbout = new System.Windows.Forms.LinkLabel();
            this.txtAboutFeedback = new System.Windows.Forms.TextBox();
            this.lblAboutVer = new System.Windows.Forms.Label();
            this.lnkLblDownload = new System.Windows.Forms.LinkLabel();
            this.txtAboutDownload = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.grpBoxOutput.SuspendLayout();
            this.grpBoxASVer.SuspendLayout();
            this.grpBoxActions.SuspendLayout();
            this.grpBoxConParams.SuspendLayout();
            this.grpBoxDevParams.SuspendLayout();
            this.grpBoxDevProps.SuspendLayout();
            this.tabDevInfo.SuspendLayout();
            this.grpBoxDevInfo.SuspendLayout();
            this.tabAutodiscover.SuspendLayout();
            this.grpBoxAutodiscoverOutput.SuspendLayout();
            this.grpBoxAutodiscoverTests.SuspendLayout();
            this.grpBoxAutodiscoverCredentials.SuspendLayout();
            this.tabWBXML.SuspendLayout();
            this.grpBoxWBXML.SuspendLayout();
            this.tabCerts.SuspendLayout();
            this.grpBoxCertChain.SuspendLayout();
            this.tabIRM.SuspendLayout();
            this.grpBoxIRM.SuspendLayout();
            this.tabBase64.SuspendLayout();
            this.grpBoxBase64.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.grpBoxAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabDevInfo);
            this.tabControl1.Controls.Add(this.tabAutodiscover);
            this.tabControl1.Controls.Add(this.tabWBXML);
            this.tabControl1.Controls.Add(this.tabCerts);
            this.tabControl1.Controls.Add(this.tabIRM);
            this.tabControl1.Controls.Add(this.tabBase64);
            this.tabControl1.Controls.Add(this.tabAbout);
            this.tabControl1.Location = new System.Drawing.Point(0, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(737, 581);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.grpBoxOutput);
            this.tabMain.Controls.Add(this.grpBoxASVer);
            this.tabMain.Controls.Add(this.grpBoxActions);
            this.tabMain.Controls.Add(this.grpBoxConParams);
            this.tabMain.Controls.Add(this.grpBoxDevParams);
            this.tabMain.Controls.Add(this.grpBoxDevProps);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(729, 555);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // grpBoxOutput
            // 
            this.grpBoxOutput.Controls.Add(this.chkWBXML);
            this.grpBoxOutput.Controls.Add(this.chkWordWrapMain);
            this.grpBoxOutput.Controls.Add(this.chkBase64);
            this.grpBoxOutput.Controls.Add(this.chkHex);
            this.grpBoxOutput.Controls.Add(this.chkBinary);
            this.grpBoxOutput.Controls.Add(this.btnClearOutput);
            this.grpBoxOutput.Controls.Add(this.txtOutput);
            this.grpBoxOutput.Location = new System.Drawing.Point(220, 120);
            this.grpBoxOutput.Name = "grpBoxOutput";
            this.grpBoxOutput.Size = new System.Drawing.Size(495, 424);
            this.grpBoxOutput.TabIndex = 29;
            this.grpBoxOutput.TabStop = false;
            this.grpBoxOutput.Text = "Output";
            // 
            // chkWBXML
            // 
            this.chkWBXML.AutoSize = true;
            this.chkWBXML.Checked = true;
            this.chkWBXML.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWBXML.Location = new System.Drawing.Point(10, 50);
            this.chkWBXML.Name = "chkWBXML";
            this.chkWBXML.Size = new System.Drawing.Size(66, 17);
            this.chkWBXML.TabIndex = 28;
            this.chkWBXML.Text = "WBXML";
            this.chkWBXML.UseVisualStyleBackColor = true;
            // 
            // chkWordWrapMain
            // 
            this.chkWordWrapMain.AutoSize = true;
            this.chkWordWrapMain.Location = new System.Drawing.Point(162, 50);
            this.chkWordWrapMain.Name = "chkWordWrapMain";
            this.chkWordWrapMain.Size = new System.Drawing.Size(144, 17);
            this.chkWordWrapMain.TabIndex = 27;
            this.chkWordWrapMain.Text = "Word Wrap (Binary XML)";
            this.chkWordWrapMain.UseVisualStyleBackColor = true;
            // 
            // chkBase64
            // 
            this.chkBase64.AutoSize = true;
            this.chkBase64.Enabled = false;
            this.chkBase64.Location = new System.Drawing.Point(308, 50);
            this.chkBase64.Name = "chkBase64";
            this.chkBase64.Size = new System.Drawing.Size(62, 17);
            this.chkBase64.TabIndex = 26;
            this.chkBase64.Text = "Base64";
            this.chkBase64.UseVisualStyleBackColor = true;
            this.chkBase64.Visible = false;
            // 
            // chkHex
            // 
            this.chkHex.AutoSize = true;
            this.chkHex.Enabled = false;
            this.chkHex.Location = new System.Drawing.Point(378, 50);
            this.chkHex.Name = "chkHex";
            this.chkHex.Size = new System.Drawing.Size(45, 17);
            this.chkHex.TabIndex = 25;
            this.chkHex.Text = "Hex";
            this.chkHex.UseVisualStyleBackColor = true;
            this.chkHex.Visible = false;
            // 
            // chkBinary
            // 
            this.chkBinary.AutoSize = true;
            this.chkBinary.Location = new System.Drawing.Point(78, 50);
            this.chkBinary.Name = "chkBinary";
            this.chkBinary.Size = new System.Drawing.Size(80, 17);
            this.chkBinary.TabIndex = 24;
            this.chkBinary.Text = "Binary XML";
            this.chkBinary.UseVisualStyleBackColor = true;
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Location = new System.Drawing.Point(6, 20);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(75, 23);
            this.btnClearOutput.TabIndex = 23;
            this.btnClearOutput.Text = "Clear Output";
            this.btnClearOutput.UseVisualStyleBackColor = true;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutput.Location = new System.Drawing.Point(6, 70);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(483, 337);
            this.txtOutput.TabIndex = 11;
            // 
            // grpBoxASVer
            // 
            this.grpBoxASVer.Controls.Add(this.lstASVersions);
            this.grpBoxASVer.Location = new System.Drawing.Point(10, 285);
            this.grpBoxASVer.Name = "grpBoxASVer";
            this.grpBoxASVer.Size = new System.Drawing.Size(200, 131);
            this.grpBoxASVer.TabIndex = 28;
            this.grpBoxASVer.TabStop = false;
            this.grpBoxASVer.Text = "MS-ASProtocolVersion";
            // 
            // lstASVersions
            // 
            listViewItem3.StateImageIndex = 0;
            this.lstASVersions.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lstASVersions.Location = new System.Drawing.Point(9, 19);
            this.lstASVersions.MultiSelect = false;
            this.lstASVersions.Name = "lstASVersions";
            this.lstASVersions.Size = new System.Drawing.Size(147, 96);
            this.lstASVersions.TabIndex = 27;
            this.lstASVersions.UseCompatibleStateImageBehavior = false;
            this.lstASVersions.View = System.Windows.Forms.View.List;
            // 
            // grpBoxActions
            // 
            this.grpBoxActions.Controls.Add(this.btnRemoteWipe);
            this.grpBoxActions.Controls.Add(this.btnBasicTest);
            this.grpBoxActions.Controls.Add(this.btnFullTest);
            this.grpBoxActions.Location = new System.Drawing.Point(10, 422);
            this.grpBoxActions.Name = "grpBoxActions";
            this.grpBoxActions.Size = new System.Drawing.Size(200, 122);
            this.grpBoxActions.TabIndex = 24;
            this.grpBoxActions.TabStop = false;
            this.grpBoxActions.Text = "Actions";
            // 
            // btnRemoteWipe
            // 
            this.btnRemoteWipe.Location = new System.Drawing.Point(20, 82);
            this.btnRemoteWipe.Name = "btnRemoteWipe";
            this.btnRemoteWipe.Size = new System.Drawing.Size(160, 23);
            this.btnRemoteWipe.TabIndex = 31;
            this.btnRemoteWipe.Text = "Remote Wipe (Emulated)";
            this.btnRemoteWipe.UseVisualStyleBackColor = true;
            this.btnRemoteWipe.Click += new System.EventHandler(this.btnRemoteWipe_Click);
            // 
            // btnBasicTest
            // 
            this.btnBasicTest.Location = new System.Drawing.Point(20, 20);
            this.btnBasicTest.Name = "btnBasicTest";
            this.btnBasicTest.Size = new System.Drawing.Size(160, 23);
            this.btnBasicTest.TabIndex = 13;
            this.btnBasicTest.Text = "Basic Connectivity Test";
            this.btnBasicTest.UseVisualStyleBackColor = true;
            this.btnBasicTest.Click += new System.EventHandler(this.btnBasicTest_Click);
            // 
            // btnFullTest
            // 
            this.btnFullTest.Location = new System.Drawing.Point(20, 51);
            this.btnFullTest.Name = "btnFullTest";
            this.btnFullTest.Size = new System.Drawing.Size(160, 23);
            this.btnFullTest.TabIndex = 14;
            this.btnFullTest.Text = "Full Sync Test";
            this.btnFullTest.UseVisualStyleBackColor = true;
            this.btnFullTest.Click += new System.EventHandler(this.btnFullTest_Click);
            // 
            // grpBoxConParams
            // 
            this.grpBoxConParams.Controls.Add(this.lblClientCertPassword);
            this.grpBoxConParams.Controls.Add(this.txtClientCertPassword);
            this.grpBoxConParams.Controls.Add(this.txtClientCertPath);
            this.grpBoxConParams.Controls.Add(this.chkUseClientCert);
            this.grpBoxConParams.Controls.Add(this.lblSAInfo);
            this.grpBoxConParams.Controls.Add(this.lblUsername);
            this.grpBoxConParams.Controls.Add(this.lblPassword);
            this.grpBoxConParams.Controls.Add(this.lblDomain);
            this.grpBoxConParams.Controls.Add(this.txtUsername);
            this.grpBoxConParams.Controls.Add(this.txtPassword);
            this.grpBoxConParams.Controls.Add(this.txtDomain);
            this.grpBoxConParams.Controls.Add(this.lblServerAddress);
            this.grpBoxConParams.Controls.Add(this.chkUseSSL);
            this.grpBoxConParams.Controls.Add(this.txtServerAddress);
            this.grpBoxConParams.Location = new System.Drawing.Point(10, 10);
            this.grpBoxConParams.Name = "grpBoxConParams";
            this.grpBoxConParams.Size = new System.Drawing.Size(200, 267);
            this.grpBoxConParams.TabIndex = 22;
            this.grpBoxConParams.TabStop = false;
            this.grpBoxConParams.Text = "Connection Parameters";
            // 
            // lblClientCertPassword
            // 
            this.lblClientCertPassword.AutoSize = true;
            this.lblClientCertPassword.Location = new System.Drawing.Point(6, 222);
            this.lblClientCertPassword.Name = "lblClientCertPassword";
            this.lblClientCertPassword.Size = new System.Drawing.Size(170, 13);
            this.lblClientCertPassword.TabIndex = 14;
            this.lblClientCertPassword.Text = "Certificate password (if applicable):";
            // 
            // txtClientCertPassword
            // 
            this.txtClientCertPassword.Location = new System.Drawing.Point(6, 240);
            this.txtClientCertPassword.Name = "txtClientCertPassword";
            this.txtClientCertPassword.PasswordChar = '*';
            this.txtClientCertPassword.Size = new System.Drawing.Size(185, 20);
            this.txtClientCertPassword.TabIndex = 13;
            // 
            // txtClientCertPath
            // 
            this.txtClientCertPath.Location = new System.Drawing.Point(6, 200);
            this.txtClientCertPath.Name = "txtClientCertPath";
            this.txtClientCertPath.Size = new System.Drawing.Size(186, 20);
            this.txtClientCertPath.TabIndex = 12;
            this.txtClientCertPath.Text = "C:\\Certificates\\User.cer (Example)";
            // 
            // chkUseClientCert
            // 
            this.chkUseClientCert.AutoSize = true;
            this.chkUseClientCert.Location = new System.Drawing.Point(6, 180);
            this.chkUseClientCert.Name = "chkUseClientCert";
            this.chkUseClientCert.Size = new System.Drawing.Size(193, 17);
            this.chkUseClientCert.TabIndex = 11;
            this.chkUseClientCert.Text = "Use Client Certificate (Specify Path)";
            this.chkUseClientCert.UseVisualStyleBackColor = true;
            // 
            // lblSAInfo
            // 
            this.lblSAInfo.AutoSize = true;
            this.lblSAInfo.Location = new System.Drawing.Point(6, 140);
            this.lblSAInfo.Name = "lblSAInfo";
            this.lblSAInfo.Size = new System.Drawing.Size(175, 13);
            this.lblSAInfo.TabIndex = 10;
            this.lblSAInfo.Text = "Only FQDN - don\'t include http(s)://";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(6, 16);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(6, 46);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Location = new System.Drawing.Point(6, 78);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(46, 13);
            this.lblDomain.TabIndex = 2;
            this.lblDomain.Text = "Domain:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(66, 16);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(66, 46);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(66, 76);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(100, 20);
            this.txtDomain.TabIndex = 5;
            // 
            // lblServerAddress
            // 
            this.lblServerAddress.AutoSize = true;
            this.lblServerAddress.Location = new System.Drawing.Point(6, 106);
            this.lblServerAddress.Name = "lblServerAddress";
            this.lblServerAddress.Size = new System.Drawing.Size(82, 13);
            this.lblServerAddress.TabIndex = 6;
            this.lblServerAddress.Text = "Server Address:";
            // 
            // chkUseSSL
            // 
            this.chkUseSSL.AutoSize = true;
            this.chkUseSSL.Location = new System.Drawing.Point(6, 160);
            this.chkUseSSL.Name = "chkUseSSL";
            this.chkUseSSL.Size = new System.Drawing.Size(68, 17);
            this.chkUseSSL.TabIndex = 9;
            this.chkUseSSL.Text = "Use SSL";
            this.chkUseSSL.UseVisualStyleBackColor = true;
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Location = new System.Drawing.Point(6, 120);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(186, 20);
            this.txtServerAddress.TabIndex = 7;
            // 
            // grpBoxDevParams
            // 
            this.grpBoxDevParams.Controls.Add(this.lblDeviceId);
            this.grpBoxDevParams.Controls.Add(this.txtUserAgent);
            this.grpBoxDevParams.Controls.Add(this.lblDeviceType);
            this.grpBoxDevParams.Controls.Add(this.txtDeviceType);
            this.grpBoxDevParams.Controls.Add(this.lblUserAgent);
            this.grpBoxDevParams.Controls.Add(this.txtDeviceId);
            this.grpBoxDevParams.Location = new System.Drawing.Point(220, 10);
            this.grpBoxDevParams.Name = "grpBoxDevParams";
            this.grpBoxDevParams.Size = new System.Drawing.Size(284, 100);
            this.grpBoxDevParams.TabIndex = 21;
            this.grpBoxDevParams.TabStop = false;
            this.grpBoxDevParams.Text = "Device Parameters";
            // 
            // lblDeviceId
            // 
            this.lblDeviceId.AutoSize = true;
            this.lblDeviceId.Location = new System.Drawing.Point(6, 16);
            this.lblDeviceId.Name = "lblDeviceId";
            this.lblDeviceId.Size = new System.Drawing.Size(56, 13);
            this.lblDeviceId.TabIndex = 15;
            this.lblDeviceId.Text = "Device Id:";
            // 
            // txtUserAgent
            // 
            this.txtUserAgent.Location = new System.Drawing.Point(102, 76);
            this.txtUserAgent.Name = "txtUserAgent";
            this.txtUserAgent.Size = new System.Drawing.Size(176, 20);
            this.txtUserAgent.TabIndex = 20;
            // 
            // lblDeviceType
            // 
            this.lblDeviceType.AutoSize = true;
            this.lblDeviceType.Location = new System.Drawing.Point(6, 46);
            this.lblDeviceType.Name = "lblDeviceType";
            this.lblDeviceType.Size = new System.Drawing.Size(68, 13);
            this.lblDeviceType.TabIndex = 16;
            this.lblDeviceType.Text = "Device Type";
            // 
            // txtDeviceType
            // 
            this.txtDeviceType.Location = new System.Drawing.Point(102, 46);
            this.txtDeviceType.Name = "txtDeviceType";
            this.txtDeviceType.Size = new System.Drawing.Size(176, 20);
            this.txtDeviceType.TabIndex = 19;
            // 
            // lblUserAgent
            // 
            this.lblUserAgent.AutoSize = true;
            this.lblUserAgent.Location = new System.Drawing.Point(6, 76);
            this.lblUserAgent.Name = "lblUserAgent";
            this.lblUserAgent.Size = new System.Drawing.Size(63, 13);
            this.lblUserAgent.TabIndex = 17;
            this.lblUserAgent.Text = "User Agent:";
            // 
            // txtDeviceId
            // 
            this.txtDeviceId.Location = new System.Drawing.Point(102, 16);
            this.txtDeviceId.Name = "txtDeviceId";
            this.txtDeviceId.Size = new System.Drawing.Size(176, 20);
            this.txtDeviceId.TabIndex = 18;
            // 
            // grpBoxDevProps
            // 
            this.grpBoxDevProps.Controls.Add(this.chkFakeSecPol);
            this.grpBoxDevProps.Controls.Add(this.chkProvisionable);
            this.grpBoxDevProps.Controls.Add(this.chkTrustAllCerts);
            this.grpBoxDevProps.Location = new System.Drawing.Point(520, 10);
            this.grpBoxDevProps.Name = "grpBoxDevProps";
            this.grpBoxDevProps.Size = new System.Drawing.Size(200, 100);
            this.grpBoxDevProps.TabIndex = 10;
            this.grpBoxDevProps.TabStop = false;
            this.grpBoxDevProps.Text = "Device Properties";
            // 
            // chkFakeSecPol
            // 
            this.chkFakeSecPol.AutoSize = true;
            this.chkFakeSecPol.Location = new System.Drawing.Point(6, 76);
            this.chkFakeSecPol.Name = "chkFakeSecPol";
            this.chkFakeSecPol.Size = new System.Drawing.Size(140, 17);
            this.chkFakeSecPol.TabIndex = 12;
            this.chkFakeSecPol.Text = "Support security policies";
            this.chkFakeSecPol.UseVisualStyleBackColor = true;
            // 
            // chkProvisionable
            // 
            this.chkProvisionable.AutoSize = true;
            this.chkProvisionable.Location = new System.Drawing.Point(6, 16);
            this.chkProvisionable.Name = "chkProvisionable";
            this.chkProvisionable.Size = new System.Drawing.Size(89, 17);
            this.chkProvisionable.TabIndex = 13;
            this.chkProvisionable.Text = "Provisionable";
            this.chkProvisionable.UseVisualStyleBackColor = true;
            // 
            // chkTrustAllCerts
            // 
            this.chkTrustAllCerts.AutoSize = true;
            this.chkTrustAllCerts.Location = new System.Drawing.Point(6, 46);
            this.chkTrustAllCerts.Name = "chkTrustAllCerts";
            this.chkTrustAllCerts.Size = new System.Drawing.Size(117, 17);
            this.chkTrustAllCerts.TabIndex = 11;
            this.chkTrustAllCerts.Text = "Trust all certificates";
            this.chkTrustAllCerts.UseVisualStyleBackColor = true;
            // 
            // tabDevInfo
            // 
            this.tabDevInfo.Controls.Add(this.grpBoxDevInfo);
            this.tabDevInfo.Location = new System.Drawing.Point(4, 22);
            this.tabDevInfo.Name = "tabDevInfo";
            this.tabDevInfo.Size = new System.Drawing.Size(729, 555);
            this.tabDevInfo.TabIndex = 3;
            this.tabDevInfo.Text = "Device Information";
            this.tabDevInfo.UseVisualStyleBackColor = true;
            // 
            // grpBoxDevInfo
            // 
            this.grpBoxDevInfo.Controls.Add(this.txtDevInf);
            this.grpBoxDevInfo.Controls.Add(this.txtDevOSLang);
            this.grpBoxDevInfo.Controls.Add(this.txtDevUA);
            this.grpBoxDevInfo.Controls.Add(this.txtDevMO);
            this.grpBoxDevInfo.Controls.Add(this.txtDevPhoneNr);
            this.grpBoxDevInfo.Controls.Add(this.txtDevOS);
            this.grpBoxDevInfo.Controls.Add(this.txtDevFriendly);
            this.grpBoxDevInfo.Controls.Add(this.txtDevIMEI);
            this.grpBoxDevInfo.Controls.Add(this.txtDevModel);
            this.grpBoxDevInfo.Controls.Add(this.lblDevUA);
            this.grpBoxDevInfo.Controls.Add(this.lblDevMO);
            this.grpBoxDevInfo.Controls.Add(this.lblDevPhoneNr);
            this.grpBoxDevInfo.Controls.Add(this.lblDevOSLang);
            this.grpBoxDevInfo.Controls.Add(this.lblDevOS);
            this.grpBoxDevInfo.Controls.Add(this.lblDevFriendly);
            this.grpBoxDevInfo.Controls.Add(this.lblDevIMEI);
            this.grpBoxDevInfo.Controls.Add(this.lblDevMod);
            this.grpBoxDevInfo.Location = new System.Drawing.Point(3, 3);
            this.grpBoxDevInfo.Name = "grpBoxDevInfo";
            this.grpBoxDevInfo.Size = new System.Drawing.Size(457, 352);
            this.grpBoxDevInfo.TabIndex = 0;
            this.grpBoxDevInfo.TabStop = false;
            this.grpBoxDevInfo.Text = "Device Information";
            // 
            // txtDevInf
            // 
            this.txtDevInf.BackColor = System.Drawing.Color.White;
            this.txtDevInf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDevInf.Location = new System.Drawing.Point(10, 275);
            this.txtDevInf.Multiline = true;
            this.txtDevInf.Name = "txtDevInf";
            this.txtDevInf.ReadOnly = true;
            this.txtDevInf.Size = new System.Drawing.Size(297, 55);
            this.txtDevInf.TabIndex = 16;
            this.txtDevInf.Text = "Provides Device Information that can be viewed in OWA. \r\nNote: Only works when pr" +
    "ovisioning with EAS Version 14.1 (Exchange 2010 SP1 / Exchange 2013.)";
            // 
            // txtDevOSLang
            // 
            this.txtDevOSLang.Location = new System.Drawing.Point(150, 132);
            this.txtDevOSLang.Name = "txtDevOSLang";
            this.txtDevOSLang.Size = new System.Drawing.Size(120, 20);
            this.txtDevOSLang.TabIndex = 15;
            this.txtDevOSLang.Text = "Nadsat";
            // 
            // txtDevUA
            // 
            this.txtDevUA.Location = new System.Drawing.Point(150, 225);
            this.txtDevUA.Name = "txtDevUA";
            this.txtDevUA.Size = new System.Drawing.Size(120, 20);
            this.txtDevUA.TabIndex = 14;
            this.txtDevUA.Text = "MobilityDojo.net";
            // 
            // txtDevMO
            // 
            this.txtDevMO.Location = new System.Drawing.Point(150, 195);
            this.txtDevMO.Name = "txtDevMO";
            this.txtDevMO.Size = new System.Drawing.Size(120, 20);
            this.txtDevMO.TabIndex = 13;
            this.txtDevMO.Text = "MobilityDojo";
            // 
            // txtDevPhoneNr
            // 
            this.txtDevPhoneNr.Location = new System.Drawing.Point(150, 165);
            this.txtDevPhoneNr.Name = "txtDevPhoneNr";
            this.txtDevPhoneNr.Size = new System.Drawing.Size(120, 20);
            this.txtDevPhoneNr.TabIndex = 12;
            this.txtDevPhoneNr.Text = "1-800-555";
            // 
            // txtDevOS
            // 
            this.txtDevOS.Location = new System.Drawing.Point(150, 105);
            this.txtDevOS.Name = "txtDevOS";
            this.txtDevOS.Size = new System.Drawing.Size(120, 20);
            this.txtDevOS.TabIndex = 11;
            this.txtDevOS.Text = "andyOS 0x1";
            // 
            // txtDevFriendly
            // 
            this.txtDevFriendly.Location = new System.Drawing.Point(150, 75);
            this.txtDevFriendly.Name = "txtDevFriendly";
            this.txtDevFriendly.Size = new System.Drawing.Size(120, 20);
            this.txtDevFriendly.TabIndex = 10;
            this.txtDevFriendly.Text = "I Am Not for Real";
            // 
            // txtDevIMEI
            // 
            this.txtDevIMEI.Location = new System.Drawing.Point(150, 45);
            this.txtDevIMEI.Name = "txtDevIMEI";
            this.txtDevIMEI.Size = new System.Drawing.Size(120, 20);
            this.txtDevIMEI.TabIndex = 9;
            this.txtDevIMEI.Text = "0123456789ABCDEF";
            // 
            // txtDevModel
            // 
            this.txtDevModel.Location = new System.Drawing.Point(150, 15);
            this.txtDevModel.Name = "txtDevModel";
            this.txtDevModel.Size = new System.Drawing.Size(120, 20);
            this.txtDevModel.TabIndex = 8;
            this.txtDevModel.Text = "AirWolf";
            // 
            // lblDevUA
            // 
            this.lblDevUA.AutoSize = true;
            this.lblDevUA.Location = new System.Drawing.Point(10, 225);
            this.lblDevUA.Name = "lblDevUA";
            this.lblDevUA.Size = new System.Drawing.Size(100, 13);
            this.lblDevUA.TabIndex = 7;
            this.lblDevUA.Text = "Device User Agent:";
            // 
            // lblDevMO
            // 
            this.lblDevMO.AutoSize = true;
            this.lblDevMO.Location = new System.Drawing.Point(10, 195);
            this.lblDevMO.Name = "lblDevMO";
            this.lblDevMO.Size = new System.Drawing.Size(122, 13);
            this.lblDevMO.TabIndex = 6;
            this.lblDevMO.Text = "Device Mobile Operator:";
            // 
            // lblDevPhoneNr
            // 
            this.lblDevPhoneNr.AutoSize = true;
            this.lblDevPhoneNr.Location = new System.Drawing.Point(10, 165);
            this.lblDevPhoneNr.Name = "lblDevPhoneNr";
            this.lblDevPhoneNr.Size = new System.Drawing.Size(118, 13);
            this.lblDevPhoneNr.TabIndex = 5;
            this.lblDevPhoneNr.Text = "Device Phone Number:";
            // 
            // lblDevOSLang
            // 
            this.lblDevOSLang.AutoSize = true;
            this.lblDevOSLang.Location = new System.Drawing.Point(10, 135);
            this.lblDevOSLang.Name = "lblDevOSLang";
            this.lblDevOSLang.Size = new System.Drawing.Size(113, 13);
            this.lblDevOSLang.TabIndex = 4;
            this.lblDevOSLang.Text = "Device OS Language:";
            // 
            // lblDevOS
            // 
            this.lblDevOS.AutoSize = true;
            this.lblDevOS.Location = new System.Drawing.Point(10, 105);
            this.lblDevOS.Name = "lblDevOS";
            this.lblDevOS.Size = new System.Drawing.Size(62, 13);
            this.lblDevOS.TabIndex = 3;
            this.lblDevOS.Text = "Device OS:";
            // 
            // lblDevFriendly
            // 
            this.lblDevFriendly.AutoSize = true;
            this.lblDevFriendly.Location = new System.Drawing.Point(10, 75);
            this.lblDevFriendly.Name = "lblDevFriendly";
            this.lblDevFriendly.Size = new System.Drawing.Size(111, 13);
            this.lblDevFriendly.TabIndex = 2;
            this.lblDevFriendly.Text = "Device FriendlyName:";
            // 
            // lblDevIMEI
            // 
            this.lblDevIMEI.AutoSize = true;
            this.lblDevIMEI.Location = new System.Drawing.Point(10, 45);
            this.lblDevIMEI.Name = "lblDevIMEI";
            this.lblDevIMEI.Size = new System.Drawing.Size(69, 13);
            this.lblDevIMEI.TabIndex = 1;
            this.lblDevIMEI.Text = "Device IMEI:";
            // 
            // lblDevMod
            // 
            this.lblDevMod.AutoSize = true;
            this.lblDevMod.Location = new System.Drawing.Point(10, 15);
            this.lblDevMod.Name = "lblDevMod";
            this.lblDevMod.Size = new System.Drawing.Size(76, 13);
            this.lblDevMod.TabIndex = 0;
            this.lblDevMod.Text = "Device Model:";
            // 
            // tabAutodiscover
            // 
            this.tabAutodiscover.Controls.Add(this.grpBoxAutodiscoverOutput);
            this.tabAutodiscover.Controls.Add(this.grpBoxAutodiscoverTests);
            this.tabAutodiscover.Controls.Add(this.grpBoxAutodiscoverCredentials);
            this.tabAutodiscover.Location = new System.Drawing.Point(4, 22);
            this.tabAutodiscover.Name = "tabAutodiscover";
            this.tabAutodiscover.Size = new System.Drawing.Size(729, 555);
            this.tabAutodiscover.TabIndex = 5;
            this.tabAutodiscover.Text = "Autodiscover";
            this.tabAutodiscover.UseVisualStyleBackColor = true;
            // 
            // grpBoxAutodiscoverOutput
            // 
            this.grpBoxAutodiscoverOutput.Controls.Add(this.txtAutodiscoverOutput);
            this.grpBoxAutodiscoverOutput.Location = new System.Drawing.Point(237, 127);
            this.grpBoxAutodiscoverOutput.Name = "grpBoxAutodiscoverOutput";
            this.grpBoxAutodiscoverOutput.Size = new System.Drawing.Size(406, 285);
            this.grpBoxAutodiscoverOutput.TabIndex = 2;
            this.grpBoxAutodiscoverOutput.TabStop = false;
            this.grpBoxAutodiscoverOutput.Text = "Output";
            // 
            // txtAutodiscoverOutput
            // 
            this.txtAutodiscoverOutput.Location = new System.Drawing.Point(7, 20);
            this.txtAutodiscoverOutput.Multiline = true;
            this.txtAutodiscoverOutput.Name = "txtAutodiscoverOutput";
            this.txtAutodiscoverOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAutodiscoverOutput.Size = new System.Drawing.Size(393, 259);
            this.txtAutodiscoverOutput.TabIndex = 0;
            // 
            // grpBoxAutodiscoverTests
            // 
            this.grpBoxAutodiscoverTests.Controls.Add(this.chkAutodiscoverTest3);
            this.grpBoxAutodiscoverTests.Controls.Add(this.chkAutodiscoverTest2);
            this.grpBoxAutodiscoverTests.Controls.Add(this.chkAutodiscoverTest1);
            this.grpBoxAutodiscoverTests.Controls.Add(this.chkAutodiscoverTest0);
            this.grpBoxAutodiscoverTests.Location = new System.Drawing.Point(237, 10);
            this.grpBoxAutodiscoverTests.Name = "grpBoxAutodiscoverTests";
            this.grpBoxAutodiscoverTests.Size = new System.Drawing.Size(406, 110);
            this.grpBoxAutodiscoverTests.TabIndex = 1;
            this.grpBoxAutodiscoverTests.TabStop = false;
            this.grpBoxAutodiscoverTests.Text = "Autodiscover Tests";
            // 
            // chkAutodiscoverTest3
            // 
            this.chkAutodiscoverTest3.AutoSize = true;
            this.chkAutodiscoverTest3.Enabled = false;
            this.chkAutodiscoverTest3.Location = new System.Drawing.Point(7, 80);
            this.chkAutodiscoverTest3.Name = "chkAutodiscoverTest3";
            this.chkAutodiscoverTest3.Size = new System.Drawing.Size(312, 17);
            this.chkAutodiscoverTest3.TabIndex = 3;
            this.chkAutodiscoverTest3.Text = "SRV query _autodiscover._tcp.FQDN (Not implemented yet.)";
            this.chkAutodiscoverTest3.UseVisualStyleBackColor = true;
            // 
            // chkAutodiscoverTest2
            // 
            this.chkAutodiscoverTest2.AutoSize = true;
            this.chkAutodiscoverTest2.Checked = true;
            this.chkAutodiscoverTest2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutodiscoverTest2.Location = new System.Drawing.Point(7, 60);
            this.chkAutodiscoverTest2.Name = "chkAutodiscoverTest2";
            this.chkAutodiscoverTest2.Size = new System.Drawing.Size(364, 17);
            this.chkAutodiscoverTest2.TabIndex = 2;
            this.chkAutodiscoverTest2.Text = "http://autodiscover.FQDN/autodiscover/autodiscover.xml (HTTP GET)";
            this.chkAutodiscoverTest2.UseVisualStyleBackColor = true;
            // 
            // chkAutodiscoverTest1
            // 
            this.chkAutodiscoverTest1.AutoSize = true;
            this.chkAutodiscoverTest1.Checked = true;
            this.chkAutodiscoverTest1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutodiscoverTest1.Location = new System.Drawing.Point(7, 40);
            this.chkAutodiscoverTest1.Name = "chkAutodiscoverTest1";
            this.chkAutodiscoverTest1.Size = new System.Drawing.Size(306, 17);
            this.chkAutodiscoverTest1.TabIndex = 1;
            this.chkAutodiscoverTest1.Text = "https://autodiscover.FQDN/autodiscover/autodiscover.xml";
            this.chkAutodiscoverTest1.UseVisualStyleBackColor = true;
            // 
            // chkAutodiscoverTest0
            // 
            this.chkAutodiscoverTest0.AutoSize = true;
            this.chkAutodiscoverTest0.Checked = true;
            this.chkAutodiscoverTest0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutodiscoverTest0.Location = new System.Drawing.Point(7, 20);
            this.chkAutodiscoverTest0.Name = "chkAutodiscoverTest0";
            this.chkAutodiscoverTest0.Size = new System.Drawing.Size(242, 17);
            this.chkAutodiscoverTest0.TabIndex = 0;
            this.chkAutodiscoverTest0.Text = "https://FQDN/autodiscover/autodiscover.xml";
            this.chkAutodiscoverTest0.UseVisualStyleBackColor = true;
            // 
            // grpBoxAutodiscoverCredentials
            // 
            this.grpBoxAutodiscoverCredentials.Controls.Add(this.chkTrustCertsAutodiscover);
            this.grpBoxAutodiscoverCredentials.Controls.Add(this.btnClearAutodiscoverOutput);
            this.grpBoxAutodiscoverCredentials.Controls.Add(this.btnAutodiscoverRunTests);
            this.grpBoxAutodiscoverCredentials.Controls.Add(this.txtAutodiscoverInf);
            this.grpBoxAutodiscoverCredentials.Controls.Add(this.lblAutodiscoverUsername);
            this.grpBoxAutodiscoverCredentials.Controls.Add(this.lblAutodiscoverDomain);
            this.grpBoxAutodiscoverCredentials.Controls.Add(this.txtAutodiscoverUsername);
            this.grpBoxAutodiscoverCredentials.Controls.Add(this.txtAutodiscoverDomain);
            this.grpBoxAutodiscoverCredentials.Controls.Add(this.txtAutodiscoverPassword);
            this.grpBoxAutodiscoverCredentials.Controls.Add(this.txtAutodiscoverEmailAddress);
            this.grpBoxAutodiscoverCredentials.Controls.Add(this.lblAutodiscoverPassword);
            this.grpBoxAutodiscoverCredentials.Controls.Add(this.lblAutodiscoverEmailAddress);
            this.grpBoxAutodiscoverCredentials.Location = new System.Drawing.Point(10, 10);
            this.grpBoxAutodiscoverCredentials.Name = "grpBoxAutodiscoverCredentials";
            this.grpBoxAutodiscoverCredentials.Size = new System.Drawing.Size(200, 402);
            this.grpBoxAutodiscoverCredentials.TabIndex = 0;
            this.grpBoxAutodiscoverCredentials.TabStop = false;
            this.grpBoxAutodiscoverCredentials.Text = "User Credentials";
            // 
            // chkTrustCertsAutodiscover
            // 
            this.chkTrustCertsAutodiscover.AutoSize = true;
            this.chkTrustCertsAutodiscover.Location = new System.Drawing.Point(6, 120);
            this.chkTrustCertsAutodiscover.Name = "chkTrustCertsAutodiscover";
            this.chkTrustCertsAutodiscover.Size = new System.Drawing.Size(117, 17);
            this.chkTrustCertsAutodiscover.TabIndex = 13;
            this.chkTrustCertsAutodiscover.Text = "Trust all certificates";
            this.chkTrustCertsAutodiscover.UseVisualStyleBackColor = true;
            // 
            // btnClearAutodiscoverOutput
            // 
            this.btnClearAutodiscoverOutput.Location = new System.Drawing.Point(119, 369);
            this.btnClearAutodiscoverOutput.Name = "btnClearAutodiscoverOutput";
            this.btnClearAutodiscoverOutput.Size = new System.Drawing.Size(75, 23);
            this.btnClearAutodiscoverOutput.TabIndex = 12;
            this.btnClearAutodiscoverOutput.Text = "Clear Output";
            this.btnClearAutodiscoverOutput.UseVisualStyleBackColor = true;
            this.btnClearAutodiscoverOutput.Click += new System.EventHandler(this.btnClearAutodiscoverOutput_Click);
            // 
            // btnAutodiscoverRunTests
            // 
            this.btnAutodiscoverRunTests.Location = new System.Drawing.Point(6, 369);
            this.btnAutodiscoverRunTests.Name = "btnAutodiscoverRunTests";
            this.btnAutodiscoverRunTests.Size = new System.Drawing.Size(75, 23);
            this.btnAutodiscoverRunTests.TabIndex = 11;
            this.btnAutodiscoverRunTests.Text = "Run Tests";
            this.btnAutodiscoverRunTests.UseVisualStyleBackColor = true;
            this.btnAutodiscoverRunTests.Click += new System.EventHandler(this.btnAutodiscoverRunTests_Click);
            // 
            // txtAutodiscoverInf
            // 
            this.txtAutodiscoverInf.BackColor = System.Drawing.Color.White;
            this.txtAutodiscoverInf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAutodiscoverInf.Location = new System.Drawing.Point(6, 141);
            this.txtAutodiscoverInf.Multiline = true;
            this.txtAutodiscoverInf.Name = "txtAutodiscoverInf";
            this.txtAutodiscoverInf.ReadOnly = true;
            this.txtAutodiscoverInf.Size = new System.Drawing.Size(188, 62);
            this.txtAutodiscoverInf.TabIndex = 10;
            this.txtAutodiscoverInf.Text = "Username & domain is only needed if authentication fails when using UPN format. \r" +
    "\n(HTTP 401 returned.)";
            // 
            // lblAutodiscoverUsername
            // 
            this.lblAutodiscoverUsername.AutoSize = true;
            this.lblAutodiscoverUsername.Location = new System.Drawing.Point(6, 224);
            this.lblAutodiscoverUsername.Name = "lblAutodiscoverUsername";
            this.lblAutodiscoverUsername.Size = new System.Drawing.Size(58, 13);
            this.lblAutodiscoverUsername.TabIndex = 6;
            this.lblAutodiscoverUsername.Text = "Username:";
            // 
            // lblAutodiscoverDomain
            // 
            this.lblAutodiscoverDomain.AutoSize = true;
            this.lblAutodiscoverDomain.Location = new System.Drawing.Point(6, 284);
            this.lblAutodiscoverDomain.Name = "lblAutodiscoverDomain";
            this.lblAutodiscoverDomain.Size = new System.Drawing.Size(46, 13);
            this.lblAutodiscoverDomain.TabIndex = 7;
            this.lblAutodiscoverDomain.Text = "Domain:";
            // 
            // txtAutodiscoverUsername
            // 
            this.txtAutodiscoverUsername.Location = new System.Drawing.Point(6, 244);
            this.txtAutodiscoverUsername.Name = "txtAutodiscoverUsername";
            this.txtAutodiscoverUsername.Size = new System.Drawing.Size(188, 20);
            this.txtAutodiscoverUsername.TabIndex = 8;
            // 
            // txtAutodiscoverDomain
            // 
            this.txtAutodiscoverDomain.Location = new System.Drawing.Point(6, 304);
            this.txtAutodiscoverDomain.Name = "txtAutodiscoverDomain";
            this.txtAutodiscoverDomain.Size = new System.Drawing.Size(188, 20);
            this.txtAutodiscoverDomain.TabIndex = 9;
            // 
            // txtAutodiscoverPassword
            // 
            this.txtAutodiscoverPassword.Location = new System.Drawing.Point(6, 90);
            this.txtAutodiscoverPassword.Name = "txtAutodiscoverPassword";
            this.txtAutodiscoverPassword.PasswordChar = '*';
            this.txtAutodiscoverPassword.Size = new System.Drawing.Size(188, 20);
            this.txtAutodiscoverPassword.TabIndex = 3;
            // 
            // txtAutodiscoverEmailAddress
            // 
            this.txtAutodiscoverEmailAddress.Location = new System.Drawing.Point(6, 40);
            this.txtAutodiscoverEmailAddress.Name = "txtAutodiscoverEmailAddress";
            this.txtAutodiscoverEmailAddress.Size = new System.Drawing.Size(188, 20);
            this.txtAutodiscoverEmailAddress.TabIndex = 2;
            // 
            // lblAutodiscoverPassword
            // 
            this.lblAutodiscoverPassword.AutoSize = true;
            this.lblAutodiscoverPassword.Location = new System.Drawing.Point(6, 70);
            this.lblAutodiscoverPassword.Name = "lblAutodiscoverPassword";
            this.lblAutodiscoverPassword.Size = new System.Drawing.Size(56, 13);
            this.lblAutodiscoverPassword.TabIndex = 1;
            this.lblAutodiscoverPassword.Text = "Password:";
            // 
            // lblAutodiscoverEmailAddress
            // 
            this.lblAutodiscoverEmailAddress.AutoSize = true;
            this.lblAutodiscoverEmailAddress.Location = new System.Drawing.Point(6, 20);
            this.lblAutodiscoverEmailAddress.Name = "lblAutodiscoverEmailAddress";
            this.lblAutodiscoverEmailAddress.Size = new System.Drawing.Size(76, 13);
            this.lblAutodiscoverEmailAddress.TabIndex = 0;
            this.lblAutodiscoverEmailAddress.Text = "Email Address:";
            // 
            // tabWBXML
            // 
            this.tabWBXML.Controls.Add(this.grpBoxWBXML);
            this.tabWBXML.Location = new System.Drawing.Point(4, 22);
            this.tabWBXML.Name = "tabWBXML";
            this.tabWBXML.Padding = new System.Windows.Forms.Padding(3);
            this.tabWBXML.Size = new System.Drawing.Size(729, 555);
            this.tabWBXML.TabIndex = 7;
            this.tabWBXML.Text = "WBXML Utility";
            this.tabWBXML.UseVisualStyleBackColor = true;
            // 
            // grpBoxWBXML
            // 
            this.grpBoxWBXML.Controls.Add(this.label1);
            this.grpBoxWBXML.Controls.Add(this.cBoxCmd);
            this.grpBoxWBXML.Controls.Add(this.txtWbxmlInf);
            this.grpBoxWBXML.Controls.Add(this.lblWbxmlInput);
            this.grpBoxWBXML.Controls.Add(this.btnClearWbxml);
            this.grpBoxWBXML.Controls.Add(this.btnExecuteWbxml);
            this.grpBoxWBXML.Controls.Add(this.txtWbxmlInput);
            this.grpBoxWBXML.Controls.Add(this.lblWbxmlOutput);
            this.grpBoxWBXML.Controls.Add(this.txtWbxmlOutput);
            this.grpBoxWBXML.Location = new System.Drawing.Point(10, 10);
            this.grpBoxWBXML.Name = "grpBoxWBXML";
            this.grpBoxWBXML.Size = new System.Drawing.Size(709, 507);
            this.grpBoxWBXML.TabIndex = 7;
            this.grpBoxWBXML.TabStop = false;
            this.grpBoxWBXML.Text = "WBXML Encoder and Decoder";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Command:";
            // 
            // cBoxCmd
            // 
            this.cBoxCmd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCmd.FormattingEnabled = true;
            this.cBoxCmd.Items.AddRange(new object[] {
            "Autodiscover",
            "FolderCreate",
            "FolderDelete",
            "FolderSync",
            "FolderUpdate",
            "GetAttachment",
            "GetItemEstimate",
            "ItemOperations",
            "MeetingResponse",
            "MoveItems",
            "Ping",
            "Provision",
            "ResolveRecipients",
            "Search",
            "SendMail",
            "Settings",
            "SmartForward",
            "SmartReply",
            "Sync",
            "ValidateCert"});
            this.cBoxCmd.Location = new System.Drawing.Point(310, 120);
            this.cBoxCmd.Name = "cBoxCmd";
            this.cBoxCmd.Size = new System.Drawing.Size(121, 21);
            this.cBoxCmd.TabIndex = 9;
            // 
            // txtWbxmlInf
            // 
            this.txtWbxmlInf.BackColor = System.Drawing.Color.White;
            this.txtWbxmlInf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWbxmlInf.Location = new System.Drawing.Point(25, 30);
            this.txtWbxmlInf.Multiline = true;
            this.txtWbxmlInf.Name = "txtWbxmlInf";
            this.txtWbxmlInf.ReadOnly = true;
            this.txtWbxmlInf.Size = new System.Drawing.Size(664, 81);
            this.txtWbxmlInf.TabIndex = 6;
            this.txtWbxmlInf.Text = resources.GetString("txtWbxmlInf.Text");
            // 
            // lblWbxmlInput
            // 
            this.lblWbxmlInput.AutoSize = true;
            this.lblWbxmlInput.Location = new System.Drawing.Point(25, 160);
            this.lblWbxmlInput.Name = "lblWbxmlInput";
            this.lblWbxmlInput.Size = new System.Drawing.Size(59, 13);
            this.lblWbxmlInput.TabIndex = 2;
            this.lblWbxmlInput.Text = "Input XML:";
            // 
            // btnClearWbxml
            // 
            this.btnClearWbxml.Location = new System.Drawing.Point(160, 120);
            this.btnClearWbxml.Name = "btnClearWbxml";
            this.btnClearWbxml.Size = new System.Drawing.Size(75, 23);
            this.btnClearWbxml.TabIndex = 4;
            this.btnClearWbxml.Text = "Clear";
            this.btnClearWbxml.UseVisualStyleBackColor = true;
            this.btnClearWbxml.Click += new System.EventHandler(this.btnClearWbxml_Click);
            // 
            // btnExecuteWbxml
            // 
            this.btnExecuteWbxml.Location = new System.Drawing.Point(25, 120);
            this.btnExecuteWbxml.Name = "btnExecuteWbxml";
            this.btnExecuteWbxml.Size = new System.Drawing.Size(107, 23);
            this.btnExecuteWbxml.TabIndex = 5;
            this.btnExecuteWbxml.Text = "Execute XML";
            this.btnExecuteWbxml.UseVisualStyleBackColor = true;
            this.btnExecuteWbxml.Click += new System.EventHandler(this.btnExecuteWbxml_Click);
            // 
            // txtWbxmlInput
            // 
            this.txtWbxmlInput.Location = new System.Drawing.Point(25, 180);
            this.txtWbxmlInput.Multiline = true;
            this.txtWbxmlInput.Name = "txtWbxmlInput";
            this.txtWbxmlInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWbxmlInput.Size = new System.Drawing.Size(320, 320);
            this.txtWbxmlInput.TabIndex = 0;
            this.txtWbxmlInput.Text = "<?xml version=\"1.0\" encoding=\"utf-8\"?> \r\n<FolderSync xmlns=\"FolderHierarchy:\"> \r\n" +
    "   <SyncKey>0</SyncKey> \r\n</FolderSync>\r\n";
            // 
            // lblWbxmlOutput
            // 
            this.lblWbxmlOutput.AutoSize = true;
            this.lblWbxmlOutput.Location = new System.Drawing.Point(365, 160);
            this.lblWbxmlOutput.Name = "lblWbxmlOutput";
            this.lblWbxmlOutput.Size = new System.Drawing.Size(67, 13);
            this.lblWbxmlOutput.TabIndex = 3;
            this.lblWbxmlOutput.Text = "Output XML:";
            // 
            // txtWbxmlOutput
            // 
            this.txtWbxmlOutput.Location = new System.Drawing.Point(365, 180);
            this.txtWbxmlOutput.Multiline = true;
            this.txtWbxmlOutput.Name = "txtWbxmlOutput";
            this.txtWbxmlOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWbxmlOutput.Size = new System.Drawing.Size(320, 320);
            this.txtWbxmlOutput.TabIndex = 1;
            // 
            // tabCerts
            // 
            this.tabCerts.Controls.Add(this.grpBoxCertChain);
            this.tabCerts.Location = new System.Drawing.Point(4, 22);
            this.tabCerts.Name = "tabCerts";
            this.tabCerts.Size = new System.Drawing.Size(729, 555);
            this.tabCerts.TabIndex = 2;
            this.tabCerts.Text = "Certificate Info";
            this.tabCerts.UseVisualStyleBackColor = true;
            // 
            // grpBoxCertChain
            // 
            this.grpBoxCertChain.Controls.Add(this.txtCertInf);
            this.grpBoxCertChain.Controls.Add(this.btnClearCertChain);
            this.grpBoxCertChain.Controls.Add(this.lblCertChain);
            this.grpBoxCertChain.Controls.Add(this.txtCertList);
            this.grpBoxCertChain.Controls.Add(this.txtServerAddressSSL);
            this.grpBoxCertChain.Controls.Add(this.btnGetChain);
            this.grpBoxCertChain.Location = new System.Drawing.Point(3, 3);
            this.grpBoxCertChain.Name = "grpBoxCertChain";
            this.grpBoxCertChain.Size = new System.Drawing.Size(573, 514);
            this.grpBoxCertChain.TabIndex = 4;
            this.grpBoxCertChain.TabStop = false;
            this.grpBoxCertChain.Text = "Certificate Chain";
            // 
            // txtCertInf
            // 
            this.txtCertInf.BackColor = System.Drawing.Color.White;
            this.txtCertInf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCertInf.Location = new System.Drawing.Point(270, 40);
            this.txtCertInf.Multiline = true;
            this.txtCertInf.Name = "txtCertInf";
            this.txtCertInf.ReadOnly = true;
            this.txtCertInf.Size = new System.Drawing.Size(297, 55);
            this.txtCertInf.TabIndex = 5;
            this.txtCertInf.Text = "Fetches some basic info on the certificate(s). \r\nThe certificates are also provid" +
    "ed as base64 strings, and can be saved to a text file with the extension .cer fo" +
    "r further use.";
            // 
            // btnClearCertChain
            // 
            this.btnClearCertChain.Location = new System.Drawing.Point(270, 115);
            this.btnClearCertChain.Name = "btnClearCertChain";
            this.btnClearCertChain.Size = new System.Drawing.Size(75, 23);
            this.btnClearCertChain.TabIndex = 4;
            this.btnClearCertChain.Text = "Clear";
            this.btnClearCertChain.UseVisualStyleBackColor = true;
            this.btnClearCertChain.Click += new System.EventHandler(this.btnClearCertChain_Click);
            // 
            // lblCertChain
            // 
            this.lblCertChain.AutoSize = true;
            this.lblCertChain.Location = new System.Drawing.Point(6, 40);
            this.lblCertChain.Name = "lblCertChain";
            this.lblCertChain.Size = new System.Drawing.Size(82, 13);
            this.lblCertChain.TabIndex = 1;
            this.lblCertChain.Text = "Server Address:";
            // 
            // txtCertList
            // 
            this.txtCertList.BackColor = System.Drawing.SystemColors.Window;
            this.txtCertList.Location = new System.Drawing.Point(6, 155);
            this.txtCertList.Multiline = true;
            this.txtCertList.Name = "txtCertList";
            this.txtCertList.ReadOnly = true;
            this.txtCertList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCertList.Size = new System.Drawing.Size(561, 354);
            this.txtCertList.TabIndex = 3;
            // 
            // txtServerAddressSSL
            // 
            this.txtServerAddressSSL.Location = new System.Drawing.Point(6, 75);
            this.txtServerAddressSSL.Name = "txtServerAddressSSL";
            this.txtServerAddressSSL.Size = new System.Drawing.Size(222, 20);
            this.txtServerAddressSSL.TabIndex = 2;
            // 
            // btnGetChain
            // 
            this.btnGetChain.Location = new System.Drawing.Point(6, 115);
            this.btnGetChain.Name = "btnGetChain";
            this.btnGetChain.Size = new System.Drawing.Size(222, 23);
            this.btnGetChain.TabIndex = 0;
            this.btnGetChain.Text = "Get Certificate Chain";
            this.btnGetChain.UseVisualStyleBackColor = true;
            this.btnGetChain.Click += new System.EventHandler(this.btnGetChain_Click);
            // 
            // tabIRM
            // 
            this.tabIRM.Controls.Add(this.grpBoxIRM);
            this.tabIRM.Location = new System.Drawing.Point(4, 22);
            this.tabIRM.Name = "tabIRM";
            this.tabIRM.Size = new System.Drawing.Size(729, 555);
            this.tabIRM.TabIndex = 4;
            this.tabIRM.Text = "Information Rights Management";
            this.tabIRM.UseVisualStyleBackColor = true;
            // 
            // grpBoxIRM
            // 
            this.grpBoxIRM.Controls.Add(this.chkWordWrapIRM);
            this.grpBoxIRM.Controls.Add(this.btnClearIRMOutput);
            this.grpBoxIRM.Controls.Add(this.txtIRMOutput);
            this.grpBoxIRM.Controls.Add(this.btnIRMGetPol);
            this.grpBoxIRM.Controls.Add(this.lblIRMInfo);
            this.grpBoxIRM.Location = new System.Drawing.Point(3, 3);
            this.grpBoxIRM.Name = "grpBoxIRM";
            this.grpBoxIRM.Size = new System.Drawing.Size(608, 394);
            this.grpBoxIRM.TabIndex = 0;
            this.grpBoxIRM.TabStop = false;
            this.grpBoxIRM.Text = "Information Rights Management (IRM)";
            // 
            // chkWordWrapIRM
            // 
            this.chkWordWrapIRM.AutoSize = true;
            this.chkWordWrapIRM.Checked = true;
            this.chkWordWrapIRM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWordWrapIRM.Location = new System.Drawing.Point(258, 100);
            this.chkWordWrapIRM.Name = "chkWordWrapIRM";
            this.chkWordWrapIRM.Size = new System.Drawing.Size(81, 17);
            this.chkWordWrapIRM.TabIndex = 4;
            this.chkWordWrapIRM.Text = "Word Wrap";
            this.chkWordWrapIRM.UseVisualStyleBackColor = true;
            // 
            // btnClearIRMOutput
            // 
            this.btnClearIRMOutput.Location = new System.Drawing.Point(150, 100);
            this.btnClearIRMOutput.Name = "btnClearIRMOutput";
            this.btnClearIRMOutput.Size = new System.Drawing.Size(75, 23);
            this.btnClearIRMOutput.TabIndex = 3;
            this.btnClearIRMOutput.Text = "Clear Output";
            this.btnClearIRMOutput.UseVisualStyleBackColor = true;
            this.btnClearIRMOutput.Click += new System.EventHandler(this.btnClearIRMOutput_Click);
            // 
            // txtIRMOutput
            // 
            this.txtIRMOutput.BackColor = System.Drawing.SystemColors.Window;
            this.txtIRMOutput.Location = new System.Drawing.Point(20, 160);
            this.txtIRMOutput.Multiline = true;
            this.txtIRMOutput.Name = "txtIRMOutput";
            this.txtIRMOutput.ReadOnly = true;
            this.txtIRMOutput.Size = new System.Drawing.Size(550, 210);
            this.txtIRMOutput.TabIndex = 2;
            // 
            // btnIRMGetPol
            // 
            this.btnIRMGetPol.Location = new System.Drawing.Point(20, 100);
            this.btnIRMGetPol.Name = "btnIRMGetPol";
            this.btnIRMGetPol.Size = new System.Drawing.Size(120, 23);
            this.btnIRMGetPol.TabIndex = 1;
            this.btnIRMGetPol.Text = "Get IRM Policies";
            this.btnIRMGetPol.UseVisualStyleBackColor = true;
            this.btnIRMGetPol.Click += new System.EventHandler(this.btnIRMGetPol_Click);
            // 
            // lblIRMInfo
            // 
            this.lblIRMInfo.AutoSize = true;
            this.lblIRMInfo.Location = new System.Drawing.Point(20, 40);
            this.lblIRMInfo.Name = "lblIRMInfo";
            this.lblIRMInfo.Size = new System.Drawing.Size(394, 39);
            this.lblIRMInfo.TabIndex = 0;
            this.lblIRMInfo.Text = resources.GetString("lblIRMInfo.Text");
            // 
            // tabBase64
            // 
            this.tabBase64.Controls.Add(this.grpBoxBase64);
            this.tabBase64.Location = new System.Drawing.Point(4, 22);
            this.tabBase64.Name = "tabBase64";
            this.tabBase64.Padding = new System.Windows.Forms.Padding(3);
            this.tabBase64.Size = new System.Drawing.Size(729, 555);
            this.tabBase64.TabIndex = 1;
            this.tabBase64.Text = "Base64 Utility";
            this.tabBase64.UseVisualStyleBackColor = true;
            // 
            // grpBoxBase64
            // 
            this.grpBoxBase64.Controls.Add(this.txtBase64Inf);
            this.grpBoxBase64.Controls.Add(this.lblConvertSource);
            this.grpBoxBase64.Controls.Add(this.btnBase64Decode);
            this.grpBoxBase64.Controls.Add(this.btnBase64Encode);
            this.grpBoxBase64.Controls.Add(this.txtConvertSource);
            this.grpBoxBase64.Controls.Add(this.lblConvertDest);
            this.grpBoxBase64.Controls.Add(this.txtConvertDest);
            this.grpBoxBase64.Location = new System.Drawing.Point(10, 10);
            this.grpBoxBase64.Name = "grpBoxBase64";
            this.grpBoxBase64.Size = new System.Drawing.Size(650, 510);
            this.grpBoxBase64.TabIndex = 6;
            this.grpBoxBase64.TabStop = false;
            this.grpBoxBase64.Text = "Base64 Encode and Decode";
            // 
            // txtBase64Inf
            // 
            this.txtBase64Inf.BackColor = System.Drawing.Color.White;
            this.txtBase64Inf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBase64Inf.Location = new System.Drawing.Point(25, 30);
            this.txtBase64Inf.Multiline = true;
            this.txtBase64Inf.Name = "txtBase64Inf";
            this.txtBase64Inf.ReadOnly = true;
            this.txtBase64Inf.Size = new System.Drawing.Size(256, 32);
            this.txtBase64Inf.TabIndex = 6;
            this.txtBase64Inf.Text = "Put a plain text string, or base64 string in the source window, and hit encode or" +
    " decode.";
            // 
            // lblConvertSource
            // 
            this.lblConvertSource.AutoSize = true;
            this.lblConvertSource.Location = new System.Drawing.Point(25, 100);
            this.lblConvertSource.Name = "lblConvertSource";
            this.lblConvertSource.Size = new System.Drawing.Size(44, 13);
            this.lblConvertSource.TabIndex = 2;
            this.lblConvertSource.Text = "Source:";
            // 
            // btnBase64Decode
            // 
            this.btnBase64Decode.Location = new System.Drawing.Point(206, 460);
            this.btnBase64Decode.Name = "btnBase64Decode";
            this.btnBase64Decode.Size = new System.Drawing.Size(75, 23);
            this.btnBase64Decode.TabIndex = 4;
            this.btnBase64Decode.Text = "Decode";
            this.btnBase64Decode.UseVisualStyleBackColor = true;
            this.btnBase64Decode.Click += new System.EventHandler(this.btnBase64Decode_Click);
            // 
            // btnBase64Encode
            // 
            this.btnBase64Encode.Location = new System.Drawing.Point(25, 460);
            this.btnBase64Encode.Name = "btnBase64Encode";
            this.btnBase64Encode.Size = new System.Drawing.Size(75, 23);
            this.btnBase64Encode.TabIndex = 5;
            this.btnBase64Encode.Text = "Encode";
            this.btnBase64Encode.UseVisualStyleBackColor = true;
            this.btnBase64Encode.Click += new System.EventHandler(this.btnBase64Encode_Click);
            // 
            // txtConvertSource
            // 
            this.txtConvertSource.Location = new System.Drawing.Point(25, 130);
            this.txtConvertSource.Multiline = true;
            this.txtConvertSource.Name = "txtConvertSource";
            this.txtConvertSource.Size = new System.Drawing.Size(600, 130);
            this.txtConvertSource.TabIndex = 0;
            // 
            // lblConvertDest
            // 
            this.lblConvertDest.AutoSize = true;
            this.lblConvertDest.Location = new System.Drawing.Point(25, 280);
            this.lblConvertDest.Name = "lblConvertDest";
            this.lblConvertDest.Size = new System.Drawing.Size(63, 13);
            this.lblConvertDest.TabIndex = 3;
            this.lblConvertDest.Text = "Destination:";
            // 
            // txtConvertDest
            // 
            this.txtConvertDest.Location = new System.Drawing.Point(25, 310);
            this.txtConvertDest.Multiline = true;
            this.txtConvertDest.Name = "txtConvertDest";
            this.txtConvertDest.Size = new System.Drawing.Size(600, 130);
            this.txtConvertDest.TabIndex = 1;
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.grpBoxAbout);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Size = new System.Drawing.Size(729, 555);
            this.tabAbout.TabIndex = 6;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // grpBoxAbout
            // 
            this.grpBoxAbout.Controls.Add(this.lnkLblGit);
            this.grpBoxAbout.Controls.Add(this.txtAboutSource);
            this.grpBoxAbout.Controls.Add(this.lblAboutCopyright);
            this.grpBoxAbout.Controls.Add(this.lnkLblAbout);
            this.grpBoxAbout.Controls.Add(this.txtAboutFeedback);
            this.grpBoxAbout.Controls.Add(this.lblAboutVer);
            this.grpBoxAbout.Controls.Add(this.lnkLblDownload);
            this.grpBoxAbout.Controls.Add(this.txtAboutDownload);
            this.grpBoxAbout.Location = new System.Drawing.Point(10, 10);
            this.grpBoxAbout.Name = "grpBoxAbout";
            this.grpBoxAbout.Size = new System.Drawing.Size(306, 257);
            this.grpBoxAbout.TabIndex = 0;
            this.grpBoxAbout.TabStop = false;
            this.grpBoxAbout.Text = "About EAS-MD";
            // 
            // lnkLblGit
            // 
            this.lnkLblGit.AutoSize = true;
            this.lnkLblGit.Location = new System.Drawing.Point(10, 170);
            this.lnkLblGit.Name = "lnkLblGit";
            this.lnkLblGit.Size = new System.Drawing.Size(183, 13);
            this.lnkLblGit.TabIndex = 7;
            this.lnkLblGit.TabStop = true;
            this.lnkLblGit.Text = "https://github.com/ahelland/EASMD";
            this.lnkLblGit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblGit_LinkClicked);
            // 
            // txtAboutSource
            // 
            this.txtAboutSource.BackColor = System.Drawing.Color.White;
            this.txtAboutSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAboutSource.Location = new System.Drawing.Point(10, 140);
            this.txtAboutSource.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtAboutSource.Multiline = true;
            this.txtAboutSource.Name = "txtAboutSource";
            this.txtAboutSource.ReadOnly = true;
            this.txtAboutSource.Size = new System.Drawing.Size(272, 33);
            this.txtAboutSource.TabIndex = 6;
            this.txtAboutSource.Text = "Want the source code?\r\nGo to GitHub and retrieve it there (GPLv2):\r\n";
            // 
            // lblAboutCopyright
            // 
            this.lblAboutCopyright.AutoSize = true;
            this.lblAboutCopyright.Location = new System.Drawing.Point(10, 222);
            this.lblAboutCopyright.Name = "lblAboutCopyright";
            this.lblAboutCopyright.Size = new System.Drawing.Size(148, 13);
            this.lblAboutCopyright.TabIndex = 5;
            this.lblAboutCopyright.Text = "© MobilityDojo.net 2010-2014";
            // 
            // lnkLblAbout
            // 
            this.lnkLblAbout.AutoSize = true;
            this.lnkLblAbout.Location = new System.Drawing.Point(10, 120);
            this.lnkLblAbout.Name = "lnkLblAbout";
            this.lnkLblAbout.Size = new System.Drawing.Size(142, 13);
            this.lnkLblAbout.TabIndex = 4;
            this.lnkLblAbout.TabStop = true;
            this.lnkLblAbout.Text = "http://mobilitydojo.net/about";
            this.lnkLblAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblAbout_LinkClicked);
            // 
            // txtAboutFeedback
            // 
            this.txtAboutFeedback.BackColor = System.Drawing.Color.White;
            this.txtAboutFeedback.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAboutFeedback.Location = new System.Drawing.Point(10, 90);
            this.txtAboutFeedback.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtAboutFeedback.Multiline = true;
            this.txtAboutFeedback.Name = "txtAboutFeedback";
            this.txtAboutFeedback.ReadOnly = true;
            this.txtAboutFeedback.Size = new System.Drawing.Size(272, 33);
            this.txtAboutFeedback.TabIndex = 3;
            this.txtAboutFeedback.Text = "Bug reports?\r\nFeature requests or general feedback?\r\nContact me through:";
            // 
            // lblAboutVer
            // 
            this.lblAboutVer.AutoSize = true;
            this.lblAboutVer.Location = new System.Drawing.Point(10, 20);
            this.lblAboutVer.Name = "lblAboutVer";
            this.lblAboutVer.Size = new System.Drawing.Size(197, 13);
            this.lblAboutVer.TabIndex = 2;
            this.lblAboutVer.Text = "Version: 2.0, Release Date August 2014";
            // 
            // lnkLblDownload
            // 
            this.lnkLblDownload.AutoSize = true;
            this.lnkLblDownload.Location = new System.Drawing.Point(10, 70);
            this.lnkLblDownload.Name = "lnkLblDownload";
            this.lnkLblDownload.Size = new System.Drawing.Size(166, 13);
            this.lnkLblDownload.TabIndex = 1;
            this.lnkLblDownload.TabStop = true;
            this.lnkLblDownload.Text = "http://mobilitydojo.net/downloads";
            this.lnkLblDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblDownload_LinkClicked);
            // 
            // txtAboutDownload
            // 
            this.txtAboutDownload.BackColor = System.Drawing.Color.White;
            this.txtAboutDownload.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAboutDownload.Location = new System.Drawing.Point(10, 40);
            this.txtAboutDownload.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.txtAboutDownload.Multiline = true;
            this.txtAboutDownload.Name = "txtAboutDownload";
            this.txtAboutDownload.ReadOnly = true;
            this.txtAboutDownload.Size = new System.Drawing.Size(272, 33);
            this.txtAboutDownload.TabIndex = 0;
            this.txtAboutDownload.Text = "To learn more about this utility and check for new releases, please check out my " +
    "web site:";
            // 
            // frmEAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 578);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmEAS";
            this.Text = "Exchange ActiveSync MD by MobilityDojo.net";
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.grpBoxOutput.ResumeLayout(false);
            this.grpBoxOutput.PerformLayout();
            this.grpBoxASVer.ResumeLayout(false);
            this.grpBoxActions.ResumeLayout(false);
            this.grpBoxConParams.ResumeLayout(false);
            this.grpBoxConParams.PerformLayout();
            this.grpBoxDevParams.ResumeLayout(false);
            this.grpBoxDevParams.PerformLayout();
            this.grpBoxDevProps.ResumeLayout(false);
            this.grpBoxDevProps.PerformLayout();
            this.tabDevInfo.ResumeLayout(false);
            this.grpBoxDevInfo.ResumeLayout(false);
            this.grpBoxDevInfo.PerformLayout();
            this.tabAutodiscover.ResumeLayout(false);
            this.grpBoxAutodiscoverOutput.ResumeLayout(false);
            this.grpBoxAutodiscoverOutput.PerformLayout();
            this.grpBoxAutodiscoverTests.ResumeLayout(false);
            this.grpBoxAutodiscoverTests.PerformLayout();
            this.grpBoxAutodiscoverCredentials.ResumeLayout(false);
            this.grpBoxAutodiscoverCredentials.PerformLayout();
            this.tabWBXML.ResumeLayout(false);
            this.grpBoxWBXML.ResumeLayout(false);
            this.grpBoxWBXML.PerformLayout();
            this.tabCerts.ResumeLayout(false);
            this.grpBoxCertChain.ResumeLayout(false);
            this.grpBoxCertChain.PerformLayout();
            this.tabIRM.ResumeLayout(false);
            this.grpBoxIRM.ResumeLayout(false);
            this.grpBoxIRM.PerformLayout();
            this.tabBase64.ResumeLayout(false);
            this.grpBoxBase64.ResumeLayout(false);
            this.grpBoxBase64.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.grpBoxAbout.ResumeLayout(false);
            this.grpBoxAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabBase64;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtServerAddress;
        private System.Windows.Forms.Label lblServerAddress;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.CheckBox chkUseSSL;
        private System.Windows.Forms.TabPage tabCerts;
        private System.Windows.Forms.CheckBox chkProvisionable;
        private System.Windows.Forms.CheckBox chkFakeSecPol;
        private System.Windows.Forms.CheckBox chkTrustAllCerts;
        private System.Windows.Forms.GroupBox grpBoxDevProps;
        private System.Windows.Forms.TextBox txtCertList;
        private System.Windows.Forms.TextBox txtServerAddressSSL;
        private System.Windows.Forms.Label lblCertChain;
        private System.Windows.Forms.Button btnGetChain;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblUserAgent;
        private System.Windows.Forms.Label lblDeviceType;
        private System.Windows.Forms.Label lblDeviceId;
        private System.Windows.Forms.Button btnFullTest;
        private System.Windows.Forms.Button btnBasicTest;
        private System.Windows.Forms.GroupBox grpBoxConParams;
        private System.Windows.Forms.GroupBox grpBoxDevParams;
        private System.Windows.Forms.TextBox txtUserAgent;
        private System.Windows.Forms.TextBox txtDeviceType;
        private System.Windows.Forms.TextBox txtDeviceId;
        private System.Windows.Forms.GroupBox grpBoxBase64;
        private System.Windows.Forms.Button btnBase64Encode;
        private System.Windows.Forms.Button btnBase64Decode;
        private System.Windows.Forms.Label lblConvertDest;
        private System.Windows.Forms.Label lblConvertSource;
        private System.Windows.Forms.TextBox txtConvertDest;
        private System.Windows.Forms.TextBox txtConvertSource;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.GroupBox grpBoxCertChain;
        private System.Windows.Forms.GroupBox grpBoxActions;
        private System.Windows.Forms.Button btnClearCertChain;
        private System.Windows.Forms.ListView lstASVersions;
        private System.Windows.Forms.GroupBox grpBoxASVer;
        private System.Windows.Forms.GroupBox grpBoxOutput;
        private System.Windows.Forms.TextBox txtBase64Inf;
        private System.Windows.Forms.TextBox txtCertInf;
        private System.Windows.Forms.CheckBox chkBase64;
        private System.Windows.Forms.CheckBox chkHex;
        private System.Windows.Forms.CheckBox chkBinary;
        private System.Windows.Forms.Label lblSAInfo;
        private System.Windows.Forms.TextBox txtClientCertPath;
        private System.Windows.Forms.CheckBox chkUseClientCert;
        private System.Windows.Forms.Button btnRemoteWipe;
        private System.Windows.Forms.TabPage tabDevInfo;
        private System.Windows.Forms.GroupBox grpBoxDevInfo;
        private System.Windows.Forms.Label lblDevUA;
        private System.Windows.Forms.Label lblDevMO;
        private System.Windows.Forms.Label lblDevPhoneNr;
        private System.Windows.Forms.Label lblDevOSLang;
        private System.Windows.Forms.Label lblDevOS;
        private System.Windows.Forms.Label lblDevFriendly;
        private System.Windows.Forms.Label lblDevIMEI;
        private System.Windows.Forms.Label lblDevMod;
        private System.Windows.Forms.TextBox txtDevOSLang;
        private System.Windows.Forms.TextBox txtDevUA;
        private System.Windows.Forms.TextBox txtDevMO;
        private System.Windows.Forms.TextBox txtDevPhoneNr;
        private System.Windows.Forms.TextBox txtDevOS;
        private System.Windows.Forms.TextBox txtDevFriendly;
        private System.Windows.Forms.TextBox txtDevIMEI;
        private System.Windows.Forms.TextBox txtDevModel;
        private System.Windows.Forms.TextBox txtDevInf;
        private System.Windows.Forms.TabPage tabIRM;
        private System.Windows.Forms.GroupBox grpBoxIRM;
        private System.Windows.Forms.TextBox txtIRMOutput;
        private System.Windows.Forms.Button btnIRMGetPol;
        private System.Windows.Forms.Label lblIRMInfo;
        private System.Windows.Forms.CheckBox chkWordWrapMain;
        private System.Windows.Forms.Button btnClearIRMOutput;
        private System.Windows.Forms.CheckBox chkWordWrapIRM;
        private System.Windows.Forms.Label lblClientCertPassword;
        private System.Windows.Forms.TextBox txtClientCertPassword;
        private System.Windows.Forms.TabPage tabAutodiscover;
        private System.Windows.Forms.GroupBox grpBoxAutodiscoverCredentials;
        private System.Windows.Forms.TextBox txtAutodiscoverPassword;
        private System.Windows.Forms.TextBox txtAutodiscoverEmailAddress;
        private System.Windows.Forms.Label lblAutodiscoverPassword;
        private System.Windows.Forms.Label lblAutodiscoverEmailAddress;
        private System.Windows.Forms.GroupBox grpBoxAutodiscoverTests;
        private System.Windows.Forms.CheckBox chkAutodiscoverTest3;
        private System.Windows.Forms.CheckBox chkAutodiscoverTest2;
        private System.Windows.Forms.CheckBox chkAutodiscoverTest1;
        private System.Windows.Forms.CheckBox chkAutodiscoverTest0;
        private System.Windows.Forms.TextBox txtAutodiscoverInf;
        private System.Windows.Forms.Label lblAutodiscoverUsername;
        private System.Windows.Forms.Label lblAutodiscoverDomain;
        private System.Windows.Forms.TextBox txtAutodiscoverUsername;
        private System.Windows.Forms.TextBox txtAutodiscoverDomain;
        private System.Windows.Forms.GroupBox grpBoxAutodiscoverOutput;
        private System.Windows.Forms.TextBox txtAutodiscoverOutput;
        private System.Windows.Forms.Button btnAutodiscoverRunTests;
        private System.Windows.Forms.Button btnClearAutodiscoverOutput;
        private System.Windows.Forms.CheckBox chkTrustCertsAutodiscover;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.GroupBox grpBoxAbout;
        private System.Windows.Forms.TextBox txtAboutDownload;
        private System.Windows.Forms.Label lblAboutVer;
        private System.Windows.Forms.LinkLabel lnkLblDownload;
        private System.Windows.Forms.Label lblAboutCopyright;
        private System.Windows.Forms.LinkLabel lnkLblAbout;
        private System.Windows.Forms.TextBox txtAboutFeedback;
        private System.Windows.Forms.CheckBox chkWBXML;
        private System.Windows.Forms.TabPage tabWBXML;
        private System.Windows.Forms.GroupBox grpBoxWBXML;
        private System.Windows.Forms.TextBox txtWbxmlInf;
        private System.Windows.Forms.Label lblWbxmlInput;
        private System.Windows.Forms.Button btnClearWbxml;
        private System.Windows.Forms.Button btnExecuteWbxml;
        private System.Windows.Forms.TextBox txtWbxmlInput;
        private System.Windows.Forms.Label lblWbxmlOutput;
        private System.Windows.Forms.TextBox txtWbxmlOutput;
        private System.Windows.Forms.ComboBox cBoxCmd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnkLblGit;
        private System.Windows.Forms.TextBox txtAboutSource;
    }
}

