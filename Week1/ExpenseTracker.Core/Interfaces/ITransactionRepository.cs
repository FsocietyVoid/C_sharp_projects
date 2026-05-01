using ExpenseTracker.Core.Entities;

namespace ExpenseTracker.Core.Interfaces;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetByUserAsync(Guid userId);
    Task<Transaction?> GetByIdAsync (Guid id);
    Task AddAsync(Transaction transaction);
    Task UpdateAsync(Transaction transaction);
    Task DeleteAsync(Guid id);
}