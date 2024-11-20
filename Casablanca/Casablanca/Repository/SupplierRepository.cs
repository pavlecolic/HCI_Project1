using Casablanca.Model;
using Casablanca.Repository.RepoInterfaces;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Casablanca.Repository
{
    public class SupplierRepository : RepositoryBase, ISupplierRepository
    {
        public bool Add(Supplier Supplier)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM `city` WHERE name = @Name";
                    using (var checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Name", Supplier.Name);
                        var userExists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
                        if (userExists)
                        {
                            return false;
                        }
                    }

                    string insertQuery = "INSERT INTO `supplier` (name, contact) VALUES (@Name, @Contact)";
                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", Supplier.Name);
                        cmd.Parameters.AddWithValue("@Contact", Supplier.Contact);
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

        public void Edit(Supplier Supplier)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplier> GetAll()
        {
            var suppliers = new List<Supplier>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from `supplier`";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        suppliers.Add(
                         new Supplier
                         {
                             Name = reader["name"].ToString(),
                             Contact = reader["contact"].ToString()
                         });
                    }
                }
            }
            return suppliers;
        }

        public Supplier GetById(int id)
        {
            Supplier supplier = null;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM `supplier` WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        supplier = new Supplier(
                            id: reader.GetInt32("id"),
                            name: reader.GetString("name"),
                            contact: reader.GetString("contact")
                        );
                    }
                }
            }
            return supplier;
        }


        public Supplier GetByName(string name)
        {
            Supplier supplier = null;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from `supplier` where name=@Name";
                command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = name;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        supplier = new Supplier(
                        id: reader.GetInt32(0),
                        name: reader.GetString(1),
                        contact: reader.GetString(2)
                        );
                    }
                }
            }
            return supplier;
        }

        public void Remove(Supplier Supplier)
        {
            try
            {
                using (var conn = GetConnection())
                using (var cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM `supplier` WHERE name = @Name";
                    cmd.Parameters.AddWithValue("@Name", Supplier.Name);
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
