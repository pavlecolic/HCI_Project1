using Casablanca.Model;
using Casablanca.Repository.RepoInterfaces;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Repository
{
    class CityRepository : RepositoryBase, ICityRepository
    {
        public bool Add(City City)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM `city` WHERE post_code = @PostalCode";
                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@PostalCode", City.PostalCode);
                        var cityExists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
                        if (cityExists)
                        {
                            return false;
                        }
                    }

                    string insertQuery = "INSERT INTO `city` (name, post_code) VALUES (@Name, @PostalCode)";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", City.Name);
                        cmd.Parameters.AddWithValue("@PostalCode", City.PostalCode);
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Edit(City city)
        {
            try
            {
                using (var conn = GetConnection())
                using (var cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE `city` SET name = @Name, post_code = @PostalCode WHERE id = @Id";
                    cmd.Parameters.AddWithValue("@Name", city.Name);
                    cmd.Parameters.AddWithValue("@PostalCode", city.PostalCode);
                    cmd.Parameters.AddWithValue("@Id", city.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IEnumerable<City> GetAll()
        {
            var cities = new List<City>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from `city`";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cities.Add(
                         new City
                         {
                             Name = reader["name"].ToString(),
                             PostalCode = reader["post_code"].ToString()
                         });
                    }
                }
            }
            return cities;
        }

        public City GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(City city)
        {
            throw new NotImplementedException();
        }
    }
}
