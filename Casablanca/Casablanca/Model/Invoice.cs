using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class Invoice
    {

        private int Id { get; }
        private double Price { get; }
        private DateTime InvoiceDate { get; }
        private User User { get; }
        private Supplier Supplier { get; }

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
    }
}
