using System.Collections.Generic;

namespace EmployeeSurvey.Domain.Dtos
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int YearsOfExperience { get; set; }

        public string CurrentPosition { get; set; }

        public IEnumerable<EmployeeProgrammingLanguageDto> EmployeeProgrammingLanguages { get; set; }

        public SeniorityLevel SeniorityLevel { get; set; }

        public int Hash => this.GetHashCode();

        public override int GetHashCode()
        {
            unchecked
            {
                return FirstName.GetDeterministicHashCode() +
                   LastName.GetDeterministicHashCode() +
                   YearsOfExperience.GetHashCode() +
                   CurrentPosition.GetDeterministicHashCode() +
                   SeniorityLevel.GetHashCode();
            }
        }

        public override bool Equals(object obj)
        {
            var employee = obj as EmployeeDto;
            return FirstName == employee.FirstName &&
                   LastName == employee.LastName &&
                   YearsOfExperience == employee.YearsOfExperience &&
                   CurrentPosition == employee.CurrentPosition &&
                   SeniorityLevel == employee.SeniorityLevel;
        }
    }
}
