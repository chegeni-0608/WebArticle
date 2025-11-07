using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebArticle.ModelLayer;
using WebArticle.ModelLayer.Context;

namespace WebArticle.ServiceLayer
{
    public class AdminService : EntityService<Admin>, IAdminService
    {
        public AdminService(WebContext context) : base(context)
        {
        }
    }
}
