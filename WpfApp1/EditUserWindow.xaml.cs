using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

#pragma warning disable CS8625
#pragma warning disable CS8602

namespace WpfApp1
{
    public partial class EditUserWindow : Window
    {
        public EditUserWindow()
        {
            InitializeComponent();

            if (Data.editableWorker is null || Data.window is null) 
            {
                this.Close();
            }

            FullnameTextBox.Text = Data.editableWorker.Fullname;
            BirthdayTextBox.Text = Data.editableWorker.Birthday;
            GenderComboBox.SelectedIndex = Data.editableWorker.Gender == "Женский" ? 1 : 0;
            JobTextBox.Text = Data.editableWorker.Job;
            ChiefFullnameTextBox.Text = Data.editableWorker.ChiefFullName;
            SubdivisionTextBox.Text = Data.editableWorker.Subdivision;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SubmitEditUserButtonClick(object sender, RoutedEventArgs e)
        {
            string? fullname = FullnameTextBox.Text.ToString();
            string? birthday = BirthdayTextBox.Text.ToString();
            string? gender = ((ComboBoxItem)GenderComboBox.SelectedItem).Content.ToString();
            string? job = JobTextBox.Text.ToString();
            string? chiefFullName = ChiefFullnameTextBox.Text.ToString();
            string? subdivision = SubdivisionTextBox.Text.ToString();
            Regex regex = new Regex(@"([0-9]{2}).([0-9]{2}).([0-9]{4})");

            if (gender is null || Data.window is null)
            {
                return;
            }

            if (Data.isNull(new string[] { fullname, birthday, gender, job, chiefFullName, subdivision }))
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка");
                return;
            }

            if (fullname.Split(' ').Length != 3)
            {
                MessageBox.Show("В ФИО введено некорректное значение", "Ошибка");
                return;
            }

            MatchCollection matches = regex.Matches(birthday);

            if (matches.Count == 0)
            {
                MessageBox.Show("Неверно указана дата рождения", "Ошибка");
                return;
            }

            int index = Data.workerList.FindIndex((worker) =>
                worker.Fullname.ToString() == Data.editableWorker.Fullname.ToString()
            );

            Data.editableWorker = null;

            Data.workerList[index].Fullname = fullname;
            Data.workerList[index].Birthday = birthday;
            Data.workerList[index].Gender = gender;
            Data.workerList[index].Job = job;
            Data.workerList[index].ChiefFullName = chiefFullName;
            Data.workerList[index].Subdivision = subdivision;

            Data.window.UpdateWorkerList(Data.filter != "");

            bool result = Data.window.db.UpdateWorkerData(Data.workerList[index]);

            if (result)
            {
                this.Close();
            }
        }
    }
}
