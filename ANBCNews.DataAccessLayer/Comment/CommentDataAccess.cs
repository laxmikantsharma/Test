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
        MySqlDataAccess SqlData = null;
        public CommentDataAccess()
        {
            SqlData = new MySqlDataAccess(); 
        }

        public DBResponse SaveComment(CommentEntity objComment)
        {
            DynamicParameters objParameter = new DynamicParameters();
            try
            {
                objParameter.Add("p_Name", objComment.Name);
                objParameter.Add("p_Email", objComment.Email);
                objParameter.Add("p_Subject", objComment.Subject);
                objParameter.Add("p_Message", objComment.Message);
                return SqlData.dataContext.QueryFirstOrDefault<DBResponse>("SaveComment", objParameter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CLoggerDataAccess.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in  Comment Data Access  while calling SaveComment Action, Ex.: " + ex.Message);
            }
            return new DBResponse();
        }
    }
}
