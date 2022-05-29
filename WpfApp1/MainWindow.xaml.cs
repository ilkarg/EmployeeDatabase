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

            Data.window = this;

            db.CreateAllTables(Data.createTableQuery, true);
            db.GetAllDataFromTable("Workers");

            AddAllWorkers();
        }

        public bool UpdateWorkerList() 
        {
            try 
            {
                MainStackPanel.Children.Clear();
                AddAllWorkers();
            }
            catch(Exception error) 
            {
                MessageBox.Show(error.Message, "Ошибка");
                return false;
            }

            return true;
        }

        public bool AddAllWorkers() 
        {
            try 
            {
                if (Data.workerList.Count > 0)
                {
                    foreach (Worker worker in Data.workerList)
                    {
                        Data.userCardList.Add(new UserCard());

                        Data.userCardList[Data.userCardList.Count - 1].FullnameLabel.Content = worker.Fullname;
                        Data.userCardList[Data.userCardList.Count - 1].BirthdayLabel.Content = $"Дата рождения: {worker.Birthday}";
                        Data.userCardList[Data.userCardList.Count - 1].GenderLabel.Content = $"Пол: {worker.Gender}";
                        Data.userCardList[Data.userCardList.Count - 1].JobLabel.Content = $"Должность: {worker.Job}";
                        Data.userCardList[Data.userCardList.Count - 1].ChiefFullNameLabel.Content = $"Начальник: {worker.ChiefFullName}";
                        Data.userCardList[Data.userCardList.Count - 1].SubdivisionLabel.Content = $"Подразделение: {worker.Subdivision}";

                        MainStackPanel.Children.Add(Data.userCardList[Data.userCardList.Count - 1]);
                    }
                }
            }
            catch(Exception error) 
            {
                MessageBox.Show(error.Message, "Ошибка");
                return false;
            }

            return true;
        }
    }
}
