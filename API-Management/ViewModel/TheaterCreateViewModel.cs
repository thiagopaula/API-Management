
using System.ComponentModel.DataAnnotations;

namespace API_Management.ViewModel
{
    public class TheaterCreateViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public int PostalCode { get; set; }
        public int Priority { get; set; }
        [Required]
        public string CityId { get; set; }
    }
}
