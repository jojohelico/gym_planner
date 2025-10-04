using Microsoft.EntityFrameworkCore;
using MuscuApp.Models.Entities;

namespace MuscuApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Exercice> Exercices { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
