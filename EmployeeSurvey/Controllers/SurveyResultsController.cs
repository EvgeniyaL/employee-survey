using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using EmployeeSurvey.Handler.Contracts;
using EmployeeSurvey.Utility;
using System.Threading.Tasks;

namespace EmployeeSurvey.Controllers
{
    public class SurveyResultsController : Controller
    {
        private readonly IGetSurveyResultsHandler _getSurveyResultsHandler;
        private readonly IStringLocalizer<SurveyResultsController> _localizer;

        public SurveyResultsController(IGetSurveyResultsHandler getSurveyResultsHandler,
            IStringLocalizer<SurveyResultsController> localizer)
        {
            _getSurveyResultsHandler = getSurveyResultsHandler;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index()
        {
            var pieDataResult = await _getSurveyResultsHandler.HandleRequest();
            var viewModel = pieDataResult.Map(_localizer);
            return View(viewModel);
        }
    }
}
