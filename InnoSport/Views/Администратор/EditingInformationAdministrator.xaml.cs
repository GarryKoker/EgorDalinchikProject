using InnoSport.Data;
using InnoSport.Models;
using System.Windows;

namespace InnoSport.Views.Администратор
{
    public partial class EditingInformationAdministrator : Window
    {
        private User CurrentUser { get; set; }

        public EditingInformationAdministrator(User user)
        {
            InitializeComponent();
            CurrentUser = user;
            LoadUserData();
        }

        private void LoadUserData()
        {
            NameTextBox.Text = CurrentUser.Name;
            SurnameTextBox.Text = CurrentUser.Surname;
            RoleComboBox.SelectedItem = CurrentUser.Role.ToString();
            PhoneNumberTextBox.Text = CurrentUser.PhoneNumber;
            EmailTextBox.Text = CurrentUser.Email;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.Name = NameTextBox.Text;
            CurrentUser.Surname = SurnameTextBox.Text;
            CurrentUser.Role = (Roles)RoleComboBox.SelectedIndex;
            CurrentUser.PhoneNumber = PhoneNumberTextBox.Text;
            CurrentUser.Email = EmailTextBox.Text;

            using (var db = new AppDBContext())
            {
                db.Users.Update(CurrentUser);
                db.SaveChanges();
            }

            MessageBox.Show("Данные успешно сохранены!");
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

