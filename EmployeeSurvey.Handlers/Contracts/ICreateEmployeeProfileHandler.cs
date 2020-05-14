using EmployeeSurvey.Domain.Dtos;
using System.Threading.Tasks;

namespace EmployeeSurvey.Handler.Contracts
{
     public interface ICreateEmployeeProfileHandler
    {
        Task<Result> HandleRequest(EmployeeDto employeeDto);
    }
}
