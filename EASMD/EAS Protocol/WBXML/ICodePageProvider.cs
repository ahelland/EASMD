using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EAS_Protocol.WBXML
{
    public interface ICodePageProvider
    {
        int GetCodePage(string name);
        int GetToken(string name, string token);
        int GetToken(int page, string token);

        string GetCodePage(int currentPage);
        string GetToken(int page, int token);
    }
}
