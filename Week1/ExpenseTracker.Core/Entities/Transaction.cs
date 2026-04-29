namespace ExpenseTracker.Core.Entities;

public class Transaction
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    
    public string? Note { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
         
}