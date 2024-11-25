using MedAgenda.Data;
using MedAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace MedAgenda.Services
{
    public class MedicoService
    {
        private readonly ApplicationDbContext _context;

        public MedicoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medico>> ObterTodasAsync()
        {
            return await _context.Medicos.ToListAsync();
        }

        public async Task<Medico?> ObterPorIdAsync(int id)
        {
            return await _context.Medicos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Medico> CriarMedicoAsync(Medico medico)
        {
            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task AtualizarMedicoAsync(Medico medico)
        {
            _context.Medicos.Update(medico);
            //var medicoExistente = await _context.Medicos.FindAsync(medico.Id);

            //if (medicoExistente != null)
            //{
                //medicoExistente.Nome = medico.Nome;
                //medicoExistente.Especialidade = medico.Especialidade;
                //medicoExistente.CRM = medico.CRM;
                //medicoExistente.Telefone = medico.Telefone;

                await _context.SaveChangesAsync();
            //}
        }

        public async Task DeleteMedicoAsync(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            if (medico != null)
            {
                _context.Medicos.Remove(medico);
                await _context.SaveChangesAsync();
            }
        }
    }
}
