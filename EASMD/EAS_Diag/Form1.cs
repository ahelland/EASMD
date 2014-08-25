using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using EAS_Protocol.WBXML;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Net.Security;

namespace EAS_MD
{
    public partial class frmEAS : Form
    {        
        private string strServerAddress = "";

        private string strDeviceId = null;
        private string strDeviceType = null;
        private string strUserAgent = null;

        private string strASVersion = null;
        private string strPolicyKey = "0";

        //Separators for use in the output views
        private string strSeparator = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
        private string strSeparator2 = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";        
      
        private bool bProvisionable = false;        
        
        private X509ChainElement[] sslCerts;

        public frmEAS()
        {
            InitializeComponent();

            cBoxCmd.SelectedItem = "FolderSync";
        }

        private void getDeviceParams()
        {
            if (txtDeviceId.Text != "")
            {
                strDeviceId = txtDeviceId.Text;
            }
            else
            {
                strDeviceId = "EASMD";
            }

            if (txtDeviceType.Text != "")
            {
                strDeviceType = txtDeviceType.Text;
            }
            else
            {
                strDeviceType = "FakeDevice";
            }

            if (txtUserAgent.Text != "")
            {
                strUserAgent = txtUserAgent.Text;
            }
            else
            {
                strUserAgent = "MobilityDojo.net";
            }
        }

        private string buildServerAddress()
        {
            if (chkUseSSL.Checked == true)
            {
                strServerAddress = "https://" + txtServerAddress.Text + "/Microsoft-Server-ActiveSync";
            }
            else
            {
                strServerAddress = "http://" + txtServerAddress.Text + "/Microsoft-Server-ActiveSync";
            }

            return strServerAddress;
        }
              
        private string getEncCredentials(string emailadress, string password)
        {
            string strEmailAddress = emailadress;
            string strPassword = password;

            string strRawCredentials = strEmailAddress + ":" + strPassword;

            //Need to base64 encode the credentials
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteSource = encoding.GetBytes(strRawCredentials);
            string strEncCredentials = System.Convert.ToBase64String(byteSource);

            return strEncCredentials;
        }

        private string getEncCredentials(string username, string password, string domain)
        {
            string strDomain = domain;
            string strUsername = username;
            string strPassword = password;

            string strRawCredentials = strDomain + "\\" + strUsername + ":" + strPassword;

            //Need to base64 encode the credentials
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteSource = encoding.GetBytes(strRawCredentials);
            string strEncCredentials = System.Convert.ToBase64String(byteSource);

            return strEncCredentials;
        }       

        private X509Certificate checkClientCert()
        {
            X509Certificate Cert = null; 

            if (chkUseClientCert.Checked == true)
            {
                if (txtClientCertPath.Text == "")
                {
                    txtOutput.Text += "\r\n" + "To use client certificates you need to provide a full path to the .cer file.\r\n";                    
                }
                if (txtClientCertPath.Text != "" && txtClientCertPassword.Text == "")
                {
                    try
                    {
                        Cert = new X509Certificate();
                        Cert = X509Certificate.CreateFromCertFile(@txtClientCertPath.Text);
                        return Cert;
                    }
                    catch (Exception)
                    {
                        txtOutput.Text += "\r\n" + "Could not load certificate. Check that's it's valid, and you've entered the correct path to the file.\r\n";                       
                    }
                    
                }
                if (txtClientCertPassword.Text != "")
                {
                    try
                    {
                        Cert = new X509Certificate(@txtClientCertPath.Text, txtClientCertPassword.Text);
                        return Cert;
                    }
                    catch (Exception)
                    {
                        txtOutput.Text += "\r\n" + "Could not load certificate. Check that's it's valid, that the password is correct, and you've entered the correct path to the file.\r\n";
                    }
                }
                else
                {
                }
            }
            else
            {               
            }
            return Cert;
        }

        private string parseHTTPException(WebException httpEx, string strEASVersion, bool bProvisionable)
        {
            string parsedEx = null;

            switch (httpEx.Status.ToString())
            {

                case ("NameResolutionFailure"):
                    parsedEx += httpEx.Message.ToString() + "\r\n";
                    parsedEx += "Possible reason: DNS lookup failed, or server is not reachable by host name.\r\n";
                    parsedEx += "Status: FAIL";
                    break;

                case ("ConnectFailure"):
                    parsedEx += httpEx.Message.ToString() + "\r\n";
                    parsedEx += "Possible reason: The server is not reachable at the specified address, or port is not open.\r\n";
                    parsedEx += "Check that necessary services are responding, and firewall rules aren't blocking connections.\r\n";
                    parsedEx += "Status: FAIL";
                    break;

                case ("SendFailure"):
                    parsedEx += httpEx.Message.ToString() + "\r\n";
                    parsedEx += "There does not seem to be a server responding at this address. \r\n";
                    parsedEx += "Verify that the URL should respond and run test again.\r\n";
                    parsedEx += "Status: Further action required";
                    break;

                case ("ProtocolError"):                    
                    parsedEx += httpEx.Message.ToString() + "\r\n";
                    HttpWebResponse resEx = (HttpWebResponse) httpEx.Response;
                    int resCode = (int)resEx.StatusCode;
                    if (resCode == 302)
                    {
                        parsedEx += "Explanation:\r\n";
                        parsedEx += "Server issued a redirect to a new URL. You should issue a new Autodiscover (and change FQDN).\r\n";
                        parsedEx += "Status: Further action required";
                    }

                    if(resCode == 400)
                    {
                        parsedEx += "Explanation:\r\n";
                        parsedEx += "Possibly a protocol mismatch, for example using version 14.0 against an Exchange 2007 server.\r\n";
                        parsedEx += "Choose a different protocol version to emulate, and try to run test again.\r\n";
                        parsedEx += "Status: FAIL";
                    }
                    if (resCode == 401)
                    {
                        parsedEx += "Explanation:\r\n";
                        parsedEx += "Wrong username/password. May also occur if you're using a reverse proxy which performs authentication.\r\n";
                        parsedEx += "Could also be caused by authenticating with user@domain.com if Active Directory doesn't accept this.\r\n";
                        parsedEx += "Status: FAIL";
                    }
                    if (resCode == 403)
                    {
                        if (strEASVersion == "12.0" || strEASVersion == "12.1")
                        {
                            parsedEx += "Explanation:\r\n";
                          parsedEx += "You are either running a non-provisionable device, or a provisionable device that haven't been provisioned yet.\r\n";
                          parsedEx += "First check: Tick off \"Provisionable device\" and run test again.\r\n";
                          parsedEx += "Second check Tick off \"Support security policies\" and run test again.\r\n";
                          parsedEx += "Status: Further action required";
                        }
                        else
                        {
                            parsedEx += "Explanation:\r\n";
                            parsedEx += "The server requires SSL and will not let you connect over HTTP.\r\n";
                            parsedEx += "(For instance trying to connect over HTTP while IIS requires SSL.)\r\n";
                            parsedEx += "Status: Further action required";
                        }                        
                    }
                    if (resCode == 404)
                    {
                        parsedEx += "Explanation:\r\n";
                        parsedEx += "File not found shouldn't occur...check IIS that files are not missing.\r\n";
                        parsedEx += "Status: FAIL";
                    }
                    if (resCode == 449)
                    {
                        if (bProvisionable == false)
                        {
                            parsedEx += "Explanation:\r\n";
                            parsedEx += "You seem to be using a non-provisionable device.\r\n";
                            parsedEx += "Check \"Provisionable device\" and run test again.\r\n";
                            parsedEx += "Status: Further action required";
                        }
                        else
                        {
                            parsedEx += "Explanation:\r\n";
                            parsedEx += "You seem to be running a provisionable device, but will need to apply policies before sync is allowed.\r\n";
                            parsedEx += "Check \"Support security policies\" and run test again.\r\n";
                            parsedEx += "Status: Further action required";
                        }
                    }
                    if (resCode == 451)
                    {
                        parsedEx += "Explanation:\r\n";
                        parsedEx += "Redirect request. Your mailbox is located on a different server.\r\n";
                        parsedEx += "Address returned by Exchange: " + httpEx.Response.Headers.Get("X-MS-Location") + "\r\n";
                        parsedEx += "Please change the FQDN part in the \"Server Address\" field.\r\n";
                        parsedEx += "Status: Further action required";
                    }
                    if (resCode == 501 || resCode == 505)
                    {
                        parsedEx += "Explanation:\r\n";
                        parsedEx += "This is correct behaviour, and means your Exchange server is responding!\r\n";
                        parsedEx += "Status: PASS";
                    }
                    if (resCode == 502)
                    {
                        parsedEx += "Explanation:\r\n";
                        parsedEx += "There is a server available at this FQDN and this port, but it's not responding to your request.\r\n";
                        parsedEx += "Could for instance happen if http://contoso.com does not redirect to an Exchange server.\r\n";
                        parsedEx += "Status: FAIL";
                    }
                    if (resCode == 503)
                    {
                        parsedEx += "Explanation:\r\n";
                        parsedEx += "You server is either experiencing too much load, or in a maintenance mode.\r\n";
                        parsedEx += "Check again in a short while, and if problem persists check that all services are running on your Exchange server.\r\n";
                        parsedEx += "Status: FAIL";
                    }
                    if (resCode == 504)
                    {
                        parsedEx += "Explanation:\r\n";
                        parsedEx += "Seems your Exchange server might have problems on the back end connecting to other servers (possibly Active Directory).\r\n";
                        parsedEx += "Check network connectivity on your Exchange server. (Problem most likely not between ActiveSync client and Exchange.)\r\n";
                        parsedEx += "Status: FAIL";
                    }                    

                    break;

                case ("TrustFailure"):
                    parsedEx += httpEx.Message.ToString() + "\r\n";
                    parsedEx += "The SSL certificate presented is not trusted. \r\n";
                    parsedEx += "Check \"Trust all certificates\" and run test again.\r\n";
                    parsedEx += "Status: Further action required";
                    break;

                default:
                    break;

            }

            return parsedEx;
        }

