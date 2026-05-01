namespace ExpenseTracker.API.DTOs;

public class TransactionRequestDto
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; }

    public Guid UserId { get; set; }
    public Guid CategoryId {  get; set; }
    //public string CategoryName { get; set; } = "";
}