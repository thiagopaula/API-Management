using Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Management.ViewModel
{
    public class TheaterViewModel : BaseViewModel
    {

        [Required]
        public string Id { get; set; }
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
