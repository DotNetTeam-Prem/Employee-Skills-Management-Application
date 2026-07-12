using EmployeeSkills.Web.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace EmployeeSkills.Tests.Validation;

public class EmployeeValidationTests
{
    [Fact]
    public void Phone_Should_Be_Invalid()
    {
        var model = new EmployeeViewModel
        {
            FirstName = "Prem",
            LastName = "Singh",
            DateOfBirth = DateTime.Today.AddYears(-20),
            Phone = "abc123",
            SelectedSkills = new List<int> { 1 }
        };

        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();

        var valid = Validator.TryValidateObject(
            model,
            context,
            results,
            validateAllProperties: true);

        Assert.False(valid);
    }

    [Fact]
    public void Phone_Should_Be_Valid()
    {
        var model = new EmployeeViewModel
        {
            FirstName = "Prem",
            LastName = "Singh",
            DateOfBirth = DateTime.Today.AddYears(-20),
            Phone = "+919876543210",
            SelectedSkills = new List<int> { 1 }   // Required
        };

        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();

        var valid = Validator.TryValidateObject(
            model,
            context,
            results,
            validateAllProperties: true);

        Assert.True(valid, string.Join(", ", results.Select(r => r.ErrorMessage)));
    }
}