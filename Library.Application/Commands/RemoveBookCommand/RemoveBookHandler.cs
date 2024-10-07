using Library.Application.Models;
using Library.Core.Repositories;
using Library.Infrastructure.Persistence;
using MediatR;

namespace Library.Application.Commands.RemoveBookCommand
{
    public class RemoveBookHandler : IRequestHandler<RemoveBookCommand, ResultViewModel>
    {
        private readonly IBookRepository _bookRepository;

        public RemoveBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null)
            {
                return ResultViewModel.Error("Book not found.");
            }

            await _bookRepository.RemoveBookAsync(request.BookId);

            return ResultViewModel.Success();
        }
    }
}
