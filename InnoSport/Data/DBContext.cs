using InnoSport.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoSport.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<UserSection> UserSections { get; set; } // Добавлено

        public AppDBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=..//..//..//InnoSport.db");
        }
    }
}
