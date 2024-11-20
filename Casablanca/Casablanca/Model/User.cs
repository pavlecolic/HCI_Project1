using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Model
{
    public class User
    {
    
        public int Id { get; }
        public string? password { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? theme { get; set; }
        public string? language { get; set; }
        public double? salary { get; set; }
        public string username { get; set; }
        public bool isAdmin { get; }

        public User() 
        {
        }

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

        public User(string username, string firstName, string lastName, double salary, bool isAdmin)
        {
            this.username = username; 
            this.firstName = firstName;
            this.lastName = lastName;
            this.salary = salary;
            this.isAdmin = isAdmin;
            this.language = "en";
            this.theme = "li";
        }
        // Add employee constructor
        public User(string username, string password, string firstName, string lastName, double salary)
        {
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.salary = salary;
            this.isAdmin = false;
            this.password = password;
            this.language = "en";
            this.theme = "li";
        }


        public override bool Equals(object obj)
        {
            if (obj is User user)
            {
                return username == user.username; // Assuming username is unique
            }
            return false;
        }

        public override int GetHashCode()
        {
            return username.GetHashCode();
        }
    }
}
