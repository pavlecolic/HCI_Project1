using Casablanca.Model;
using Casablanca.Repository.RepoInterfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Repository
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {

        public void Add(Address address)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO address (name, number, city_id)
                             VALUES (@Name, @Number, @CityId)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", address.Name);
                    command.Parameters.AddWithValue("@Number", address.Number);
                    command.Parameters.AddWithValue("@CityId", address.City.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(Address address)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"UPDATE address 
                             SET name = @Name, number = @Number, city_id = @CityId 
                             WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", address.Id);
                    command.Parameters.AddWithValue("@Name", address.Name);
                    command.Parameters.AddWithValue("@Number", address.Number);
                    command.Parameters.AddWithValue("@CityId", address.City.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Address> GetAll()
        {
            var addresses = new List<Address>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"SELECT a.id, a.name, a.number, 
                                    c.id AS city_id, c.name AS city_name, c.post_code 
                             FROM address a
                             JOIN city c ON a.city_id = c.id";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var city = new City(
                            reader.GetInt32("city_id"),
                            reader.GetString("city_name"),
                            reader.GetString("post_code")
                        );

                        var address = new Address(
                            reader.GetInt32("id"),
                            reader.GetString("name"),
                            reader.GetInt32("number"),
                            city
                        );

                        addresses.Add(address);
                    }
                }
            }

            return addresses;
        }

        public Address GetById(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"SELECT a.id, a.name, a.number, 
                                    c.id AS city_id, c.name AS city_name, c.post_code 
                             FROM address a
                             JOIN city c ON a.city_id = c.id
                             WHERE a.id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var city = new City(
                                reader.GetInt32("city_id"),
                                reader.GetString("city_name"),
                                reader.GetString("post_code")
                            );

                            return new Address(
                                reader.GetInt32("id"),
                                reader.GetString("name"),
                                reader.GetInt32("number"),
                                city
                            );
                        }
                    }
                }
            }

            return null;
        }

        public void Remove(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"DELETE FROM address WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
