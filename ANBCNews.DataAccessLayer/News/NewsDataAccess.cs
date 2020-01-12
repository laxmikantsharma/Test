using ANBCNews.DataAccessLayer.Config;
using ANBCNews.Model.News;
using ANBCNews.Model.User;
using ANBCNews.Utility;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ANBCNews.DataAccessLayer.News
{
    public class NewsDataAccess
    {
        SqlDataAccess SqlData = null;
        public NewsDataAccess()
        {
            SqlData = new SqlDataAccess();
        }

        public NewsHeader GetNewsDetail(long NewsID, string Group = "Full")
        {
            try
            {
                DynamicParameters objParameter = new DynamicParameters();
                objParameter.Add("@NewsID", NewsID);
                objParameter.Add("@Group", Group);
                var result = SqlData.dataContext.QueryMultiple("GetNewsDetails", objParameter, commandType: CommandType.StoredProcedure);
                NewsHeader obj = result.ReadSingle<NewsHeader>();
                if (obj.NewsID > 0 && Group == "Full")
                    obj.objUserInfo = result.ReadSingle<UserInfo>();
                return obj;
            }
            catch (Exception ex)
            {
                CLogger.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in News Data Access while calling GetNewsDetail Action, Ex.: " + ex.Message);
            }
            return null;
        }
        public IEnumerable<NewsHeadline> GetNewsHeadlines(NewsParam objNewsParam)
        {
            try
            {
                DynamicParameters objParameter = new DynamicParameters();
                objParameter.Add("@NewsTypeID", objNewsParam.NewsTypeID);
                objParameter.Add("@SectionID", objNewsParam.SectionID);
                objParameter.Add("@PageNo", objNewsParam.PageNo);
                return SqlData.dataContext.Query<NewsHeadline>("[GetNewsHeadlines]", objParameter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CLogger.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in News Data Access  while calling GetNewsHeadlines Action, Ex.: " + ex.Message);
            }
            return null;
        }
        public IEnumerable<NewsHeadline> SearchNews(int PageNo, string Keyword)
        {
            try
            {
                DynamicParameters objParameter = new DynamicParameters();
                objParameter.Add("@Keyword", Keyword);
                objParameter.Add("@PageNo", PageNo);
                
                return SqlData.dataContext.Query<NewsHeadline>("[SearchNews]", objParameter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CLogger.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in News Data Access  while calling SearchNews Action, Ex.: " + ex.Message);
            }
            return null;
        }
    }

}
