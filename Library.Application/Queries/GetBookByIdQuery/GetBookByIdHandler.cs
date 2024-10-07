using Library.Application.Models;
using Library.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Queries.GetBookByIdQuery
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, ResultViewModel<BookViewModel>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel<BookViewModel>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);

            if (book is null)
            {
                return new ResultViewModel<BookViewModel>(null, false, "Book not found.");
            }

            var bookViewModel = BookViewModel.FromEntity(book);

            return ResultViewModel<BookViewModel>.Success(bookViewModel);
        }
    }
}
