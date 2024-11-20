using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class ArticlePublisher
    {

        public int Id { get; }
        public string PublisherName { get; set; }

        public ArticlePublisher(int id, string publisherName)
        {
            Id = id;
            PublisherName = publisherName;
        }

        public override bool Equals(object? obj)
        {
            return obj is ArticlePublisher publisher &&
                   Id == publisher.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public int getId()
        {
        
        return Id; }

        public override string ToString()
        {
            return $"Publisher ID: {Id}, Name: {PublisherName}";
        }

    }
}
