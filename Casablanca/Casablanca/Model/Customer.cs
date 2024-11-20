using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class Customer
    {
        public int Id {
            get; 
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMB { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public List<Rental> rentals { get; set; }


        public Customer(int id, string firstName, string lastName, string jMB, Address address, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            JMB = jMB;
            Address = address;
            Phone = phone;
            rentals = new List<Rental>();
        }


        public Customer(string firstName, string lastName, string jMB, Address address, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            JMB = jMB;
            Address = address;
            Phone = phone;
            rentals = new List<Rental>();
        }

        public Boolean AddRental(Rental rental)
        {
            if (rentals.Contains(rental))
            {
                return false;
            }
            rentals.Add(rental);
            return true;
        }

        public override bool Equals(object? obj)
        {
            return obj is Customer customer &&
                   Id == customer.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }


        public override string ToString()
        {
            return $"{FirstName} {LastName}: {JMB}";
        }

    }

}
