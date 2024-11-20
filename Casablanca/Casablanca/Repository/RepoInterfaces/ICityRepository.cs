using Casablanca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Repository.RepoInterfaces
{
    interface ICityRepository
    {
        bool Add(City city);
        void Edit(City city);
        void Remove(City city);
        City GetById(int id);
        IEnumerable<City> GetAll();
    }
}
