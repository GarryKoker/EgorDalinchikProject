using InnoSport.Models;
using InnoSport.Data;
using System.Windows;

namespace InnoSport
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Password != ConfirmPasswordTextBox.Password)
            {
                MessageBox.Show("Пароли не совпадают.");
                return;
            }

            using (AppDBContext db = new AppDBContext())
            {
                var newUser = new User
                {
                    Name = NameTextBox.Text,
                    Surname = SurnameTextBox.Text,
                    Login = LoginTextBox.Text,
                    PhoneNumber = PhoneNumberTextBox.Text,
                    Password = PasswordTextBox.Password,
                    Role = Roles.Пользователь
                };

                db.Users.Add(newUser);
                db.SaveChanges();
            }

            MessageBox.Show("Регистрация успешна!");
            new LoginWindow().Show();
            this.Close();
        }

        private void GoToLoginLink_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }
    }
}
