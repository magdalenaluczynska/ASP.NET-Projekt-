
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

[Route("api/appointments")]
[ApiController]
public class AppointmentsApiController : ControllerBase {
    private readonly IRepository<Appointment> _repository;
    public AppointmentsApiController(IRepository<Appointment> repository) => _repository = repository;

    [HttpGet]
    public async Task<IEnumerable<Appointment>> GetAppointments() => await _repository.GetAll();

    [HttpGet("{id}")]
    public async Task<Appointment> GetAppointment(int id) => await _repository.GetById(id);

    [HttpPost]
    public async Task<IActionResult> Create(Appointment appointment) { 
        await _repository.Add(appointment); 
        return Ok(); 
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Appointment appointment) {
        if (id != appointment.Id) return BadRequest();
        await _repository.Update(appointment);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        await _repository.Delete(id);
        return NoContent();
    }
}
