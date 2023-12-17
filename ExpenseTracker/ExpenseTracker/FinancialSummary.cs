using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    /// <summary>
    /// Calculates Financial summary.
    /// </summary>
    internal class FinancialSummary
    {
        /// <summary>
        /// Repesent number of days.
        /// </summary>
        private int _days = 0;

        /// <summary>
        /// Total income.
        /// </summary>
        public decimal TotalIncome { get; set; }

        /// <summary>
        /// Total Expense.
        /// </summary>
        public decimal TotalExpense { get; set; }

        /// <summary>
        /// Savings.
        /// </summary>
        public decimal Savings { get; set; }

        public FinancialSummary(ExpenseRecordOperation expenseOperation,IncomeRecordOperation incomeOperation,int days) 
        { 
            _days = days;
            CalculateSavings(expenseOperation,incomeOperation);
        }
        
        /// <summary>
        /// Calculates savings amount.
        /// </summary>
        /// <param name="expenseOperation">expenseOperation.</param>
        /// <param name="incomeOperation">incomeOperation.</param>
        public void CalculateSavings(ExpenseRecordOperation expenseOperation, IncomeRecordOperation incomeOperation)
        {
            TotalIncome = incomeOperation.IncomeRecords.Where(income => (DateTime.Now - income.Date).TotalDays <= _days).Sum(income => income.Amount);
            TotalExpense = expenseOperation.ExpenseRecords.Where(expense => (DateTime.Now - expense.Date).TotalDays <= _days).Sum(income => income.Amount);
            Savings = TotalIncome - TotalExpense;
        }

    }
}
