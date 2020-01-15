using ANBCNews.DataAccessLayer.Config;
using ANBCNews.Model.Contact;
using ANBCNews.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using ANBCNews.Model;

namespace ANBCNews.DataAccessLayer.Comment
{
    public class ContactDataAccess 
    {
        SqlDataAccess SqlData = null;
        public ContactDataAccess()
        {
            SqlData = new SqlDataAccess(); 
        }

        public DBResponse SaveContact(ContactEntity objComment)
        {
            DynamicParameters objParameter = new DynamicParameters();
            try
            {
                objParameter.Add("@Name", objComment.Name);
                objParameter.Add("@Email", objComment.Email); 
                objParameter.Add("@Message", objComment.Message);
                return SqlData.dataContext.QueryFirstOrDefault<DBResponse>("SaveContact", objParameter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CLogger.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in  Comment Data Access  while calling SaveComment Action, Ex.: " + ex.Message);
            }
            return new DBResponse();
        }
    }
}
