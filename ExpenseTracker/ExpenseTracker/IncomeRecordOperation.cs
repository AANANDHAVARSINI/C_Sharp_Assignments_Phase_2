using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
        /// <summary>
        /// Represents operations performed in IncomeRecord.
        /// </summary>
        internal class IncomeRecordOperation
        {
            /// <summary>
            /// Represents list of income.
            /// </summary>
            public List<IncomeRecord> IncomeRecords { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="IncomeRecordOperation"/> class no expenses.
            /// </summary>
            public IncomeRecordOperation()
            {
                IncomeRecords = new List<IncomeRecord>();
            }

            /// <summary>
            /// Add an income to ExpenseRecords.
            /// </summary>
            /// <param name="income">income.</param>
            public void AddIncome(IncomeRecord income)
            {
                IncomeRecords.Add(income);
            }

            /// <summary>
            /// Delete an income to ExpenseRecords.
            /// </summary>
            /// <param name="income">Income id.</param>
            /// <returns>Returns true if successfully deleted.</returns>
            public bool DeleteIncome(int id)
            {
                foreach (var income in IncomeRecords)
                {
                    if (income.Id == id)
                    {
                        IncomeRecords.Remove(income);
                        return true;
                    }
                }

                return false;
            }

        /// <summary>
        /// Search income in ExpenseRecords.
        /// </summary>
        /// <param name="id">Income Id.</param>
        /// <returns>Returns true if income with given id present.</returns>
        public bool IsIncomePresent(int id)
        {
            foreach (var income in IncomeRecords)
            {
                if (income.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
