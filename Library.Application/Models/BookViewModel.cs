using Library.Core.Entities;

namespace Library.Application.Models
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string author, int publicationYear)
        {
            Id = id;
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }

        public static BookViewModel FromEntity(Book book)
        {
            return new BookViewModel(book.Id, book.Title, book.Author, book.PublicationYear);
        }
    }
}
