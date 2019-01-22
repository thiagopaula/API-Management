
using GraphQL.Types;


namespace API_Management.GraphQL.Types
{
    public class CityInterface : InterfaceGraphType<City>
    {
        public CityInterface()
        {
            Name = "City";

            Field(d => d.Id);
            Field(d => d.Name);
            Field(d => d.State);
            Field(d => d.UF);
            Field(d => d.TimeZone);
            Field(d => d.Enabled);
        }
    }
}