        private string parseResponseStatus(string responseBody, string strEASVersion)
        {
            string parsedStatus = null;

            if (responseBody.Contains("108") == true)
            {
                parsedStatus += "The device ID is invalid.";
                parsedStatus += "\r\nAre you using any special characters? Only plain characters and numerals recommended.)";
                parsedStatus += "\r\n";
            }

            if (responseBody.Contains("126") == true)
            {
                parsedStatus += "The user account does not have permission to synchronize.";
                parsedStatus += "\r\nThis could also be due to using an admin account. (Domain admin is not allowed to sync by default.)";
                parsedStatus += "\r\n";
            }

            //if EAS >= 12.1 (Exchange 2007 SP1) we need to parse the returned wbxml for '142' to find out if we need to provision
            //EAS 12.0 indicates the same status through HTTP 449
            if (strEASVersion == "12.1" || strEASVersion == "14.0" || strEASVersion == "14.1")
            {
                if (responseBody.Contains("142") == true)
                {
                    parsedStatus += "The response is ok, but you need to provision";
                    parsedStatus += "\r\n";
                }
            }
            if (responseBody.Contains("141") == true)
            {
                parsedStatus += "Only provisionable devices are allowed to sync, and you seem to be non-provisionable.\r\n";
                parsedStatus += "Check the \"Provisionable device\" and run the test again.\r\n";
            }
            if (responseBody.Contains("140") == true)
            {
                parsedStatus += "A remote wipe has been issued for your device.\r\n";
                parsedStatus += "Choose \"Remote Wipe (Emulated)\" to simulate a wipe.\r\n";
            }
            if (responseBody.Contains("144") == true)
            {
                parsedStatus += "The device's policy key is invalid. The policy has probably changed on the server. The device needs to re-provision.\r\n";
                parsedStatus += "This may happen if you have synced a \"device\" with security policies and then removed the support for all policies.\r\n";
            }

            else if (responseBody.Length <= 15)
            {
                parsedStatus += "More status codes can be looked up here:\r\n";
                parsedStatus += "http://msdn.microsoft.com/en-us/library/ee218647(v=EXCHG.80).aspx\r\n";
            }
            

            return parsedStatus;
        }

        private void btnBasicTest_Click(object sender, EventArgs e)
        {
            string strUsername = txtUsername.Text;
            string strPassword = txtPassword.Text;
            string strDomain = txtDomain.Text;

            string strEncCredentials = null;

            if (txtDomain.Text == "")
            {
                strEncCredentials = getEncCredentials(strUsername, strPassword);
            }
            else if (txtDomain.Text != "")
            {
                strEncCredentials = getEncCredentials(strUsername, strPassword, strDomain);
            }

            if (chkTrustAllCerts.Checked == true)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback =
                    delegate(object sender2, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    { return true; };
            }
            else
            {
                // BUG - Once all certs are trusted it cannot be reset to default!!!
                // Requires restarting the app to reset.
            }                                                       
            

            string uri = buildServerAddress();

            //Perform a HTTP GET first. This will test network level issues.
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);           
            webRequest.Method = "GET";
            webRequest.Headers.Add("Authorization", "Basic " + strEncCredentials);
            webRequest.AllowAutoRedirect = false; //catch HTTP 302 instead of following them

            //Check to see if we're using client certificates
            if (chkUseClientCert.Checked == true)
            {
                webRequest.ClientCertificates.Add(checkClientCert());
            }
                    
            try
            {
                //It is expected behaviour that we will have to catch an exception
                txtOutput.Text += "Testing HTTP GET:\r\n";
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse == null)
                {
                }

                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                sr.ReadToEnd().Trim();
            }
            catch (WebException ex)
            {                               
                txtOutput.Text += "Response: " + parseHTTPException(ex,strASVersion,bProvisionable) + "\r\n";               
            }

            //Perform a HTTP OPTIONS. This will fetch info about the Exchange server.
            txtOutput.Text += strSeparator + "\r\n";
            txtOutput.Text += "Testing HTTP OPTIONS:\r\n";

            HttpWebRequest webRequestOptions = (HttpWebRequest)WebRequest.Create(uri);
            
            webRequestOptions.Method = "OPTIONS";
            webRequestOptions.Headers.Add("Authorization", "Basic " + strEncCredentials);

            //Check to see if we're using client certificates
            if (chkUseClientCert.Checked == true)
            {
                webRequestOptions.ClientCertificates.Add(checkClientCert());
            }

