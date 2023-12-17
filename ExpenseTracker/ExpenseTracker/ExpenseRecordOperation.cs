using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    /// <summary>
    /// Represents operations performed in ExpenseRecord.
    /// </summary>
    internal class ExpenseRecordOperation
    {
        /// <summary>
        /// Represents list of expenses.
        /// </summary>
        public List<ExpenseRecord> ExpenseRecords { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseRecordOperation"/> class no expenses.
        /// </summary>
        public ExpenseRecordOperation()
        {
            ExpenseRecords = new List<ExpenseRecord>();
        }

        /// <summary>
        /// Add an expense to ExpenseRecords.
        /// </summary>
        /// <param name="expense">expense.</param>
        public void AddExpense(ExpenseRecord expense)
        {
            ExpenseRecords.Add(expense);
        }

        /// <summary>
        /// Delete an expense to ExpenseRecords.
        /// </summary>
        /// <param name="expense">Expense id.</param>
        /// <returns>Returns true if successfully deleted.</returns>
        public bool DeleteExpense(int id)
        {
            foreach (var expense in ExpenseRecords)
            {
                if (expense.Id == id)
                {
                    ExpenseRecords.Remove(expense);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Search expense in ExpenseRecords.
        /// </summary>
        /// <param name="id">Expense Id.</param>
        /// <returns>Returns true if expense with given id present..</returns>
        public bool IsExpensePresent(int id)
        {
            foreach(var expense in ExpenseRecords)
            {
                if (expense.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
