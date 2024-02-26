using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class Address
    {
        private string Id { get; }
        private string Name { get; set; }
        private int Number { get; set; }
        private City City { get; set; }
        private List<Customer> customers { get; set; }

        public Address(string id, string name, int number, City city)
        {
            Id = id;
            Name = name;
            Number = number;
            City = city;
            customers = new List<Customer>();
        }

        public override bool Equals(object? obj)
        {
            return obj is Address address &&
                   Id == address.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
