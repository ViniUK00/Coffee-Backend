using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace CoffeePlus.Data.Data
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; } // MongoDB uses ObjectId for unique identifier

        [BsonElement("name")] // Optional: Specify MongoDB field name
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("imageUrl")]
        public string? ImageUrl { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("isAvailable")]
        public bool IsAvailable { get; set; }

        [BsonElement("sku")]
        public string SKU { get; set; }

        [BsonElement("size")]
        public string Size { get; set; }

        [BsonElement("tags")]
        public List<string> Tags { get; set; }
    }
}