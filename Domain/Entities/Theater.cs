
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Theater : Base
    {
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public int PostalCode { get; set; }
        public int Priority { get; set; }       
        public string CityId { get; set; }
        public List<Location> Locations { get; set; }
        


    }
}
