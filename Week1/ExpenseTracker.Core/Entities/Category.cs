namespace ExpenseTracker.Core.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}