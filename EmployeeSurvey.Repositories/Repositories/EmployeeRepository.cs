using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EmployeeSurvey.Domain.Dtos;
using EmployeeSurvey.Domain.Entities;
using EmployeeSurvey.RepositoryContracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSurvey.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RepositoriesContext _context;
        private readonly Mapper _mapper;

        public EmployeeRepository(RepositoriesContext context)
        {
            _context = context;
            _mapper = new Mapper(new MapperConfiguration(x => { x.CreateMap<Employee, EmployeeDto>().ReverseMap(); 
                                                                x.CreateMap<EmployeeProgrammingLanguage, EmployeeProgrammingLanguageDto>().ReverseMap();
                                                                x.CreateMap<ProgrammingLanguage, ProgrammingLanguageDto>().ReverseMap();}));
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesBySeniorityLevel(string seniorityLevel)
        {
            var results =  _context.Employees.Include(e => e.EmployeeProgrammingLanguages)
                                            .ThenInclude(p => p.ProgrammingLanguage).AsEnumerable()
                                            .Where(x => x.SeniorityLevel.ToString() == seniorityLevel);

            return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(results);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByHash(int hash)
        {
            var results = await _context.Employees.Where(x => x.Hash == hash).ToListAsync();
            return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(results);
        }

        public async Task<EmployeeDto> GetEmployeeByID(int employeeId)
        {
            var result = await _context.Employees.FindAsync(employeeId);
            return _mapper.Map<Employee, EmployeeDto>(result);
        }

        public async Task InsertEmployee(EmployeeDto employee)
        {
            var employeeEntity = _mapper.Map<EmployeeDto, Employee>(employee);
            await _context.Employees.AddAsync(employeeEntity);
            await _context.SaveChangesAsync();
        }
    }
}
