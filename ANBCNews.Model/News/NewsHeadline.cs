using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ANBCNews.Model.News
{
   public class NewsHeadline
    {
        public long NewsID { get; set; }

        public string Headline { get; set; }
        public string NewsType { get; set; }
        public string ImagePath  { get; set; }
        public string SubContent { get; set; }
        public DateTime PublishedDate { get; set; }
        private string _strPublishedDate;
        public string strPublishedDate
        {
            get { return (string.IsNullOrEmpty(_strPublishedDate) ? PublishedDate.ToString("dd MMM yyyy", CultureInfo.InvariantCulture) : _strPublishedDate); }
            set { _strPublishedDate = value; }
        }
        public int TotalRecored { get; set; }

    }
}
