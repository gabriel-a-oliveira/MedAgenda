﻿using MedAgenda.Models;
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
        if (medico == null) return NotFound();

        return Ok(medico);
    }

    [HttpPost]
    public async Task<IActionResult> CriarMedico(Medico medico)
    {
        var newMedico = await _context.CriarMedicoAsync(medico);
        return CreatedAtAction(nameof(ObterPorId), new { id = newMedico.Id }, newMedico);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarMedico(int id, Medico medico)
    {
        if (id != medico.Id)
            return BadRequest("ID do médico na URL não corresponde ao ID no corpo da requisição.");

        try
        {
            var medicoAtualizado = await _context.AtualizarMedicoAsync(id, medico);
            return Ok(medicoAtualizado);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverMedico(int id)
    {
        try
        {
            var medicoRemovido = await _context.RemoverMedicoAsync(id);
            return Ok(medicoRemovido);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }
}
