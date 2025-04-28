using InnoSport.Views;
using InnoSport.Data;
using InnoSport.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace InnoSport.Views.Пользователь
{
    public partial class AvailableSections : Window
    {
        private ObservableCollection<Section> Sections { get; set; }

        public AvailableSections()
        {
            InitializeComponent();
            LoadSections();
        }

        private void LoadSections()
        {
            using (var db = new AppDBContext())
            {
                Sections = new ObservableCollection<Section>(db.Sections.ToList());
            }
            SectionsDataGrid.ItemsSource = Sections;
        }

        private void JoinSectionButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedSection = SectionsDataGrid.SelectedItem as Section;
            if (selectedSection != null)
            {
                MessageBox.Show($"Вы присоединились к секции: {selectedSection.Name}");
            }
            else
            {
                MessageBox.Show("Выберите секцию для присоединения.");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window Window = new UserMainWindow();
        }
    }
}
