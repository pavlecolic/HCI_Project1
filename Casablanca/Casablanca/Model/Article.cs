using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class Article : INotifyPropertyChanged
    {
        public int Id {
            get; set;
        }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public ArticleType Type { get; set; }
        public ArticlePublisher Publisher { get; set; }
        public Boolean IsRented { get; set; }
        public double Price { get; set; }

        public Invoice Invoice {
            get; set;
        }
        public Boolean IsForSale
        {
            get;
            set;
        }

        public Article(int id, string name, string imageURL, ArticleType type, ArticlePublisher publisher, bool isForSale, bool isRented, double price, Invoice invoice)
        {
            Id = id;
            Name = name;
            ImageURL = imageURL;
            Type = type;
            Publisher = publisher;
            IsRented = isRented;
            Price = price;
            Invoice = invoice;
            IsForSale = isForSale;
        }

        public Article(string name, string imageURL, ArticleType type, ArticlePublisher publisher, bool isForSale, bool isRented, double price)
        {
            Name = name;
            ImageURL = imageURL;
            Type = type;
            Publisher = publisher;
            IsRented = isRented;
            Price = price;
            IsForSale = isForSale;
        }

        public Article()
        {
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

        public int getId()
        {
            return this.Id;
        }


        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Article ID: {Id}");
            builder.AppendLine($"Name: {Name}");
            builder.AppendLine($"Image URL: {ImageURL}");
            builder.AppendLine($"Type: {Type?.ToString() ?? "None"}");
            builder.AppendLine($"Publisher: {Publisher?.ToString() ?? "None"}");
            builder.AppendLine($"Is For Sale: {IsForSale}");
            builder.AppendLine($"Is Rented: {IsRented}");
            builder.AppendLine($"Price: {Price:C}");
            builder.AppendLine($"Invoice: {Invoice?.ToString() ?? "None"}");
            return builder.ToString();
        }

    }

}

