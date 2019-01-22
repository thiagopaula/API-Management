
using System.ComponentModel.DataAnnotations;

namespace API_Management.ViewModel
{
    public class CityViewModel : BaseViewModel
    {
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string UF { get; set; }
        public string TimeZone { get; set; }
    }
}
