using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using EAS_Protocol.Models;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.XPath;
using EAS_Protocol.WBXML;
using System.Xml.Linq;

namespace EAS_Protocol
{
    public class AS_CMD
    {
        public void Autodiscover()
        {}

        public void FolderCreate()
        {}

        public void FolderDelete()
        {}

        /// <summary>
        /// <para>Retrieves the collection ID for a given item type.</para>
        /// <para>A call to FolderSync should be made first to acquire the FolderSync XML.</para>
        /// </summary>
        /// <param name="FolderSyncResponse">A FolderSync XML string containing a folder hierarchy.</param>
        /// <param name="ItemType">Type of item to retrieve collection ID for. Use FolderSyncTypes enum for this.</param>
        /// <returns>Collection ID for the given item type.</returns>
        public static string GetCollectionID(string FolderSyncResponse, int ItemType)
        {
            string collectionId = "";

            try
            {
                var xmlFolderSync = new XmlDocument();
                xmlFolderSync.LoadXml(FolderSyncResponse);

                //Check the status of the search request
                var status = xmlFolderSync.GetElementsByTagName("Status");

                //Status of "1" == Success
                if (status[0].InnerXml == "1")
                {
                    //Acquire all "Add" nodes in FolderSync
                    XPathNavigator nav = xmlFolderSync.CreateNavigator();
                    XmlNamespaceManager man = new XmlNamespaceManager(nav.NameTable);
                    man.AddNamespace("fs", "FolderHierarchy:");
                    XPathNodeIterator nodes = nav.Select("/fs:FolderSync/fs:Changes/fs:Add", man);

                    //We're only interested in the node for the Default Tasks
                    while (nodes.MoveNext())
                    {
                        XPathNavigator nodesNav = nodes.Current;
                        XPathNodeIterator nodesElement = nodesNav.SelectDescendants(XPathNodeType.Element, true);

                        var v = "0";
                        foreach (XPathNavigator item in nodesElement)
                        {
                            //FolderSync "ServerId" == Sync "CollectionId"
                            //If the Type is the right one we assign the value to the collectionId variable
                            if (item.Name == "ServerId")
                            {
                                v = item.Value;
                            }
                            if (item.Name == "Type" && item.Value == (ItemType.ToString()))
                            {
                                collectionId = v;
                            }

                        }
                    }
                }
                //Status !1 == !OK
                else
                {
                    switch (status[0].InnerXml)
                    {
                        case "2":
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
            return collectionId;
        }

        /// <summary>
        /// Retrieves the Folder structure from a mailbox when no SyncKey exists.
        /// </summary>
        /// <param name="dev">A "Device" object.</param>
        /// <returns>XML response from Exchange.</returns>
        public static string FolderSync(Device dev)
        {
            return FolderSync(dev, "0");
        }

        /// <summary>
        /// Retrieves the Folder structure from the mailbox with a given SyncKey.
        /// </summary>
        /// <param name="dev">A "Device" object.</param>
        /// <param name="SyncKey">The current SyncKey. Pass in 0 if a SyncKey has not been acquired yet.</param>
        /// <returns>XML response from Exchange.</returns>
        public static string FolderSync(Device dev, string SyncKey)
        {            
            string strUsername = dev.Username;
            string strPassword = dev.Password;
            string strDeviceID = dev.DeviceID;
            string strDeviceType = dev.DeviceType;
            string credentials = dev.Credentials;

            string easUrl = dev.ServerAddress;                        

            string ASVersion = dev.ASVersion;
            string UserAgent = dev.UserAgent;

            MemoryStream ms = new MemoryStream();
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.Encoding = new UTF8Encoding();

            XmlWriter xwFolderSync = XmlWriter.Create(ms, xmlSettings);

            //Do a FolderSync to discover the Server/Collection Id
            xwFolderSync.WriteStartDocument();
            xwFolderSync.WriteStartElement("FolderSync", "FolderHierarchy");
            xwFolderSync.WriteStartElement("SyncKey"); xwFolderSync.WriteString("0"); xwFolderSync.WriteEndElement();
            xwFolderSync.WriteEndElement();
            xwFolderSync.WriteEndDocument();

            xwFolderSync.Flush();

            byte[] syncXml = ms.ToArray();
            string strsyncXml = Encoding.UTF8.GetString(syncXml);

            ms.Position = 0;

            byte[] wbXml = null;
            byte[] responseXml = null;

            string decodedResponse = null;

            #region
            //FolderSync
            using (var client = new HttpClient())
            {
                string queryString = "?Cmd=FolderSync" +
                    "&User=" + strUsername +
                    "&DeviceId=" + strDeviceID +
                    "&DeviceType=" + strDeviceType;

                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/vnd.ms-sync.wbxml");

                //Convert XML => WBXML
                //byte[] b = this.Request.BinaryRead(this.Request.ContentLength);
                //string xmlSource = System.Text.Encoding.UTF8.GetString(b);

                StringReader sr = new StringReader(strsyncXml);

                XDocument xDoc = XDocument.Load(sr, LoadOptions.None);

                WBXMLWriter wbWriter = new WBXMLWriter(new ASCodePageProvider());
                WBXMLConverter wbConvert = new WBXMLConverter(new ASCodePageProvider(), wbWriter, null);

                IList<byte> wbXmlResult = wbConvert.Parse(xDoc);

                byte[] bytesArr = wbXmlResult.ToArray();

                wbXml = bytesArr;

                //System.Text.Encoding.UTF8.GetString(bytesArr);


                //var post = client.PostAsync(toWBXMLUrl, new StringContent(strsyncXml));
                //if (post.Result.IsSuccessStatusCode)
                //{
                //    var result = post.Result.Content;
                //    wbXml = result.ReadAsByteArrayAsync().Result;
                //}

                //Clear headers so "client" can be re-used
                client.DefaultRequestHeaders.Clear();

                ByteArrayContent easWbxml = new ByteArrayContent(wbXml);
                easWbxml.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.ms-sync.wbxml");

                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Basic " + credentials);
                client.DefaultRequestHeaders.Add("MS-ASProtocolVersion", ASVersion);
                client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Length", wbXml.Length.ToString());

                //POST WBXML
                var response = client.PostAsync(easUrl + queryString, easWbxml);
                if (response.Result.IsSuccessStatusCode)
                {
                    var responseContent = response.Result.Content;
                    responseXml = responseContent.ReadAsByteArrayAsync().Result;
                }

                //Clear headers so "client" can be re-used
                //client.DefaultRequestHeaders.Clear();

                //client.DefaultRequestHeaders.Add("Accept", "application/xml");

                //Convert WBXML => XML
                byte[] xmlSource = responseXml;

                //WBXMLWriter wbWriter = new WBXMLWriter(new ASCodePageProvider());
                //WBXMLConverter wbConvert = new WBXMLConverter(new ASCodePageProvider(), wbWriter, null);

                XElement xmlResult = wbConvert.Parse(xmlSource);
                decodedResponse = xmlResult.ToString();
                //response = client.PostAsync(toXMLUrl, new ByteArrayContent(responseXml));
                //if (response.Result.IsSuccessStatusCode)
                //{
                //    var responseContent = response.Result.Content;
                //    decodedResponse = responseContent.ReadAsStringAsync().Result;
                //}
            }

            return decodedResponse;

            
            #endregion
        
        }
        
        public void FolderUpdate()
        {}

        public void GetAttachment()
        {}

        public void GetItemEstimate()
        {}

        public static string ItemOperations(Device dev, string Operation,string CollectionId, string ServerId)
        {
            string strUsername = dev.Username;
            string strPassword = dev.Password;
            string strDeviceID = dev.DeviceID;
            string strDeviceType = dev.DeviceType;
            string credentials = dev.Credentials;

            string easUrl = dev.ServerAddress;

            string ASVersion = dev.ASVersion;
            string UserAgent = dev.UserAgent;
            
            string TruncationSize = "5120";
            string AllOrNone = "0";
            string BodyType = BodyTypes.HTML;

            MemoryStream ms = new MemoryStream();
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.Encoding = new UTF8Encoding();

            XmlWriter xw = XmlWriter.Create(ms, xmlSettings);

            switch (Operation)
            {
                case ItemOperationTypes.FETCH:
                    xw.WriteStartDocument();
                    xw.WriteStartElement("ItemOperations", "ItemOperations");                   
                    xw.WriteAttributeString("xmlns", "airsync", null, "AirSync");
                    xw.WriteAttributeString("xmlns","airsyncbase",null,"AirSyncBase");                    
                    xw.WriteStartElement("Fetch");
                    xw.WriteStartElement("Store"); xw.WriteString("Mailbox"); xw.WriteEndElement();
                    xw.WriteStartElement("airsync","CollectionId",null); xw.WriteString(CollectionId); xw.WriteEndElement();
                    xw.WriteStartElement("airsync","ServerId",null); xw.WriteString(CollectionId + ":" + ServerId); xw.WriteEndElement();
                    xw.WriteStartElement("Options");
                    xw.WriteStartElement("airsyncbase","BodyPreference",null);
                    xw.WriteStartElement("airsyncbase","Type",null); xw.WriteString(BodyType); xw.WriteEndElement();
                    xw.WriteStartElement("airsyncbase","TruncationSize",null); xw.WriteString(TruncationSize); xw.WriteEndElement();
                    xw.WriteStartElement("airsyncbase","AllOrNone",null); xw.WriteString(AllOrNone); xw.WriteEndElement();
                    xw.WriteEndElement();
                    xw.WriteEndElement();
                    xw.WriteEndElement();
                    xw.WriteEndDocument();
                    xw.Flush();
                    break;

                //To be implemented later
                case ItemOperationTypes.EMPTY_FOLDER_CONTENTS:
                    break;

                //To be implemented later
                case ItemOperationTypes.MOVE:
                    break;

                default:
                    break;
            }

            byte[] itemXml = ms.ToArray();
            string stritemXml = Encoding.UTF8.GetString(itemXml);

            byte[] wbXml = null;
            byte[] responseXml = null;

            StringReader sr = new StringReader(stritemXml);

            XDocument xDoc = XDocument.Load(sr, LoadOptions.None);

            WBXMLWriter wbWriter = new WBXMLWriter(new ASCodePageProvider());
            WBXMLConverter wbConvert = new WBXMLConverter(new ASCodePageProvider(), wbWriter, null);

            IList<byte> wbXmlResult = wbConvert.Parse(xDoc);

            byte[] bytesArr = wbXmlResult.ToArray();

            wbXml = bytesArr;

            string decodedResponse = null;

            using (var client = new HttpClient())
            {
                string queryString = "?Cmd=ItemOperations" +
                    "&User=" + strUsername +
                    "&DeviceId=" + strDeviceID +
                    "&DeviceType=" + strDeviceType;

                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/vnd.ms-sync.wbxml");                

                ByteArrayContent easWbxml = new ByteArrayContent(wbXml);
                easWbxml.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.ms-sync.wbxml");

                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Basic " + credentials);
                client.DefaultRequestHeaders.Add("MS-ASProtocolVersion", ASVersion);
                client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Length", wbXml.Length.ToString());

                var response = client.PostAsync(easUrl + queryString, easWbxml);
                if (response.Result.IsSuccessStatusCode)
                {
                    var responseContent = response.Result.Content;
                    responseXml = responseContent.ReadAsByteArrayAsync().Result;
                }

                //Convert WBXML => XML
                byte[] xmlSource = responseXml;
                XElement xmlResult = wbConvert.Parse(xmlSource);
                decodedResponse = xmlResult.ToString();

                return decodedResponse;
            }
        }

        public void MeetingResponse()
        {}

        public void MoveItems()
        {}

        public void Ping()
        {}

        public void Provision()
        {}

        public void ResolveRecipients()
        {}

        /// <summary>
        /// Performs a search operation on the Exchange Server.
        /// </summary>
        /// <param name="dev">A "Device" object.</param>
        /// <param name="SearchType">The kind of search to perform. Use the SearchTypes class to specify.</param>
        /// <param name="SearchQuery">What to search for.</param>
        /// <param name="StartIndex">Start Index of results.</param>
        /// <param name="EndIndex">End Index of results.</param>
        /// <returns>XML document with results.</returns>
        public static string Search(Device dev, string SearchType, string SearchQuery, int StartIndex, int EndIndex)
        {
            string strUsername = dev.Username;
            string strPassword = dev.Password;
            string strDeviceID = dev.DeviceID;
            string strDeviceType = dev.DeviceType;
            string credentials = dev.Credentials;

            string easUrl = dev.ServerAddress;
           
            string ASVersion = dev.ASVersion;
            string UserAgent = dev.UserAgent;

            MemoryStream ms = new MemoryStream();
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.Encoding = new UTF8Encoding();

            XmlWriter xw = XmlWriter.Create(ms, xmlSettings);

            switch(SearchType)
            {
                case SearchTypes.SEARCH_GAL:
                    xw.WriteStartDocument();
                    xw.WriteStartElement("Search", "Search:");
                    xw.WriteStartElement("Store");
                    xw.WriteStartElement("Name"); xw.WriteString(SearchTypes.SEARCH_GAL); xw.WriteEndElement();
                    xw.WriteStartElement("Query"); xw.WriteString(SearchQuery); xw.WriteEndElement();
                    xw.WriteStartElement("Options");
                    xw.WriteStartElement("Range"); xw.WriteString("0-" + EndIndex.ToString()); xw.WriteEndElement();
                    xw.WriteEndElement();
                    xw.WriteEndElement();
                    xw.WriteEndDocument();
                    xw.Flush();
                break;

                //To be implemented later
                case SearchTypes.SEARCH_MAILBOX:
                break;

                //To be implemented later
                case SearchTypes.SEARCH_DOCUMENT_LIBRARY:
                break;

                default:
                break;
            }
                       
            byte[] galXml = ms.ToArray();
            string strgalXml = Encoding.UTF8.GetString(galXml);

            byte[] wbXml = null;
            byte[] responseXml = null;

            StringReader sr = new StringReader(strgalXml);

            XDocument xDoc = XDocument.Load(sr, LoadOptions.None);

            WBXMLWriter wbWriter = new WBXMLWriter(new ASCodePageProvider());
            WBXMLConverter wbConvert = new WBXMLConverter(new ASCodePageProvider(), wbWriter, null);

            IList<byte> wbXmlResult = wbConvert.Parse(xDoc);

            byte[] bytesArr = wbXmlResult.ToArray();

            wbXml = bytesArr;

            string decodedResponse = null;

            using (var client = new HttpClient())
            {                
                string queryString = "?Cmd=Search" +
                    "&User=" + strUsername +
                    "&DeviceId=" + strDeviceID +
                    "&DeviceType=" + strDeviceType;

                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/vnd.ms-sync.wbxml");
                
                //Clear headers so "client" can be re-used
                //client.DefaultRequestHeaders.Clear();

                ByteArrayContent easWbxml = new ByteArrayContent(wbXml);
                easWbxml.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.ms-sync.wbxml");

                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Basic " + credentials);
                client.DefaultRequestHeaders.Add("MS-ASProtocolVersion", ASVersion);
                client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Length", wbXml.Length.ToString());

                var response = client.PostAsync(easUrl + queryString, easWbxml);
                if (response.Result.IsSuccessStatusCode)
                {
                    var responseContent = response.Result.Content;
                    responseXml = responseContent.ReadAsByteArrayAsync().Result;
                }                
            }
            //Convert WBXML => XML
            byte[] xmlSource = responseXml;
            XElement xmlResult = wbConvert.Parse(xmlSource);
            decodedResponse = xmlResult.ToString();

            return decodedResponse;
        }

        //http://msdn.microsoft.com/en-us/library/ee178477(v=exchg.80).aspx
        public void SendMail(Device dev, string SendMail, string ClientId, string AccountId, bool SaveInSentItems, string Mime )
        {}

        public void Settings()
        {}

        public void SmartForward()
        {}

        public void SmartReply()
        {}

        /// <summary>
        /// Retrieves the SyncKey for a given CollectionID.
        /// </summary>
        /// <param name="dev">A "Device" object.</param>
        /// <param name="collectionId"></param>
        /// <returns>SyncKey</returns>
        public static string Sync(Device dev, string collectionId)
        {
            string strUsername = dev.Username;
            string strPassword = dev.Password;
            string strDeviceID = dev.DeviceID;
            string strDeviceType = dev.DeviceType;
            string credentials = dev.Credentials;

            string easUrl = dev.ServerAddress;

            string syncKey = "0";

            string ASVersion = dev.ASVersion;
            string UserAgent = dev.UserAgent;

            MemoryStream ms = new MemoryStream();
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.Encoding = new UTF8Encoding();

            XmlWriter xwFolderSync = XmlWriter.Create(ms, xmlSettings);

            //Do a FolderSync to discover the Server/Collection Id
            XmlWriter xwSync01 = XmlWriter.Create(ms, xmlSettings);
            xwSync01.WriteStartDocument();
            xwSync01.WriteStartElement("Sync", "AirSync");
            xwSync01.WriteStartElement("Collections");
            xwSync01.WriteStartElement("Collection");
            xwSync01.WriteStartElement("SyncKey"); xwSync01.WriteString(syncKey); xwSync01.WriteEndElement();
            xwSync01.WriteStartElement("CollectionId"); xwSync01.WriteString(collectionId); xwSync01.WriteEndElement();
            xwSync01.WriteEndElement();
            xwSync01.WriteEndElement();
            xwSync01.WriteEndDocument();
            xwSync01.Flush();


            xwFolderSync.Flush();

            byte[] syncXml = ms.ToArray();
            string strsyncXml = Encoding.UTF8.GetString(syncXml);

            ms.Position = 0;

            byte[] wbXml = null;
            byte[] responseXml = null;

            string decodedResponse = null;

            //Sync
            using (var client = new HttpClient())
            {
                string queryString = "?Cmd=Sync" +
                             "&User=" + strUsername +
                             "&DeviceId=" + strDeviceID +
                             "&DeviceType=" + strDeviceType;

                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/vnd.ms-sync.wbxml");

                //Convert XML => WBXML     
                StringReader sr = new StringReader(strsyncXml);

                XDocument xDoc = XDocument.Load(sr, LoadOptions.None);

                WBXMLWriter wbWriter = new WBXMLWriter(new ASCodePageProvider());
                WBXMLConverter wbConvert = new WBXMLConverter(new ASCodePageProvider(), wbWriter, null);

                IList<byte> wbXmlResult = wbConvert.Parse(xDoc);

                byte[] bytesArr = wbXmlResult.ToArray();

                wbXml = bytesArr;

                //Clear headers so "client" can be re-used
                client.DefaultRequestHeaders.Clear();

                ByteArrayContent easWbxml = new ByteArrayContent(wbXml);
                easWbxml.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.ms-sync.wbxml");

                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Basic " + credentials);
                client.DefaultRequestHeaders.Add("MS-ASProtocolVersion", ASVersion);
                client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Length", wbXml.Length.ToString());

                //POST WBXML
                var response = client.PostAsync(easUrl + queryString, easWbxml);
                if (response.Result.IsSuccessStatusCode)
                {
                    var responseContent = response.Result.Content;
                    responseXml = responseContent.ReadAsByteArrayAsync().Result;
                }

                //Convert WBXML => XML
                byte[] xmlSource = responseXml;
                XElement xmlResult = wbConvert.Parse(xmlSource);
                decodedResponse = xmlResult.ToString();

            }

            try
            {
                //Extract the SyncKey
                var xmlSync = new XmlDocument();
                xmlSync.LoadXml(decodedResponse);

                //Check the status of the search request
                var status = xmlSync.GetElementsByTagName("Status");

                //Status of "1" == Success
                if (status[0].InnerXml == "1")
                {
                    var key = xmlSync.GetElementsByTagName("SyncKey");
                    syncKey = key[0].InnerXml;
                }
                //Status !1 == !OK
                else
                {
                    switch (status[0].InnerXml)
                    {
                        case "2":
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
            return syncKey;
        }

        /// <summary>
        /// Performs a sync for a given CollectionID.
        /// </summary>
        /// <param name="dev">A "Device" object.</param>
        /// <param name="syncKey"></param>
        /// <param name="collectionId"></param>
        /// <returns>XML response from the Exchange Server.</returns>
        public static string Sync(Device dev, string syncKey, string collectionId)
        {
            string strUsername = dev.Username;
            string strPassword = dev.Password;
            string strDeviceID = dev.DeviceID;
            string strDeviceType = dev.DeviceType;
            string credentials = dev.Credentials;

            string easUrl = dev.ServerAddress;

            //string syncKey = "0";

            string ASVersion = dev.ASVersion;
            string UserAgent = dev.UserAgent;

            MemoryStream ms = new MemoryStream();
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.Encoding = new UTF8Encoding();

            XmlWriter xwFolderSync = XmlWriter.Create(ms, xmlSettings);

            //Do a FolderSync to discover the Server/Collection Id
            XmlWriter xwSync01 = XmlWriter.Create(ms, xmlSettings);
            xwSync01.WriteStartDocument();
            xwSync01.WriteStartElement("Sync", "AirSync");
            xwSync01.WriteStartElement("Collections");
            xwSync01.WriteStartElement("Collection");
            xwSync01.WriteStartElement("SyncKey"); xwSync01.WriteString(syncKey); xwSync01.WriteEndElement();
            xwSync01.WriteStartElement("CollectionId"); xwSync01.WriteString(collectionId); xwSync01.WriteEndElement();
            xwSync01.WriteEndElement();
            xwSync01.WriteEndElement();
            xwSync01.WriteEndDocument();
            xwSync01.Flush();


            xwFolderSync.Flush();

            byte[] syncXml = ms.ToArray();
            string strsyncXml = Encoding.UTF8.GetString(syncXml);

            ms.Position = 0;

            byte[] wbXml = null;
            byte[] responseXml = null;

            string decodedResponse = null;

            //Sync
            using (var client = new HttpClient())
            {
                string queryString = "?Cmd=Sync" +
                             "&User=" + strUsername +
                             "&DeviceId=" + strDeviceID +
                             "&DeviceType=" + strDeviceType;

                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/vnd.ms-sync.wbxml");

                //Convert XML => WBXML     
                StringReader sr = new StringReader(strsyncXml);

                XDocument xDoc = XDocument.Load(sr, LoadOptions.None);

                WBXMLWriter wbWriter = new WBXMLWriter(new ASCodePageProvider());
                WBXMLConverter wbConvert = new WBXMLConverter(new ASCodePageProvider(), wbWriter, null);

                IList<byte> wbXmlResult = wbConvert.Parse(xDoc);

                byte[] bytesArr = wbXmlResult.ToArray();

                wbXml = bytesArr;

                //Clear headers so "client" can be re-used
                client.DefaultRequestHeaders.Clear();

                ByteArrayContent easWbxml = new ByteArrayContent(wbXml);
                easWbxml.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.ms-sync.wbxml");

                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Basic " + credentials);
                client.DefaultRequestHeaders.Add("MS-ASProtocolVersion", ASVersion);
                client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Length", wbXml.Length.ToString());

                //POST WBXML
                var response = client.PostAsync(easUrl + queryString, easWbxml);
                if (response.Result.IsSuccessStatusCode)
                {
                    var responseContent = response.Result.Content;
                    responseXml = responseContent.ReadAsByteArrayAsync().Result;
                }

                //Convert WBXML => XML
                byte[] xmlSource = responseXml;
                XElement xmlResult = wbConvert.Parse(xmlSource);
                decodedResponse = xmlResult.ToString();

                try
                {
                    //Extract the SyncKey
                    var xmlSync = new XmlDocument();
                    xmlSync.LoadXml(decodedResponse);

                    //Check the status of the search request
                    var status = xmlSync.GetElementsByTagName("Status");

                    //Status of "1" == Success
                    if (status[0].InnerXml == "1")
                    {
                        var key = xmlSync.GetElementsByTagName("SyncKey");
                        syncKey = key[0].InnerXml;
                    }
                    //Status !1 == !OK
                    else
                    {
                        switch (status[0].InnerXml)
                        {
                            case "2":
                                break;

                            default:
                                break;
                        }
                    }
                }
                catch (Exception)
                {
                }
                return decodedResponse;

            }
        }

        
        public void ValidateCert()
        {}
    }
}
