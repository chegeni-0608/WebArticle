using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webarticle.RepositoryLayer;
using WebArticle.ModelLayer;
using WebArticle.ModelLayer.Context;

namespace WebArticle.ServiceLayer
{
    public class EntityService<T> : GenericRepository<T> where T : BaseEntity
    {
        public EntityService(WebContext context) : base(context)
        {
        }
    }
}
