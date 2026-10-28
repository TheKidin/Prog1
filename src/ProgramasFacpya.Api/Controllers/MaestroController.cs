using Microsoft.AspNetCore.Mvc;
using ProgramasFacpya.Api.Features.Maestros; 
using ProgramasFacpya.Api.Features.Maestros.Dominio.Entidad;
using ProgramasFacpya.Api.Features.Maestros.Dominio.Dto;

namespace ProgramasFacpya.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaestroController(MaestroService maestroService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var respuesta = await maestroService.ObtenerTodos();
        if (!respuesta.Status)
            return BadRequest(respuesta);

        return Ok(respuesta);
    }

    [HttpGet("ObtenerPorId/{idMaestro:int}")]
    public async Task<IActionResult> GetPorId(int idMaestro)
    {
        var respuesta = await maestroService.ObtenerPorId(idMaestro);
        if (!respuesta.Status)
            return BadRequest(respuesta);

        return Ok(respuesta);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MaestroDTO maestroDto)
    {
        var respuesta = await maestroService.Crear(maestroDto);
        if (!respuesta.Status)
            return BadRequest(respuesta);

        return Ok(respuesta);
    }

    [HttpPut("Actualizar/{idMaestro:int}")]
    public async Task<IActionResult> Put(int idMaestro, [FromBody] MaestroDTO maestroDto)
    {
        var respuesta = await maestroService.Actualizar(idMaestro, maestroDto);
        if (!respuesta.Status)
            return BadRequest(respuesta);

        return Ok(respuesta);
    }

    [HttpDelete("Eliminar/{idMaestro:int}")]
    public async Task<IActionResult> Delete(int idMaestro)
    {
        var respuesta = await maestroService.Eliminar(idMaestro);
        if (!respuesta.Status)
            return BadRequest(respuesta);

        return Ok(respuesta);
    }
}