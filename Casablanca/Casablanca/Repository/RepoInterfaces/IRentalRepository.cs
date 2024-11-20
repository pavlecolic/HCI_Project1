using Casablanca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Repository.RepoInterfaces
{
    internal interface IRentalRepository
    {
        List<Rental> GetByCustomerId(int  customerId);
        bool Create(Rental entity);
        void Delete(int id);
        void Update(Rental entity);
    }
}
