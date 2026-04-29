using ExpenseTracker.Core.Entities;

namespace ExpenseTracket.Core.Interfaces;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetAllAsync(Guid userId);
    Task<Transaction?> GetByIdAsync (Guid id);
    Task AddAsync(Transaction transaction);
    Task UpdateAsync(Transaction transaction);
    Task DeleteAsync(Guid id);
}