using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebArticle.ModelLayer
{
    [Table("T_Article")]
    public class Article
    {
        [Key]
        [Required]
        public int ArticleId { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [MaxLength(50)]
        public string ImageName { get; set; }
        public int Like { get; set; }
        public int Visit { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public int AdminId { get; set; }

        public Admin admin { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Comment> comments { get; set; }
    }
}
