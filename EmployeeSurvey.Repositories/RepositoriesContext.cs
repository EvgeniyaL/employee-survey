using Microsoft.EntityFrameworkCore;
using EmployeeSurvey.Domain.Entities;

namespace EmployeeSurvey.Repositories
{
    public class RepositoriesContext : DbContext
    {
        public RepositoriesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupEmployee(modelBuilder);
            SetupProgrammingLanguge(modelBuilder);
            SetupEmployeeProgrammingLanguage(modelBuilder);

            modelBuilder.Entity<ProgrammingLanguage>().HasData(
                new ProgrammingLanguage { ProgrammingLanguageId = 1, Name = "C#" },
                new ProgrammingLanguage { ProgrammingLanguageId = 2, Name = "C++" },
                new ProgrammingLanguage { ProgrammingLanguageId = 3, Name = "C" },
                new ProgrammingLanguage { ProgrammingLanguageId = 4, Name = "Java" },
                new ProgrammingLanguage { ProgrammingLanguageId = 5, Name = "Go" },
                new ProgrammingLanguage { ProgrammingLanguageId = 6, Name = "Java Script" },
                new ProgrammingLanguage { ProgrammingLanguageId = 7, Name = "Python" },
                new ProgrammingLanguage { ProgrammingLanguageId = 8, Name = "PHP" },
                new ProgrammingLanguage { ProgrammingLanguageId = 9, Name = "Scala" },
                new ProgrammingLanguage { ProgrammingLanguageId = 10, Name = "Ruby" },
                new ProgrammingLanguage { ProgrammingLanguageId = 11, Name = "Erlang" }
            );
        }

        private static void SetupEmployeeProgrammingLanguage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeProgrammingLanguage>()
                        .HasKey(t => new { t.EmployeeId, t.ProgrammingLanguageId });

            modelBuilder.Entity<EmployeeProgrammingLanguage>()
                .HasOne(pt => pt.Employee)
                .WithMany(p => p.EmployeeProgrammingLanguages)
                .HasForeignKey(pt => pt.EmployeeId);

            modelBuilder.Entity<EmployeeProgrammingLanguage>()
                .HasOne(pt => pt.ProgrammingLanguage)
                .WithMany(t => t.EmployeeProgrammingLanguages)
                .HasForeignKey(pt => pt.ProgrammingLanguageId);
        }

        private static void SetupProgrammingLanguge(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>()
                    .Property(s => s.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(50)
                    .IsRequired();
        }

        private static void SetupEmployee(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                    .Property(s => s.FirstName)
                    .HasColumnName("FirstName")
                    .HasMaxLength(50)
                    .IsRequired();
            modelBuilder.Entity<Employee>()
                    .Property(s => s.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(50)
                    .IsRequired();
            modelBuilder.Entity<Employee>()
                    .Property(s => s.YearsOfExperience)
                    .HasColumnName("YearsOfExperience")
                    .HasDefaultValue(0)
                    .IsRequired();
            modelBuilder.Entity<Employee>()
                    .Property(s => s.CurrentPosition)
                    .HasColumnName("CurrentPosition")
                    .HasMaxLength(50)
                    .IsRequired();
            modelBuilder.Entity<Employee>()
                    .HasIndex(s => s.SeniorityLevel);
            modelBuilder.Entity<Employee>()
                    .HasIndex(s => s.Hash);
        }
    }
}
