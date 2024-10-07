using Library.Application.Models;
using MediatR;

namespace Library.Application.Commands.RemoveBookCommand
{
    public class RemoveBookCommand : IRequest<ResultViewModel>
    {
        public RemoveBookCommand(int bookId)
        {
            BookId = bookId;
        }

        public int BookId { get; set; }
    }
}
