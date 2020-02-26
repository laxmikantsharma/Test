using ANBCNews.DataAccessLayer.Config;
using ANBCNews.Model.Master;
using ANBCNews.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace ANBCNews.DataAccessLayer.Master
{
    public class MasterDataAccess
    {
        MySqlDataAccess SqlData = null;
        public MasterDataAccess()
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
                CLoggerDataAccess.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in  Masters Operation  while calling GetImageType Action, Ex.: " + ex.Message);
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
                CLoggerDataAccess.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in  Masters Operation  while calling GetNewsType Action, Ex.: " + ex.Message);
            }
            return null;
        }
        public MasterTemplate GetTemplate(string TemplateCode)
        {
            MasterTemplate objMasterTemplate = new MasterTemplate();
            DynamicParameters objParameter = new DynamicParameters();
            try
            {
                objParameter.Add("@p_ID", 0);
                objParameter.Add("@p_ACCESSIBLE", "");
                objParameter.Add("@P_TemplateCode", TemplateCode);
                objMasterTemplate = SqlData.dataContext.QueryFirst<MasterTemplate>("MailTemplates_Read", objParameter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CLoggerDataAccess.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in  MailTemplate Operation  while calling GetMailTemplate Action, Ex.: " + ex.Message);
            }
            return objMasterTemplate;
        }
    }
}
