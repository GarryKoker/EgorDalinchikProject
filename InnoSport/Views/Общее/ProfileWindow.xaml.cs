using System.Windows;

namespace InnoSport.Views.Общее
{
    public partial class ProfileWindow : Window
    {
        public ProfileWindow()
        {
            InitializeComponent();
            LoadProfileData();
        }

        private void LoadProfileData()
        {
            // Пример данных пользователя
            NameTextBlock.Text = "Иван";
            SurnameTextBlock.Text = "Иванов";
            OtchestvoTextBlock.Text = "Иванович";
            PhoneNumberTextBlock.Text = "+7 123 456 78 90";
            EmailTextBlock.Text = "ivanov@example.com";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}



