using EmployeeSurvey.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSurvey.RepositoryContracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesByHash(int hash);

        Task<IEnumerable<EmployeeDto>> GetEmployeesBySeniorityLevel(string seniorityLevel);

        Task<EmployeeDto> GetEmployeeByID(int employeeId);

        Task InsertEmployee(EmployeeDto employee);
    }
}
