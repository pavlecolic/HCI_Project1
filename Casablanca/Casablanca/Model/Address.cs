using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class Address
    {
        public int Id {
            get; set;
        }
        public string Name { get; set; }
        public int Number { get; set; }
        public City City { get; set; }
        public List<Customer> customers { get; set; }

        public Address(int id, string name, int number, City city)
        {
            Id = id;
            Name = name;
            Number = number;
            City = city;
            customers = new List<Customer>();
        }

        public Address(string name, int number)
        {
            Name = name;
            Number = number;
            City = new City(1, "Banja Luka", "78000");
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
