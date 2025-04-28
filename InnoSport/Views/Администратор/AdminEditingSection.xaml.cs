using InnoSport.Models;
using System.Windows;

namespace InnoSport.Views.Администратор
{
    public partial class AdminEditingSection : Window
    {
        public Section EditedSection { get; private set; }

        public AdminEditingSection(Section section)
        {
            InitializeComponent();
            LoadSectionData(section);
        }

        private void LoadSectionData(Section section)
        {
            // Заполнение полей данными секции
            EditedSection = section;
            NameTextBox.Text = section.Name;
            TypeTextBox.Text = section.Type;
            DescriptionTextBox.Text = section.Description;
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

            // Обновление данных секции
            EditedSection.Name = NameTextBox.Text;
            EditedSection.Type = TypeTextBox.Text;
            EditedSection.Description = DescriptionTextBox.Text;

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


