using AutoMapper;
using EmployeeSurvey.Domain.Dtos;
using EmployeeSurvey.Domain.Entities;
using EmployeeSurvey.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSurvey.Repositories
{
    public class ProgrammingLanguageRepository : IProgrammingLanguageRepository
    {
        private readonly RepositoriesContext _context;
        private readonly Mapper _mapper;

        public ProgrammingLanguageRepository(RepositoriesContext context)
        {
            _context = context;
            _mapper = new Mapper(new MapperConfiguration(x => x.CreateMap<ProgrammingLanguage, ProgrammingLanguageDto>().ReverseMap()));
        }

        public async Task<IEnumerable<ProgrammingLanguageDto>> GetProgrammingLanguages()
        {
            var results = await _context.ProgrammingLanguages.ToListAsync();
            return _mapper.Map<IEnumerable<ProgrammingLanguage>, IEnumerable<ProgrammingLanguageDto>>(results);
        }

        public async Task InsertProgrammingLanguage(ProgrammingLanguage language)
        {
           await _context.ProgrammingLanguages.AddAsync(language);
            await _context.SaveChangesAsync();
        }
    }
}
