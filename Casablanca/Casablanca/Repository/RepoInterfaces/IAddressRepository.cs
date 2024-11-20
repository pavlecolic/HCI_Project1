using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casablanca.Model;

namespace Casablanca.Repository.RepoInterfaces
{
    internal interface IAddressRepository
    {
        void Add(Address address);
        void Edit(Address address);
        List<Address> GetAll();
        Address GetById(int id);
        void Remove(int id);    
    }
}
