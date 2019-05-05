
using MongoDB.Bson;



namespace API_Management.GraphQL.Types
{  
    public class City 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string UF { get; set; }
        public string TimeZone { get; set; }
        public bool Enabled { get; set; }

        public City(ObjectId id)
        {
            Id = id.ToString();
        }
    }
}

