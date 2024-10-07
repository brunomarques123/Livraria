using Library.Core.Entities;

namespace Library.Core.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAllByUserIdAsync(int userId);
        Task<Loan> GetLoanByIdAsync(int loanId);
        Task AddLoanAsync(Loan loan);
        Task UpdateAsync(Loan loan);
        Task RemoveAsync(int loanId);
        Task<bool> ExistsAsync(int loanId);
    }
}
