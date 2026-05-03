namespace ExpenseTracker.Web.Models;

public class TransactionResponseDto
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; }
    public string CategoryName { get; set; } = "";
}