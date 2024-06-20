using Casablanca.Model;
using Casablanca.Model.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net;

namespace Casablanca.Repository
{
    public class UserRepository : RepositoryBase, IUserRepository
    {

        public bool Add(User user)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM `user` WHERE username = @Username";
                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", user.username);
                        var userExists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
                        if (userExists)
                        {
                            return false; 
                        }
                    }

                    // Insert the new user
                    string insertQuery = "INSERT INTO `user` (first_name, last_name, password, salary, username, theme, language, is_admin) VALUES (@FirstName, @LastName, @Password, @Salary, @Username, @Theme, @Language, @IsAdmin)";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", user.firstName);
                        cmd.Parameters.AddWithValue("@LastName", user.lastName);
                        cmd.Parameters.AddWithValue("@Password", user.password);
                        cmd.Parameters.AddWithValue("@Salary", user.salary);
                        cmd.Parameters.AddWithValue("@Username", user.username);
                        cmd.Parameters.AddWithValue("@Theme", user.language ?? "li");
                        cmd.Parameters.AddWithValue("@Language",user.theme ??  "en");
                        cmd.Parameters.AddWithValue("@IsAdmin", user.isAdmin ? 1 : 0);
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; // Return false in case of an exception
            }
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
            try
            {
                using (var conn = GetConnection())
                using (var cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE `user` SET firstName = @FirstName, lastName = @LastName, salary = @Salary WHERE username = @Username";
                    cmd.Parameters.AddWithValue("@FirstName", user.firstName);
                    cmd.Parameters.AddWithValue("@LastName", user.lastName);
                    cmd.Parameters.AddWithValue("@Salary", user.salary);
                    cmd.Parameters.AddWithValue("@Username", user.username);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // loguj nekako
            }
        }

        public IEnumerable<User> GetAll()
        {
            var Users = new List<User>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from `user`";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Users.Add(
                         new User
                        (
                            reader["username"].ToString(),
                            reader["first_name"].ToString(),
                            reader["last_name"].ToString(),
                            Convert.ToDouble(reader["salary"]),
                            Convert.ToBoolean(reader["is_admin"])
                        ));
                    }
                }
            }
            return Users;
        }

        public IEnumerable<User> GetAllEmployees()
        {
            var Employees = new List<User>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from `user`";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User toAdd = new User
                        (
                            reader["username"].ToString(),
                            reader["first_name"].ToString(),
                            reader["last_name"].ToString(),
                            Convert.ToDouble(reader["salary"]),
                            Convert.ToBoolean(reader["is_admin"])
                        );
                        if (toAdd.isAdmin == false)
                            Employees.Add(toAdd);
                    }
                }
            }
            return Employees;
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
            try
            {
                using (var conn = GetConnection())
                using (var cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM `user` WHERE username = @Username";
                    cmd.Parameters.AddWithValue("@username", user.username);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
