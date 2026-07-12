using System.ComponentModel.DataAnnotations;

namespace EmployeeSkills.Web.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(
            @"^\+?[1-9]\d{0,2}[-.\s()]?(\d[-.\s()]?){6,14}$",
            ErrorMessage = "Enter a valid phone number.")]
        public string Phone { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    }
}