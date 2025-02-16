
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class AppointmentsController : Controller {
    private readonly IRepository<Appointment> _repository;
    public AppointmentsController(IRepository<Appointment> repository) => _repository = repository;

    public async Task<IActionResult> Index() => View(await _repository.GetAll());

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Appointment appointment) {
        await _repository.Add(appointment);
        return RedirectToAction("Index");
    }
}