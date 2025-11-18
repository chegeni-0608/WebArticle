using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebArticle.ModelLayer;
using WebArticle.ModelLayer.Context;

namespace WebArticle.ServiceLayer
{
    public class CategoryService : EntityService<Category>, ICategoryService
    {
        public CategoryService(WebContext context) : base(context)
        {
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
