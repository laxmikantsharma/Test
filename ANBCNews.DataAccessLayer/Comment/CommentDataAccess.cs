using ANBCNews.DataAccessLayer.Config;
using ANBCNews.Model.Comment;
using ANBCNews.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using ANBCNews.Model;

namespace ANBCNews.DataAccessLayer.Comment
{
    public class CommentDataAccess 
    {
        SqlDataAccess SqlData = null;
        public CommentDataAccess()
        {
            SqlData = new SqlDataAccess(); 
        }

        public DBResponse SaveComment(CommentEntity objComment)
        {
            DynamicParameters objParameter = new DynamicParameters();
            try
            {
                objParameter.Add("@Name", objComment.Name);
                objParameter.Add("@Email", objComment.Email);
                objParameter.Add("@Subject", objComment.Subject);
                objParameter.Add("@Message", objComment.Message);
                return SqlData.dataContext.QueryFirstOrDefault<DBResponse>("SaveComment", objParameter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CLogger.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in  Comment Data Access  while calling SaveComment Action, Ex.: " + ex.Message);
            }
            return new DBResponse();
        }
    }
}
