using System.Linq;
using System.Windows;
using InnoSport.Data;
using InnoSport.Models;

namespace InnoSport.Views.Администратор
{
    public partial class ViewMainInformation : Window
    {
        public ViewMainInformation()
        {
            InitializeComponent();
            LoadInformation();
        }

        private void LoadInformation()
        {
            using (var db = new AppDBContext())
            {
                // Загрузка данных из базы данных
                TotalUsersTextBlock.Text = db.Users.Count().ToString();
                TotalSectionsTextBlock.Text = db.Sections.Count().ToString();
                TotalAdminsTextBlock.Text = db.Users.Count(u => u.Role == Roles.Администратор).ToString();
                TotalAthletesTextBlock.Text = db.Users.Count(u => u.Role == Roles.Спортсмен).ToString();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрытие текущего окна
            this.Close();
        }
    }
}
