using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineMedicineShopping.Entities
{
    public class Medicine
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MedicineId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Stock { get; set; }
        public int Discount { get; set; }
        [Required]
        public string Details { get; set; }
        public string Size { get; set; }
        [Required]
        public string Features { get; set; }
        [Required]
        public int CatId { get; set; }
    }
}
