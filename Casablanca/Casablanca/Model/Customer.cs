using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class Customer
    {
        private int Id { get; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string JMB { get; set; }
        private Address Address { get; set; }
        private string Phone { get; set; }
        private List<Rental> rentals { get; set; }


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
