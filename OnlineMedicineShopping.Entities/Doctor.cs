using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMedicineShopping.Entities
{
    public class Doctor
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Qualification { get; set; }
        public DateTime PracticingFrom { get; set; }
    }
}
