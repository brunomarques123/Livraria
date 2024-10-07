using Library.Application.Models;
using Library.Core.Repositories;
using Library.Infrastructure.Persistence;
using MediatR;

namespace Library.Application.Commands.ReturnLoanCommand
{
    public class ReturnLoanHandler : IRequestHandler<ReturnLoanCommand, ResultViewModel>
    {
        private readonly ILoanRepository _loanRepository;

        public ReturnLoanHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel> Handle(ReturnLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(request.LoanId);
            if (loan == null)
            {
                return new ResultViewModel(false, "Loan not found.");
            }

            loan.MarkAsReturned(request.ReturnDate);

            await _loanRepository.UpdateAsync(loan);

            return ResultViewModel.Success();
        }
    }
}
