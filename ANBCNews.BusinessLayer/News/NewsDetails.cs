using ANBCNews.DataAccessLayer.News;
using ANBCNews.Model.News;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANBCNews.BusinessLayer.News
{
    public class NewsDetails
    {
        public NewsHeader GetNewsDetail(long NewsID)
        {
            NewsDataAccess objDataAccess = new NewsDataAccess();
            return objDataAccess.GetNewsDetail(NewsID);
        }
        public IEnumerable<NewsHeadline> GetNewsHeadlines(int NewsTypeID, int SectionID)
        {
            NewsDataAccess objDataAccess = new NewsDataAccess();
            return objDataAccess.GetNewsHeadlines(NewsTypeID, SectionID);
        }

    }

}
