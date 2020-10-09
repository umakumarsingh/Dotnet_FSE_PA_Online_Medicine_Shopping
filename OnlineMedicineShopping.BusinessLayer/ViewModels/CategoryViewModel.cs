using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMedicineShopping.BusinessLayer.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        public int CatId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Url { get; set; }
        public bool OpenInNewWindow { get; set; }
    }
}
