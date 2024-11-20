using Casablanca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Repository.RepoInterfaces
{
    internal interface IInvoiceRepository
    {
        Invoice GetById(int id);
        void Add(Invoice invoice);
        List<Invoice> GetAll();
        void Update(Invoice invoice);
        void Delete(int id);

    }
}
