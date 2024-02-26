using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class Article
    {
        private int Id { get; }
        private string Name { get; set; }
        private string ImageURL { get; set; }
        private ArticleType Type { get; set; }
        private ArticlePublisher Publisher { get; set; }
        private Boolean IsRented { get; set; }
        private double Price { get; set; }
        private Invoice Invoice { get; }

        public Article(int id, string name, string imageURL, ArticleType type, ArticlePublisher publisher, bool isRented, double price, Invoice invoice)
        {
            Id = id;
            Name = name;
            ImageURL = imageURL;
            Type = type;
            Publisher = publisher;
            IsRented = isRented;
            Price = price;
            Invoice = invoice;
        }

        public override bool Equals(object? obj)
        {
            return obj is Article article &&
                   Id == article.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
