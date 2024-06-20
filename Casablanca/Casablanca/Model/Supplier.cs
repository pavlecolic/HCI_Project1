using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class Supplier
    {

        public int Id { get; }
        public string Name { get; set; }
        public string Contact { get; set; }

        public Supplier()
        {
        }

        public Supplier(int id, string name, string contact)
        {
            Id = id;
            this.Name = name;
            this.Contact = contact;
        }

        public Supplier(string name, string contact)
        {
            this.Name = name;
            this.Contact = contact;
        }

        public override bool Equals(object? obj)
        {
            return obj is Supplier supplier &&
                   Name == supplier.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
