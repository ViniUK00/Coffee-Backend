using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoffeePlus.Data.Data
{
    public class OrderItem
    {
        [BsonId]
        public ObjectId Id { get; set; } // MongoDB identifier

        [BsonElement("productId")]
        public ObjectId ProductId { get; set; } // Reference to Product, stored as ObjectId

        [BsonIgnore] // We won't store the Product entity directly in MongoDB, it's referenced by ProductId
        public Product Product { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }

        [BsonElement("unitPrice")]
        public double UnitPrice { get; set; }

        [BsonIgnore] // This is a computed property, it won't be stored in MongoDB
        public double Subtotal => Quantity * UnitPrice;

        [BsonElement("orderId")]
        public ObjectId OrderId { get; set; } // Reference to Order, stored as ObjectId

        [BsonIgnore] // We won't store the Order entity directly in MongoDB, it's referenced by OrderId
        public Order Order { get; set; }
    }
}