using Microsoft.Extensions.Localization;
using EmployeeSurvey.Controllers;
using EmployeeSurvey.Domain;
using EmployeeSurvey.Domain.Dtos;
using EmployeeSurvey.Models;
using System.Linq;

namespace EmployeeSurvey.Utility
{
    public static class Mapper
    {
        public static EmployeeDto Map(this HomeViewModel viewModel)
        {
            return new EmployeeDto
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                YearsOfExperience = viewModel.YearsOfExperience.Value,
                CurrentPosition = viewModel.CurrentPosition,
                EmployeeProgrammingLanguages = viewModel.ProgrammingLanguages.Select(x => new EmployeeProgrammingLanguageDto { ProgrammingLanguageId = x }),
                SeniorityLevel = viewModel.SeniorityLevel.Value
            };
        }

        public static SurveyResultChartsViewModel Map(this SurveyResultsDto pieDataResult, IStringLocalizer<SurveyResultsController> localizer)
        {
            return new SurveyResultChartsViewModel
            {
                JuniorData = new LangaugeSeniorityLevelChartViewModel
                {
                    Title = localizer[ResourceKeys.JuniorChartTitle],
                    PieSeries = pieDataResult.JuniorPieData,
                    Type = SeniorityLevel.Junior.ToString()
                },
                MidData = new LangaugeSeniorityLevelChartViewModel
                {
                    Title = localizer[ResourceKeys.MidChartTitle],
                    PieSeries = pieDataResult.MidPieData,
                    Type = SeniorityLevel.Mid.ToString()
                },
                SeniorData = new LangaugeSeniorityLevelChartViewModel
                {
                    Title = localizer[ResourceKeys.SeniorChartTitle],
                    PieSeries = pieDataResult.SeniorPieData,
                    Type = SeniorityLevel.Senior.ToString()
                }
            };
        }
    }
}
