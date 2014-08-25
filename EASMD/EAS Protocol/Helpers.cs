using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
using System.Net;
using System.Text;

namespace EAS_Protocol.Helpers
{
    public static class HelperMethods
    {
        public static string getEncCredentials(string emailadress, string password)
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

        public static string getEncCredentials(string username, string password, string domain)
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

        public static string getUsername(string credentials)
        {
            byte[] bRawCredentials = System.Convert.FromBase64String(credentials);
            string strRawCredentials = Encoding.UTF8.GetString(bRawCredentials,0,bRawCredentials.Length);

            string username = "";
            
            //If username == user@domain.com
            if (strRawCredentials.Contains("@"))
            {
                try
                {
                    string[] creds = strRawCredentials.Split('@');
                    username = creds[0];
                }
                catch
                { }
            }
            //If username == domain\username
            if (strRawCredentials.Contains("\\"))
            {
                try
                {
                    char[] splitParams = { '\\', ':' };
                    string[] creds = strRawCredentials.Split(splitParams);
                    username = creds[1];
                }
                catch
                { }
            }

            return username;
        }

        //private static string parseHTTPException(WebException httpEx, string strEASVersion, bool bProvisionable)
        //{
        //    string parsedEx = null;

        //    switch (httpEx.Status.ToString())
        //    {

        //        case ("NameResolutionFailure"):
        //            parsedEx += httpEx.Message.ToString() + "<br />";
        //            parsedEx += "Possible reason: DNS lookup failed, or server is not reachable by host name.<br />";
        //            parsedEx += "Status: FAIL";
        //            break;

        //        case ("ConnectFailure"):
        //            parsedEx += httpEx.Message.ToString() + "<br />";
        //            parsedEx += "Possible reason: The server is not reachable at the specified address, or port is not open.<br />";
        //            parsedEx += "Check that necessary services are responding, and firewall rules aren't blocking connections.<br />";
        //            parsedEx += "Status: FAIL";
        //            break;

        //        case ("SendFailure"):
        //            parsedEx += httpEx.Message.ToString() + "<br />";
        //            parsedEx += "There does not seem to be a server responding at this address. <br />";
        //            parsedEx += "Verify that the URL should respond and run test again.<br />";
        //            parsedEx += "Status: Further action required";
        //            break;

        //        case ("ProtocolError"):
        //            parsedEx += httpEx.Message.ToString() + "<br />";
        //            HttpWebResponse resEx = (HttpWebResponse)httpEx.Response;
        //            int resCode = (int)resEx.StatusCode;
        //            if (resCode == 302)
        //            {
        //                parsedEx += "Explanation:<br />";
        //                parsedEx += "Server issued a redirect to a new URL. You should issue a new Autodiscover (and change FQDN).<br />";
        //                parsedEx += "Status: Further action required";
        //            }

