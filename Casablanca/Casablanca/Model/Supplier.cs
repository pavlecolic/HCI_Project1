using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class Supplier
    {

        private int Id { get; }
        private string Name { get; set; }
        private string Contact { get; set; }

        public Supplier(int id, string name, string contact)
        {
            Id = id;
            Name = name;
            Contact = contact;
        }

        public override bool Equals(object? obj)
        {
            return obj is Supplier supplier &&
                   Id == supplier.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
