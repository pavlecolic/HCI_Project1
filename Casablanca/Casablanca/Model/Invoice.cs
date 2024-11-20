using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class Invoice
    {

        public int Id { get; }
        public double Price { get; }
        public DateTime InvoiceDate { get; }
        public User User { get; }
        public Supplier Supplier { get; }

        public Invoice(int id, double price, DateTime invoiceDate, User user, Supplier supplier)
        {
            Id = id;
            Price = price;
            InvoiceDate = invoiceDate;
            User = user;
            Supplier = supplier;
        }

        public override bool Equals(object? obj)
        {
            return obj is Invoice invoice &&
                   Id == invoice.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public int getId()
        {
            return Id;
        }

    }
}
