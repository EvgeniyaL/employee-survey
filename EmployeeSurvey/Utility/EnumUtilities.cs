using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using EmployeeSurvey.Controllers;
using EmployeeSurvey.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeSurvey.Utility
{
    public static class EnumUtilities
    {
        public static IEnumerable<SelectListItem> GetSeniorityLevelTextAndValue(IStringLocalizer<HomeController> localizer)
        {
            return Enum.GetValues(typeof(SeniorityLevel))
                                                 .Cast<SeniorityLevel>()
                                                 .Select(x => new SelectListItem
                                                 {
                                                     Text = localizer[x.ToString()],
                                                     Value = ((int)x).ToString()
                                                 });
        }
    }
}
