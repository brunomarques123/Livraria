using Library.Application.Models;
using Library.Core.Repositories;
using MediatR;

namespace Library.Application.Commands.UpdateBookCommand
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ResultViewModel>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null)
            {
                return ResultViewModel.Error("Book not found.");
            }

            await _bookRepository.UpdateBookAsync(book);

            return ResultViewModel.Success();
        }
    }
}
