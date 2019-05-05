

using System.ComponentModel.DataAnnotations;

namespace API_Management.ViewModel
{
    public class LocationCreateViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string ResumeName { get; set; }
        [Required]
        public string TheaterId { get; set; }
    }
}
