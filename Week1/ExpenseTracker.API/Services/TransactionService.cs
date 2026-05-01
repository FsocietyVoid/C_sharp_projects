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
}