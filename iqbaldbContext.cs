using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CampusApp.Models;

#nullable disable

namespace CampusApp
{
    public partial class iqbaldbContext : DbContext
    {
        public iqbaldbContext()
        {
        }

        public iqbaldbContext(DbContextOptions<iqbaldbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:ubaidb.database.windows.net,1433;Database=iqbaldb;User ID=ubai;Password=Admin123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<CampusApp.Models.Department> Department { get; set; }

        public DbSet<CampusApp.Models.Student> Student { get; set; }

        public DbSet<CampusApp.Models.Course> Course { get; set; }

        public DbSet<CampusApp.Models.Enrollment> Enrollment { get; set; }
    }
}
