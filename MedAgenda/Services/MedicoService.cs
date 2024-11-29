using AutoMapper;
using MedAgenda.Data;
using MedAgenda.DTOs;
using MedAgenda.Models;
using Microsoft.EntityFrameworkCore;

namespace MedAgenda.Services;

public class MedicoService(ApplicationDbContext context, IMapper mapper)
{
    private readonly ApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<MedicoResponseDto>> ObterTodasAsync()
    {
        var medicos = await _context.Medicos
            .Order()
            .ToListAsync();

        return _mapper.Map<IEnumerable<MedicoResponseDto>>(medicos);
    }

    public async Task<MedicoResponseDto?> ObterPorIdAsync(int id)
    {
        var medico = await _context.Medicos.FirstOrDefaultAsync(p => p.Id == id);

        return medico is null ? throw new KeyNotFoundException("Médico não encontrado.") : _mapper.Map<MedicoResponseDto>(medico);
    }

    public async Task<MedicoResponseDto> CriarMedicoAsync(MedicoRequestDto medicoRequestDto)
    {
        var medico = _mapper.Map<Medico>(medicoRequestDto);

        _context.Medicos.Add(medico);
        await _context.SaveChangesAsync();

        var medicoResponseDto = _mapper.Map<MedicoResponseDto>(medico);

        return medicoResponseDto;
    }

    public async Task<MedicoResponseDto> AtualizarMedicoAsync(int id, MedicoRequestDto medicoRequestDto)
    {
        var medicoExistente = await _context.Medicos.FindAsync(id) ?? throw new KeyNotFoundException("Médico não encontrado.");

        _mapper.Map(medicoRequestDto, medicoExistente);
        await _context.SaveChangesAsync();

        var medicoResponseDto = _mapper.Map<MedicoResponseDto>(medicoExistente);

        return medicoResponseDto;
    }

    public async Task RemoverMedicoAsync(int id)
    {
        var medico = await _context.Medicos.FindAsync(id) ?? throw new KeyNotFoundException("Médico não encontrado.");

        _context.Medicos.Remove(medico);
        await _context.SaveChangesAsync();
    }
}
