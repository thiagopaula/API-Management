using System;
using System.ComponentModel.DataAnnotations;

namespace API_Management.ViewModel
{
    public class SessionCreateViewModel : BaseViewModel
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string CopyType { get; set; }
        [Required]
        public string MovieId { get; set; }
        [Required]
        public string LocationId { get; set; }
    }
}
