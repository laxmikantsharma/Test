using System;
using System.Collections.Generic;
using System.Text;

namespace ANBCNews.Model.News
{
    public class NewsVideo
    {
        public long VideoID { get; set; }
        public long NewsID { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public bool? IsActive { get; set; }
        public string VideoUrl
        {
            get { return  (!string.IsNullOrEmpty(Name) && Type == "ABNC" ? ConfigurationSetting.VideoWebUrl + "/video/" + NewsID + "/" + Name : Name); }
        }
    }


}
