public class BudgetService
{
    private readonly List<Transaction> transactions = new();

    public void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);
    }

    public IReadOnlyList<Transaction> GetAllTransactions()
    {
        return transactions.AsReadOnly();
    }

    public decimal GetTotalSpent()
    {
        // TODO: Implement using LINQ
        throw new NotImplementedException();
    }

    public Dictionary<Category, decimal> GetTotalByCategory()
    {
        // TODO: Implement using GroupBy
        throw new NotImplementedException();
    }

    public Transaction? GetLargestExpense()
    {
        // TODO: Implement safely (handle empty list)
        throw new NotImplementedException();
    }
}
