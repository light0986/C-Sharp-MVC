using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC01.Models
{
    public class URLView
    {
        public string strMsg{get; set;}
        public string str2Msg { get; set; }
        public string urlview()
        {
            return "https://qrc.mrtools.us/Infos/Search/"+strMsg+","+str2Msg;
        }
    }
}
