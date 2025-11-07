using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebArticle.ModelLayer;

namespace WebArticle.ServiceLayer
{
    public interface IEntityService<in T> where T : BaseEntity 
    {
    }
}
