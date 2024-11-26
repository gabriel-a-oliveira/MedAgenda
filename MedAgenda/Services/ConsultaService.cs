using MedAgenda.Data;
using MedAgenda.DTOs;
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

    public async Task<ConsultaResponseDto> CriarConsultaAsync(ConsultaRequestDto consultaRequestDTO)
    {
        var medicoExistente = await _context.Medicos.FindAsync(consultaRequestDTO.MedicoId);
        var pacienteExistente = await _context.Pacientes.FindAsync(consultaRequestDTO.PacienteId);

        if (medicoExistente == null || pacienteExistente == null)
        {
            throw new Exception("Médico ou paciente não encontrado.");
        }

        var consulta = new Consulta
        {
            MedicoId = consultaRequestDTO.MedicoId,
            PacienteId = consultaRequestDTO.PacienteId,
            DataHora = consultaRequestDTO.DataHora,
            Status = consultaRequestDTO.Status
        };

        _context.Consultas.Add(consulta);
        await _context.SaveChangesAsync();

        var consultaResponseDTO = new ConsultaResponseDto
        {
            Id = consulta.Id,
            MedicoId = consulta.MedicoId,
            MedicoNome = medicoExistente.Nome, 
            PacienteId = consulta.PacienteId,
            PacienteNome = pacienteExistente.Nome, 
            DataHora = consulta.DataHora,
            Status = consulta.Status
        };

        return consultaResponseDTO;
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
