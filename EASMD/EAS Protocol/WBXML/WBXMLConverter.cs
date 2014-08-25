using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace EAS_Protocol.WBXML
{
    public class WBXMLConverter
    {
        private ICodePageProvider codePageProvider;
        private IWBXMLWriter writer;
        private IWBXMLReader reader;

        public WBXMLConverter(ICodePageProvider codePageProvider = null, IWBXMLWriter writer = null, IWBXMLReader reader = null)
        {
            this.codePageProvider = codePageProvider ?? new ASCodePageProvider();
            this.writer = writer ?? new WBXMLWriter(this.codePageProvider);
            this.reader = reader ?? new WBXMLReader(this.codePageProvider);
        }

        public IList<byte> Parse(XDocument document)
        {
            return writer.Parse(document.Root);
        }

        public XElement Parse(IList<byte> document)
        {
            return reader.Parse(document);
        }
    }
}
