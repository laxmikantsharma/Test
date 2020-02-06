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
        MySqlDataAccess SqlData = null;
        public NewsDataAccess()
        {
            SqlData = new MySqlDataAccess();
        }

        public NewsHeader GetNewsDetail(long NewsID, string Group = "Full")
        {
            try
            {
                DynamicParameters objParameter = new DynamicParameters();
                objParameter.Add("p_NewsID", NewsID);
                objParameter.Add("p_Group", Group);
                var result = SqlData.dataContext.QueryMultiple("GetNewsDetails", objParameter, commandType: CommandType.StoredProcedure);
                NewsHeader obj = result.ReadSingle<NewsHeader>();

                if (obj.NewsID > 0)
                    obj.objNewsContent = result.ReadFirstOrDefault<NewsContent>();

                if (obj.NewsID > 0)
                    obj.objNewsImage = result.ReadFirstOrDefault<NewsImage>();

                if (obj.NewsID > 0)
                    obj.objNewsVideo = result.ReadFirstOrDefault<NewsVideo>();

              //  if (obj.NewsID > 0 && Group == "Full")
                //    obj.objUserInfo = result.ReadFirstOrDefault<UserInfo>();

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
                objParameter.Add("p_NewsTypeID", objNewsParam.NewsTypeID);
                objParameter.Add("p_SectionID", objNewsParam.SectionID);
                objParameter.Add("p_OnlyVideo", objNewsParam.OnlyVideo);
                objParameter.Add("p_PageNo", objNewsParam.PageNo);
                return SqlData.dataContext.Query<NewsHeadline>("GetNewsHeadlines", objParameter, commandType: CommandType.StoredProcedure);
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
                objParameter.Add("p_Keyword", Keyword);
                objParameter.Add("p_PageNo", PageNo);
                
                return SqlData.dataContext.Query<NewsHeadline>("SearchNews", objParameter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CLogger.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in News Data Access  while calling SearchNews Action, Ex.: " + ex.Message);
            }
            return null;
        }
    }

}
