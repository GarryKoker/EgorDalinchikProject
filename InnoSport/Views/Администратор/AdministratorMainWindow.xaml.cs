using InnoSport.Data;
using InnoSport.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using InnoSport.Views;

namespace InnoSport.Views.Администратор
{
    public partial class AdministratorMainWindow : Window
    {
        private ObservableCollection<User> Users { get; set; }
        private ObservableCollection<Section> Sections { get; set; }

        public AdministratorMainWindow()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            using (var db = new AppDBContext())
            {
                Users = new ObservableCollection<User>(db.Users.ToList());
                Sections = new ObservableCollection<Section>(db.Sections.ToList());
            }

            UsersDataGrid.ItemsSource = Users;
            SectionsDataGrid.ItemsSource = Sections;
        }

        private void EditData_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, выбран ли пользователь
            var selectedUser = UsersDataGrid.SelectedItem as User;
            if (selectedUser != null)
            {
                var editUserWindow = new EditingInformationAdministrator(selectedUser);
                editUserWindow.ShowDialog();

                // Обновление данных после редактирования
                LoadData();
                return;
            }

            // Проверка, выбрана ли секция
            var selectedSection = SectionsDataGrid.SelectedItem as Section;
            if (selectedSection != null)
            {
                var editSectionWindow = new AdminEditingSection(selectedSection);
                if (editSectionWindow.ShowDialog() == true)
                {
                    // Сохранение изменений в базе данных
                    using (var db = new AppDBContext())
                    {
                        db.Sections.Update(editSectionWindow.EditedSection);
                        db.SaveChanges();
                    }

                    // Обновление данных после редактирования
                    LoadData();
                }
                return;
            }

            // Если ничего не выбрано
            MessageBox.Show("Выберите пользователя или секцию для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ViewMainInformationButton_Click(object sender, RoutedEventArgs e)
        {
            var mainInfoWindow = new ViewMainInformation();
            mainInfoWindow.ShowDialog();
        }
    }
}
