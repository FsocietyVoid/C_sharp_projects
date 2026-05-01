
namespace ExpenseTracker.API.DTOs;

public class TransactionResponseDto
{
    public Guid Id { get; set; }   // Transaction Id
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; }

    public string CategoryName { get; set; } = "";
}