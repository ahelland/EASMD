using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace EAS_Protocol.WBXML
{
    public class WBXMLWriter : IWBXMLWriter
    {
        private ICodePageProvider codePageProvider;
        private int currentPage = 0;

        public WBXMLWriter(ICodePageProvider codePageProvider)
        {
            this.codePageProvider = codePageProvider;
        }

        public IList<byte> Parse(XElement element)
        {
            var parseResult = GetHeader() as List<byte>;
            parseResult.AddRange(GetElement(element));
            return parseResult;
        }

        private IList<byte> GetElement(XElement element)
        {
            var result = new List<byte>();
            var codePage = codePageProvider.GetCodePage(element.Name.Namespace.NamespaceName);
            result.AddRange(GetCodePage(codePage));
            result.AddRange(GetContent(element));
            result.AddRange(GetClosing());
            return result;
        }

        private IList<byte> GetCodePage(int codePage)
        {
            var result = new List<byte>();
            if (codePage != currentPage)
            {
                currentPage = codePage;
                result.AddRange(GetCodepageChange(currentPage));
            }
            return result;
        }

        private IList<byte> GetContent(XElement element)
        {
            var result = new List<byte>();
            if (element.HasElements)
            {
                result.AddRange(GetTokenWithContent(currentPage, element.Name.LocalName));
                foreach (var child in element.Elements())
                {
                    result.AddRange(GetElement(child));
                }
            }
            else if (!string.IsNullOrEmpty(element.Value))
            {
                result.AddRange(GetTokenWithContent(currentPage, element.Name.LocalName));
                result.AddRange(GetInlineString(element.Value));
            }
            else
            {
                result.AddRange(GetToken(currentPage, element.Name.LocalName));
            }
            return result;
        }

        public IList<byte> GetHeader()
        {
            return new List<byte> { 0x03, 0x01, 0x6A, 0x00 };
        }

        public IList<byte> GetInlineString(string p)
        {
            var bytes = new List<byte> { 0x03 };
            bytes.AddRange(GetString(p));
            return bytes;
        }

        private IList<byte> GetString(string p)
        {
            var bytes = UnicodeEncoding.UTF8.GetBytes(p).ToList();
            bytes.Add(0x00);
            return bytes;
        }

        private IList<byte> GetCodepageChange(int currentPage)
        {
            return new List<byte> { 0x00, (byte)currentPage };
        }

        private IList<byte> GetTokenWithContent(int codePage, string token)
        {
            return new List<byte> { (byte)(codePageProvider.GetToken(codePage, token) + 0x40) };
        }

        private IList<byte> GetToken(int codePage, string token)
        {
            return new List<byte> { (byte)(codePageProvider.GetToken(codePage, token)) };
        }

        private IList<byte> GetClosing()
        {
            return new List<byte> { 0x01 };
        }

    }
}
