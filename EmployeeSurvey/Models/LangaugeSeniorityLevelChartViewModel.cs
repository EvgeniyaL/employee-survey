using Highsoft.Web.Mvc.Charts;
using System.Collections.Generic;

namespace EmployeeSurvey.Models
{
    public class LangaugeSeniorityLevelChartViewModel
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public IEnumerable<PieSeriesData> PieSeries { get; set; }
    }
}
