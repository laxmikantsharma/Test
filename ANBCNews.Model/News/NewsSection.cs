using System;
using System.Collections.Generic;
using System.Text;

namespace ANBCNews.Model.News
{
    public class NewsSection
    {
        public int NewSectionID { get; set; }

        public int? SectionID { get; set; }

        public long? NewsID { get; set; }

        public DateTime? ArchiveDate { get; set; }

        public bool? IsActive { get; set; }

    }

}
