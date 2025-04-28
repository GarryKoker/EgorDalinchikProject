using InnoSport.Models;
using System.Windows;

namespace InnoSport.Views.ГлавныйАдминистратор
{
    public partial class ChiefAdminAddNewUser : Window
    {
        public User NewUser { get; private set; }

        public ChiefAdminAddNewUser()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на заполненность полей
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(SurnameTextBox.Text) ||
                string.IsNullOrWhiteSpace(LoginTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password) ||
                string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                RoleComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Создание нового пользователя
            var NewUser = new User
            {
                Name = NameTextBox.Text,
                Surname = SurnameTextBox.Text,
                Login = LoginTextBox.Text,
                Password = PasswordBox.Password,
                PhoneNumber = PhoneNumberTextBox.Text,
                Email = EmailTextBox.Text,
                Role = (Roles)RoleComboBox.SelectedIndex
            };

            // Закрытие окна с подтверждением
            DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрытие окна без сохранения
            DialogResult = false;
            this.Close();
        }
    }
}
