using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebArticle.ModelLayer;
using WebArticle.ModelLayer.Context;

namespace WebArticle.ServiceLayer
{
    public class ArticleService : EntityService<Article>, IArticleService
    {
        public ArticleService(WebContext context) : base(context)
        {
        }
    }
}
