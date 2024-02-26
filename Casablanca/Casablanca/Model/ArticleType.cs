using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class ArticleType
    {

        private int Id { get; }
        private string TypeName { get; set; }

        public ArticleType(int id, string typeName)
        {
            Id = id;
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
    }
    
}
