using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMedicineShopping.Entities
{
    public class MedicineOrder
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderId { get; set; }
        public string MedicineId { get; set; }
        public string UserId { get; set; }
        public ICollection<Medicine> Medicine { get; set; }
    }
}
