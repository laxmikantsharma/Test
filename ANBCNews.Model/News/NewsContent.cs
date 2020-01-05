using System;
using System.Collections.Generic;
using System.Text;

namespace ANBCNews.Model.News
{
    public class NewsContent
    {
        public long ContentID { get; set; }

        public long? NewsID { get; set; }

        public string SubContent { get; set; }

        public string MainContent { get; set; }

    }

}
