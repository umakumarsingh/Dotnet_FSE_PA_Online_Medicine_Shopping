using OnlineMedicineShopping.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMedicineShopping.BusinessLayer.ViewModels
{
    public class AppointmentViewModel
    {
        [Required]
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }
        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime Takendate { get; set; }
        public string Symtoms { get; set; }
        public string Remark { get; set; }
        [Required]
        [Display(Name = "Patient Age")]
        public int PatientAge { get; set; }
        public virtual Doctor Doctors { get; set; }
    }
}
