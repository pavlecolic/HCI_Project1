using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class Rental
    {

        private int Id { get; }
        private DateTime RentDate { get; }
        private DateTime DueDate { get; }
        private DateTime ReturnDate { get; }
        private double Price { get; set; }
        private Customer Customer { get; }
        private List<RentedArticle> Articles { get; set; }


        public Rental(int id, DateTime rentDate, DateTime dueDate, double price, Customer customer, List<RentedArticle> rentedArticles)
        {
            Id = id;
            RentDate = rentDate;
            DueDate = dueDate;
            Price = price;
            Customer = customer;
            Articles = rentedArticles;
        }

        public override bool Equals(object? obj)
        {
            return obj is Rental rental &&
                   Id == rental.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

    }
}
