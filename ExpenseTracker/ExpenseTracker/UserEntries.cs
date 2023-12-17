using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ExpenseTracker
{
    internal class UserEntries
    {
        /// <summary>
        /// Adds an income.
        /// </summary>
        /// <param name="incomeOperation">Income operation.</param>
        public static void AddIncome(IncomeRecordOperation incomeOperation)
        {
            Console.Clear();
            Console.Write("Enter the amount of the Income: ");

            decimal amount;
            string source;
            while (true)
            {
                string input = Console.ReadLine();
                if (!decimal.TryParse(input, out amount))
                {
                    ErrorMessage("Please enter valid amount.");
                    continue;
                }

                if (amount <= 0)
                {
                    ErrorMessage("Please enter positive amount.");
                    continue;
                }

                break;
            }

            Console.Write("Enter the source of the income: ");
           
            while (true)
            {
                source = Console.ReadLine();
                if (string.IsNullOrEmpty(source))
                {
                    ErrorMessage("Source cannot be null.Please enter source name.");
                    continue;
                }

                break;
            }

            incomeOperation.AddIncome(new IncomeRecord(amount, DateTime.Now, source));
            SuccessMessage("Income is successfully added!");
        }
        /// <summary>
        /// Adds an expense.
        /// </summary>
        /// <param name="expenseOperations">Expense operations.</param>
        public static void AddExpense(ExpenseRecordOperation expenseOperation)
        {
            Console.Clear();
            Console.Write("Enter the amount of the expense: ");

            decimal amount;
            string category;
            while (true)
            {
                string input = Console.ReadLine();
                if (!decimal.TryParse(input, out amount))
                {
                    ErrorMessage("Please enter valid amount.");
                    continue;
                }

                if (amount <= 0)
                {
                    ErrorMessage("Please enter positive amount.");
                    continue;
                }

                break;
            }

            Console.Write("Enter the category of the expense: ");

            while (true)
            {
                category = Console.ReadLine();
                if (string.IsNullOrEmpty(category))
                {
                    ErrorMessage("Category cannot be null.Please enter category name.");
                    continue;
                }

                break;
            }

            expenseOperation.AddExpense(new ExpenseRecord(amount, DateTime.Now, category));
            SuccessMessage("Expense is successfully added!");
        }

        /// <summary>
        /// Deletes an income, if present.
        /// </summary>
        /// <param name="incomeOperations">Income operations.</param>
        public static void DeleteIncome(IncomeRecordOperation incomeOperation)
        {
            if (incomeOperation.IncomeRecords.Count <= 0)
            {
                ErrorMessage("Income Record is empty.");
                return;
            }

            Console.Write("Enter income ID to be deleted: ");
            int id;
            while (true)
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out id))
                {
                    ErrorMessage("Please enter only positive integer");
                    continue;
                }

                break;
            }

            if (!incomeOperation.IsIncomePresent(id))
            {
                ErrorMessage("Income with given id is not present");
                return;
            }
            incomeOperation.DeleteIncome(id);
            SuccessMessage($"Income with Id {id} is deleted!");
        }

        /// <summary>
        /// Deletes an income, if present.
        /// </summary>
        /// <param name="incomeOperations">Income operations.</param>
        public static void DeleteExpense(ExpenseRecordOperation expenseOperation)
        {
            if(expenseOperation.ExpenseRecords.Count <= 0)
            {
                ErrorMessage("Expense Record is empty.");
                return;
            }

            Console.Write("Enter expense ID to be deleted: ");
            int id;
            while (true)
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out id))
                {
                    ErrorMessage("Please enter only positive integer");
                    continue;
                }

                break;
            }

            if (!expenseOperation.IsExpensePresent(id))
            {
                ErrorMessage("Expense with given id is not present");
                return;
            }
            expenseOperation.DeleteExpense(id);
            SuccessMessage($"Expense with Id {id} is deleted!");
        }

        /// <summary>
        /// Print all expenses.
        /// </summary>
        /// <param name="expenseOperation">Expense operation.</param>
        public static void PrintAllExpenses(ExpenseRecordOperation expenseOperation)
        {
            if (expenseOperation.ExpenseRecords.Count <= 0)
            {
                ErrorMessage("Expense Record is empty.");
                return;
            }

            ConsoleTable expenseTable = new ConsoleTable("ID", "Amount", "Date", "Category"); ;
            

            foreach (ExpenseRecord expense in expenseOperation.ExpenseRecords)
            {
                expenseTable.AddRow(expense.Id, expense.Amount, expense.Date, expense.Category);
            }

            SuccessMessage(expenseTable.ToString());
        }

        /// <summary>
        /// Print all expenses.
        /// </summary>
        /// <param name="expenseOperation">Expense operation.</param>
        public static void PrintAllIncomes(IncomeRecordOperation incomeOperation)
        {
            if (incomeOperation.IncomeRecords.Count <= 0)
            {
                ErrorMessage("Income Record is empty.");
                return;
            }

            ConsoleTable incomeTable = new ConsoleTable("ID", "Amount", "Date", "Source"); ;


            foreach (IncomeRecord income in incomeOperation.IncomeRecords)
            {
                incomeTable.AddRow(income.Id, income.Amount, income.Date, income.Source);
            }

            SuccessMessage(incomeTable.ToString());
        }

        /// <summary>
        /// Print Financial Summary report.
        /// </summary>
        /// <param name="expenseOperation">expenseOperation.</param>
        /// <param name="incomeOperation">incomeOperation.</param>
        public static void GenerateFinancialReport(ExpenseRecordOperation expenseOperation, IncomeRecordOperation incomeOperation)
        {
            Console.Clear();
            int days;
            while (true)
            {
                Console.WriteLine("How many days past the financial report do you need?");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out days))
                {
                    ErrorMessage("Please enter valid number of days.");
                    continue;
                }
                break;
            }
            
            FinancialSummary summaryReport = new FinancialSummary(expenseOperation, incomeOperation, days);
            
            SuccessMessage($"Total Income: {summaryReport.TotalIncome}\nTotal Expense: {summaryReport.TotalExpense}\nTotal Savings: {summaryReport.Savings}");
            if (summaryReport.Savings <= 0)
            {
                ErrorMessage($"You do not have any savings this month.You've spent {-summaryReport.Savings} rupees more than your income.");
            }
            else
            {
                ErrorMessage($"Your Savings: {summaryReport.Savings}");
            }
        }

        /// <summary>
        /// Exports data to the file.
        /// </summary>
        public static void Export(ExpenseRecordOperation expenseOperation, IncomeRecordOperation incomeOperation)
        {
            Console.WriteLine("1. Export Expense\n2. Export Income");
            Console.Write("Enter your choice: ");
            string choice;
            while (true)
            {
                choice = Console.ReadLine();

                if (choice != "1" && choice != "2")
                {
                    ErrorMessage("Please enter one of the given options: ");
                    continue;
                }

                break;
            }

            Console.Write("Enter the path to store the data: ");
            string path = Console.ReadLine();
            try
            {
                if (choice == "2")
                {
                    var incomes = incomeOperation.IncomeRecords;
                    if (incomes.Count() == 0)
                    {
                        ErrorMessage("There are no income entries to export.");
                        return;
                    }
                    JsonFileSerializer.SerializeIncome(incomeOperation.IncomeRecords.ToList(), path);
                }
                else
                {
                    var expenses = expenseOperation.ExpenseRecords;
                    if (expenses.Count() == 0)
                    {
                        ErrorMessage("There are no expense entries to export.");
                        return;
                    }
                    JsonFileSerializer.SerializeExpense(expenseOperation.ExpenseRecords.ToList(), path);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage($"{ex.Message}");
                return;
            }

           SuccessMessage($"The data has been successfully exported to: {Path.GetFullPath(path)}");
        }

        /// <summary>
        /// Imports data from the file.
        /// </summary>
        public static void Import(ExpenseRecordOperation expenseOperation, IncomeRecordOperation incomeOperation)
        {
            Console.WriteLine("1. Import Expense\n2. Import Income");
            Console.Write("Enter your choice: ");

            string choice;
            while (true)
            {
                choice = Console.ReadLine();
                if (choice != "1" && choice != "2")
                {
                    ErrorMessage("Please enter one of the given options:");
                    continue;
                }

                break;
            }

            Console.Write("Enter the path to import the data: ");
            string path;

            while (true)
            {
                path = Console.ReadLine();
                if (!File.Exists(path))
                {
                    ErrorMessage("The given file does not exists.\nPlease enter a valid file path: ");
                    continue;
                }

                break;
            }

            try
            {
                if (choice == "1")
                {
                    List<ExpenseRecord> expenses = JsonFileSerializer.DeserializeExpense(path);
                    foreach (ExpenseRecord expense in expenses)
                    {
                        expenseOperation.AddExpense(expense);
                    }
                }
                else
                {
                    List<IncomeRecord> incomes = JsonFileSerializer.DeserializeIncome(path);
                    foreach (IncomeRecord income in incomes)
                    {
                        incomeOperation.AddIncome(income);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage($"{ex.Message}");
                return;
            }

            SuccessMessage($"The data has been successfully imported to: {Path.GetFullPath(path)}");
        }
    
    /// <summary>
    /// Print Error message.
    /// </summary>
    /// <param name="message">Message.</param>
    public static void ErrorMessage(string message)
     {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{message}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

    /// <summary>
    /// Print Success message.
    /// </summary>
    /// <param name="message">Message.</param>
    public static void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{message}\n");
            Console.ForegroundColor= ConsoleColor.White;
        }
    }
}
