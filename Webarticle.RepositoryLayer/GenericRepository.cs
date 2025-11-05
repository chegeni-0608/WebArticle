using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebArticle.ModelLayer;
using WebArticle.ModelLayer.Context;

namespace Webarticle.RepositoryLayer
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        
        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public bool Add(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

       
      
    }
}
