using Casablanca.Model;
using Casablanca.Model.Repository;
using Casablanca.Resources;
using MySql.Data.MySqlClient;
using Mysqlx.Datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Repository
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from `user` where username=@username and `password`=@password";
                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = credential.UserName;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
                  
            }
            return validUser;
        }

        public void Edit(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            User user = null;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from `user` where username=@username";
                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                using(var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User(
                        id: reader.GetInt32(0),
                        username: reader.GetString(1),
                        password: reader.GetString(2),
                        firstName: reader.GetString(3),
                        lastName: reader.GetString(4),
                        theme: reader.GetString(5),
                        language: reader.GetString(6),
                        salary: reader.GetDouble(7),
                        isAdmin: reader.GetByte(8) != 0
                        );
                    }

                        
                }
            }
            return user;
        }

        public void Remove(User user)
        {
            throw new NotImplementedException();
        }
    }
}
