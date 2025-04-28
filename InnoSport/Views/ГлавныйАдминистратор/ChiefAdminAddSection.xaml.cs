using InnoSport.Models;
using System.Windows;

namespace InnoSport.Views.ГлавныйАдминистратор
{
    public partial class ChiefAdminAddSection : Window
    {
        public Section NewSection { get; private set; }

        public ChiefAdminAddSection()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на заполненность полей
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(TypeTextBox.Text) ||
                string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Создание новой секции
            NewSection = new Section
            {
                Name = NameTextBox.Text,
                Type = TypeTextBox.Text,
                Description = DescriptionTextBox.Text
            };

            // Закрытие окна с подтверждением
            DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрытие окна без сохранения
            DialogResult = false;
            this.Close();
        }
    }
}

