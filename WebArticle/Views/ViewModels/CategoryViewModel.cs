using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebArticle.ModelLayer;

namespace WebArticle.Views.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        [Display(Name = "آیدی دسته بندی")]
        public int CategoryId { get; set; }


        [Required]
        [MaxLength(80)]
        [Display(Name = "نام دسته بندی")]
        public string Title { get; set; }


        [MaxLength(50)]
        [Display(Name = "تصویر دسته بندی")]
        public string ImageName { get; set; }


        public IEnumerable<Article> articles { get; set; }
    }
}