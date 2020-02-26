using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ANBCNews.Model;
using ANBCNews.Utility;
using Dapper;

namespace ANBCNews.DataAccessLayer.Config
{
    public static class CLoggerDataAccess
    {
        public static void WriteLog(ProjectSource projectSource, ELogLevel logLevel, String log)
        {
            WriteLog(projectSource, logLevel, log, null);
        }

        public static void WriteLog(ProjectSource projectSource, ELogLevel logLevel, String log, Exception exception)
        {
            WriteLogToDB(projectSource.ToString(), logLevel.ToString(), log, exception);
        }
        public static void WriteLogToDB(string projectSource, string logLevel, String log, Exception exception)
        {
            try
            {

                SqlDataAccess SqlData = new SqlDataAccess();
                DynamicParameters objParameter = new DynamicParameters();
                DBLogger objDBLogger = new DBLogger();
                objDBLogger.Message = log + (exception != null ? "\n\n exception:" + exception.ToString() : "");
                objDBLogger.Type = logLevel;
                objDBLogger.Source = projectSource;
                objParameter.Add("p_ID", objDBLogger.ExceptionID);
                objParameter.Add("p_Message", objDBLogger.Message);
                objParameter.Add("p_Type", objDBLogger.Type);
                objParameter.Add("p_Source", objDBLogger.Source);
                 SqlData.dataContext.QuerySingle<Response>("USP_INSERT_EXCEPTIONLOG", objParameter, commandType: CommandType.StoredProcedure);
            }
            catch
            {
            }

        }
    }
}
