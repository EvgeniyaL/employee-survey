using EmployeeSurvey.Repositories;
using EmployeeSurvey.RepositoryContracts;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyExtentions
    {
        public static void AddReposiotories(this IServiceCollection services)
        {
            services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
