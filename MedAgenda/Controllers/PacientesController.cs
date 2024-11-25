using MedAgenda.Models;
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
        if (paciente == null)
        {
            return NotFound();
        }

        return Ok(paciente);
    }

    [HttpPost]
    public async Task<IActionResult> CriarPaciente([FromBody] Paciente paciente)
    {
        if (paciente == null)
        {
            return BadRequest("Os dados do paciente não foram fornecidos.");
        }

        var novoPaciente = await _pacienteService.CriarPacienteAsync(paciente);
        return CreatedAtAction(nameof(ObterPorId), new { id = novoPaciente.Id }, novoPaciente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarPaciente(int id, [FromBody] Paciente paciente)
    {
        if (id != paciente.Id)
        {
            return BadRequest("ID do paciente na URL não corresponde ao ID no corpo da requisição.");
        }

        try
        {
            await _pacienteService.AtualizarPacienteAsync(paciente);
            return NoContent(); 
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Paciente não encontrado.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverPaciente(int id)
    {
        try
        {
            await _pacienteService.RemoverPacienteAsync(id);
            return NoContent(); 
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Paciente não encontrado.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }
}
