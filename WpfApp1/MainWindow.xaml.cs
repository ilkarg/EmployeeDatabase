using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

#pragma warning disable CS8622

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public DataBase db = new DataBase("workers.db");

        public MainWindow()
        {
            InitializeComponent();

            Application.Current.MainWindow.Closing += new CancelEventHandler(MainWindowClosing);

            Data.window = this;

            db.CreateAllTables(Data.createTableQuery, true);
            db.GetAllDataFromTable("Workers");

            AddAllWorkers();
        }

        private void MainWindowClosing(object sender, CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        public bool UpdateWorkerList(bool filtering) 
        {
            try 
            {
                MainStackPanel.Children.Clear();

                if (!filtering) 
                {
                    AddAllWorkers();
                }
                else 
                {
                    foreach(UserCard card in Data.filteredWorkerCardsList) 
                    {
                        MainStackPanel.Children.Add(card);
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

        private void ConfirmFilterButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxItem jobItem = (ComboBoxItem)JobComboBox.SelectedItem;
                ComboBoxItem subdivisionItem = (ComboBoxItem)SubdivisionComboBox.SelectedItem;

                if (Data.filter is null) 
                {
                    return;
                }

                if (Data.filter.Trim().Length > 0 || Data.filteredWorkerCardsList.Count > 0)
                {
                    Data.filter = "";
                    Data.filteredWorkerCardsList.Clear();
                }

                Data.filter = $"{jobItem.Content.ToString()}|{subdivisionItem.Content.ToString()}";

                if (Data.filter != "Нет фильтра|Нет фильтра")
                {
                    string[] filter = Data.filter.Split("|");

                    if (filter[0] != "Нет фильтра" && filter[1] == "Нет фильтра")
                    {
                        foreach (UserCard card in Data.userCardList)
                        {
                            if (card.JobLabel.Content.ToString() == $"Должность: {filter[0]}")
                            {
                                if (Data.filteredWorkerCardsList.IndexOf(card) == -1)
                                {
                                    Data.filteredWorkerCardsList.Add(card);
                                }
                            }
                        }
                    }
                    else if (filter[0] == "Нет фильтра" && filter[1] != "Нет фильтра")
                    {
                        foreach (UserCard card in Data.userCardList)
                        {
                            if (card.SubdivisionLabel.Content.ToString() == $"Подразделение: {filter[1]}")
                            {
                                if (Data.filteredWorkerCardsList.IndexOf(card) == -1)
                                {
                                    Data.filteredWorkerCardsList.Add(card);
                                }
                            }
                        }
                    }
                    else if (filter[0] != "Нет фильтра" && filter[1] != "Нет фильтра")
                    {
                        foreach (UserCard card in Data.userCardList)
                        {
                            if (card.JobLabel.Content.ToString() == $"Должность: {filter[0]}"
                                || card.SubdivisionLabel.Content.ToString() == $"Подразделение: {filter[1]}")
                            {
                                if (Data.filteredWorkerCardsList.IndexOf(card) == -1)
                                {
                                    Data.filteredWorkerCardsList.Add(card);
                                }
                            }
                        }
                    }

                    UpdateWorkerList(true);
                }
            }
            catch(Exception error) 
            {
                MessageBox.Show(error.Message, "Ошибка");
            }
        }

        private void ResetFilterButtonClick(object sender, RoutedEventArgs e)
        {
            Data.filter = "";
            Data.filteredWorkerCardsList = new List<UserCard>();
            UpdateWorkerList(false);
        }

        private void AddUserButtonClick(object sender, RoutedEventArgs e)
        {
            CreateUserWindow createUserWindow = new CreateUserWindow();
            createUserWindow.Show();
        }
    }
}
