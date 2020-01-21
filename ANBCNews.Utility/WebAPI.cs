using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ANBCNews.Utility
{
  public  class WebAPI
    {
        public static string TranslateToHindi(string Keyword)
        {
            string url = "https://translation.googleapis.com/language/translate/v2?key=AIzaSyDSysUY5eF0ES9BDAjuyABK8Ivj7WZqcvY";
            url += "&source=EN&target=HI&q=" + Uri.EscapeDataString(Keyword.Trim());
            WebClient client = new WebClient();
            return   client.DownloadString(url); 
        }
    }
}
