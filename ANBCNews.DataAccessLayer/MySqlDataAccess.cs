using ANBCNews.Model;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ANBCNews.DataAccessLayer
{
    public class MySqlDataAccess : IDisposable
    {
        private Lazy<MySqlConnection> lazy = new Lazy<MySqlConnection>(() => new MySqlConnection(ConfigurationSetting.ConnectionString));

       public IDbConnection dataContext  { get { return lazy.Value; } }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}