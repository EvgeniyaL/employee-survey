using EmployeeSurvey.Domain.Dtos;
using System.Threading.Tasks;

namespace EmployeeSurvey.Handler.Contracts
{
    public interface IGetSurveyResultsHandler
    {
        Task<SurveyResultsDto> HandleRequest();
    }
}
