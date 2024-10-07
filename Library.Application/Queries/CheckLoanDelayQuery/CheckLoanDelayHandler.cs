using Library.Application.Models;
using Library.Core.Repositories;
using MediatR;

namespace Library.Application.Queries.CheckLoanDelayQuery
{
    public class CheckLoanDelayHandler : IRequestHandler<CheckLoanDelayQuery, ResultViewModel<string>>
    {
        private readonly ILoanRepository _loanRepository;

        public CheckLoanDelayHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel<string>> Handle(CheckLoanDelayQuery request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(request.LoanId);

            if (loan == null)
                return new ResultViewModel<string>(null, false, "Loan not found.");

            if (loan.IsReturned)
                return new ResultViewModel<string>("Loan already returned.", true);

            if (loan.DueDate < DateTime.Now)
                return new ResultViewModel<string>("Loan is overdue.", true);

            else
                return new ResultViewModel<string>("Loan is within the return date.", true);
        }
    }
}
