using System.ComponentModel.DataAnnotations;

namespace InnoSport.Models
{
    public class Section
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
