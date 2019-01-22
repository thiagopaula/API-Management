
using System.ComponentModel.DataAnnotations;


namespace API_Management.ViewModel
{
    public class LocationViewModel : BaseViewModel
    {
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ResumeName { get; set; }
        public string TheaterId { get; set; }
    }
}
