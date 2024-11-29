using MedAgenda.DTOs;
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
        return Ok(consulta);
    }

    [HttpPost]
    public async Task<IActionResult> CriarConsulta([FromBody] ConsultaRequestDto consultaRequestDto)
    {
        var consultaResponseDto = await _consultaService.CriarConsultaAsync(consultaRequestDto);
        return Ok(consultaResponseDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarConsulta(int id, [FromBody] ConsultaRequestDto consultaRequestDto)
    {
        var consultaAtualizada = await _consultaService.AtualizarConsultaAsync(id, consultaRequestDto);
        return Ok(consultaAtualizada);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverConsulta(int id)
    {
        await _consultaService.RemoverConsultaAsync(id);
        return NoContent();
    }
}
