using Domain.Entities;
using MongoDB.Bson.Serialization;


namespace API_Management.App_Start
{
    public class MongoDBConfig
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<City>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(t => t.Id).SetElementName("_id");
                cm.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<Theater>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(t => t.Id).SetElementName("_id");
                cm.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<Location>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(t => t.Id).SetElementName("_id");
                cm.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<Session>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(t => t.Id).SetElementName("_id");
                cm.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<Movie>(cm =>
            {
                cm.AutoMap();
                cm.GetMemberMap(t => t.Id).SetElementName("_id");
                cm.SetIgnoreExtraElements(true);
            });
        }
    }
}
