using EmployeeSurvey.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSurvey.RepositoryContracts
{
    public interface IProgrammingLanguageRepository
    {
        Task<IEnumerable<ProgrammingLanguageDto>> GetProgrammingLanguages();
    }
}
