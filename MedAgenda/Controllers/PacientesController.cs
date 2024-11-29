using MedAgenda.DTOs;
using MedAgenda.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedAgenda.Controllers;

[ApiController]
[Route("api/pacientes")]
public class PacientesController : ControllerBase
{
    private readonly PacienteService _pacienteService;

    public PacientesController(PacienteService pacienteService)
    {
        _pacienteService = pacienteService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var pacientes = await _pacienteService.ObterTodasAsync();
        return Ok(pacientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var paciente = await _pacienteService.ObterPorIdAsync(id);
        return Ok(paciente);
    }

    [HttpPost]
    public async Task<IActionResult> CriarPaciente([FromBody] PacienteRequestDto pacienteRequestDto)
    {
        var novoPaciente = await _pacienteService.CriarPacienteAsync(pacienteRequestDto);
        return CreatedAtAction(nameof(ObterPorId), new { id = novoPaciente.Id }, novoPaciente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarPaciente(int id, [FromBody] PacienteRequestDto pacienteRequestDto)
    {
        await _pacienteService.AtualizarPacienteAsync(id, pacienteRequestDto);
        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverPaciente(int id)
    {
        await _pacienteService.RemoverPacienteAsync(id);
        return NoContent(); 
    }
}
