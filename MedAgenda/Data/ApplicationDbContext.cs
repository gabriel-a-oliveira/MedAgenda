using MedAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace MedAgenda.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Medico> Medicos { get; set; }  
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
    }
}
