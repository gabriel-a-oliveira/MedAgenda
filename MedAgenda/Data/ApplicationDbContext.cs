using MedAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace MedAgenda.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Medico)
                .WithMany()
                .HasForeignKey(c => c.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Paciente)
                .WithMany()
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
