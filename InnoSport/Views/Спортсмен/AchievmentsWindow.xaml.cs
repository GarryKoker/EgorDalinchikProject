using System.Collections.ObjectModel;
using System.Windows;

namespace InnoSport.Views.Спортсмен
{
    public partial class AchievmentsWindow : Window
    {
        private ObservableCollection<Achievment> Achievments { get; set; }

        public AchievmentsWindow()
        {
            InitializeComponent();
            LoadAchievments();
        }

        private void LoadAchievments()
        {
            // Пример данных для достижений
            Achievments = new ObservableCollection<Achievment>
            {
                new Achievment { Name = "Золотая медаль", Type = "Медаль", Date = "01.05.2025", Description = "Победа в соревнованиях" },
                new Achievment { Name = "Кубок чемпиона", Type = "Кубок", Date = "15.05.2025", Description = "Первое место в турнире" }
            };
            AchievmentsDataGrid.ItemsSource = Achievments;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class Achievment
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}



