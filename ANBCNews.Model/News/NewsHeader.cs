using ANBCNews.Model.User;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ANBCNews.Model.News
{
    public class NewsHeader
    {
        public long NewsID { get; set; }
        public string Headline { get; set; }
        public long? NewsTypeID { get; set; }
        public string NewsType { get; set; }
        public DateTime PublishedDate { get; set; }
        private string _strPublishedDate;
        public string strPublishedDate
        {
            get { return (string.IsNullOrEmpty(_strPublishedDate) ? PublishedDate.ToString("dd MMM yyyy", new CultureInfo("hi")) : _strPublishedDate); }
            set { _strPublishedDate = value; }
        }
        public bool? IsPublished { get; set; }  
        public UserInfo objUserInfo { get; set; }
        public NewsContent objNewsContent { get; set; }
        public NewsImage objNewsImage { get; set; }
        public NewsVideo objNewsVideo { get; set; }
        public bool IsVideo { get; set; }
    }


}
