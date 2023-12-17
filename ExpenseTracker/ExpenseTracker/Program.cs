namespace ExpenseTracker
{
    /// <summary>
    /// This is driver program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Userchoice
        /// </summary>
        enum Userchoice
        {
            AddIncome = 1, 
            AddExpense = 2,
            DeleteIncome = 3,
            DeleteExpense = 4,
            PrintRecords = 5,
            GetFinancialSummary = 6,
            ImportReport= 7,
            ExportReport= 8,
            Exit = 9,
        }
        /// <summary>
        /// This is driver program.
        /// </summary>
        public static void Main()
        {
            IncomeRecordOperation incomeRecordOperation = new IncomeRecordOperation();
            ExpenseRecordOperation expenseRecordOperation = new ExpenseRecordOperation();
            while (true)
            {
                Console.WriteLine("\nWelcome to Expense Tracker\n1.Add Income\n2.Add Expense\n3.DeleteIncome\n4.DeleteExpense\n5.PrintRecords\n6.GetFinancialSummary\n7.Import Report\n8.Export Report\n9.Exit");
                int validvalue = IsValidValue();
                switch ((Userchoice)validvalue)
                {
                    case Userchoice.AddIncome:
                        UserEntries.AddIncome(incomeRecordOperation);
                        break;
                    case Userchoice.AddExpense:
                        UserEntries.AddExpense(expenseRecordOperation);
                        break;
                    case Userchoice.DeleteIncome:
                        UserEntries.DeleteIncome(incomeRecordOperation);
                        break;
                    case Userchoice.DeleteExpense:
                        UserEntries.DeleteExpense(expenseRecordOperation);
                        break;
                    case Userchoice.PrintRecords:
                        UserEntries.PrintAllIncomes(incomeRecordOperation);
                        UserEntries.PrintAllExpenses(expenseRecordOperation);
                        break;
                    case Userchoice.GetFinancialSummary:
                        UserEntries.GenerateFinancialReport(expenseRecordOperation, incomeRecordOperation);
                        break;
                    case Userchoice.ImportReport:
                        UserEntries.Import(expenseRecordOperation, incomeRecordOperation);
                        break;
                    case Userchoice.ExportReport:
                        UserEntries.Export(expenseRecordOperation, incomeRecordOperation);
                        break;
                    case Userchoice.Exit:
                        Console.WriteLine("\nThank you..");
                        return;
                    default:
                        Console.WriteLine("Please enter any of the given values");
                        break;
                }
            }
        }

            /// <summary>
            /// Checks given input is valid positive integer.
            /// </summary>
            /// <returns>returns valid integer</returns>
            public static int IsValidValue()
            {
            int validValue;
            while (!int.TryParse(Console.ReadLine(), out validValue))
            {
                Console.WriteLine("Choose any valid positive integer!");
            }
            return validValue;
        }

    }
}