            try
            {               
                WebResponse webResponse = webRequestOptions.GetResponse();
                if (webResponse == null)
                {
                }
                //No body, but we parse out the return headers
                int optionsHeadersCount = webResponse.Headers.Count;
                for (int i = 0; i < optionsHeadersCount; i++)
                {
                    txtOutput.Text += webResponse.Headers.Keys[i].ToString() + ":" + webResponse.Headers.Get(i).ToString() + "\r\n";
                }
                txtOutput.Text += "\r\nStatus: PASS\r\n";

            }
            catch (WebException ex)
            {
                txtOutput.Text += "Response: " + parseHTTPException(ex, strASVersion, bProvisionable) + "\r\n";                 
            }
            txtOutput.Text += strSeparator + "\r\n";
        }

        private void btnFullTest_Click(object sender, EventArgs e)
        {
            if (chkTrustAllCerts.Checked == true)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback =
                    delegate(object sender2, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    { return true; };
            }
            else
            {
                // BUG - Once all certs are trusted it cannot be reset to default!!!
                // Requires restarting the app to reset.
            } 
            
            string strUsername = txtUsername.Text;
            string strPassword = txtPassword.Text;
            string strDomain = txtDomain.Text;

            string strEncCredentials = null;

            if (txtDomain.Text == "")
            {
                strEncCredentials = getEncCredentials(strUsername, strPassword);
            }
            else if (txtDomain.Text != "")
            {
                strEncCredentials = getEncCredentials(strUsername, strPassword, strDomain);
            }
 
            getDeviceParams();
           
            bool bProvOk = false;

            //fetch chosen MS-ASProtocolVersion from list
            //if unable to get version default to 12.1
            try
            {
                ListViewItem lstASVersion = lstASVersions.FocusedItem;
                int intASVersion = lstASVersion.Index;
                strASVersion = lstASVersions.Items[intASVersion].SubItems[1].Text;
            }
            catch (Exception)
            {
                txtOutput.Text += "\r\n" + "You seem to not have chosen an ActiveSync version. Defaulting to 12.1 (Exchange 2007 SPx)" + "\r\n";
                strASVersion = "12.1";
            }

            //are we emulating a provisionable device?
            if (chkProvisionable.Checked == true)
            {
                bProvisionable = true;
            }

            //do we need to provision?
            if (chkFakeSecPol.Checked == true)
            {
                //Exchange 2010 SP1 (EAS 14.1) introduces a new method for acquiring a policy key
                //01.07.2012 - Added EAS 15.0 to the same assumption
                //21.08.2014 - Removed EAS 15.0 since Exchange 2013 didn't introduce new major version
                if (strASVersion == "14.1")
                    strPolicyKey = ProvisionE141(strUsername,strEncCredentials);
                else
                    strPolicyKey = Provision(strUsername,strEncCredentials);
                bProvOk = true;
            }                      

            strServerAddress = buildServerAddress();

            string uri = strServerAddress + "?Cmd=FolderSync&User=" + strUsername + "&DeviceId=" + strDeviceId +"&DeviceType=" + strDeviceType; 

            //FolderSync cmd
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);           
            webRequest.Method = "POST";
            webRequest.Headers.Add("Authorization", "Basic " + strEncCredentials);
            webRequest.ContentType = "application/vnd.ms-sync.wbxml";
            webRequest.AllowAutoRedirect = false; //catch HTTP 302 instead of following them

            //Check to see if we're using client certificates
            if (chkUseClientCert.Checked == true)
            {
                webRequest.ClientCertificates.Add(checkClientCert());
            }
                
            //Emulate the chosen AS version
            webRequest.Headers.Add("MS-ASProtocolVersion", strASVersion);
            
            webRequest.UserAgent = strUserAgent;
            
            //If we emulate provisionable we need to set X-MS-PolicyKey in the header
            //If we're not provisionable, but the server requires this we'll get a 403 response
            if (bProvisionable == true)
            {
                if (bProvOk)
                {
                    webRequest.Headers.Add("X-MS-PolicyKey", strPolicyKey);
                }
                else
                {
                   webRequest.Headers.Add("X-MS-PolicyKey", "0");
                }

            }

            //the wbxml required for initial FolderSync
            byte[] postBytes = new byte[13]{03,01,106,00,00,07,86,82,03,48,00,01,01};

            webRequest.ContentLength = postBytes.Length;

            try
            {
                Stream sw = webRequest.GetRequestStream();
                sw.Write(postBytes, 0, postBytes.Length);
                sw.Close();

                txtOutput.Text += "Testing FolderSync:\r\n";
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse == null)
                {
                }
                txtOutput.Text += webResponse.ResponseUri.PathAndQuery + "\r\n";
                
                System.Text.UTF8Encoding utf8Encoding = new System.Text.UTF8Encoding();
                

                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                
                txtOutput.Text += "HTTP 200 - OK\r\n";
                txtOutput.Text += "Response body \r\n";
                string responseBody = sr.ReadToEnd().Trim();
                Byte[] byteResp = utf8Encoding.GetBytes(responseBody);

                txtOutput.Text += parseResponseStatus(responseBody, strASVersion);

                //Output if WBXML is checked (default)
                if (chkWBXML.Checked == true)
                {
                    WBXMLWriter wbxmlWriter = new WBXMLWriter(new ASCodePageProvider());
                    WBXMLConverter wbxmlConverter = new WBXMLConverter(new ASCodePageProvider(), wbxmlWriter, null);                   

                    XElement destXml = wbxmlConverter.Parse(byteResp);

                    txtOutput.Text += destXml.ToString();

                }

                //Only output if binary is checked (default up to v 1.4)
                if (chkBinary.Checked == true)
                {

                    txtOutput.Text += "Binary format: \r\n";            
                    //to be able to represent the response in a textbox we need to parse the individual chars
                    char charResp = '0';
                    for (int i = 0; i < byteResp.Length; i++)
                    {
                        charResp = (char)byteResp[i];
                        
                        if (byteResp[i] == 0x01)
                        {
                            if (chkWordWrapMain.Checked == true)
                            {
                                txtOutput.Text += "\r\n";
                            }
                            else
                            {
                                txtOutput.Text += charResp;
                            }
                        }
                        else
                        {
                            txtOutput.Text += charResp;
                        }
                    }
                    txtOutput.Text += "\r\n";
                }
                               
                //only output if hex is checked
                if (chkHex.Checked == true)
                {
                    
                    byteResp = utf8Encoding.GetBytes(responseBody);

                    string hexStrResp = "";
                    for (int loopCounter = 0; loopCounter < byteResp.Length; loopCounter++)
                    {
                        hexStrResp += byteResp[loopCounter].ToString();
                    }
                    txtOutput.Text += "Hex format: " + hexStrResp;
                    txtOutput.Text += "\r\n";
                }

                //only output if base64 is checked
                if (chkBase64.Checked == true)
                {
                    txtOutput.Text += "Base64: " + Convert.ToBase64String(utf8Encoding.GetBytes(responseBody)) + "\r\n";
                }                                
            }
            catch (WebException ex)
            {
                txtOutput.Text += "Response: " + parseHTTPException(ex,strASVersion,bProvisionable) + "\r\n";                
            }
            txtOutput.Text += strSeparator + "\r\n";
        }

        private string ProvisionE141(string strUsername,string strCredentials)
        {
            System.Text.UTF8Encoding utf8Encoding = new System.Text.UTF8Encoding();
            
            byte[] bModel       = utf8Encoding.GetBytes(txtDevModel.Text);
            byte[] bIMEI        = utf8Encoding.GetBytes(txtDevIMEI.Text);
            byte[] bFriendly    = utf8Encoding.GetBytes(txtDevFriendly.Text);
            byte[] bOS          = utf8Encoding.GetBytes(txtDevOS.Text);
            byte[] bOSLang      = utf8Encoding.GetBytes(txtDevOSLang.Text);
            byte[] bPhoneNr     = utf8Encoding.GetBytes(txtDevPhoneNr.Text);
            byte[] bMO          = utf8Encoding.GetBytes(txtDevMO.Text);
            byte[] bUserAgent   = utf8Encoding.GetBytes(txtDevUA.Text);

            byte[] polType = utf8Encoding.GetBytes("MS-EAS-Provisioning-WBXML");

            strServerAddress = buildServerAddress();
            string strEncCredentials = strCredentials;

            string uri = strServerAddress + "?Cmd=Provision&User=" + strUsername + "&DeviceId=" + strDeviceId + "&DeviceType=" + strDeviceType;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.ContentType = "application/vnd.ms-sync.wbxml";

            webRequest.Method = "POST";
            webRequest.Headers.Add("Authorization", "Basic " + strEncCredentials);
            webRequest.Headers.Add("MS-ASProtocolVersion", strASVersion);
            webRequest.UserAgent = strUserAgent;
            webRequest.Headers.Add("X-MS-PolicyKey", "0");

            //let's define a byte array with the wbxml for the temp key including device info
            int ProvXmlLength = bModel.Length + bIMEI.Length + bFriendly.Length + bOS.Length + bOSLang.Length + bPhoneNr.Length + bMO.Length + bUserAgent.Length + polType.Length + 58;
            byte[] postBytes = new byte[ProvXmlLength];

            //wbxml for the final prov
            byte[] postBytesFinal = new byte[60]{03,01,106,00,00,14,69,70,71,72,03,77,83,45,69,65,
                                                 83,45,80,114,111,118,105,115,105,111,110,105,110,103,45,87,
                                                 66,88,77,76,00,01,73,00,00,00,00,00,00,00,00,00,
                                                 00,00,00,01,75,03,49,00,01,01,01,01};
                        
            postBytes[0] = 0x03;
            postBytes[1] = 0x01;
            postBytes[2] = 0x6A;
            postBytes[3] = 0x00;
            postBytes[4] = 0x00;
            postBytes[5] = 0x0E;
            postBytes[6] = 0x45;
            postBytes[7] = 0x00;
            postBytes[8] = 0x12;
            postBytes[9] = 0x56;
            postBytes[10] = 0x48;
            postBytes[11] = 0x57;                        
            
            int outerCount = 12;
            int innerCount = 0;

            //Fill in DeviceModel
            postBytes[outerCount] = 0x03;
            outerCount++;
            for (innerCount = 0; innerCount < bModel.Length; innerCount++)
            {
                postBytes[outerCount] = bModel[innerCount];
                outerCount++;
            }           
            postBytes[outerCount] = 0x00;
            outerCount++;

            postBytes[outerCount] = 0x01;
            postBytes[outerCount + 1] = 0x58;
            outerCount += 2;

            //Fill in Device IMEI
            postBytes[outerCount] = 0x03;
            outerCount++;
            for (innerCount = 0; innerCount < bIMEI.Length; innerCount++)
            {
                postBytes[outerCount] = bIMEI[innerCount];
                outerCount++;
            }
            postBytes[outerCount] = 0x00;
            outerCount++;
            
            postBytes[outerCount] = 0x01;
            postBytes[outerCount + 1] = 0x59;
            outerCount += 2;

            //Fill in Device Friendly Name
            postBytes[outerCount] = 0x03;
            outerCount++;
            for (innerCount = 0; innerCount < bFriendly.Length; innerCount++)
            {
                postBytes[outerCount] = bFriendly[innerCount];
                outerCount++;
            }
            postBytes[outerCount] = 0x00;
            outerCount++;
          
            postBytes[outerCount] = 0x01;
            postBytes[outerCount + 1] = 0x5A;
            outerCount += 2;

            //Fill in Device OS
            postBytes[outerCount] = 0x03;
            outerCount++;
            for (innerCount = 0; innerCount < bOS.Length; innerCount++)
            {
                postBytes[outerCount] = bOS[innerCount];
                outerCount++;
            }
            postBytes[outerCount] = 0x00;
            outerCount++;
           
            postBytes[outerCount] = 0x01;
            postBytes[outerCount + 1] = 0x5B;
            outerCount += 2;

            //Fill in Device OS Language
            postBytes[outerCount] = 0x03;
            outerCount++;
            for (innerCount = 0; innerCount < bOSLang.Length; innerCount++)
            {
                postBytes[outerCount] = bOSLang[innerCount];
                outerCount++;
            }
            postBytes[outerCount] = 0x00;
            outerCount++;
            
            postBytes[outerCount] = 0x01;
            postBytes[outerCount + 1] = 0x5C;
            outerCount += 2;

            //Fill in Device Phone Number
            postBytes[outerCount] = 0x03;
            outerCount++;
            for (innerCount = 0; innerCount < bPhoneNr.Length; innerCount++)
            {
                postBytes[outerCount] = bPhoneNr[innerCount];
                outerCount++;
            }
            postBytes[outerCount] = 0x00;
            outerCount++;
           
            postBytes[outerCount] = 0x01;
            postBytes[outerCount + 1] = 0x62;
            outerCount += 2;

            //Fill in Mobile Operator
            postBytes[outerCount] = 0x03;
            outerCount++;
            for (innerCount = 0; innerCount < bMO.Length; innerCount++)
            {
                postBytes[outerCount] = bMO[innerCount];
                outerCount++;
            }
            postBytes[outerCount] = 0x00;
            outerCount++;
            
            postBytes[outerCount] = 0x01;
            postBytes[outerCount + 1] = 0x60;
            outerCount += 2;

            //Fill in User Agent
            postBytes[outerCount] = 0x03;
            outerCount++;
            for (innerCount = 0; innerCount < bUserAgent.Length; innerCount++)
            {
                postBytes[outerCount] = bUserAgent[innerCount];
                outerCount++;
            }
            postBytes[outerCount] = 0x00;
            outerCount++;
            
            postBytes[outerCount] = 0x01;
            postBytes[outerCount+1] = 0x01;
            postBytes[outerCount+2] = 0x01;           

            outerCount += 3;

            postBytes[outerCount] = 0x00;
            postBytes[outerCount +1] = 0x0E;
            outerCount += 2;
            
            postBytes[outerCount] = 0x46;
            postBytes[outerCount+1] = 0x47;
            postBytes[outerCount+2] = 0x48;

            outerCount += 3;

            //Switch to provision to include MS-EAS-Provisioning-WBXML as the Policy type
            postBytes[outerCount] = 0x03;
            outerCount++;            

            for (innerCount = 0; innerCount < polType.Length; innerCount++)
            {
                postBytes[outerCount] = polType[innerCount];
                outerCount++;
            }
            postBytes[outerCount] = 0x00;
            outerCount++;

            postBytes[outerCount] = 0x01;
            postBytes[outerCount+1] = 0x01;
            postBytes[outerCount+2] = 0x01;
            postBytes[outerCount+3] = 0x01;
            postBytes[outerCount+4] = 0x01;

            webRequest.ContentLength = postBytes.Length;
            try
            {
                Stream sw = webRequest.GetRequestStream();
                sw.Write(postBytes, 0, postBytes.Length);
                sw.Close();
                WebResponse webResponse = webRequest.GetResponse();

                if (webResponse == null)
                {
                }
                txtOutput.Text += "Requesting temporary policy key ";                

                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                
                string responseBody = sr.ReadToEnd().Trim();
                Byte[] byteResp = utf8Encoding.GetBytes(responseBody);
                Byte[] polKey = new Byte[14];

                int intRecBytes = 0;
                bool recBytes = false;
                char chrPolKey;
                string hexStrResp = "";

                //to get the temp key we loop the array, and "record" only the necessary bytes
                for (int loopCounter = 0; loopCounter < byteResp.Length; loopCounter++)
                {
                    hexStrResp = byteResp[loopCounter].ToString();
                    chrPolKey = (char)byteResp[loopCounter];

                    //set recording on when finding the start character
                    if (chrPolKey == 'I')
                    {
                        recBytes = true;
                    }
                    //end recording when finding the end character
                    if (hexStrResp == "1")
                    {
                        recBytes = false;
                    }
                    //record the temp policy key
                    if (recBytes == true)
                    {
                        polKey[intRecBytes] = byteResp[loopCounter];
                        intRecBytes++;
                    }
                }

                for (int loopTmpPolKey = 1; loopTmpPolKey < 13; loopTmpPolKey++)
                {
                    postBytesFinal[loopTmpPolKey + 38] = polKey[loopTmpPolKey];
                }
                
                txtOutput.Text += "\r\n";


            }
            catch (WebException ex)
            {
                ex.ToString();
            }


            //The second post will request the final policy key
            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(uri);
            webRequest2.ContentType = "application/vnd.ms-sync.wbxml";

            webRequest2.Method = "POST";
            webRequest2.Headers.Add("Authorization", "Basic " + strEncCredentials);
            webRequest2.Headers.Add("MS-ASProtocolVersion", strASVersion);
            webRequest2.UserAgent = strUserAgent;
            webRequest2.Headers.Add("X-MS-PolicyKey", strPolicyKey);

            //Check to see if we're using client certificates
            if (chkUseClientCert.Checked == true)
            {
                webRequest2.ClientCertificates.Add(checkClientCert());
            }

            webRequest2.ContentLength = postBytesFinal.Length;
            try
            {
                Stream sw = webRequest2.GetRequestStream();
                sw.Write(postBytesFinal, 0, postBytesFinal.Length);
                sw.Close();
                txtOutput.Text += "Requesting final policy key " + "\r\n";
                WebResponse webResponse2 = webRequest2.GetResponse();
                if (webResponse2 == null)
                {
                }

                StreamReader sr = new StreamReader(webResponse2.GetResponseStream());

                string responseBody = sr.ReadToEnd().Trim();
                Byte[] byteResp = utf8Encoding.GetBytes(responseBody);

                Byte[] polKey = new Byte[14];

                int intRecBytes = 0;
                bool recBytes = false;
                char chrPolKey;
                string hexStrResp = "";

                //to get the final key we loop the array, and "record" only the necessary bytes
                for (int loopCounter = 0; loopCounter < byteResp.Length; loopCounter++)
                {
                    hexStrResp = byteResp[loopCounter].ToString();
                    chrPolKey = (char)byteResp[loopCounter];

                    //set recording on when finding the start character
                    if (chrPolKey == 'I')
                    {
                        recBytes = true;
                    }
                    //end recording when finding the end character
                    if (hexStrResp == "1")
                    {
                        recBytes = false;
                    }
                    //record the temp policy key
                    if (recBytes == true)
                    {
                        polKey[intRecBytes] = byteResp[loopCounter];
                        intRecBytes++;
                    }
                }

                char[] finalKey = new char[14];
                strPolicyKey = "0";

                for (int loopTmpPolKey = 2; loopTmpPolKey < 13; loopTmpPolKey++)
                {
                    finalKey[loopTmpPolKey] = (char)polKey[loopTmpPolKey];
                    //we need to filter out the escaped zeroes
                    if (finalKey[loopTmpPolKey] == '\0')
                    {
                        strPolicyKey += "";
                    }
                    else
                    {
                        strPolicyKey += finalKey[loopTmpPolKey];
                    }
                }

                txtOutput.Text += "Policy Key: " + strPolicyKey + "\r\n";
                txtOutput.Text += "\r\n";

            }
            catch (WebException ex)
            {
                ex.ToString();
            }

            return strPolicyKey;
            
        }

        private string Provision(string strUsername,string strCredentials)
        {
            strServerAddress = buildServerAddress();
            string strEncCredentials = strCredentials;
            
            string uri = strServerAddress + "?Cmd=Provision&User=" + strUsername + "&DeviceId=" + strDeviceId + "&DeviceType=" + strDeviceType; 
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.ContentType = "application/vnd.ms-sync.wbxml";

            webRequest.Method = "POST";
            webRequest.Headers.Add("Authorization", "Basic " + strEncCredentials);
            webRequest.Headers.Add("MS-ASProtocolVersion", strASVersion);
            webRequest.UserAgent = strUserAgent;
            webRequest.Headers.Add("X-MS-PolicyKey", "0");

            //Check to see if we're using client certificates
            if (chkUseClientCert.Checked == true)
            {
                webRequest.ClientCertificates.Add(checkClientCert());
            }


            //wbxml for initial prov request
            byte[] postBytes = new byte[41] {03,01,106,00,00,14,69,70,71,72,03,77,83,45,69,65,
                                             83,45,80,114,111,118,105,115,105,111,110,105,110,103,45,87,
                                             66,88,77,76,00,01,01,01,01};
  

            //wbxml for the final prov
            byte[] postBytesFinal = new byte[60]{03,01,106,00,00,14,69,70,71,72,03,77,83,45,69,65,
                                                 83,45,80,114,111,118,105,115,105,111,110,105,110,103,45,87,
                                                 66,88,77,76,00,01,73,00,00,00,00,00,00,00,00,00,
                                                 00,00,00,01,75,03,49,00,01,01,01,01};


            webRequest.ContentLength = postBytes.Length;
            try
            {
                Stream sw = webRequest.GetRequestStream();
                sw.Write(postBytes, 0, postBytes.Length);
                sw.Close();
                WebResponse webResponse = webRequest.GetResponse();
                
                if (webResponse == null)
                {
                }
                txtOutput.Text += "Requesting temporary policy key " + "\r\n";

                System.Text.UTF8Encoding utf8Encoding = new System.Text.UTF8Encoding();

                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
               
                string responseBody = sr.ReadToEnd().Trim();
                Byte[] byteResp = utf8Encoding.GetBytes(responseBody);
                Byte[] polKey = new Byte[14];

                int intRecBytes = 0;
                bool recBytes = false;
                char chrPolKey;
                string hexStrResp = "";

                //to get the temp key we loop the array, and "record" only the necessary bytes
                for (int loopCounter = 0; loopCounter < byteResp.Length; loopCounter++)
                {
                    hexStrResp = byteResp[loopCounter].ToString();
                    chrPolKey = (char) byteResp[loopCounter];
                    
                    //set recording on when finding the start character
                    if (chrPolKey == 'I')
                    {
                        recBytes = true;                                               
                    }
                    //end recording when finding the end character
                    if (hexStrResp == "1")
                    {
                        recBytes = false;
                    }
                    //record the temp policy key
                    if (recBytes == true)
                    {                       
                        polKey[intRecBytes] = byteResp[loopCounter];
                        intRecBytes++;
                    }
                }

                for (int loopTmpPolKey = 1; loopTmpPolKey < 13 ; loopTmpPolKey++)
                {
                    postBytesFinal[loopTmpPolKey + 38] = polKey[loopTmpPolKey];
                }                              
            
                
            }
            catch (WebException ex)
            {
                ex.ToString();
            }

            //The second post will request the final policy key
            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(uri);
            webRequest2.ContentType = "application/vnd.ms-sync.wbxml";

            webRequest2.Method = "POST";
            webRequest2.Headers.Add("Authorization", "Basic " + strEncCredentials);
            webRequest2.Headers.Add("MS-ASProtocolVersion", strASVersion);
            webRequest2.UserAgent = strUserAgent;
            webRequest2.Headers.Add("X-MS-PolicyKey", strPolicyKey);

            //Check to see if we're using client certificates
            if (chkUseClientCert.Checked == true)
            {
                webRequest2.ClientCertificates.Add(checkClientCert());
            }

            webRequest2.ContentLength = postBytesFinal.Length;
            try
            {
                Stream sw = webRequest2.GetRequestStream();
                sw.Write(postBytesFinal, 0, postBytesFinal.Length);
                sw.Close();
                txtOutput.Text += "Requesting final policy key " + "\r\n";
                WebResponse webResponse2 = webRequest2.GetResponse();
                if (webResponse2 == null)
                {
                }
                
                System.Text.UTF8Encoding utf8Encoding = new System.Text.UTF8Encoding();

                StreamReader sr = new StreamReader(webResponse2.GetResponseStream());

                string responseBody = sr.ReadToEnd().Trim();
                Byte[] byteResp = utf8Encoding.GetBytes(responseBody);

                Byte[] polKey = new Byte[14];

                int intRecBytes = 0;
                bool recBytes = false;
                char chrPolKey;
                string hexStrResp = "";

                //to get the final key we loop the array, and "record" only the necessary bytes
                for (int loopCounter = 0; loopCounter < byteResp.Length; loopCounter++)
                {
                    hexStrResp = byteResp[loopCounter].ToString();
                    chrPolKey = (char)byteResp[loopCounter];

                    //set recording on when finding the start character
                    if (chrPolKey == 'I')
                    {
                        recBytes = true;
                    }
                    //end recording when finding the end character
                    if (hexStrResp == "1")
                    {
                        recBytes = false;
                    }
                    //record the temp policy key
                    if (recBytes == true)
                    {                       
                        polKey[intRecBytes] = byteResp[loopCounter];
                        intRecBytes++;
                    }
                }

                char[] finalKey = new char[14];
                strPolicyKey = "0";
                
                for (int loopTmpPolKey = 2; loopTmpPolKey < 13; loopTmpPolKey++)
                {
                    finalKey[loopTmpPolKey] = (char)polKey[loopTmpPolKey];
                    //we need to filter out the escaped zeroes
                    if (finalKey[loopTmpPolKey] == '\0')
                    {
                        strPolicyKey += "";
                    }
                    else
                    {
                        strPolicyKey += finalKey[loopTmpPolKey];
                    }
                }
                
                txtOutput.Text += "Policy Key: " + strPolicyKey + "\r\n";
                txtOutput.Text += "\r\n";              

            }
            catch (WebException ex)
            {
                ex.ToString();
            }

            return strPolicyKey;
        }

        private void btnClearOutput_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
        }

        private void btnGetChain_Click(object sender, EventArgs e)
        {                     
            
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ParseRemoteCertificate);
            using (TcpClient cli = new TcpClient(txtServerAddressSSL.Text, 443))
            {
                SslStream ssh = new SslStream(cli.GetStream(), false, ParseRemoteCertificate);
                ssh.AuthenticateAsClient(txtServerAddressSSL.Text);
                ssh.Close();
            }
            txtCertList.Text += "Number of certificates in chain: " + sslCerts.Length + "\r\n";
            txtCertList.Text += strSeparator + "\r\n";
            for (int loopCounter = 0; loopCounter < sslCerts.Length; loopCounter++)
            {
                int j = loopCounter + 1;
                txtCertList.Text += "Certificate number: " + j + "\r\n";
                txtCertList.Text += "Subject Name: " + sslCerts[loopCounter].Certificate.Subject + "\r\n";
                txtCertList.Text += "Issued by: " + sslCerts[loopCounter].Certificate.Issuer + "\r\n";
                txtCertList.Text += "Valid from: " + sslCerts[loopCounter].Certificate.GetEffectiveDateString() + "\r\n";
                txtCertList.Text += "Valid to: " + sslCerts[loopCounter].Certificate.GetExpirationDateString() + "\r\n";
                txtCertList.Text += strSeparator + "\r\n";
                
            }
            txtCertList.Text += "~~~~~ Certificates ~~~~~ Save as .cer ~~~~~\r\n";
            for (int loopCounter = 0; loopCounter < sslCerts.Length; loopCounter++)
            {
                int j = loopCounter + 1;
                txtCertList.Text += "===== Certificate number: " + j + " =====\r\n";
                txtCertList.Text += Convert.ToBase64String(sslCerts[loopCounter].Certificate.GetRawCertData()) + "\r\n";
                txtCertList.Text += strSeparator + "\r\n";
            }

        }

        private bool ParseRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {          
            int certsNumber = chain.ChainElements.Count;
            sslCerts = new X509ChainElement[certsNumber];
            chain.ChainElements.CopyTo(sslCerts, 0);

            return true;

        }

        private void btnBase64Encode_Click(object sender, EventArgs e)
        {
            string source = txtConvertSource.Text;

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteSource = encoding.GetBytes(source);
           
            string dest = System.Convert.ToBase64String(byteSource);
            
            txtConvertDest.Text = dest;

        }

        private void btnBase64Decode_Click(object sender, EventArgs e)
        {
            string source = txtConvertSource.Text;

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            Byte[] byteSource = encoding.GetBytes(source);

            byte[] dest = System.Convert.FromBase64String(source);
            txtConvertDest.Text = encoding.GetString(dest);
        }

        private void btnRemoteWipe_Click(object sender, EventArgs e)
        {
            byte[] postReqWipe = new byte[41]   {0x03,0x01,0x6a,0x00,0x00,0x0e,0x45,0x46,0x47,0x48,0x03,0x4d,0x53,0x2d,0x45,0x41,
                                                 0x53,0x2d,0x50,0x72,0x6f,0x76,0x69,0x73,0x69,0x6f,0x6e,0x69,0x6e,0x67,0x2d,0x57,
                                                 0x42,0x58,0x4d,0x4c,0x00,0x01,0x01,0x01,0x01};
            byte[] postAckWipe = new byte[67]   {0x03,0x01,0x6a,0x00,0x00,0x0e,0x45,0x46,0x47,0x48,0x03,0x4d,0x53,0x2d,0x45,0x41,
                                                 0x53,0x2d,0x50,0x72,0x6f,0x76,0x69,0x73,0x69,0x6f,0x6e,0x69,0x6e,0x67,0x2d,0x57,
                                                 0x42,0x58,0x4d,0x4c,0x00,0x01,0x49,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                                                 0x00,0x00,0x00,0x01,0x4b,0x03,0x31,0x00,0x01,0x01,0x01,0x4c,0x4b,0x03,0x31,0x00,
                                                 0x01,0x01,0x01};

            strServerAddress = buildServerAddress();

            string strUsername = txtUsername.Text;
            string strPassword = txtPassword.Text;
            string strDomain = txtDomain.Text;

            string strEncCredentials = null;

            if (txtDomain.Text == "")
            {
                strEncCredentials = getEncCredentials(strUsername, strPassword);
            }
            else if (txtDomain.Text != "")
            {
                strEncCredentials = getEncCredentials(strUsername, strPassword, strDomain);
            }            

            string uri = strServerAddress + "?Cmd=Provision&User=" + strUsername + "&DeviceId=" + strDeviceId + "&DeviceType=" + strDeviceType;
            HttpWebRequest webRequestWipe = (HttpWebRequest)WebRequest.Create(uri);
            webRequestWipe.ContentType = "application/vnd.ms-sync.wbxml";

            webRequestWipe.Method = "POST";
            webRequestWipe.Headers.Add("Authorization", "Basic " + strEncCredentials);
            webRequestWipe.Headers.Add("MS-ASProtocolVersion", strASVersion);
            webRequestWipe.UserAgent = strUserAgent;
            webRequestWipe.Headers.Add("X-MS-PolicyKey", strPolicyKey);

            //Check to see if we're using client certificates
            if (chkUseClientCert.Checked == true)
            {
                webRequestWipe.ClientCertificates.Add(checkClientCert());
            }

            webRequestWipe.ContentLength = postReqWipe.Length;
            try
            {
                Stream sw = webRequestWipe.GetRequestStream();
                sw.Write(postReqWipe, 0, postReqWipe.Length);
                sw.Close();
                txtOutput.Text += "Requesting wipe " + "\r\n";
                WebResponse webResponseWipe = webRequestWipe.GetResponse();
                if (webResponseWipe == null)
                {
                }

                System.Text.UTF8Encoding utf8Encoding = new System.Text.UTF8Encoding();


                StreamReader sr = new StreamReader(webResponseWipe.GetResponseStream());

                txtOutput.Text += "HTTP 200 - OK\r\n";
                string responseBody = sr.ReadToEnd().Trim();
                Byte[] byteResp = utf8Encoding.GetBytes(responseBody);
                Byte[] polKey = new byte[14];

                char[] Key = new char[14];
                //strPolicyKey = "0";

                int intRecBytes = 0;
                bool recBytes = false;
                char chrPolKey;
                string hexStrResp = "";

                ////to get the new key we loop the array, and "record" only the necessary bytes
                for (int loopCounter = 0; loopCounter < byteResp.Length; loopCounter++)
                {
                    hexStrResp = byteResp[loopCounter].ToString();
                    chrPolKey = (char)byteResp[loopCounter];

                    //set recording on when finding the start character
                    if (chrPolKey == 'I')
                    {
                        recBytes = true;
                    }
                    //end recording when finding the end character
                    if (hexStrResp == "1")
                    {
                        recBytes = false;
                    }
                    //record the temp policy key
                    if (recBytes == true)
                    {
                        polKey[intRecBytes] = byteResp[loopCounter];
                        intRecBytes++;
                    }
                }
                
                strPolicyKey = "";
                for (int loopTmpPolKey = 1; loopTmpPolKey < 13; loopTmpPolKey++)
                {
                    postAckWipe[loopTmpPolKey + 38] = polKey[loopTmpPolKey];
                    strPolicyKey += polKey[loopTmpPolKey];
                }
                txtOutput.Text += "New Policy Key: " + strPolicyKey;
                txtOutput.Text += "\r\n";
            }
            catch (WebException)
            {
            }
          
            //ACK the wipe
            HttpWebRequest webAckWipe = (HttpWebRequest)WebRequest.Create(uri);
            webAckWipe.ContentType = "application/vnd.ms-sync.wbxml";

            webAckWipe.Method = "POST";
            webAckWipe.Headers.Add("Authorization", "Basic " + strEncCredentials);
            webAckWipe.Headers.Add("MS-ASProtocolVersion", strASVersion);
            webAckWipe.UserAgent = strUserAgent;
            //webAckWipe.Headers.Add("X-MS-PolicyKey", strPolicyKey);

            //Check to see if we're using client certificates
            if (chkUseClientCert.Checked == true)
            {
                webAckWipe.ClientCertificates.Add(checkClientCert());
            }

            webAckWipe.ContentLength = postAckWipe.Length;
            try
            {
                Stream sw = webAckWipe.GetRequestStream();
                sw.Write(postAckWipe, 0, postAckWipe.Length);
                sw.Close();
                txtOutput.Text += "ACKing wipe " + "\r\n";
                WebResponse webResponseAckWipe = webAckWipe.GetResponse();
                if (webResponseAckWipe == null)
                {
                }

                System.Text.UTF8Encoding utf8Encoding = new System.Text.UTF8Encoding();


                StreamReader sr = new StreamReader(webResponseAckWipe.GetResponseStream());

                txtOutput.Text += "HTTP 200 - OK\r\n";
                string responseBody = sr.ReadToEnd().Trim();
                Byte[] byteResp = utf8Encoding.GetBytes(responseBody);
                txtOutput.Text += "Device has been wiped (emulated).\r\n";
            }
            catch (WebException)
            {
            }
            

        }

        private void btnClearCertChain_Click(object sender, EventArgs e)
        {
            txtCertList.Text = "";
        }

        private void btnIRMGetPol_Click(object sender, EventArgs e)
        {                        
            strServerAddress = buildServerAddress();

            string strUsername = txtUsername.Text;
            string strPassword = txtPassword.Text;
            string strDomain = txtDomain.Text;

            string strEncCredentials = null;

            if (txtDomain.Text == "")
            {
                strEncCredentials = getEncCredentials(strUsername, strPassword);
            }
            else if (txtDomain.Text != "")
            {
                strEncCredentials = getEncCredentials(strUsername, strPassword, strDomain);
            }

            System.Text.UTF8Encoding utf8Encoding = new System.Text.UTF8Encoding();

            //fetch chosen MS-ASProtocolVersion from list
            try
            {
                ListViewItem lstASVersion = lstASVersions.FocusedItem;
                int intASVersion = lstASVersion.Index;
                strASVersion = lstASVersions.Items[intASVersion].SubItems[1].Text;
            }
            catch (Exception)
            {                
            }

            //Check to see we're running against Exchange 2010 SP1
            if (strASVersion != "14.1")
            {
                txtIRMOutput.Text += "Sorry, requires Exchange 2010 Service Pack 1. Please check this on the \"Main\" tab\r\n";
                return;
            }

            string uri = strServerAddress + "?Cmd=Settings&User=" + strUsername + "&DeviceId=" + strDeviceId + "&DeviceType=" + strDeviceType;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.ContentType = "application/vnd.ms-sync.wbxml";

            webRequest.Method = "POST";
            webRequest.Headers.Add("Authorization", "Basic " + strEncCredentials);
            webRequest.Headers.Add("MS-ASProtocolVersion", strASVersion);
            webRequest.UserAgent = strUserAgent;

            //Add policykey if we are provisionable (requires that we have provisioned as well)
            if (chkProvisionable.Checked == true)
            {
                webRequest.Headers.Add("X-MS-PolicyKey", strPolicyKey);
            }

            //Check to see if we're using client certificates
            if (chkUseClientCert.Checked == true)
            {
                webRequest.ClientCertificates.Add(checkClientCert());
            }

            byte[] postBytes = new byte[12];

            //intro
            postBytes[0] = 0x03;
            postBytes[1] = 0x01;
            postBytes[2] = 0x6a;
            postBytes[3] = 0x00;
            
            //code page 18
            postBytes[4] = 0x00;
            postBytes[5] = 0x12;
            
            //Settings->IRM->Get
            postBytes[6] = 0x45;
            postBytes[7] = 0x6b;
            postBytes[8] = 0x47;

            //close up
            postBytes[9] = 0x01;
            postBytes[10] = 0x01;
            postBytes[11] = 0x01;


            webRequest.ContentLength = postBytes.Length;
            try
            {
                Stream sw = webRequest.GetRequestStream();
                sw.Write(postBytes, 0, postBytes.Length);
                sw.Close();
                WebResponse webResponse = webRequest.GetResponse();

                if (webResponse == null)
                {
                }                

                StreamReader sr = new StreamReader(webResponse.GetResponseStream());

                string responseBody = sr.ReadToEnd().Trim();
                Byte[] byteResp = utf8Encoding.GetBytes(responseBody);
                Byte[] statusCode = new Byte[14];
                string strStatusCode = "";

                //Only parse if the response is less than 30 chars in length (indicating an error)
                if (byteResp.Length <= 30)
                {
                    int intRecBytes = 0;
                    bool recBytes = false;
                    char chrStatusCode;
                    string hexStrResp = "";

                    //to get the temp key we loop the array, and "record" only the necessary bytes
                    for (int loopCounter = 0; loopCounter < byteResp.Length; loopCounter++)
                    {
                        hexStrResp = byteResp[loopCounter].ToString();
                        chrStatusCode = (char)byteResp[loopCounter];

                        //set recording on when finding the start character
                        if (chrStatusCode == 'F')
                        {
                            recBytes = true;
                        }
                        //end recording when finding the end character
                        if (hexStrResp == "1")
                        {
                            recBytes = false;
                        }
                        //record the temp policy key
                        if (recBytes == true)
                        {
                            statusCode[intRecBytes] = byteResp[loopCounter];
                            intRecBytes++;
                        }
                    }

                    char[] finalKey = new char[14];
                    string str_tmp_StatusCode = "";

                    for (int loopTmpPolKey = 2; loopTmpPolKey < 13; loopTmpPolKey++)
                    {
                        finalKey[loopTmpPolKey] = (char)statusCode[loopTmpPolKey];
                        //we need to filter out the escaped zeroes
                        if (finalKey[loopTmpPolKey] == '\0')
                        {
                            str_tmp_StatusCode += "";
                        }
                        else
                        {
                            str_tmp_StatusCode += finalKey[loopTmpPolKey];
                        }
                    }

                    //"dirty parse" to get the proper output
                    strStatusCode = str_tmp_StatusCode.Remove(0, 3);
                }
                //if content was longer we assume it's ok and set status to 1
                else
                {
                    strStatusCode = "1";
                }

                switch (strStatusCode)
                {
                    case "168":
                        txtIRMOutput.Text += "Status:" + strStatusCode + "\r\n";
                        txtIRMOutput.Text += "IRM disabled. Check ActiveSync policy.\r\n";
                        break;

                    case "169":
                        txtIRMOutput.Text += "Status:" + strStatusCode + "\r\n";
                        txtIRMOutput.Text += "Transient failure. Please retry in a few minutes.\r\n";
                        break;

                    case "170":
                        txtIRMOutput.Text += "Status:" + strStatusCode + "\r\n";
                        txtIRMOutput.Text += "Permanent failure or multiple transient failures. Please check your servers (Exchange and IRM).\r\n";
                        break;

                    case "171":
                        //Should not be able to get this status code on a get policy action
                        txtIRMOutput.Text += "Status:" + strStatusCode + "\r\n";
                        txtIRMOutput.Text += "Invalid template ID value.\r\n";
                        break;

                    case "172":
                        //Should not be able to get this status code on a get policy action
                        txtIRMOutput.Text += "Status:" + strStatusCode + "\r\n";
                        txtIRMOutput.Text += "Action prohibited by rights policy template.\r\n";
                        break;

                    default:
                        txtIRMOutput.Text += "IRM Policies: \r\n";            
                        //to be able to represent the response in a textbox we need to parse the individual chars
                        char charResp = '0';
                        for (int i = 0; i < byteResp.Length; i++)
                        {
                            charResp = (char)byteResp[i];
                            if (byteResp[i] == 0x01)
                            {
                                if (chkWordWrapIRM.Checked == true)
                                {
                                    txtIRMOutput.Text += "\r\n";
                                }
                                else
                                {
                                    txtIRMOutput.Text += charResp;
                                }
                            }
                            else
                            {
                                txtIRMOutput.Text += charResp;
                            }
                        }
                        break;
                }
              
            }
            catch (WebException ex)
            {
                txtOutput.Text += "Exception: " + ex.Message.ToString() + "\r\n";

                switch (ex.Status.ToString())
                {

                    case ("NameResolutionFailure"):
                        txtIRMOutput.Text += "Possible reason: DNS lookup failed, or server is not reachable by host name.";
                        break;

                    case ("ConnectFailure"):
                        txtIRMOutput.Text += "Possible reason: The server is not reachable at the specified address, or port is not open. \r\n";
                        txtIRMOutput.Text += "Check that necessary services are responding, and firewall rules aren't blocking connections.";
                        break;

                    case ("ProtocolError"):
                        if (ex.Message.ToString().Contains("(400)") == true)
                        {
                            txtIRMOutput.Text += "Possibly a protocol mismatch. Will be returned if you're not using ASProtocolVersion 14.1\r\n";
                            txtIRMOutput.Text += "Choose Exchange 2010 SP1, and try to run test again.\r\n";
                        }
                        
                        if (ex.Message.ToString().Contains("(449)"))
                        {
                            if (chkProvisionable.Checked == false)
                            {
                                txtOutput.Text += "You seem to be using a non-provisionable device.\r\n";
                                txtOutput.Text += "Check \"Provisionable device\" and run test again.\r\n";
                            }
                            else
                            {
                                txtOutput.Text += "You seem to be running a provisionable device, but will need to apply policies before sync is allowed.\r\n";
                                txtOutput.Text += "Check \"Support security policies\" and run test again.\r\n";
                            }
                        }

                        if (ex.Message.ToString().Contains("(451)") == true)
                        {
                            txtIRMOutput.Text += "Redirect request. Your mailbox could have been moved to a different server.\r\n";                          
                            txtIRMOutput.Text += "Address returned by Exchange: " + ex.Response.Headers.Get("X-MS-Location") + "\r\n";
                            txtIRMOutput.Text += "Please change the FQDN part in the \"Server Address\" field.\r\n";
                        }

                        break;

                    case ("TrustFailure"):
                        txtOutput.Text += "The SSL certificate presented is not trusted. \r\n";
                        txtOutput.Text += "Check \"Trust all certificates\" and run test again.";
                        break;

                    default:
                        break;

                }
            }

        }

        private void btnClearIRMOutput_Click(object sender, EventArgs e)
        {
            txtIRMOutput.Text = "";
        }

        private void btnAutodiscoverRunTests_Click(object sender, EventArgs e)
        {
            if (txtAutodiscoverEmailAddress.Text == "" || txtAutodiscoverPassword.Text == "")
            {
                txtAutodiscoverOutput.Text += "You need to enter email address and password to run tests.";
                return;
            }
            
            string[] strEmailAddressSplit;
            string strEmailAddress = txtAutodiscoverEmailAddress.Text;
            string strUsername = null;
            string strFqdn = null;
            string strPassword = txtAutodiscoverPassword.Text;
            string strEncCredentials = null;

            try
            {
                strEmailAddressSplit = txtAutodiscoverEmailAddress.Text.Split('@');
                strUsername = strEmailAddressSplit[0];
                strFqdn = strEmailAddressSplit[1];
            }
            catch (Exception)
            {
                txtAutodiscoverOutput.Text += "You sure you typed in a valid email address?\r\n";
            }

            if (chkTrustCertsAutodiscover.Checked == true)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback =
                    delegate(object sender2, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    { return true; };
            }
            else
            {
                // BUG - Once all certs are trusted it cannot be reset to default!!!
                // Requires restarting the app to reset.
            }
           
            string autodiscoverRequest = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Autodiscover xmlns=\"http://schemas.microsoft.com/exchange/autodiscover/mobilesync/requestschema/2006\"><Request><EMailAddress>" + txtAutodiscoverEmailAddress.Text + "</EMailAddress><AcceptableResponseSchema>http://schemas.microsoft.com/exchange/autodiscover/mobilesync/responseschema/2006</AcceptableResponseSchema></Request></Autodiscover>";

            if (txtAutodiscoverUsername.Text != "" && txtAutodiscoverDomain.Text != "")
            {
                strEncCredentials = getEncCredentials(txtAutodiscoverUsername.Text, strPassword, txtAutodiscoverDomain.Text);
            }
            else
            {
                strEncCredentials = getEncCredentials(strEmailAddress, strPassword);
            }

            if (chkAutodiscoverTest0.Checked == true)
            {
                string uri = "https://" + strFqdn + "/autodiscover/autodiscover.xml";
                txtAutodiscoverOutput.Text += "Test #1:\r\n\r\n";
                txtAutodiscoverOutput.Text += autodiscoverTest(autodiscoverRequest, strFqdn, strEncCredentials, "POST", uri) + "\r\n";
                txtAutodiscoverOutput.Text += strSeparator2 + "\r\n";
            }

            if (chkAutodiscoverTest1.Checked == true)
            {
                string uri = "https://autodiscover." + strFqdn + "/autodiscover/autodiscover.xml";
                txtAutodiscoverOutput.Text += "Test #2:\r\n\r\n";
                txtAutodiscoverOutput.Text += autodiscoverTest(autodiscoverRequest, strFqdn, strEncCredentials, "POST", uri) + "\r\n";
                txtAutodiscoverOutput.Text += strSeparator2 + "\r\n";
            }

            if (chkAutodiscoverTest2.Checked == true)
            {
                string uri = "http://autodiscover." + strFqdn + "/autodiscover/autodiscover.xml";
                txtAutodiscoverOutput.Text += "Test #3:\r\n\r\n";
                txtAutodiscoverOutput.Text += autodiscoverTest(autodiscoverRequest, strFqdn, strEncCredentials, "GET", uri) + "\r\n";
                txtAutodiscoverOutput.Text += strSeparator2 + "\r\n";
            }

            if (chkAutodiscoverTest3.Checked == true)
            {                
                //Not implemented yet - just a placeholder                
            }

        }

        private string autodiscoverTest(string autodiscoverRequest,string strFqdn, string strEncCredentials,string httpMethod, string uri)
        {
            string strResponseBody = null;
            string strResult = null;

            try
            {             
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
                webRequest.Method = httpMethod;
                webRequest.UserAgent = "MobilityDojo.net";                

                strResponseBody += "Testing following Autodiscover address:\r\n" + uri + "\r\n";

                if (httpMethod == "POST")
                {
                    System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                    Byte[] byteRequest = encoding.GetBytes(autodiscoverRequest);  

                    webRequest.Headers.Add("Authorization", "Basic " + strEncCredentials);
                    webRequest.ContentType = "text/xml";
                    webRequest.ContentLength = byteRequest.Length;

                    Stream sw = webRequest.GetRequestStream();
                    sw.Write(byteRequest, 0, byteRequest.Length);
                    sw.Close();
                }

                //If we allow automatic redirection (HTTP 302) we end up with HTTP 401
                //Need to disable redirection to catch it
                if (httpMethod == "GET")
                {                    
                    webRequest.AllowAutoRedirect = false;                                        
                }
                
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse == null)
                {
                }

                //If we get a redirect notification we parse out the address.
                //This is expected/correct behaviour for the HTTP GET test.                
                HttpWebResponse resEx = (HttpWebResponse)webResponse;
                int resCode = (int)resEx.StatusCode;
                if (resCode == 302)
                {

                    try
                    {
                        string[] resultHeaders = webResponse.Headers.GetValues("Location");
                        strResponseBody += "Autodiscover redirect; " + resultHeaders[0].ToString() + "\r\n";
                    }
                    catch (Exception)
                    {
                    }
                }

                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                strResult = "PASS\r\n";
                strResponseBody += "Status: " + strResult + "\r\n";               
                strResponseBody += sr.ReadToEnd().Trim();               
            }
            catch (WebException ex)
            {                
                //We provide "fake" values for the parameters we don't use/need
                strResponseBody += "Response: " + parseHTTPException(ex, "12.1", false) + "\r\n";                
            }

            return strResponseBody;
        }

        private void btnClearAutodiscoverOutput_Click(object sender, EventArgs e)
        {
            txtAutodiscoverOutput.Text = "";
        }

        private void lnkLblDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://mobilitydojo.net/downloads/");
        }

        private void lnkLblAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://mobilitydojo.net/about/");
        }

        private void lnkLblGit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ahelland/EASMD");
        }

        private void btnClearWbxml_Click(object sender, EventArgs e)
        {
            txtWbxmlInput.Text = "";
            txtWbxmlOutput.Text = "";
        }

        private void btnExecuteWbxml_Click(object sender, EventArgs e)
        {
            if (chkTrustAllCerts.Checked == true)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback =
                    delegate(object sender2, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    { return true; };
            }
            else
            {
                // BUG - Once all certs are trusted it cannot be reset to default!!!
                // Requires restarting the app to reset.
            }

            string strUsername = txtUsername.Text;
            string strPassword = txtPassword.Text;
            string strDomain = txtDomain.Text;

            string strWbxmlInput = txtWbxmlInput.Text;
            StringReader sourceXml = new StringReader(strWbxmlInput);

            XDocument sourceWbxml = XDocument.Load(sourceXml);

            WBXMLWriter wbxmlWriter = new WBXMLWriter(new ASCodePageProvider());
            WBXMLConverter wbxmlConverter = new WBXMLConverter(new ASCodePageProvider(), wbxmlWriter, null);

            IList<byte> bSourceWbxml = wbxmlConverter.Parse(sourceWbxml);

            string strEncCredentials = null;

            if (txtDomain.Text == "")
            {
                strEncCredentials = getEncCredentials(strUsername, strPassword);
            }
            else if (txtDomain.Text != "")
            {
                strEncCredentials = getEncCredentials(strUsername, strPassword, strDomain);
            }

            getDeviceParams();

            bool bProvOk = false;

            //fetch chosen MS-ASProtocolVersion from list
            //if unable to get version default to 12.1
            try
            {
                ListViewItem lstASVersion = lstASVersions.FocusedItem;
                int intASVersion = lstASVersion.Index;
                strASVersion = lstASVersions.Items[intASVersion].SubItems[1].Text;
            }
            catch (Exception)
            {
                txtWbxmlOutput.Text += "\r\n" + "You seem to not have chosen an ActiveSync version. Defaulting to 12.1 (Exchange 2007 SPx)" + "\r\n";
                strASVersion = "12.1";
            }

            //are we emulating a provisionable device?
            if (chkProvisionable.Checked == true)
            {
                bProvisionable = true;
            }

            //do we need to provision?
            if (chkFakeSecPol.Checked == true)
            {
                //Exchange 2010 SP1 (EAS 14.1) introduces a new method for acquiring a policy key
                if (strASVersion == "14.1")
                    strPolicyKey = ProvisionE141(strUsername, strEncCredentials);
                else
                    strPolicyKey = Provision(strUsername, strEncCredentials);
                bProvOk = true;
            }

            strServerAddress = buildServerAddress();

            string strCmd = cBoxCmd.SelectedItem.ToString();

            string uri = strServerAddress + "?Cmd=" + strCmd + "&User=" + strUsername + "&DeviceId=" + strDeviceId + "&DeviceType=" + strDeviceType;

            //FolderSync cmd
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.Method = "POST";
            webRequest.Headers.Add("Authorization", "Basic " + strEncCredentials);
            webRequest.ContentType = "application/vnd.ms-sync.wbxml";
            webRequest.AllowAutoRedirect = false; //catch HTTP 302 instead of following them

            //Check to see if we're using client certificates
            if (chkUseClientCert.Checked == true)
            {
                webRequest.ClientCertificates.Add(checkClientCert());
            }

            //Emulate the chosen AS version
            webRequest.Headers.Add("MS-ASProtocolVersion", strASVersion);

            webRequest.UserAgent = strUserAgent;

            //If we emulate provisionable we need to set X-MS-PolicyKey in the header
            //If we're not provisionable, but the server requires this we'll get a 403 response
            if (bProvisionable == true)
            {
                if (bProvOk)
                {
                    webRequest.Headers.Add("X-MS-PolicyKey", strPolicyKey);
                }
                else
                {
                    webRequest.Headers.Add("X-MS-PolicyKey", "0");
                }

            }

            webRequest.ContentLength = bSourceWbxml.Count;

            try
            {
                byte[] bBuffer = new byte[bSourceWbxml.Count];
                bSourceWbxml.CopyTo(bBuffer, 0);

                Stream sw = webRequest.GetRequestStream();
                sw.Write(bBuffer, 0, bBuffer.Length);
                sw.Close();

                txtWbxmlOutput.Text += "Response: " + "\r\n\r\n";
                WebResponse webResponseWbxml = webRequest.GetResponse();
                if (webResponseWbxml == null)
                {
                }

                System.Text.UTF8Encoding utf8Encoding = new System.Text.UTF8Encoding();
                StreamReader srResponse = new StreamReader(webResponseWbxml.GetResponseStream());

                string strResponseBody = srResponse.ReadToEnd().Trim();
                byte[] bDestWbxml = utf8Encoding.GetBytes(strResponseBody);

                XElement destXml = wbxmlConverter.Parse(bDestWbxml);

                txtWbxmlOutput.Text += destXml.ToString();
                txtWbxmlOutput.Text += "\r\n";
            }

            catch (WebException ex)
            {
                txtWbxmlOutput.Text += "Response: " + parseHTTPException(ex, strASVersion, bProvisionable) + "\r\n";                
            }


        }

        


    }
}
