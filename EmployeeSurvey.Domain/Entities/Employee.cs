using System.Collections.Generic;

namespace EmployeeSurvey.Domain.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int YearsOfExperience { get; set; }

        public string CurrentPosition { get; set; }

        public IEnumerable<EmployeeProgrammingLanguage> EmployeeProgrammingLanguages { get; set; }

        public SeniorityLevel SeniorityLevel { get; set; }

        public int Hash { get; set; }


    }
}
