namespace Core.Client.Models
{
    public class Movie
    {


        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }
        public string Owner { get; set; }
    }
}
