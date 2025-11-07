using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebArticle.ModelLayer;
using WebArticle.ModelLayer.Context;

namespace Webarticle.RepositoryLayer
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(WebContext context) : base(context)
        {
        }
    }
}
