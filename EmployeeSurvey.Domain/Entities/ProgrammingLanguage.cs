using System.Collections.Generic;

namespace EmployeeSurvey.Domain.Entities
{
    public class ProgrammingLanguage
    {
        public int ProgrammingLanguageId { get; set; }

        public string Name { get; set; }

        public IEnumerable<EmployeeProgrammingLanguage> EmployeeProgrammingLanguages { get; set; }
    }
}
