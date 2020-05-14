using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using EmployeeSurvey.Domain.Dtos;
using EmployeeSurvey.Handler.Contracts;
using EmployeeSurvey.Models;
using EmployeeSurvey.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSurvey.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetProgramingLanguagesHandler _programmingLanguageHandler;
        private readonly ICreateEmployeeProfileHandler _createEmployeeProfileHandler;
        private readonly IStringLocalizer<HomeController> _localizer;
        public HomeController(IGetProgramingLanguagesHandler programmingLanguageHandler,
                              ICreateEmployeeProfileHandler createEmployeeProfileHandler,
                              IStringLocalizer<HomeController> localizer)
        {
            _programmingLanguageHandler = programmingLanguageHandler;
            _createEmployeeProfileHandler = createEmployeeProfileHandler;
            _localizer = localizer;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var languages = await _programmingLanguageHandler.HandleRequest();
            AddViewBagData(languages);
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(HomeViewModel viewModel)
        {
            var languages = await _programmingLanguageHandler.HandleRequest();
            AddViewBagData(languages);

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var employeeDto = viewModel.Map();
            var result = await _createEmployeeProfileHandler.HandleRequest(employeeDto);

            if (!result.IsSuccess)
            {
                ViewData["Result"] = _localizer[result.ErrorMessage];
                return View(viewModel);
            }

            return RedirectToAction("Index", controllerName: "SurveyResults");
        }

        private void AddViewBagData(IEnumerable<ProgrammingLanguageDto> languages)
        {
            ViewBag.ProgrammingLanguages = new MultiSelectList(languages,
                                                          nameof(ProgrammingLanguageDto.ProgrammingLanguageId),
                                                          nameof(ProgrammingLanguageDto.Name));

            ViewBag.SeniorityLevels = new SelectList(EnumUtilities.GetSeniorityLevelTextAndValue(_localizer),
                                                     nameof(SelectListItem.Value),
                                                     nameof(SelectListItem.Text));
        }
    }
}
