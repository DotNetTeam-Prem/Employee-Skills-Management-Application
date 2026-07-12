using EmployeeSkills.Web.Models;

namespace EmployeeSkills.Tests.TestData;

public static class EmployeeTestData
{
    public static EmployeeViewModel GetEmployee()
    {
        return new EmployeeViewModel
        {
            FirstName = "Prem",
            LastName = "Singh",
            DateOfBirth = new DateTime(1998, 1, 1),
            Phone = "+919876543210"
        };
    }
}