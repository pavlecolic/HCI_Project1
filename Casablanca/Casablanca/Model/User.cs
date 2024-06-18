using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class User
    {
    
        private int Id { get; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string theme { get; set; }
        public string language { get; set; }
        public double salary { get; set; }
        public string username { get; set; }
        private bool isAdmin { get; }

        public User() { }

        public User(int id, string username, string password, string firstName, string lastName, string theme, string language, double salary, bool isAdmin)
        {
            Id = id;
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.theme = theme;
            this.language = language;
            this.salary = salary;
            this.isAdmin = isAdmin;
        }

        public override bool Equals(object? obj)
        {
            return obj is User user  &&
               user.Id == Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
