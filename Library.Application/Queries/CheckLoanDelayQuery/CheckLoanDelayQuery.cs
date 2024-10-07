using Library.Application.Models;
using MediatR;

namespace Library.Application.Queries.CheckLoanDelayQuery
{
    public class CheckLoanDelayQuery : IRequest<ResultViewModel<string>>
    {
        public CheckLoanDelayQuery(int loanId)
        {
            LoanId = loanId;
        }

        public int LoanId { get; set; }
    }
}
