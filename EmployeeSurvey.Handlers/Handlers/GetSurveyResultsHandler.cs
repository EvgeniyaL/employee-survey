using Highsoft.Web.Mvc.Charts;
using EmployeeSurvey.Domain.Dtos;
using EmployeeSurvey.Handler.Contracts;
using EmployeeSurvey.RepositoryContracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeSurvey.Domain;

namespace EmployeeSurvey.Handlers
{
    public class GetSurveyResultsHandler : IGetSurveyResultsHandler
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetSurveyResultsHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<SurveyResultsDto> HandleRequest()
        {
            List<PieSeriesData> juniorPieData = await GetSeniorityLevelpieData(SeniorityLevel.Junior.ToString());
            List<PieSeriesData> midPieData = await GetSeniorityLevelpieData(SeniorityLevel.Mid.ToString());
            List<PieSeriesData> seniorPieData = await GetSeniorityLevelpieData(SeniorityLevel.Senior.ToString());

            return new SurveyResultsDto
            {
                JuniorPieData = juniorPieData,
                MidPieData = midPieData,
                SeniorPieData = seniorPieData
            };
        }

        private async Task<List<PieSeriesData>> GetSeniorityLevelpieData(string seniorityLevel)
        {
            var employeeResult = await _employeeRepository.GetEmployeesBySeniorityLevel(seniorityLevel);
            var languageRatio = GetLanguageRatio(employeeResult);
            List<PieSeriesData> pieData = GetPieSeriesData(languageRatio);
            return pieData;
        }

        private static List<PieSeriesData> GetPieSeriesData(Dictionary<string, List<EmployeeDto>> languageRatio)
        {
            List<PieSeriesData> pieData = new List<PieSeriesData>();

            foreach (var item in languageRatio)
            {
                var percentage = ((double)item.Value.Count / languageRatio.Count)*100;
                pieData.Add(new PieSeriesData { Name = item.Key, Y = percentage });
            }

            return pieData;
        }

        private Dictionary<string, List<EmployeeDto>> GetLanguageRatio(IEnumerable<EmployeeDto> employeeResult)
        {
            var languageRatio = new Dictionary<string, List<EmployeeDto>>();

            foreach (var employee in employeeResult)
            {
                foreach (var еmployeeProgrammingLanguage in employee.EmployeeProgrammingLanguages)
                {
                    if (!languageRatio.ContainsKey(еmployeeProgrammingLanguage.ProgrammingLanguage.Name))
                    {
                        languageRatio.Add(еmployeeProgrammingLanguage.ProgrammingLanguage.Name, new List<EmployeeDto>());
                    }

                    languageRatio[еmployeeProgrammingLanguage.ProgrammingLanguage.Name].Add(employee);
                }
            }

            return languageRatio;
        }
    }
}
