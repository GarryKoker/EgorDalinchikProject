using InnoSport.Models;
using System.Windows;

namespace InnoSport.Views.ГлавныйАдминистратор
{
    public partial class ChiefAdminEditingUser : Window
    {
        public User EditedUser { get; private set; }

        public ChiefAdminEditingUser(User user)
        {
            InitializeComponent();
            LoadUserData(user);
        }

        private void LoadUserData(User user)
        {
            // Заполнение полей данными пользователя
            EditedUser = user;
            NameTextBox.Text = user.Name;
            SurnameTextBox.Text = user.Surname;
            LoginTextBox.Text = user.Login;
            PasswordBox.Password = user.Password;
            PhoneNumberTextBox.Text = user.PhoneNumber;
            EmailTextBox.Text = user.Email;
            RoleComboBox.SelectedIndex = (int)user.Role;
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

            // Обновление данных пользователя
            EditedUser.Name = NameTextBox.Text;
            EditedUser.Surname = SurnameTextBox.Text;
            EditedUser.Login = LoginTextBox.Text;
            EditedUser.Password = PasswordBox.Password;
            EditedUser.PhoneNumber = PhoneNumberTextBox.Text;
            EditedUser.Email = EmailTextBox.Text;
            EditedUser.Role = (Roles)RoleComboBox.SelectedIndex;

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

