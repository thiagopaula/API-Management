using MongoDB.Bson;
namespace Domain.Entities
{
    public class Base
    {
        public ObjectId Id { get; set; }
        public bool Enabled { get; set; }
    }
}
