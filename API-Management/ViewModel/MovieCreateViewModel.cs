
namespace API_Management.ViewModel
{
    public class MovieCreateViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Sinopsis { get; set; }
        public string Directors { get; set; }
        public int Year { get; set; }
        public int Priority { get; set; }
    }
}
