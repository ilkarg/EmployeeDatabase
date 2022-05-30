using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

#pragma warning disable CS8600

namespace WpfApp1
{
    public partial class UserCard : UserControl
    {
        public UserCard()
        {
            InitializeComponent();
        }

        private void DeleteWorkerButtonClick(object sender, RoutedEventArgs e)
        {
            Worker worker = Data.workerList.FirstOrDefault(worker => 
                worker.Fullname == FullnameLabel.Content.ToString()
            );

            if (worker is null || Data.window is null) 
            {
                return;
            }

            Data.workerList.RemoveAll(worker_ => worker_ == worker);
            Data.userCardList.RemoveAll(card => card.FullnameLabel.Content == this.FullnameLabel.Content);

            Data.window.UpdateWorkerList();
            Data.window.db.DeleteWorker(worker);
        }

        private void UpgradeJobButtonClick(object sender, RoutedEventArgs e)
        {
            Worker worker = Data.workerList.FirstOrDefault(worker =>
                worker.Fullname == FullnameLabel.Content.ToString()
            );

            if (worker is null || Data.window is null) 
            {
                return;
            }

            int jobId = Array.IndexOf(Data.jobsList, worker.Job);

            if (worker.Job != Data.jobsList[0] && jobId != -1) 
            {
                worker.Job = Data.jobsList[jobId - 1];
                this.JobLabel.Content = $"Должность: {worker.Job}";
                Data.window.db.UpdateWorker(worker);
            }
            else if (worker.Job == Data.jobsList[0]) 
            {
                MessageBox.Show("Сотрудник уже имеет максимально возможную должность, повышение невозможно", "Ошибка");
            }
        }

        private void DowngradeJobButtonClick(object sender, RoutedEventArgs e)
        {
            Worker worker = Data.workerList.FirstOrDefault(worker =>
                worker.Fullname == FullnameLabel.Content.ToString()
            );

            if (worker is null || Data.window is null) 
            {
                return;
            }

            int jobId = Array.IndexOf(Data.jobsList, worker.Job);

            if (worker.Job != Data.jobsList[Data.jobsList.Count() - 1] && jobId != -1)
            {
                worker.Job = Data.jobsList[jobId + 1];
                this.JobLabel.Content = $"Должность: {worker.Job}";
                Data.window.db.UpdateWorker(worker);
            }
            else if (worker.Job == Data.jobsList[Data.jobsList.Count() - 1]) 
            {
                MessageBox.Show("Сотрудник уже имеет минимально возможную должность, понижение невозможно", "Ошибка");
            }
        }
    }
}
