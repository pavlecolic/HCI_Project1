using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class City
    {
        private int Id { get; }
        private string Name { get; set; }
        private string PostalCode { get; set; }
        
        private List<Address> CityAddresses { get; set; }

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
