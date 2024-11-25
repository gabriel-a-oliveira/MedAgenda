using MedAgenda.Models;
using MedAgenda.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedAgenda.Controllers;

[ApiController]
[Route("api/consultas")]
public class ConsultasController : ControllerBase
{
    private readonly ConsultaService _consultaService;

    public ConsultasController(ConsultaService consultaService)
    {
        _consultaService = consultaService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodas()
    {
        var consultas = await _consultaService.ObterTodasAsync();
        return Ok(consultas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var consulta = await _consultaService.ObterPorIdAsync(id);
        if (consulta == null)
        {
            return NotFound();
        }

        return Ok(consulta);
    }

    [HttpPost]
    public async Task<IActionResult> CriarConsulta([FromBody] Consulta consulta)
    {
        if (consulta == null)
        {
            return BadRequest("Os dados da consulta não foram fornecidos.");
        }

        await _consultaService.CriarConsultaAsync(consulta);
        return CreatedAtAction(nameof(ObterPorId), new { id = consulta.Id }, consulta);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarConsulta(int id, [FromBody] Consulta consulta)
    {
        if (id != consulta.Id)
        {
            return BadRequest("ID da consulta na URL não corresponde ao ID no corpo da requisição.");
        }

        try
        {
            await _consultaService.AtualizarConsultaAsync(consulta);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Consulta não encontrada.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverConsulta(int id)
    {
        try
        {
            await _consultaService.RemoverConsultaAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Consulta não encontrada.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }
}
