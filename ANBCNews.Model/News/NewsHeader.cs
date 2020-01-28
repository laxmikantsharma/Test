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

        private string _ImagePath = "";
        public string ImagePath
        {
            get { return this._ImagePath; }
            set { this._ImagePath = (!string.IsNullOrEmpty(value) ? ConfigurationSetting.ImageWebUrl + value : ""); }
        }
        public string MainContent { get; set; }
        public DateTime PublishedDate { get; set; }
        private string _strPublishedDate;
        public string strPublishedDate
        {
            get { return (string.IsNullOrEmpty(_strPublishedDate) ? PublishedDate.ToString("dd MMM yyyy", new CultureInfo("hi")) : _strPublishedDate); }
            set { _strPublishedDate = value; }
        }

        public bool? IsPublished { get; set; }  
        public UserInfo objUserInfo { get; set; }
        public bool IsVideo { get; set; }
        public string VideoType { get; set; }
        public string VideoTime { get; set; }
        private string _VideoUrl = "";
        public string VideoUrl
        {
            get { return this._VideoUrl; }
            set { this._VideoUrl = (!string.IsNullOrEmpty(value) && VideoType== "ABNC" ? ConfigurationSetting.VideoWebUrl + "/video/" + NewsID +"/"+ value : value); }
        }

    }


}
