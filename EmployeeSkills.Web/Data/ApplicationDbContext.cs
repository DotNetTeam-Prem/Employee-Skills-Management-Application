using EmployeeSkills.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EmployeeSkills.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees => Set<Employee>();

        public DbSet<Skill> Skills => Set<Skill>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Skills
            modelBuilder.Entity<Skill>().HasData(

                new Skill { Id = 1, Name = "C#" },
                new Skill { Id = 2, Name = "ASP.NET" },
                new Skill { Id = 3, Name = "C++" },
                new Skill { Id = 4, Name = "Java" },
                new Skill { Id = 5, Name = "JavaScript" },
                new Skill { Id = 6, Name = "SQL" }

            );
        }
    }
}