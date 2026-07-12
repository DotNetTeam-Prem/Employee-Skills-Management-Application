using System.ComponentModel.DataAnnotations;

namespace EmployeeSkills.Web.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}