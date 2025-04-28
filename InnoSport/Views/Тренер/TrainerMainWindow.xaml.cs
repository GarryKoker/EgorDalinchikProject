using System.Collections.ObjectModel;
using System.Windows;

namespace InnoSport.Views.Тренер
{
    public partial class TrainerMainWindow : Window
    {
        private ObservableCollection<Training> Schedule { get; set; }
        private ObservableCollection<Athlete> Athletes { get; set; }

        public TrainerMainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            // Пример данных для расписания
            Schedule = new ObservableCollection<Training>
            {
                new Training { Date = "01.05.2025", Time = "10:00", Section = "Футбол", Description = "Тренировка по футболу" },
                new Training { Date = "02.05.2025", Time = "12:00", Section = "Плавание", Description = "Занятие в бассейне" }
            };
            ScheduleDataGrid.ItemsSource = Schedule;

            // Пример данных для спортсменов
            Athletes = new ObservableCollection<Athlete>
            {
                new Athlete { Name = "Иван", Surname = "Иванов", Section = "Футбол", Progress = "Хорошо" },
                new Athlete { Name = "Петр", Surname = "Петров", Section = "Плавание", Progress = "Отлично" }
            };
            AthletesDataGrid.ItemsSource = Athletes;
        }

        private void AddTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добавление тренировки (реализуйте логику).");
        }

        private void DeleteTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Удаление тренировки (реализуйте логику).");
        }

        private void ViewProgressButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Просмотр прогресса спортсмена (реализуйте логику).");
        }

        private void ProfileSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Настройки профиля (реализуйте логику).");
        }
    }

    public class Training
    {
        public required string Date { get; set; }
        public required string Time { get; set; }
        public required string Section { get; set; }
        public required string Description { get; set; }
    }

    public class Athlete
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Section { get; set; }
        public required string Progress { get; set; }
    }
}


