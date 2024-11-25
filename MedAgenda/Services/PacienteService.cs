using MedAgenda.Data;
using MedAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace MedAgenda.Services
{
    public class PacienteService
    {
        private readonly ApplicationDbContext _context;

        public PacienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> ObterTodasAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente?> ObterPorIdAsync(int id)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CriarPacienteAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarPacienteAsync(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverPaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                _context.Remove(paciente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
