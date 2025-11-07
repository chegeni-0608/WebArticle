using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebArticle.ModelLayer
{
    [Table("T_Comment")]
    public class Comment: BaseEntity
    {
        [Key]
        [Required]
        public int CommentId { get; set; }
        [Required]
        [MaxLength(40)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(80)]
        public string Email { get; set; }
        [Required]
        [MaxLength(200)]
        public string Content { get; set; }
        [Required]
        public DateTime Registerdate { get; set; }
        [Required]
        public bool IsActive { get; set; }


        public Article article { get; set; }
    }
}
