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
    public class CustomerRepository : RepositoryBase, ICustomerRepository
    {


        public bool Add(Customer customer)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert the address first and get the generated ID
                        string addressQuery = @"INSERT INTO address (name, number, city_id)
                                        VALUES (@Name, @Number, @CityId);
                                        SELECT LAST_INSERT_ID();";
                        int addressId;
                        using (var addressCommand = new MySqlCommand(addressQuery, connection, transaction))
                        {
                            addressCommand.Parameters.AddWithValue("@Name", customer.Address.Name);
                            addressCommand.Parameters.AddWithValue("@Number", customer.Address.Number);
                            addressCommand.Parameters.AddWithValue("@CityId", customer.Address.City.Id);

                            addressId = Convert.ToInt32(addressCommand.ExecuteScalar());
                        }

                        customer.Address.Id = addressId;

                        // Insert the 
                        string customerQuery = @"INSERT INTO customer (first_name, last_name, JMB, address_id, phone_number)
                                         VALUES (@FirstName, @LastName, @JMB, @AddressId, @PhoneNumber)";
                        using (var customerCommand = new MySqlCommand(customerQuery, connection, transaction))
                        {
                            customerCommand.Parameters.AddWithValue("@FirstName", customer.FirstName);
                            customerCommand.Parameters.AddWithValue("@LastName", customer.LastName);
                            customerCommand.Parameters.AddWithValue("@JMB", customer.JMB);
                            customerCommand.Parameters.AddWithValue("@AddressId", customer.Address.Id);
                            customerCommand.Parameters.AddWithValue("@PhoneNumber", customer.Phone);

                            customerCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error saving customer: {ex.Message}");
                        return false;
                    }
                }
            }
        }


        public void Edit(Customer customer)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"UPDATE customer 
                             SET first_name = @FirstName, 
                                 last_name = @LastName, 
                                 JMB = @JMB, 
                                 address_id = @AddressId, 
                                 phone_number = @PhoneNumber 
                             WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", customer.Id);
                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@JMB", customer.JMB);
                    command.Parameters.AddWithValue("@AddressId", customer.Address.Id);
                    command.Parameters.AddWithValue("@PhoneNumber", customer.Phone);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Customer> GetAll()
        {
            var customers = new List<Customer>();

            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"SELECT c.id, c.first_name, c.last_name, c.JMB, c.phone_number, 
                                    a.id AS address_id, a.name AS street_name, a.number AS street_number, 
                                    city.id AS city_id, city.name AS city_name, city.post_code 
                             FROM customer c
                             JOIN address a ON c.address_id = a.id
                             JOIN city ON a.city_id = city.id";
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
                            reader.GetInt32("address_id"),
                            reader.GetString("street_name"),
                            reader.GetInt32("street_number"),
                            city
                        );

                        var customer = new Customer(
                            reader.GetInt32("id"),
                            reader.GetString("first_name"),
                            reader.GetString("last_name"),
                            reader.GetString("JMB"),
                            address,
                            reader.GetString("phone_number")
                        );

                        customers.Add(customer);
                    }
                }
            }

            return customers;
        }

        public Customer GetById(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"SELECT c.id, c.first_name, c.last_name, c.JMB, c.phone_number, 
                                    a.id AS address_id, a.name AS street_name, a.number AS street_number, 
                                    city.id AS city_id, city.name AS city_name, city.post_code 
                             FROM customer c
                             JOIN address a ON c.address_id = a.id
                             JOIN city ON a.city_id = city.id
                             WHERE c.id = @Id";
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

                            var address = new Address(
                                reader.GetInt32("address_id"),
                                reader.GetString("street_name"),
                                reader.GetInt32("street_number"),
                                city
                            );

                            return new Customer(
                                reader.GetInt32("id"),
                                reader.GetString("first_name"),
                                reader.GetString("last_name"),
                                reader.GetString("JMB"),
                                address,
                                reader.GetString("phone_number")
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

                string query = @"DELETE FROM customer WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
