using Casablanca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Repository.RepoInterfaces
{
    internal interface ITypeRepository
    {
        ArticleType GetById(int id);
        List<ArticleType> GetAll();
        void Update(ArticleType articleType);
        void Add(ArticleType article);
        void Delete(int id);

    }
}
