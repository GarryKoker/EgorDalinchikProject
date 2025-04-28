using InnoSport.Data;
using InnoSport.Models;
using InnoSport.Views.Администратор;
using System.Collections.ObjectModel;
using System.Windows;

namespace InnoSport.Views.ГлавныйАдминистратор
{
    public partial class ChiefAdministratorMainWindow : Window
    {
        private ObservableCollection<User> Users { get; set; }
        private ObservableCollection<Section> Sections { get; set; }

        public ChiefAdministratorMainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            using (var db = new AppDBContext())
            {
                Users = new ObservableCollection<User>(db.Users.ToList());
                Sections = new ObservableCollection<Section>(db.Sections.ToList());
            }

            UsersDataGrid.ItemsSource = Users;
            SectionsDataGrid.ItemsSource = Sections;
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие окна для добавления пользователя
            var addUserWindow = new ChiefAdminAddNewUser();
            if (addUserWindow.ShowDialog() == true) // Если пользователь нажал "Сохранить"
            {
                var newUser = addUserWindow.NewUser;

                // Сохранение нового пользователя в базе данных
                using (var db = new AppDBContext())
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }

                // Добавление нового пользователя в ObservableCollection для обновления интерфейса
                Users.Add(newUser);

                // Уведомление об успешном добавлении
                MessageBox.Show("Пользователь успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UsersDataGrid.SelectedItem as User;
            if (selectedUser != null)
            {
                using (var db = new AppDBContext())
                {
                    db.Users.Remove(selectedUser);
                    db.SaveChanges();
                }
                Users.Remove(selectedUser);
            }
            else
            {
                MessageBox.Show("Выберите пользователя для удаления.");
            }
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UsersDataGrid.SelectedItem as User;
            if (selectedUser != null)
            {
                var editUserWindow = new ChiefAdminEditingUser(selectedUser);
                if (editUserWindow.ShowDialog() == true) // Если пользователь нажал "Сохранить"
                {
                    // Сохранение изменений в базе данных
                    using (var db = new AppDBContext())
                    {
                        db.Users.Update(editUserWindow.EditedUser);
                        db.SaveChanges();
                    }

                    // Обновление интерфейса
                    LoadData();

                    // Уведомление об успешном редактировании
                    MessageBox.Show("Данные пользователя успешно обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для редактирования.");
            }
        }

        private void AddSectionButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие окна для добавления секции
            var addSectionWindow = new ChiefAdminAddSection();
            if (addSectionWindow.ShowDialog() == true) // Если пользователь нажал "Сохранить"
            {
                var newSection = addSectionWindow.NewSection;

                // Сохранение новой секции в базе данных
                using (var db = new AppDBContext())
                {
                    db.Sections.Add(newSection);
                    db.SaveChanges();
                }

                // Добавление новой секции в ObservableCollection для обновления интерфейса
                Sections.Add(newSection);

                // Уведомление об успешном добавлении
                MessageBox.Show("Секция успешно добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }



        private void DeleteSectionButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedSection = SectionsDataGrid.SelectedItem as Section;
            if (selectedSection != null)
            {
                using (var db = new AppDBContext())
                {
                    db.Sections.Remove(selectedSection);
                    db.SaveChanges();
                }
                Sections.Remove(selectedSection);
            }
            else
            {
                MessageBox.Show("Выберите секцию для удаления.");
            }
        }

        private void EditSectionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewReportsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Просмотр отчётов (реализуйте логику).");
        }

        private void SystemSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Настройки системы (реализуйте логику).");
        }
    }
}

