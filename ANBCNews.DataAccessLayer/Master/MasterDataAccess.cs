using ANBCNews.DataAccessLayer.Config;
using ANBCNews.Model.Master;
using ANBCNews.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace ANBCNews.DataAccessLayer.Master
{
    public class CommentAccess 
    {
        MySqlDataAccess SqlData = null;
        public CommentAccess()
        {
            SqlData = new MySqlDataAccess(); 
        }

        public IEnumerable<MasterImageType> GetImageType()
        {
            try
            {
                return SqlData.dataContext.Query<MasterImageType>("GetAllImageType", null, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CLogger.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in  Masters Operation  while calling GetImageType Action, Ex.: " + ex.Message);
            }
            return null;
        }

        public IEnumerable<MasterNewsType> GetNewsType()
        {
            try
            {
                return SqlData.dataContext.Query<MasterNewsType>("GetAllNewsType", null, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CLogger.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in  Masters Operation  while calling GetNewsType Action, Ex.: " + ex.Message);
            }
            return null;
        }
    }
}
