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
        private string username { get; set; }
        private string password { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string theme { get; set; }
        private string language { get; set; }
        private double salary { get; set; }
        private bool isAdmin { get; }

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
