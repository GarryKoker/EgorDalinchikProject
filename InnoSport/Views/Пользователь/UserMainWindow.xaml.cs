using InnoSport.Views.Общее;
using System.Windows;

namespace InnoSport.Views.Пользователь
{
    public partial class UserMainWindow : Window
    {
        public UserMainWindow()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {
            // Пример загрузки данных пользователя
            WelcomeTextBlock.Text = "Привет, Иван!";
        }

        private void GoToProfile_Click(object sender, RoutedEventArgs e)
        {
            new ProfileWindow().Show();
            this.Close();
        }

        private void ViewSections_Click(object sender, RoutedEventArgs e)
        {
            new AvailableSections().Show();
            this.Close();
        }
    }
}

