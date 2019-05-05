using System;
using System.ComponentModel.DataAnnotations;

namespace API_Management.ViewModel
{
    public class SessionViewModel : BaseViewModel
    {
        [Required]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string CopyType { get; set; }
        public string MovieId { get; set; }
        public string LocationId { get; set; }
    }
}
