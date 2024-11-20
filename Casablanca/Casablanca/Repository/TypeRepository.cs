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
    public class TypeRepository : RepositoryBase, ITypeRepository
    {


        public ArticleType GetById(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "SELECT id, type_name FROM `article_type` WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ArticleType(
                                id: Convert.ToInt32(reader["id"]),
                                typeName: reader["type_name"].ToString()
                            );
                        }
                    }
                }
            }
            return null;
        }


        public List<ArticleType> GetAll()
        {
            var articleTypes = new List<ArticleType>();

            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "SELECT id, type_name FROM `article_type`";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        articleTypes.Add(new ArticleType(
                            id: Convert.ToInt32(reader["id"]),
                            typeName: reader["type_name"].ToString()
                        ));
                    }
                }
            }
            return articleTypes;
        }


        public void Add(ArticleType articleType)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "INSERT INTO `article_type` (type_name) VALUES (@TypeName)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TypeName", articleType.TypeName);
                    command.ExecuteNonQuery();
                }
            }
        }


        public void Update(ArticleType articleType)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "UPDATE `article type` SET type_name = @TypeName WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TypeName", articleType.TypeName);
                    command.Parameters.AddWithValue("@Id", articleType.getId());
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "DELETE FROM `article_type` WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
