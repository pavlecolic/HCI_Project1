using Casablanca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Repository.RepoInterfaces
{
    internal interface ICustomerRepository
    {
        bool Add(Customer customer);
        void Remove(int id);
        void Edit(Customer custeomr);
        Customer GetById(int id);
        List<Customer> GetAll();

    }
}
