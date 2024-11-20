using Casablanca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Repository.RepoInterfaces
{
    internal interface IArticleRepository
    {
        bool Add(Article article);
        void Edit(Article article);
        void Remove(Article article);
        Article GetById(int id);
        IEnumerable<Article> GetAll();
    }
}
