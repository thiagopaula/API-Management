
using GraphQL.Types;


namespace API_Management.GraphQL.Types
{
    public class CityType : ObjectGraphType<City>
    {
        public CityType()
        {
            Name = "City";

            Field(h => h.Id);
            Field(h => h.Name);
            Field(h => h.State);
            Field(h => h.UF);
            Field(h => h.TimeZone);
            Field(h => h.Enabled);

            Interface<CityInterface>();

        }
    }
}
