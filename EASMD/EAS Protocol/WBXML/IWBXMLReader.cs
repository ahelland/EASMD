﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace EAS_Protocol.WBXML
{
    public interface IWBXMLReader
    {
        XElement Parse(IList<byte> document);
    }
}
