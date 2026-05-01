using ExpenseTracker.Core.Entities;
using ExpenseTracker.Core.Interfaces;
using ExpenseTracker.API.DTOs;

namespace ExpenseTracker.API.Services;

public class TransactionService
{
	private readonly ITransactionRepository _repository;

	public TransactionService(ITransactionRepository respository)
	{
		_repository = respository;
	}

	public async Task AddTransactionAsync(TransactionRequestDto dto)
	{
		if (dto.Amount <= 0)
			throw new Exception("Amount must be greator than zero");

		var transaction = new Transaction
		{
			Id = Guid.NewGuid(),
			Amount = dto.Amount,
			Date = dto.Date,
			Note = dto.Note,
			UserId = dto.UserId,
			CategoryId = dto.CategoryId,
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
		var transactions = await _repository.GetByUserAsync(userId);

		if (startDate.HasValue)
			transactions = transactions.Where(t => t.Date >= startDate.Value);

		if (endDate.HasValue)
			transactions = transactions.Where(t => t.Date <= endDate.Value);

		return transactions.Select(t => new TransactionResponseDto
		{
			Id = t.Id,
			Amount = t.Amount,
			Date = t.Date,
			Note = t.Note,
			CategoryName = t.Category != null ? t.Category.Name : "Unknown"
		});
	}
}