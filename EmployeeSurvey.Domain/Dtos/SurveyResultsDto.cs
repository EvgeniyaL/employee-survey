using Highsoft.Web.Mvc.Charts;
using System.Collections.Generic;

namespace EmployeeSurvey.Domain.Dtos
{
    public class SurveyResultsDto
    {
        public IEnumerable<PieSeriesData> SeniorPieData { get; set; }

        public IEnumerable<PieSeriesData> MidPieData { get; set; }

        public IEnumerable<PieSeriesData> JuniorPieData { get; set; }
    }
}
