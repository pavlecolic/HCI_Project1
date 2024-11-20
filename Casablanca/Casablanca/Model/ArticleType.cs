using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class ArticleType
    {

        public int Id { get; }
        public string TypeName { get; set; }

        public ArticleType(int id, string typeName)
        {
            Id = id;
            TypeName = typeName;
        }

        public ArticleType(string typeName)
        {
            TypeName = typeName;
        }
        public override bool Equals(object? obj)
        {
            return obj is ArticleType type &&
                   Id == type.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public int getId()
        {
        return Id; 
        }

        public override string ToString()
        {
            return $"Type ID: {Id}, Name: {TypeName}";
        }

    }

}
