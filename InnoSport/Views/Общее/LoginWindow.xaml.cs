using InnoSport.Data;
using InnoSport.Models;
using InnoSport.Views.Администратор;
using InnoSport.Views.ГлавныйАдминистратор;
using InnoSport.Views.Пользователь;
using InnoSport.Views.Спортсмен;
using InnoSport.Views.Тренер;
using System.Windows;

namespace InnoSport
{
    public partial class LoginWindow : Window
    {

        public static User AuthorizedUser { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (AppDBContext db = new AppDBContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Login == LoginTextBox.Text && u.Password == PasswordTextBox.Password);
                    if (user != null)
                    {
                        switch (user.Role)
                        {
                            case Roles.Пользователь:
                                new UserMainWindow().Show();
                                break;
                            case Roles.Спортсмен:
                                new SportsmainMainWindow().Show();
                                break;
                            case Roles.Тренер:
                                new TrainerMainWindow().Show();
                                break;
                            case Roles.Администратор:
                                new AdministratorMainWindow().Show();
                                break;
                            case Roles.ГлавныйАдминистратор:
                                new ChiefAdministratorMainWindow().Show();
                                break;
                            default:
                                MessageBox.Show("Неизвестная роль.");
                                return;
                        }
                        AuthorizedUser = user;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void GoToRegistrationLink_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().Show();
            this.Close();
        }
    }
}
