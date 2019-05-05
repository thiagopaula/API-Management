
namespace Domain.Entities
{
    public class Movie : Base
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Sinopsis { get; set; }
        public string Directors { get; set; }
        public int Year { get; set; }
        public int Priority { get; set; }
    }
}
