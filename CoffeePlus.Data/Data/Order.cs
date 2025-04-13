using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace CoffeePlus.Data.Data
{
    public class Order
    {
        [BsonId]
        public ObjectId Id { get; set; } // MongoDB identifier

        [BsonElement("orderDate")]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow; // DateTime stored in MongoDB

        [BsonElement("totalAmount")]
        public double TotalAmount { get; set; }

        [BsonElement("items")]
        public List<OrderItem> Items { get; set; } = new(); // Embedded list of OrderItems in MongoDB

        [BsonElement("status")]
        public string Status { get; set; } = "Pending";

        [BsonElement("paymentMethod")]
        public string PaymentMethod { get; set; }
    }
}