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
    public class PublisherRepository : RepositoryBase, IPublisherRepository
    {
        public List<ArticlePublisher> GetAll()
        {
            var publishers = new List<ArticlePublisher>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT id, name FROM publisher";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        publishers.Add(new ArticlePublisher(
                            id: Convert.ToInt32(reader["id"]),
                            publisherName: reader["name"].ToString()
                        ));
                    }
                }
            }
            return publishers;
        }

        public ArticlePublisher GetById(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT id, name FROM publisher WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ArticlePublisher(
                                id: Convert.ToInt32(reader["id"]),
                                publisherName: reader["name"].ToString()
                            );
                        }
                    }
                }
            }
            return null;
        }

        public void Add(ArticlePublisher publisher)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO publisher (id, name) VALUES (@Id, @Name)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", publisher.Id);
                    command.Parameters.AddWithValue("@Name", publisher.PublisherName);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(ArticlePublisher publisher)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE publisher SET name = @Name WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", publisher.PublisherName);
                    command.Parameters.AddWithValue("@Id", publisher.getId());
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM publisher WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
