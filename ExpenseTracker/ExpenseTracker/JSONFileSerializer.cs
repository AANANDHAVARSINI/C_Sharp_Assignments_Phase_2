using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    /// <summary>
    /// Implements methods for a JSON Serializer.
    /// </summary>
    internal static class JsonFileSerializer
    {
        /// <summary>
        /// Serializes income data and stores in a file.
        /// </summary>
        /// <param name="incomes">Incomes.</param>
        public static void SerializeIncome(List<IncomeRecord> incomes, string filePath)
        {
            try
            {
                string incomeJson = JsonSerializer.Serialize(incomes);
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(incomeJson);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Deserializes income data from the file. 
        /// </summary>
        /// <param name="filePath">File path.</param>
        /// <returns>Income data.</returns>
        public static List<IncomeRecord> DeserializeIncome(string filePath)
        {
            try
            {
                string incomeJson;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    incomeJson = reader.ReadToEnd();
                }
                return JsonSerializer.Deserialize<List<IncomeRecord>>(incomeJson);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Serializes expense data and stores in a file.
        /// </summary>
        /// <param name="expenses">Expenses.</param>
        public static void SerializeExpense(List<ExpenseRecord> expenses, string filePath)
        {
            try
            {
                string expenseJson = JsonSerializer.Serialize(expenses);
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(expenseJson);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Deserializes expense data from the file. 
        /// </summary>
        /// <param name="filePath">File path.</param>
        /// <returns>Expense data.</returns>
        public static List<ExpenseRecord> DeserializeExpense(string filePath)
        {
            try
            {
                string expenseJson;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    expenseJson = reader.ReadToEnd();
                }
                return JsonSerializer.Deserialize<List<ExpenseRecord>>(expenseJson);
            }
            catch
            {
                throw;
            }
        }
    }
}
