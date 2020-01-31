using System;
using System.Collections.Generic;
using System.Text;

namespace ANBCNews.Model.News
{
    public class NewsImage
    {
        public long ImageID { get; set; }
        public string Name { get; set; }
        public int ImageTypeID { get; set; }
        public long NewsID { get; set; } 
        public string AlternateText { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string ImageUrl
        {
            get { return (!string.IsNullOrEmpty(this.Name) ? ConfigurationSetting.ImageWebUrl + "/image/" + this.NewsID + "/" + this.Name : this.Name); }
        }
    }


}
