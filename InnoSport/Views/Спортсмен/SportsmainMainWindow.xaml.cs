using InnoSport.Views.Общее;
using System.Windows;

namespace InnoSport.Views.Спортсмен
{
    public partial class SportsmainMainWindow : Window
    {
        public SportsmainMainWindow()
        {
            InitializeComponent();
        }

        private void GoToProfile_Click(object sender, RoutedEventArgs e)
        {
            new ProfileWindow().Show();
            this.Close();
        }

        private void GoToAchievments_Click(object sender, RoutedEventArgs e)
        {
            new AchievmentsWindow().Show();
            this.Close();
        }

        private void GoToSportsmainMainWindow_Click(object sender, RoutedEventArgs e)
        {
            new SportsmainMainWindow().Show();
            this.Close();
        }
    }
}

