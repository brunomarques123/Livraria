using Library.Application.Models;
using MediatR;

namespace Library.Application.Queries.GetBookByIdQuery
{
    public class GetBookByIdQuery : IRequest<ResultViewModel<BookViewModel>>
    {
        public GetBookByIdQuery(int bookId)
        {
            BookId = bookId;
        }

        public int BookId { get; set; }
    }
}
