using Library.Application.Models;
using Library.Core.Entities;
using MediatR;

namespace Library.Application.Commands.AddBookCommand
{
    public class AddBookCommand : IRequest<ResultViewModel>
    {
        public AddBookCommand(string title, string author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }

        public Book ToEntity()
            => new Book(Title, Author, PublicationYear);
    }
}
