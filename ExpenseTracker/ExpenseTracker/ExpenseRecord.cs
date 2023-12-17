using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    /// <summary>
    /// Represents expense record.
    /// </summary>
    internal class ExpenseRecord
    {
        /// <summary>
        /// Unique Expense Id.
        /// </summary>
        private static int _id = 0;
        public ExpenseRecord(Decimal amount, DateTime date, string category) 
        {
            Id =_id++;
            Amount =amount;
            Date =date;
            Category = category;
        }

        public int Id { get; private set; }

        /// <summary>
        /// Expense amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Expense date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Expense category.
        /// </summary>
        public string Category { get; set; }
    }
}
