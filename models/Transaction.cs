public enum Category
{
    Food,
    Rent,
    Utilities,
    Entertainment,
    Transportation,
    Other,
}

public class Transaction
{
    public decimal Amount { get; }
    public Category Category { get; }
    public string Description { get; }
    public DateTime Date { get; }

    public Transaction(decimal amount, Category category, string description)
    {
        Amount = amount;
        Category = category;
        Description = description;
        Date = DateTime.Now;
    }
}
