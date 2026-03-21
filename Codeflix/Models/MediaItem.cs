namespace Codeflix.Models
{
    public class MediaItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Type { get; set; } // Movie or TV Show
        public double Rating { get; set; }
        public string Director { get; set; }

        public MediaItem(int id, string title, string genre, int releaseYear, string type, double rating, string director)
        {
            Id = id;
            Title = title;
            Genre = genre;
            ReleaseYear = releaseYear;
            Type = type;
            Rating = rating;
            Director = director;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Title: {Title}, Genre: {Genre}, Year: {ReleaseYear}, Type: {Type}, Rating: {Rating}, Director: {Director}";
        }
    }
}