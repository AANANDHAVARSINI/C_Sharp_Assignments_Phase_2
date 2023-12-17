using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    /// <summary>
    /// Represents income record.
    /// </summary>
    internal class IncomeRecord
    {
        /// <summary>
        /// Unique Income Id.
        /// </summary>
        private static int _id = 0;
        public IncomeRecord(Decimal amount, DateTime date, string source)
        {
            Id = _id++;
            Amount = amount;
            Date = date;
            Source = source;
        }

        public int Id { get; private set; }
        /// <summary>
        /// Income amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Income date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Income source.
        /// </summary>
        public string Source { get; set; }
    }
}
