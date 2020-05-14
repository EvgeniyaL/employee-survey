using EmployeeSurvey.Domain.Dtos;
using EmployeeSurvey.Handler.Contracts;
using EmployeeSurvey.RepositoryContracts;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSurvey.Handlers
{
    public class CreateEmployeeProfileHandler : ICreateEmployeeProfileHandler
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeProfileHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Result> HandleRequest(EmployeeDto employeeDto)
        {
            var employeeLookUp = await _employeeRepository.GetEmployeesByHash(employeeDto.Hash);

            if (employeeLookUp.Any(x => x.Equals(employeeDto)))
            {
                return new Result { IsSuccess = false, ErrorMessage = "The Employee already exists." };
            }

            await _employeeRepository.InsertEmployee(employeeDto);
            return new Result { IsSuccess = true };
        }
    }
}
