using EmployeeSkills.Web.Models;

namespace EmployeeSkills.Web.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Skills.Any())
            {
                context.Skills.AddRange(

                    new Skill { Name = "C#" },
                    new Skill { Name = "ASP.NET" },
                    new Skill { Name = "C++" },
                    new Skill { Name = "Java" },
                    new Skill { Name = "JavaScript" },
                    new Skill { Name = "SQL" }

                );

                context.SaveChanges();
            }
        }
    }
}