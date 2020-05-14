using EmployeeSurvey.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSurvey.Models
{
    public class HomeViewModel
    {
        [Required(ErrorMessage = ResourceKeys.Required)]
        [StringLength(50, MinimumLength = 3,ErrorMessage = ResourceKeys.LengthError)]
        [Display(Name = ResourceKeys.FirstName)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ResourceKeys.Required)]
        [StringLength(50,MinimumLength = 3, ErrorMessage = ResourceKeys.LengthError)]
        [Display(Name = ResourceKeys.LastName)]
        public string LastName { get; set; }

        [Required(ErrorMessage = ResourceKeys.Required)]
        [Display(Name = ResourceKeys.YearsOfExperience)]
        [Range(1, 40, ErrorMessage = ResourceKeys.YearsRangeError)]
        public int? YearsOfExperience { get; set; }

        [Required(ErrorMessage = ResourceKeys.Required)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = ResourceKeys.LengthError)]
        [Display(Name = ResourceKeys.CurrentPosition)]
        public string CurrentPosition { get; set; }

        [Required(ErrorMessage = ResourceKeys.Required)]
        [Display(Name = ResourceKeys.ProgrammingLanguages)]
        [MaxLength(5, ErrorMessage = ResourceKeys.MaxLengthError)]
        public IEnumerable<int> ProgrammingLanguages { get; set; }

        [Required(ErrorMessage = ResourceKeys.Required)]
        [Display(Name = ResourceKeys.SeniorityLevel)]
        public SeniorityLevel? SeniorityLevel { get; set; }
    }
}
