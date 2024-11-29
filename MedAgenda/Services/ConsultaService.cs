using AutoMapper;
using MedAgenda.Data;
using MedAgenda.DTOs;
using MedAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace MedAgenda.Services;

public class ConsultaService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ConsultaService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ConsultaResponseDto>> ObterTodasAsync()
    {
        var consultas = await _context.Consultas
               .Include(c => c.Medico) 
               .Include(c => c.Paciente) 
               .ToListAsync();

        return _mapper.Map<IEnumerable<ConsultaResponseDto>>(consultas);
    }

    public async Task<ConsultaResponseDto?> ObterPorIdAsync(int id)
    {
        var consulta = await _context.Consultas
            .Include(c => c.Medico)
            .Include(c => c.Paciente)
            .FirstOrDefaultAsync(c => c.Id == id);

        return consulta is null ? throw new KeyNotFoundException("Consulta não encontrada.") : _mapper.Map<ConsultaResponseDto>(consulta);
    }

    public async Task<ConsultaResponseDto> CriarConsultaAsync(ConsultaRequestDto consultaRequestDto)
    {
        var medicoExistente = await _context.Medicos.FindAsync(consultaRequestDto.MedicoId);
        var pacienteExistente = await _context.Pacientes.FindAsync(consultaRequestDto.PacienteId);

        if (medicoExistente is null || pacienteExistente is null)
        {
            throw new KeyNotFoundException("Médico ou paciente não encontrado.");
        }

        var consulta = _mapper.Map<Consulta>(consultaRequestDto);

        _context.Consultas.Add(consulta);
        await _context.SaveChangesAsync();

        var consultaResponseDto = _mapper.Map<ConsultaResponseDto>(consulta);
        return consultaResponseDto;
    }

    public async Task<ConsultaResponseDto> AtualizarConsultaAsync(int id, ConsultaRequestDto consultaRequestDto)
    {
        var consultaExistente = await _context.Consultas.FindAsync(id) ?? throw new KeyNotFoundException("Consulta não encontrada.");
        _mapper.Map(consultaRequestDto, consultaExistente);

        await _context.SaveChangesAsync();

        var consultaResponseDto = _mapper.Map<ConsultaResponseDto>(consultaExistente);
        return consultaResponseDto;

    }

    public async Task RemoverConsultaAsync(int id)
    {
        var consulta = await _context.Consultas.FindAsync(id) ?? throw new KeyNotFoundException("Consulta não encontradoa");
        _context.Consultas.Remove(consulta);
        await _context.SaveChangesAsync();
    }
}
