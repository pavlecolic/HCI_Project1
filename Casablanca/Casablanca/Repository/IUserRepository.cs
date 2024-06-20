using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Casablanca.Model.Repository
{
    public interface IUserRepository
    {

        bool AuthenticateUser(NetworkCredential credential);
        bool Add(User user);
        void Edit(User user);
        void Remove(User user);
        User GetById(int id);
        User GetByUsername(string username);
        IEnumerable<User> GetAll();
        IEnumerable<User> GetAllEmployees();

    }
}
