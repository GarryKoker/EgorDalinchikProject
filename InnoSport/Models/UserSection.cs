using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnoSport.Models
{
    public class UserSection
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [ForeignKey("Section")]
        public int SectionId { get; set; }
        public Section Section { get; set; } = null!;
    }
}
