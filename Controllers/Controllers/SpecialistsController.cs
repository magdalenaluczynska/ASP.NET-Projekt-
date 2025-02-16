
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class SpecialistsController : Controller {
    private readonly IRepository<Specialist> _repository;
    public SpecialistsController(IRepository<Specialist> repository) => _repository = repository;

    public async Task<IActionResult> Index() => View(await _repository.GetAll());

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Specialist specialist) {
        await _repository.Add(specialist);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id) => View(await _repository.GetById(id));

    [HttpPost]
    public async Task<IActionResult> Edit(Specialist specialist) {
        await _repository.Update(specialist);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id) => View(await _repository.GetById(id));

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        await _repository.Delete(id);
        return RedirectToAction("Index");
    }
}
