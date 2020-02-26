using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ANBCNews.Model;
using ANBCNews.Utility;
using Dapper;

namespace ANBCNews.DataAccessLayer.Config
{
    public  class SettingDataAccess
    {
        MySqlDataAccess SqlData = null;
        public SettingDataAccess()
        {
            SqlData = new MySqlDataAccess();
        }
        public SystemSettings GetSystemSetting(string SettingCode)
        {
            SystemSettings obj = new SystemSettings();
            DynamicParameters objParameter = new DynamicParameters();
            try
            {
                objParameter.Add("@P_SETTINGCODE", SettingCode);
                return SqlData.dataContext.QueryFirst<SystemSettings>("SystemSettings_Read", objParameter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CLoggerDataAccess.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in  SystemSetting Operation  while calling GetSystemSetting Action, Ex.: " + ex.Message);
            }
            return null;

        }
        public IEnumerable<SystemSettings> GetAllSystemSetting(string SettingCode)
        {
            DynamicParameters objParameter = new DynamicParameters();
            try
            {
                objParameter.Add("SettingCode", SettingCode);
                return SqlData.dataContext.Query<SystemSettings>("SystemSettings_Read_Grid", objParameter, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                CLoggerDataAccess.WriteLog(ProjectSource.DataAccessLayer, ELogLevel.ERROR, "ERROR ocurred in  SystemSetting Operation  while calling GetAllSystemSetting Action, Ex.: " + ex.Message);
            }
            return null;

        }
    }
}
