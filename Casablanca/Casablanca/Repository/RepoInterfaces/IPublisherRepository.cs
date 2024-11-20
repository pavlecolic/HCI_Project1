using Casablanca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Repository.RepoInterfaces
{
    internal interface IPublisherRepository
    {

        ArticlePublisher GetById(int id);
        List<ArticlePublisher> GetAll();
        void Add(ArticlePublisher publisher);
        void Delete(int id);
        void Edit(ArticlePublisher publisher);
    }
}
