// See https://aka.ms/new-console-template for more information
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
    // TODO:
    // - Parse decimal
    // - Parse enum safely
    // - Handle invalid input
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
    // TODO:
    // - Print total spent
    // - Print totals by category
    // - Print largest expense
}
