using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ANBCNews.DataAccessLayer.Config;
using ANBCNews.Model;
using ANBCNews.Utility;
using Dapper;

namespace ANBCNews.BusinessLayer.Config
{
    public static class CLogger
    {
        public static void WriteLog(ProjectSource projectSource, ELogLevel logLevel, String log)
        {
            CLoggerDataAccess.WriteLogToDB(projectSource.ToString(), logLevel.ToString(), log, null);
        }
    }
}
