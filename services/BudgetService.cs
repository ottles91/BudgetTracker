using System.Linq;

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
        // Check if the list is empty
        if (transactions.Count == 0 || transactions == null)
        {
            return 0;
        }

        return GetAllTransactions().OrderBy(t => t.Amount).FirstOrDefault().Amount;
    }

    public Dictionary<Category, decimal> GetTotalByCategory()
    {
        return GetAllTransactions()
            .GroupBy(t => t.Category)
            .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));
    }

    public Transaction? GetLargestExpense()
    {
        if (GetAllTransactions().Count == 0)
        {
            return null;
        }

        return GetAllTransactions().OrderByDescending(t => t.Amount).FirstOrDefault();
    }
}
