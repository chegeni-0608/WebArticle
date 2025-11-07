using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebArticle.ModelLayer;
using WebArticle.ModelLayer.Context;

namespace WebArticle.ServiceLayer
{
    public class CommentService : EntityService<Comment>, ICommentService
    {
        public CommentService(WebContext context) : base(context)
        {
        }
    }
}
