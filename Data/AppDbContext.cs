using Microsoft.EntityFrameworkCore;
using MuscuApp.Models.Entities;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MuscuApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Exercice> Exercices { get; set; }
        public DbSet<Category> Categories { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) // writes relations between classes
        //{
        //    modelBuilder.Entity<Company>(e =>
        //    {
        //        e.ToTable("companies");
        //        e.HasKey(e => e.Id);
        //        e.Property(e => e.Name).HasColumnType("varchar(255)");
        //        e.Property(e => e.Treasury).HasColumnType("integer").HasDefaultValue(1000000); // Default value
        //        e.HasOne(e => e.Player)
        //            .WithOne(e => e.Company)
        //            .HasForeignKey<Company>(e => e.PlayerId) // relation 1 1
        //            .IsRequired()
        //            .OnDelete(DeleteBehavior.Cascade); // if delete player, company gets deleted
        //        e.HasMany(e => e.Employees)
        //            .WithOne(e => e.Company)
        //            .HasForeignKey(e => e.CompanyId);
        //        e.HasMany(e => e.Projects)
        //            .WithOne(e => e.Company)
        //            .HasForeignKey(e => e.CompanyId);
        //    });

        //    modelBuilder.Entity<Consultant>(e =>
        //    {
        //        e.ToTable("consultants");
        //        e.HasKey(e => e.Id);
        //        e.Property(e => e.Name).HasColumnType("varchar(255)");
        //        e.HasOne(e => e.Game)
        //            .WithMany()
        //            .HasForeignKey(e => e.GameId)
        //            .OnDelete(DeleteBehavior.Cascade);
        //        e.OwnsMany(e => e.Skills, builder => builder.ToJson());
        //    });
        //}
    }
    }
