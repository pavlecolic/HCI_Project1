using Casablanca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Repository.RepoInterfaces
{
    public interface ISupplierRepository
    {
        bool Add(Supplier Supplier);
        void Edit(Supplier Supplier);
        void Remove(Supplier Supplier);
        Supplier GetById(int id);
        Supplier GetByName(string name);
        IEnumerable<Supplier> GetAll();
    }
}
