using AutoMapper;
using MedAgenda.Data;
using MedAgenda.DTOs;
using MedAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace MedAgenda.Services;

public class PacienteService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;


    public PacienteService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PacienteResponseDto>> ObterTodasAsync()
    {
        var pacientes = await _context.Pacientes.ToListAsync();
        return _mapper.Map<IEnumerable<PacienteResponseDto>>(pacientes);
    }

    public async Task<PacienteResponseDto?> ObterPorIdAsync(int id)
    {
        var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.Id == id);

        if (paciente is null)
        {
            throw new KeyNotFoundException("Paciente não encontrado.");
        }

        return _mapper.Map<PacienteResponseDto>(paciente);
    }

    public async Task<PacienteResponseDto> CriarPacienteAsync(PacienteRequestDto pacienteRequest)
    {
        var paciente = _mapper.Map<Paciente>(pacienteRequest); 

        _context.Pacientes.Add(paciente);
        await _context.SaveChangesAsync();

        var pacienteResponseDto = _mapper.Map<PacienteResponseDto>(paciente);
        return pacienteResponseDto;
    }

    public async Task<PacienteResponseDto> AtualizarPacienteAsync(int id, PacienteRequestDto pacienteRequestDto)
    {
        var pacienteExistente = await _context.Pacientes.FindAsync(id);

        if (pacienteExistente is null)
        {
            throw new KeyNotFoundException("Paciente não encontrado.");
        }

        _mapper.Map(pacienteRequestDto, pacienteExistente);
        await _context.SaveChangesAsync();

        var pacienteResponseDto = _mapper.Map<PacienteResponseDto>(pacienteExistente);

        return pacienteResponseDto;
    }

    public async Task<PacienteResponseDto> RemoverPacienteAsync(int id)
    {
        var paciente = await _context.Pacientes.FindAsync(id);
        
        if (paciente is null)
        {
            throw new KeyNotFoundException("Médico não encontrado.");
        }

        _context.Remove(paciente);
        await _context.SaveChangesAsync();

        var pacienteResponseDto = _mapper.Map<PacienteResponseDto>(paciente);
        return pacienteResponseDto;
    }
}
