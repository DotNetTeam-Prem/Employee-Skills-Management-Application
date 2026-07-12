using EmployeeSkills.Web.Validation;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSkills.Web.Models;

public class EmployeeViewModel
{
    [Required(ErrorMessage = "First Name is required.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last Name is required.")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Date of Birth is required.")]
    [DataType(DataType.Date)]
    [PastDate(ErrorMessage = "Date of Birth must be in the past.")]
    public DateTime? DateOfBirth { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(
        @"^\+?[1-9]\d{6,14}$",
        ErrorMessage = "Enter a valid international phone number.")]
    public string Phone { get; set; } = string.Empty;

    [MinLength(1, ErrorMessage = "Please select at least one skill.")]
    public List<int> SelectedSkills { get; set; } = new();
}