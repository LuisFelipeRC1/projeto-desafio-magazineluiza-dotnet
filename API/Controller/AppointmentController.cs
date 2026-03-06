using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DesafioMagazineLuiza.Application.Service;
using DesafioMagazineLuiza.Application.DTO;

namespace DesafioMagazineLuiza.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase {
    private readonly AppointmentService _service;

    public AppointmentController(AppointmentService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAppointment([FromBody] AppointmentRequest request)
    {
        try
        {
            var response = await _service.CreateAppointment(request);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = response.Id }, response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointmentById(Guid id)
    {
        try
        {
            var response = await _service.GetAppointmentById(id);
            return Ok(response);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(Guid id)
    {
        try
        {
            await _service.DeleteAppointment(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

}
