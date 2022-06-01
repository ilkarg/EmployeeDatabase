using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class CreateUserWindow : Window
    {
        public CreateUserWindow()
        {
            InitializeComponent();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddUserButtonClick(object sender, RoutedEventArgs e)
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

            if (isNull(new string[] { fullname, birthday, gender, job, chiefFullName, subdivision }))
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

            Data.userCardList.Add(new UserCard());

            Data.userCardList[Data.userCardList.Count - 1].FullnameLabel.Content = fullname;
            Data.userCardList[Data.userCardList.Count - 1].BirthdayLabel.Content = $"Дата рождения: {birthday}";
            Data.userCardList[Data.userCardList.Count - 1].GenderLabel.Content = $"Пол: {gender}";
            Data.userCardList[Data.userCardList.Count - 1].JobLabel.Content = $"Должность: {job}";
            Data.userCardList[Data.userCardList.Count - 1].ChiefFullNameLabel.Content = $"Начальник: {chiefFullName}";
            Data.userCardList[Data.userCardList.Count - 1].SubdivisionLabel.Content = $"Подразделение: {subdivision}";

            if (Data.filter == "") 
            {
                Data.window.MainStackPanel.Children.Add(Data.userCardList[Data.userCardList.Count - 1]);
            }

            bool result = Data.window.db.AddUser(
                new Worker()
                {
                    Fullname = fullname,
                    Birthday = birthday,
                    Gender = gender,
                    Job = job,
                    ChiefFullName = chiefFullName,
                    Subdivision = subdivision
                }
            );

            if (result)
            {
                this.Close();
            }
        }

        private bool isNull(string[] elements)
        {
            foreach (string element in elements)
            {
                if (element.Trim().Length == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
