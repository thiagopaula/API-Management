using System;


namespace Domain.Entities
{
    public class Session : Base
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string CopyType { get; set; }
        public string MovieId { get; set; }
        public string LocationId { get; set; }
    }
}
