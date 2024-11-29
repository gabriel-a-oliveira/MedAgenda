using MedAgenda.DTOs;
using MedAgenda.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedAgenda.Controllers;

[ApiController]
[Route("api/medicos")]
public class MedicosController : ControllerBase
{
    private readonly MedicoService _context;

    public MedicosController(MedicoService context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodas()
    {
        var medicos = await _context.ObterTodasAsync();
        return Ok(medicos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var medico = await _context.ObterPorIdAsync(id);
        return Ok(medico);
    }

    [HttpPost]
    public async Task<IActionResult> CriarMedico(MedicoRequestDto medico)
    {
        var newMedico = await _context.CriarMedicoAsync(medico);
        return CreatedAtAction(nameof(ObterPorId), new { id = newMedico.Id }, newMedico);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarMedico(int id, MedicoRequestDto medico)
    {
        var medicoAtualizado = await _context.AtualizarMedicoAsync(id, medico);
        return Ok(medicoAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverMedico(int id)
    {
        await _context.RemoverMedicoAsync(id);
        return NoContent();
    }
}
