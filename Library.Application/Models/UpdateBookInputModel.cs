namespace Library.Application.Models
{
    public class UpdateBookInputModel
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public int? PublicationYear { get; set; }
    }
}
