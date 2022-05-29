using System;
using System.Windows;
using Microsoft.Data.Sqlite;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public DataBase db = new DataBase("workers.db");

        public MainWindow()
        {
            InitializeComponent();

            db.CreateAllTables(Data.createTableQuery, true);
        }

        public void GetWorkersClick(object sender, RoutedEventArgs e)
        {
            db.OutputAllDataFromTable("Workers");
        }

        public void GetJobsClick(object sender, RoutedEventArgs e)
        {
            db.OutputAllDataFromTable("Jobs");
        }
    }
}
