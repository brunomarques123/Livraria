using Library.Application.Models;
using Library.Core.Entities;
using Library.Core.Repositories;
using MediatR;

namespace Library.Application.Commands.AddBookCommand
{
    public class AddBookHandler : IRequestHandler<AddBookCommand, ResultViewModel>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResultViewModel> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            Book book = new(request.Title, request.Author, request.PublicationYear);

            await _bookRepository.AddBookAsync(book);

            return ResultViewModel.Success();
        }
    }
}
