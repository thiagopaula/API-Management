using System.ComponentModel.DataAnnotations;

namespace API_Management.ViewModel
{
    public class BaseViewModel
    {
        [Required]
        public  bool Enabled{ get; set; }
         
    }
}
