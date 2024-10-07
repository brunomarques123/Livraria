using Library.Application.Models;
using MediatR;

namespace Library.Application.Queries.GetAllBooksQuery
{
    public class GetAllBooksQuery : IRequest<ResultViewModel<List<BookViewModel>>>
    {
    }
}
