using EmployeeSkills.Web.Data;
using EmployeeSkills.Web.IServices;
using EmployeeSkills.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSkills.Web.Services;

public class EmployeeService : IEmployeeService
{
    private readonly ApplicationDbContext _context;

    public EmployeeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _context.Employees
            .Include(e => e.Skills)
            .ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _context.Employees
            .Include(e => e.Skills)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Skill>> GetSkillsAsync()
    {
        return await _context.Skills.ToListAsync();
    }

    public async Task AddAsync(EmployeeViewModel model)
    {
        var skills = await _context.Skills
            .Where(s => model.SelectedSkills.Contains(s.Id))
            .ToListAsync();

        Employee employee = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            DateOfBirth = (DateTime)model.DateOfBirth,
            Phone = model.Phone,
            Skills = skills
        };

        _context.Employees.Add(employee);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, EmployeeViewModel model)
    {
        var employee = await _context.Employees
            .Include(e => e.Skills)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (employee == null)
            return;

        employee.FirstName = model.FirstName;
        employee.LastName = model.LastName;
        employee.DateOfBirth = (DateTime)model.DateOfBirth;
        employee.Phone = model.Phone;

        employee.Skills.Clear();

        var skills = await _context.Skills
            .Where(s => model.SelectedSkills.Contains(s.Id))
            .ToListAsync();

        foreach (var skill in skills)
        {
            employee.Skills.Add(skill);
        }

        await _context.SaveChangesAsync();
    }
    public async Task<EmployeeViewModel?> GetEmployeeForEditAsync(int id)
    {
        var employee = await _context.Employees
            .Include(e => e.Skills)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (employee == null)
            return null;

        return new EmployeeViewModel
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            DateOfBirth = employee.DateOfBirth,
            Phone = employee.Phone,
            SelectedSkills = employee.Skills
                .Select(s => s.Id)
                .ToList()
        };
    }
    public async Task DeleteAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee != null)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}