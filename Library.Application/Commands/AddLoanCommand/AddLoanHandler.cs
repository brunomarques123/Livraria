using Library.Application.Models;
using Library.Core.Entities;
using Library.Core.Repositories;
using Library.Infrastructure.Persistence;
using MediatR;

namespace Library.Application.Commands.AddLoanCommand
{
    public class AddLoanHandler : IRequestHandler<AddLoanCommand, ResultViewModel>
    {
        private readonly ILoanRepository _loanRepository;

        public AddLoanHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel> Handle(AddLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = new Loan(
                userId: request.UserId,
                bookId: request.BookId,
                loanDate: request.LoanDate,
                dueDate: request.DueDate,
                returnDate: null,
                isReturned: false
            );

            await _loanRepository.AddLoanAsync(loan);

            return ResultViewModel.Success();
        }
    }
}
