using MedAgenda.Data;
using MedAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace MedAgenda.Services;

public class ConsultaService
{
    private readonly ApplicationDbContext _context;

    public ConsultaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Consulta>> ObterTodasAsync()
    {
        return await _context.Consultas
            .Include(c => c.Medico)
            .Include(c => c.Paciente)
            .ToListAsync();
    }

    public async Task<Consulta?> ObterPorIdAsync(int id)
    {
        return await _context.Consultas.Include(c => c.Medico).Include(c => c.Paciente).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task CriarConsultaAsync(Consulta consulta)
    {
        _context.Consultas.Add(consulta);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarConsultaAsync(Consulta consulta)
    {
        _context.Consultas.Update(consulta);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverConsultaAsync(int id)
    {
        var consulta = await _context.Consultas.FindAsync(id);
        if (consulta != null)
        {
            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
        }
    }
}
