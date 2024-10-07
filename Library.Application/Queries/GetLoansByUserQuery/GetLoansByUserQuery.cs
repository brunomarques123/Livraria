using Library.Application.Models;
using MediatR;

namespace Library.Application.Queries.GetLoansByUserQuery
{
    public class GetLoansByUserQuery : IRequest<ResultViewModel<List<LoanViewModel>>>
    {
        public int UserId { get; set; }
    }
}
