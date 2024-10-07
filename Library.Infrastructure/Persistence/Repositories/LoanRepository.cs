using Library.Core.Entities;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryDbContext _context;

        public LoanRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Loans
                                 .Where(loan => loan.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<Loan> GetLoanByIdAsync(int loanId)
        {
            return await _context.Loans
                                 .FindAsync(loanId);
        }

        public async Task AddLoanAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Loan loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int loanId)
        {
            var loan = await _context.Loans.FindAsync(loanId);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int loanId)
        {
            return await _context.Loans.AnyAsync(loan => loan.Id == loanId);
        }
    }
}
