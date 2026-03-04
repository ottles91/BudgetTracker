// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

var budgetService = new BudgetService();
bool running = true;

while (running)
{
    Console.WriteLine("\n1. Add Transaction");
    Console.WriteLine("2. View All");
    Console.WriteLine("3. Show Summary");
    Console.WriteLine("4. Exit");

    Console.Write("Choose an option: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            AddTransactionFlow(budgetService);
            break;
        case "2":
            ViewAllFlow(budgetService);
            break;
        case "3":
            ShowSummaryFlow(budgetService);
            break;
        case "4":
            running = false;
            break;
    }
}

static void AddTransactionFlow(BudgetService service)
{
    // Prompt User for description
    Console.Write("Enter description: ");
    string description = Console.ReadLine() ?? "";

    //Prompt user for amount
    Console.WriteLine("Enger amount: ");
    string amount = Console.ReadLine() ?? "";
    decimal parsedAmount;
    if (decimal.TryParse(amount, out parsedAmount)) { }
    else
    {
        Console.WriteLine("Invalid input");
    }

    //Promt user for category (show options)
    Console.WriteLine("Choose Category:");
    Console.WriteLine("1. Food");
    Console.WriteLine("2. Rent");
    Console.WriteLine("3. Utilities");
    Console.WriteLine("4. Entertainment");
    Console.WriteLine("5. Transportation");
    Console.WriteLine("6. Other");
    var categoryInput = Console.ReadLine();

    switch (categoryInput)
    {
        case "1":
            service.AddTransaction(new Transaction(parsedAmount, Category.Food, description));
            break;
        case "2":
            service.AddTransaction(new Transaction(parsedAmount, Category.Rent, description));
            break;
        case "3":
            service.AddTransaction(new Transaction(parsedAmount, Category.Utilities, description));
            break;
        case "4":
            service.AddTransaction(
                new Transaction(parsedAmount, Category.Entertainment, description)
            );
            break;
        case "5":
            service.AddTransaction(
                new Transaction(parsedAmount, Category.Transportation, description)
            );
            break;
        case "6":
            service.AddTransaction(new Transaction(parsedAmount, Category.Other, description));
            break;
        default:
            Console.WriteLine("Invalid category");
            break;
    }
}

static void ViewAllFlow(BudgetService service)
{
    foreach (var transaction in service.GetAllTransactions())
    {
        Console.WriteLine(
            $"{transaction.Date:d} | {transaction.Category} | {transaction.Amount:C} | {transaction.Description}"
        );
    }
}

static void ShowSummaryFlow(BudgetService service)
{
    // - Print total spent
    Console.WriteLine($"Total Spent: {service.GetTotalSpent():C}");

    // - Print totals by category
    foreach (var pair in service.GetAllTransactions())
    {
        Console.WriteLine($"{pair.Category}: {pair.Amount}");
    }

    // - Print largest expense
    Transaction? largest = service.GetLargestExpense();
    if (largest != null)
    {
        Console.WriteLine(
            $"Largest Expense: {largest.Amount:C} on {largest.Date:d} for {largest.Description}"
        );
    }
    else
    {
        Console.WriteLine("No transactions found.");
    }
}
