using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string path = "Contacts.db";
        static string database = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string databasePath = System.IO.Path.Combine(database, path);
    }
}
