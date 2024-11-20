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
    public class RentalRepository : RepositoryBase, IRentalRepository
    {
        public bool Create(Rental entity)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                // Start a transaction to ensure atomicity
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insert the rental into the rental table
                        string rentalQuery = @"INSERT INTO rental (rent_date, due_date, return_date, price, cutomer_id)
                                       VALUES (@RentDate, @DueDate, @ReturnDate, @Price, @CustomerId); 
                                       SELECT LAST_INSERT_ID();";

                        int rentalId;
                        using (var rentalCommand = new MySqlCommand(rentalQuery, connection, transaction))
                        {
                            rentalCommand.Parameters.AddWithValue("@RentDate", entity.RentDate);
                            rentalCommand.Parameters.AddWithValue("@DueDate", entity.DueDate);
                            rentalCommand.Parameters.AddWithValue("@ReturnDate", (object)entity.ReturnDate ?? DBNull.Value);
                            rentalCommand.Parameters.AddWithValue("@Price", entity.Price);
                            rentalCommand.Parameters.AddWithValue("@CustomerId", entity.Customer.Id);

                            // Get the newly generated Rental ID
                            rentalId = Convert.ToInt32(rentalCommand.ExecuteScalar());
                        }

                        // Insert each rented article into the rented_article table
                        string rentedArticleQuery = @"INSERT INTO rented_article (article_id, rental_id, price) 
                                              VALUES (@ArticleId, @RentalId, @Price)";

                        foreach (var rentedArticle in entity.Articles)
                        {
                            using (var rentedArticleCommand = new MySqlCommand(rentedArticleQuery, connection, transaction))
                            {
                                rentedArticleCommand.Parameters.AddWithValue("@ArticleId", rentedArticle.Article.Id);
                                rentedArticleCommand.Parameters.AddWithValue("@RentalId", rentalId);
                                rentedArticleCommand.Parameters.AddWithValue("@Price", rentedArticle.Price);

                                rentedArticleCommand.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Error creating rental: {ex.Message}");
                        return false;
                    }
                }
            }
        }


        public List<Rental> GetByCustomerId(int customerId)
        {
            var rentals = new List<Rental>();

            using (var connection = GetConnection())
            {
                connection.Open();

                string query = @"SELECT id, rent_date, due_date, return_date, price
                             FROM rental
                             WHERE cutomer_id = @CustomerId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rentals.Add(new Rental(
                                reader.GetInt32("id"),
                                reader.GetDateTime("rent_date"),
                                reader.GetDateTime("due_date"),
                                reader.IsDBNull(reader.GetOrdinal("return_date")) ? (DateTime?)null : reader.GetDateTime("return_date"), reader.GetDouble("price"),
                                null,
                                new List<RentedArticle>()
                            ));
                        }
                    }
                }
            }

            return rentals;
        }

        public void Delete(int rentalId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var deleteRentedArticlesCommand = new MySqlCommand(
                            "DELETE FROM rented_article WHERE rental_id = @RentalId", connection, transaction))
                        {
                            deleteRentedArticlesCommand.Parameters.AddWithValue("@RentalId", rentalId);
                            deleteRentedArticlesCommand.ExecuteNonQuery();
                        }
                        using (var deleteRentalCommand = new MySqlCommand(
                            "DELETE FROM rental WHERE id = @RentalId", connection, transaction))
                        {
                            deleteRentalCommand.Parameters.AddWithValue("@RentalId", rentalId);
                            deleteRentalCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        System.Diagnostics.Debug.WriteLine($"Error deleting rental: {ex.Message}");
                        throw;
                    }
                }

            }
        }

        public void Update(Rental rental)
        {
            System.Diagnostics.Debug.WriteLine("Updating");
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"UPDATE rental 
                         SET return_date = @ReturnDate, 
                             price = @Price 
                         WHERE id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ReturnDate", rental.ReturnDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Price", rental.Price);
                    command.Parameters.AddWithValue("@Id", rental.Id);
                                System.Diagnostics.Debug.WriteLine("Updating");

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
