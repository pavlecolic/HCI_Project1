using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Casablanca.Repository
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;

        public RepositoryBase()
        {
            _connectionString = "Server=localhost;Database=casablanca;UserId=root;Password=admin;Port=3306;SslMode=None;Charset=utf8;Connection Timeout=30;";
        }

        protected MySqlConnection  GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
