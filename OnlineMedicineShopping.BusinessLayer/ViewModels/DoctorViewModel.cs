using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMedicineShopping.BusinessLayer.ViewModels
{
    public class DoctorViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public DateTime PracticingFrom { get; set; }
    }
}
