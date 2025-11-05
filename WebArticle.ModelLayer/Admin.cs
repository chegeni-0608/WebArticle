using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebArticle.ModelLayer
{
    [Table("T_Admin")]
    public class Admin
    {
        [Key]
        [Required]
        public int AdminId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Family { get; set; }
        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        [Required]
        public DateTime RegisterDat { get; set; }
        [Required]
        public bool IsActive { get; set; }


        public IEnumerable<Article> articles { get; set; }
    }
}
