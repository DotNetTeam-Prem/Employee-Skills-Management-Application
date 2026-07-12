using System.ComponentModel.DataAnnotations;

namespace EmployeeSkills.Web.Validation;

public class PastDateAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is DateTime date)
            return date < DateTime.Today;

        return false;
    }
}