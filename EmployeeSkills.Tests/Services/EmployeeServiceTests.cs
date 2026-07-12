using EmployeeSkills.Web.Data;
using EmployeeSkills.Web.Models;
using EmployeeSkills.Web.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EmployeeSkills.Tests.Services;

public class EmployeeServiceTests
{
    private ApplicationDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options);
    }

    [Fact]
    public async Task AddEmployee_Should_Insert_Record()
    {
        var context = GetDbContext();

        context.Skills.Add(new Skill { Id = 1, Name = "C#" });
        await context.SaveChangesAsync();

        var service = new EmployeeService(context);

        var employee = new EmployeeViewModel
        {
            FirstName = "Prem",
            LastName = "Singh",
            DateOfBirth = new DateTime(1998, 1, 1),
            Phone = "+919876543210",
            SelectedSkills = new List<int> { 1 }
        };

        await service.AddAsync(employee);

        Assert.Single(context.Employees);
    }

    [Fact]
    public async Task GetAll_Should_Return_All_Employees()
    {
        var context = GetDbContext();

        context.Employees.Add(new Employee
        {
            FirstName = "Prem",
            LastName = "Singh",
            DateOfBirth = new DateTime(1998, 1, 1),
            Phone = "+919876543210"
        });

        context.Employees.Add(new Employee
        {
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1995, 1, 1),
            Phone = "+12345678901"
        });

        await context.SaveChangesAsync();

        var service = new EmployeeService(context);

        var result = await service.GetAllAsync();

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task UpdateEmployee_Should_Update_Record()
    {
        var context = GetDbContext();

        var skill = new Skill { Id = 1, Name = "C#" };
        context.Skills.Add(skill);

        var employee = new Employee
        {
            FirstName = "Prem",
            LastName = "Singh",
            DateOfBirth = new DateTime(1998, 1, 1),
            Phone = "+919876543210"
        };

        context.Employees.Add(employee);
        await context.SaveChangesAsync();

        var service = new EmployeeService(context);

        var model = new EmployeeViewModel
        {
            FirstName = "Rahul",
            LastName = "Sharma",
            DateOfBirth = new DateTime(1997, 2, 2),
            Phone = "+919999999999",
            SelectedSkills = new List<int> { 1 }
        };

        await service.UpdateAsync(employee.Id, model);

        var updated = await context.Employees.FindAsync(employee.Id);

        Assert.Equal("Rahul", updated!.FirstName);
        Assert.Equal("Sharma", updated.LastName);
    }

    [Fact]
    public async Task DeleteEmployee_Should_Remove_Record()
    {
        var context = GetDbContext();

        var employee = new Employee
        {
            FirstName = "Prem",
            LastName = "Singh",
            DateOfBirth = new DateTime(1998, 1, 1),
            Phone = "+919876543210"
        };

        context.Employees.Add(employee);
        await context.SaveChangesAsync();

        var service = new EmployeeService(context);

        await service.DeleteAsync(employee.Id);

        Assert.Empty(context.Employees);
    }

    [Fact]
    public async Task GetEmployeeForEdit_Should_Return_Employee()
    {
        var context = GetDbContext();

        var skill = new Skill { Id = 1, Name = "C#" };
        context.Skills.Add(skill);

        var employee = new Employee
        {
            FirstName = "Prem",
            LastName = "Singh",
            DateOfBirth = new DateTime(1998, 1, 1),
            Phone = "+919876543210"
        };

        employee.Skills.Add(skill);

        context.Employees.Add(employee);

        await context.SaveChangesAsync();

        var service = new EmployeeService(context);

        var result = await service.GetEmployeeForEditAsync(employee.Id);

        Assert.NotNull(result);
        Assert.Equal("Prem", result.FirstName);
        Assert.Equal("Singh", result.LastName);
    }
}