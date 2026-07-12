using EmployeeSkills.Web.Models;

namespace EmployeeSkills.Web.IServices;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllAsync();

    Task<Employee?> GetByIdAsync(int id);

    Task AddAsync(EmployeeViewModel model);

    Task UpdateAsync(int id, EmployeeViewModel model);
    Task<EmployeeViewModel?> GetEmployeeForEditAsync(int id);

    Task DeleteAsync(int id);

    Task<List<Skill>> GetSkillsAsync();
}