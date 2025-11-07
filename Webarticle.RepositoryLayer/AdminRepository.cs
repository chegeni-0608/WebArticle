using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebArticle.ModelLayer;
using WebArticle.ModelLayer.Context;

namespace Webarticle.RepositoryLayer
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(WebContext context) : base(context)
        {
        }
    }
}
