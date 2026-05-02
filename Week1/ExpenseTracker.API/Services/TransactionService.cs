using ExpenseTracker.Core.Entities;
using ExpenseTracker.Core.Interfaces;
using ExpenseTracker.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.API.Services;

public class TransactionService
{
    private readonly ITransactionRepository _repository;

    public TransactionService(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task AddTransactionAsync(TransactionRequestDto dto)
    {
        if (dto.Amount <= 0)
            throw new Exception("Amount must be greater than zero");

        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Amount = dto.Amount,
            Date = dto.Date,
            Note = dto.Note,
            UserId = dto.UserId,
            CategoryId = dto.CategoryId
        };

        await _repository.AddAsync(transaction);
    }

    public async Task<IEnumerable<TransactionResponseDto>> GetUserTransactions(Guid userId)
    {
        var transactions = await _repository.GetByUserAsync(userId);

        return transactions.Select(t => new TransactionResponseDto
        {
            Id = t.Id,
            Amount = t.Amount,
            Date = t.Date,
            Note = t.Note,
            CategoryName = t.Category != null ? t.Category.Name : "Unknown"
        });
    }

    public async Task<IEnumerable<TransactionResponseDto>> GetFilteredTransactions(
        Guid userId,
        DateTime? startDate,
        DateTime? endDate)
    {
        var query = _repository.GetQueryable()
            .Where(t => t.UserId == userId);

        if (startDate.HasValue)
            query = query.Where(t => t.Date >= startDate.Value);

        if (endDate.HasValue)
            query = query.Where(t => t.Date <= endDate.Value);

        return await query
            .OrderByDescending(t => t.Date)
            .Select(t => new TransactionResponseDto
            {
                Id = t.Id,
                Amount = t.Amount,
                Date = t.Date,
                Note = t.Note,
                CategoryName = t.Category != null ? t.Category.Name : "Unknown"
            })
            .ToListAsync();
    }

    public async Task<decimal> GetTotalSpending(Guid userId)
    {
        return await _repository.GetQueryable()
            .Where(t => t.UserId == userId)
            .SumAsync(t => t.Amount);
    }

    public async Task<object> GetSpendingByCategory(Guid userId)
    {
        return await _repository.GetQueryable()
            .Where(t => t.UserId == userId)
            .GroupBy(t => t.Category!.Name)
            .Select(g => new
            {
                Category = g.Key,
                Total = g.Sum(t => t.Amount)
            })
            .ToListAsync();
    }
}