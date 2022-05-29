using System;
using System.Windows;
using System.Windows.Controls;
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

            UserCard card = new UserCard();
            UserCard card2 = new UserCard();

            MainStackPanel.Children.Add(card);
            MainStackPanel.Children.Add(card2);
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
