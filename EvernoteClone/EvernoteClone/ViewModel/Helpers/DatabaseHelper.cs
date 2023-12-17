using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel.Helpers
{
    public class DatabaseHelper
    {
        private static string dbFile = Path.Combine(Environment.CurrentDirectory, "notesDb.db3");

        /// <summary>
        /// Insert into table.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="item">Item.</param>
        /// <returns>true if and only if insertion is succesful.</returns>
        public static bool Insert<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection connection = new SQLiteConnection(dbFile))
            {
                connection.CreateTable<T>();
                int rows = connection.Insert(item);
                if(rows > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Update into table.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="item">Item.</param>
        /// <returns>true if and only if update is succesful.</returns>
        public static bool Update<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection connection = new SQLiteConnection(dbFile))
            {
                connection.CreateTable<T>();
                int rows = connection.Update(item);
                if (rows > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Delete from table.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="item">Item.</param>
        /// <returns>true if and only if deletion is succesful.</returns>
        public static bool Delete<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection connection = new SQLiteConnection(dbFile))
            {
                connection.CreateTable<T>();
                int rows = connection.Delete(item);
                if (rows > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Read from table.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <returns>Returns content of table.</returns>
        public static List<T> Read<T>() where T : new()
        {
            List<T> items;
            using (SQLiteConnection connection = new SQLiteConnection(dbFile))
            {
                connection.CreateTable<T>();
                items = connection.Table<T>().ToList();
            }
            return items;
        }
    }
}
