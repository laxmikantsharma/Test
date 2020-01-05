using System;

namespace ANBCNews.Model.Master
{
    public class MasterNewsSection
    {
        public long SectionID { get; set; }

        public string NewsSection { get; set; }

        public int? MaxNewsInSection { get; set; }

        public bool? IsActive { get; set; }

    }

}
