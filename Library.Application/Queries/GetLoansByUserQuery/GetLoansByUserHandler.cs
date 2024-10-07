using Library.Application.Models;
using Library.Core.Repositories;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Queries.GetLoansByUserQuery
{
    public class GetLoansByUserHandler : IRequestHandler<GetLoansByUserQuery, ResultViewModel<List<LoanViewModel>>>
    {
        private readonly ILoanRepository _loanRepository;

        public GetLoansByUserHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<ResultViewModel<List<LoanViewModel>>> Handle(GetLoansByUserQuery request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.GetAllByUserIdAsync(request.UserId);

            var loanViewModels = loans.Select(LoanViewModel.FromEntity).ToList();

            return ResultViewModel<List<LoanViewModel>>.Success(loanViewModels);
        }
    }
}
