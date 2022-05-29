using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
                worker.Fullname == FullnameLabel.Content);

            Data.workerList.RemoveAll(worker_ => worker_ == worker);
            Data.userCardList.RemoveAll(card => card.FullnameLabel.Content == this.FullnameLabel.Content);

            Data.window.UpdateWorkerList();
            Data.window.db.DeleteWorker(worker);
        }
    }
}
