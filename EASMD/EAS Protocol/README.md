##EAS_Diag##

**EAS Protocol**

This Visual Studio Project contains the files for the helper library used by EAS_Diag. This is mainly used for encoding plaintext XML to WBXML, and decoding it the other way.

It has no dependencies on EAS_Diag so you can easily re-use this for other .Net solutions if you like.

If you browse the code you'll probably find you're self wondering what all of it is used for now, and the answer is that a lot of the code isn't being used for anything at the moment :)

There are the beginnings of implementing the entire AS-CMD stack, but it's kind of in a limbo state right now.

**How to use**

To convert POX to WBXML:  
```c#
public string xmlToWb()  
{  
    byte[] b = this.Request.BinaryRead(this.Request.ContentLength);            
    string xmlSource = System.Text.Encoding.UTF8.GetString(b);

    StringReader sr = new StringReader(xmlSource);

    XDocument xDoc = XDocument.Load(sr, LoadOptions.None);

    WBXMLWriter wbWriter = new WBXMLWriter(new ASCodePageProvider());
    WBXMLConverter wbConvert = new WBXMLConverter(new ASCodePageProvider(), wbWriter, null);

    IList<byte> wbXmlResult = wbConvert.Parse(xDoc);

    byte[] bytesArr = wbXmlResult.ToArray();

    return System.Text.Encoding.UTF8.GetString(bytesArr);
}  
```

To convert WBXML to POX:  
```c#  
public string wbToXml()
{            
    byte[] xmlSource = this.Request.BinaryRead(this.Request.ContentLength);
            
    WBXMLWriter wbWriter = new WBXMLWriter(new ASCodePageProvider());
    WBXMLConverter wbConvert = new WBXMLConverter(new ASCodePageProvider(), wbWriter, null);
    XElement xmlResult = wbConvert.Parse(xmlSource);

    return xmlResult.ToString();
}
```