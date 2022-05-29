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
            db.GetAllDataFromTable("Workers");

            if (Data.workerList.Count > 0)
            {
                foreach(Worker worker in Data.workerList) 
                {
                    Data.userCardList.Add(new UserCard());

                    Data.userCardList[Data.userCardList.Count - 1].UsernameLabel.Content = worker.Fullname;
                    Data.userCardList[Data.userCardList.Count - 1].BirthdayLabel.Content = $"Дата рождения: {worker.Birthday}";
                    Data.userCardList[Data.userCardList.Count - 1].GenderLabel.Content = $"Пол: {worker.Gender}";
                    Data.userCardList[Data.userCardList.Count - 1].JobLabel.Content = $"Должность: {worker.Job}";
                    Data.userCardList[Data.userCardList.Count - 1].ChiefFullNameLabel.Content = $"Начальник: {worker.ChiefFullName}";
                    Data.userCardList[Data.userCardList.Count - 1].SubdivisionLabel.Content = $"Подразделение: {worker.Subdivision}";

                    MainStackPanel.Children.Add(Data.userCardList[Data.userCardList.Count - 1]);
                }
            }
        }
    }
}
