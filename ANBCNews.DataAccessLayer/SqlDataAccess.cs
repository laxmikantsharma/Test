using ANBCNews.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ANBCNews.DataAccessLayer
{
    public class SqlDataAccess : IDisposable
    {
        private Lazy<SqlConnection> lazy = new Lazy<SqlConnection>(() => new SqlConnection(ConfigurationSetting.ConnectionString));

       public IDbConnection dataContext  { get { return lazy.Value; } }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}