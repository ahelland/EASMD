using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace EAS_Protocol.WBXML
{
    class WBXMLReader : IWBXMLReader
    {
        private ICodePageProvider codePageProvider;
        private int currentPage = 0;
        private int position = 0;

        public WBXMLReader(ICodePageProvider codePageProvider)
        {
            this.codePageProvider = codePageProvider;
        }

        public XElement Parse(IList<byte> document)
        {
            ConsumeHeader(document);
            return ParseElement(document, GetCurrentToken(document));
        }

        private XElement ParseElement(IList<byte> document, int next)
        {
            if (next == 0)
            {
                currentPage = GetCurrentToken(document);
                next = GetCurrentToken(document);
            }
            var codePage = codePageProvider.GetCodePage(currentPage) + ":";
            var hasContent = (next & 0x40) == 0x40;
            var currentToken = next & 0x3f;
            var element = new XElement((XNamespace)codePage + codePageProvider.GetToken(currentPage, currentToken));

            if (hasContent)
            {
                while ((next = GetCurrentToken(document)) != 1)
                {                    
                    //If value == 3 it marks the start of a string
                    if (next == 3)                    
                    {
                        element.Value = GetString(document);
                    }
                    //If value == 0xC3 it marks the start of an opaque blob
                    else if (next == 195)
                    {
                        element.Value = GetBlob(document);
                    }
                    else
                    {
                        element.Add(ParseElement(document, next));
                    }
                }
            }
            return element;
        }

        private string GetBlob(IList<byte> document)
        {           
            var next = 0;
            var bytes = new List<byte>();
            string blob = "";
            next = GetCurrentToken(document);
            int length = next;
            for (int i = 0; i < length; i++)
            {
                next = GetCurrentToken(document);
                bytes.Add((byte)next);
            }
            for (int i=0;i<length;i++)
            {
                blob += bytes[i].ToString("X");
            }
            return blob;
        }

        private string GetString(IList<byte> document)
        {
            var next = 0;
            var bytes = new List<byte>();            
            //Values terminate with '0' or '8A'
            while ((next = GetCurrentToken(document)) != 0) 
            //while ( (next = GetCurrentToken(document)) != 0 && (next = GetCurrentToken(document)) != 138) 
            {
                bytes.Add((byte)next);
            }
            return UnicodeEncoding.UTF8.GetString(bytes.ToArray(), 0, bytes.Count);
        }

        private int GetCurrentToken(IList<byte> document)
        {
            return document.ElementAt(position++);
        }

        private void ConsumeHeader(IList<byte> document)
        {
            for (int a = 0; a < 4; a++)
            {
                GetCurrentToken(document);
            }
        }


    }
}
