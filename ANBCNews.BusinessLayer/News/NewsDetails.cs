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
        public IEnumerable<NewsHeadline> GetNewsHeadlines(NewsParam objNewsParam)
        {
            NewsDataAccess objDataAccess = new NewsDataAccess();
            return objDataAccess.GetNewsHeadlines(objNewsParam);
        }
        public IEnumerable<NewsHeadline> SearchNews(int PageNo, string Keyword)
        {
            NewsDataAccess objDataAccess = new NewsDataAccess();
            return objDataAccess.SearchNews(PageNo,Keyword);
        }
    }

}
