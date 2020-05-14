using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeSurvey.Domain.Dtos
{
    public class EmployeeProgrammingLanguageDto
    {
        public int EmployeeId { get; set; }

        public EmployeeDto Employee { get; set; }

        public int ProgrammingLanguageId { get; set; }

        public ProgrammingLanguageDto ProgrammingLanguage { get; set; }
    }
}
