using EmployeeSurvey.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSurvey.Handler.Contracts
{
    public interface IGetProgramingLanguagesHandler
    {
        Task<IEnumerable<ProgrammingLanguageDto>> HandleRequest();
    }
}
