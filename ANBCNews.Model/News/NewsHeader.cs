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
        public string ImagePath { get; set; }
        public string MainContent { get; set; }
        public DateTime PublishedDate { get; set; }
        private string _strPublishedDate;
        public string strPublishedDate
        {
            get { return (string.IsNullOrEmpty(_strPublishedDate) ? PublishedDate.ToString("dd MMM yyyy", CultureInfo.InvariantCulture) : _strPublishedDate); }
            set { _strPublishedDate = value; }
        }

        public bool? IsPublished { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public long? ModifyBy { get; set; }

    }


}
