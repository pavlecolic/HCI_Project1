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
    public class ArticleRepository : RepositoryBase, IArticleRepository
    {

        private TypeRepository TypeRepository = new TypeRepository();
        private PublisherRepository PublisherRepository = new PublisherRepository();
        private InvoiceRepository InvoiceRepository = new InvoiceRepository();

        public bool Add(Article article)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    
                    
                    string insertQuery = "INSERT INTO `article` (name, image, type_id, is_rented, price, publisher_id, invoice_id, is_for_sale) VALUES (@Name, @Image, @TypeId, @IsRented, @Price, @PublisherId, @InvoiceId, @IsForSale)";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        String debug = article.Name + " " + article.ImageURL + " " + article.Type.getId() + "  " + article.Price + " " + article.Publisher.getId();
                        System.Diagnostics.Debug.WriteLine("DEBUGFFF: " + debug);


                        cmd.Parameters.AddWithValue("@Name", article.Name);
                        cmd.Parameters.AddWithValue("@Image", "/Images/Articles/" + article.ImageURL);
                        cmd.Parameters.AddWithValue("@TypeId", article.Type.getId());
                        cmd.Parameters.AddWithValue("@IsRented", 0);
                        cmd.Parameters.AddWithValue("@Price", article.Price);
                        cmd.Parameters.AddWithValue("@PublisherId", article.Publisher.getId());
                        cmd.Parameters.AddWithValue("@InvoiceId", 1);
                        cmd.Parameters.AddWithValue("@IsForSale", 0);

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


        public void Edit(Article article)
        {
            try
            {
                using (var conn = GetConnection())
                using (var cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE `city` SET name = @Name, image = @Image, type_id=@ArticleType, is_rented=@IsRented, price=@Price, is_for_sale=@IsForSale WHERE id = @Id";
                    cmd.Parameters.AddWithValue("@Name", article.Name);
                    cmd.Parameters.AddWithValue("@Image", article.ImageURL);
                    cmd.Parameters.AddWithValue("@ArticleType", article.Type.getId());
                    cmd.Parameters.AddWithValue("@IsRented", article.IsRented);
                    cmd.Parameters.AddWithValue("@Price", article.Price);
                    cmd.Parameters.AddWithValue("@IsForSale", article.IsForSale);
                    cmd.Parameters.AddWithValue("@Id", article.getId());

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
            

        public IEnumerable<Article> GetAll()
        {
            var articles = new List<Article>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from `article`";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        articles.Add(
                         new Article
                         (
                             id : reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : -1,
                             name : reader["name"].ToString(),
                             imageURL : reader["image"].ToString(),
                             type : TypeRepository.GetById(reader["type_id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0),
                             publisher : PublisherRepository.GetById(reader["publisher_id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0),
                             isForSale : Convert.ToInt32(reader["is_for_sale"]) != 0,
                             isRented : Convert.ToInt32(reader["is_rented"]) != 0,
                             price : reader["price"] != DBNull.Value ? Convert.ToDouble(reader["price"]) : 0.0,
                             invoice : InvoiceRepository.GetById(reader["invoice_id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0)
                         ));
                    }
                }
            }
            return articles;
        }

        public Article GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Article article)
        {
            if (article == null)
                throw new ArgumentNullException(nameof(article));

            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM `article` WHERE `id` = @Id";

                    using (var cmd = new MySqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", article.Id);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new InvalidOperationException($"No article found with ID {article.Id}.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error while deleting article: {ex.Message}");
                throw;
            }
        }

    }
}
