using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class Rental
    {

        public int Id { get; }
        public DateTime RentDate { get; }
        public DateTime DueDate { get; }
        public DateTime? ReturnDate {
            get; set;
        }
        public double Price { get; set; }
        public Customer Customer { get; }
        public List<RentedArticle> Articles { get; set; }


        public Rental(int id, DateTime rentDate, DateTime dueDate, DateTime? returnDate, double price, Customer customer, List<RentedArticle> rentedArticles)
        {
            Id = id;
            RentDate = rentDate;
            DueDate = dueDate;
            ReturnDate = returnDate;
            Price = price;
            Customer = customer;
            Articles = rentedArticles;
        }

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
