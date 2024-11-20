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
    internal class InvoiceRepository : RepositoryBase, IInvoiceRepository
    {

        UserRepository UserRepository = new UserRepository();
        SupplierRepository SupplierRepository = new SupplierRepository();

        public Invoice GetById(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT id, price, date, user_id, supplier_id FROM invoice WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Invoice(
                                id: Convert.ToInt32(reader["id"]),
                                price: Convert.ToDouble(reader["price"]),
                                invoiceDate: Convert.ToDateTime(reader["date"]),
                                user: UserRepository.GetById(Convert.ToInt32(reader["user_id"])),
                                supplier: SupplierRepository.GetById(Convert.ToInt32(reader["supplier_id"]))
                            );
                        }
                    }
                }
            }

            return null; // Return null if not found
        }

        // Add a new Invoice
        public void Add(Invoice invoice)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO invoice (price, date, user_id, supplier_id) VALUES (@Price, @Date, @UserId, @SupplierId)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Price", invoice.Price);
                    command.Parameters.AddWithValue("@Date", invoice.InvoiceDate);
                    command.Parameters.AddWithValue("@UserId", invoice.User.Id);
                    command.Parameters.AddWithValue("@SupplierId", invoice.Supplier.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Invoice> GetAll()
        {
            var invoices = new List<Invoice>();

            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT id, price, date, user_id, supplier_id FROM invoice";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        invoices.Add(new Invoice(
                            id: Convert.ToInt32(reader["id"]),
                            price: Convert.ToDouble(reader["price"]),
                            invoiceDate: Convert.ToDateTime(reader["date"]),
                            user: UserRepository.GetById(Convert.ToInt32(reader["user_id"])),
                            supplier: SupplierRepository.GetById(Convert.ToInt32(reader["supplier_id"]))
                        ));
                    }
                }
            }

            return invoices;
        }


        public void Update(Invoice invoice)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE invoice SET price = @Price, date = @Date, user_id = @UserId, supplier_id = @SupplierId WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Price", invoice.Price);
                    command.Parameters.AddWithValue("@Date", invoice.InvoiceDate);
                    command.Parameters.AddWithValue("@UserId", invoice.User.Id);
                    command.Parameters.AddWithValue("@SupplierId", invoice.Supplier.Id);
                    command.Parameters.AddWithValue("@Id", invoice.getId());
                    command.ExecuteNonQuery();
                }
            }
        }

        // Delete an Invoice by Id
        public void Delete(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM invoice WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