        //            if (resCode == 400)
        //            {
        //                parsedEx += "Explanation:<br />";
        //                parsedEx += "Possibly a protocol mismatch, for example using version 14.0 against an Exchange 2007 server.<br />";
        //                parsedEx += "Choose a different protocol version to emulate, and try to run test again.<br />";
        //                parsedEx += "Status: FAIL";
        //            }
        //            if (resCode == 401)
        //            {
        //                parsedEx += "Explanation:<br />";
        //                parsedEx += "Wrong username/password. May also occur if you're using a reverse proxy which performs authentication.<br />";
        //                parsedEx += "Could also be caused by authenticating with user@domain.com if Active Directory doesn't accept this.<br />";
        //                parsedEx += "Status: FAIL";
        //            }
        //            if (resCode == 403)
        //            {
        //                if (strEASVersion == "12.0" || strEASVersion == "12.1")
        //                {
        //                    parsedEx += "Explanation:<br />";
        //                    parsedEx += "You are either running a non-provisionable device, or a provisionable device that haven't been provisioned yet.<br />";
        //                    parsedEx += "First check: Tick off \"Provisionable device\" and run test again.<br />";
        //                    parsedEx += "Second check Tick off \"Support security policies\" and run test again.<br />";
        //                    parsedEx += "Status: Further action required";
        //                }
        //                else
        //                {
        //                    parsedEx += "Explanation:<br />";
        //                    parsedEx += "The server requires SSL and will not let you connect over HTTP.<br />";
        //                    parsedEx += "(For instance trying to connect over HTTP while IIS requires SSL.)<br />";
        //                    parsedEx += "Status: Further action required";
        //                }
        //            }
        //            if (resCode == 404)
        //            {
        //                parsedEx += "Explanation:<br />";
        //                parsedEx += "File not found shouldn't occur...check IIS that files are not missing.<br />";
        //                parsedEx += "Status: FAIL";
        //            }
        //            if (resCode == 449)
        //            {
        //                if (bProvisionable == false)
        //                {
        //                    parsedEx += "Explanation:<br />";
        //                    parsedEx += "You seem to be using a non-provisionable device.<br />";
        //                    parsedEx += "Check \"Provisionable device\" and run test again.<br />";
        //                    parsedEx += "Status: Further action required";
        //                }
        //                else
        //                {
        //                    parsedEx += "Explanation:<br />";
        //                    parsedEx += "You seem to be running a provisionable device, but will need to apply policies before sync is allowed.<br />";
        //                    parsedEx += "Check \"Support security policies\" and run test again.<br />";
        //                    parsedEx += "Status: Further action required";
        //                }
        //            }
        //            if (resCode == 451)
        //            {
        //                parsedEx += "Explanation:<br />";
        //                parsedEx += "Redirect request. Your mailbox is located on a different server.<br />";
        //                parsedEx += "Address returned by Exchange: " + httpEx.Response.Headers.Get("X-MS-Location") + "<br />";
        //                parsedEx += "Please change the FQDN part in the \"Server Address\" field.<br />";
        //                parsedEx += "Status: Further action required";
        //            }
        //            if (resCode == 501 || resCode == 505)
        //            {
        //                parsedEx += "Explanation:<br />";
        //                parsedEx += "This is correct behaviour, and means your Exchange server is responding!<br />";
        //                parsedEx += "Status: PASS";
        //            }
        //            if (resCode == 502)
        //            {
        //                parsedEx += "Explanation:<br />";
        //                parsedEx += "There is a server available at this FQDN and this port, but it's not responding to your request.<br />";
        //                parsedEx += "Could for instance happen if http://contoso.com does not redirect to an Exchange server.<br />";
        //                parsedEx += "Status: FAIL";
        //            }
        //            if (resCode == 503)
        //            {
        //                parsedEx += "Explanation:<br />";
        //                parsedEx += "You server is either experiencing too much load, or in a maintenance mode.<br />";
        //                parsedEx += "Check again in a short while, and if problem persists check that all services are running on your Exchange server.<br />";
        //                parsedEx += "Status: FAIL";
        //            }
        //            if (resCode == 504)
        //            {
        //                parsedEx += "Explanation:<br />";
        //                parsedEx += "Seems your Exchange server might have problems on the back end connecting to other servers (possibly Active Directory).<br />";
        //                parsedEx += "Check network connectivity on your Exchange server. (Problem most likely not between ActiveSync client and Exchange.)<br />";
        //                parsedEx += "Status: FAIL";
        //            }

        //            break;

        //        case ("TrustFailure"):
        //            parsedEx += httpEx.Message.ToString() + "<br />";
        //            parsedEx += "The SSL certificate presented is not trusted. <br />";
        //            parsedEx += "Check \"Trust all certificates\" and run test again.<br />";
        //            parsedEx += "Status: Further action required";
        //            break;

        //        default:
        //            break;

        //    }

        //    return parsedEx;
        //}

        //private static string parseResponseStatus(string responseBody, string strEASVersion)
        //{
        //    string parsedStatus = null;

        //    if (responseBody.Contains("108") == true)
        //    {
        //        parsedStatus += "The device ID is invalid.";
        //        parsedStatus += "<br />Are you using any special characters? Only plain characters and numerals recommended.)";
        //        parsedStatus += "<br />";
        //    }

        //    if (responseBody.Contains("126") == true)
        //    {
        //        parsedStatus += "The user account does not have permission to synchronize.";
        //        parsedStatus += "<br />This could also be due to using an admin account. (Domain admin is not allowed to sync.)";
        //        parsedStatus += "<br />";
        //    }

        //    //if EAS >= 12.1 (Exchange 2007 SP1) we need to parse the returned wbxml for '142' to find out if we need to provision
        //    //EAS 12.0 indicates the same status through HTTP 449
        //    if (strEASVersion == "12.1" || strEASVersion == "14.0" || strEASVersion == "14.1")
        //    {
        //        if (responseBody.Contains("142") == true)
        //        {
        //            parsedStatus += "The response is ok, but you need to provision";
        //            parsedStatus += "<br />";
        //        }
        //    }
        //    if (responseBody.Contains("141") == true)
        //    {
        //        parsedStatus += "Only provisionable devices are allowed to sync, and you seem to be non-provisionable.<br />";
        //        parsedStatus += "Check the \"Provisionable device\" and run the test again.<br />";
        //    }
        //    if (responseBody.Contains("140") == true)
        //    {
        //        parsedStatus += "A remote wipe has been issued for your device.<br />";
        //        parsedStatus += "Choose \"Remote Wipe (Emulated)\" to simulate a wipe.<br />";
        //    }
        //    if (responseBody.Contains("144") == true)
        //    {
        //        parsedStatus += "The device's policy key is invalid. The policy has probably changed on the server. The device needs to re-provision.<br />";
        //        parsedStatus += "This may happen if you have synced a \"device\" with security policies and then removed the support for all policies.<br />";
        //    }

        //    else if (responseBody.Length <= 15)
        //    {
        //        parsedStatus += "More status codes can be looked up here:<br />";
        //        parsedStatus += "http://msdn.microsoft.com/en-us/library/ee218647(v=EXCHG.80).aspx<br />";
        //    }


        //    return parsedStatus;
        //}
    }
}
