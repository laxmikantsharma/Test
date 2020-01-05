using System;
using System.Collections.Generic;
using System.Text;

namespace ANBCNews.Model.News
{
    public class NewsHeader
    {
        public long NewsID { get; set; }

        public string Headlines { get; set; }

        public long? NewsTypeID { get; set; }

        public DateTime? PublishedDate { get; set; }

        public bool? IsPublished { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public long? ModifyBy { get; set; }

    }


}
