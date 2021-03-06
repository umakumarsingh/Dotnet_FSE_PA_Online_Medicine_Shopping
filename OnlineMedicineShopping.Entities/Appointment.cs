﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMedicineShopping.Entities
{
    public class Appointment
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Display(Name = "Appointment Number")]
        public string AppointmentId { get; set; }
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
