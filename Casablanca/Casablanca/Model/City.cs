using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class City
    {
        public int Id { get; }
        public string Name { get; set; }
        public string PostalCode { get; set; }

        public List<Address> CityAddresses { get; set; }

        public City()
        {
        }

        public City(string name, string postalCode)
        {
            Name = name;
            PostalCode = postalCode;
        }

        public City(int id, string name, string postalCode)
        {
            Id = id;
            this.Name = name;
            PostalCode = postalCode;
        }


        public City(int id, string name, string postalCode, List<Address> cityAddresses)
        {
            Id = id;
            Name = name;
            PostalCode = postalCode;
            CityAddresses = cityAddresses;
        }

        public override bool Equals(object? obj)
        {
            return obj is City city &&
                   Id == city.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
