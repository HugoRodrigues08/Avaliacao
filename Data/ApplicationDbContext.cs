using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using escola.Models;

namespace escola.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<escola.Models.Professores> Professores { get; set; }
        public DbSet<escola.Models.Turmas> Turmas { get; set; }
        public DbSet<escola.Models.Alunos> Alunos { get; set; }
        public DbSet<escola.Models.ProfessoresCandidatos> ProfessoresCandidatos { get; set; }
        public DbSet<escola.Models.AlunosCandidatos> AlunosCandidatos { get; set; }
    }
}