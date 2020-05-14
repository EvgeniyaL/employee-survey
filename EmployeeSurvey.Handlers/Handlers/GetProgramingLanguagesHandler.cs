using EmployeeSurvey.Domain.Dtos;
using EmployeeSurvey.Handler.Contracts;
using EmployeeSurvey.RepositoryContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSurvey.Handlers
{
    public class GetProgramingLanguagesHandler: IGetProgramingLanguagesHandler
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public GetProgramingLanguagesHandler(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task<IEnumerable<ProgrammingLanguageDto>> HandleRequest()
        {
            return await _programmingLanguageRepository.GetProgrammingLanguages();
        }
    }
}
