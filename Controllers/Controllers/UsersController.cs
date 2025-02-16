
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

public class UsersController : Controller {
    private readonly IRepository<User> _repository;
    public UsersController(IRepository<User> repository) => _repository = repository;

    public async Task<IActionResult> Index() => View(await _repository.GetAll());

    public async Task<IActionResult> Details(int id) => View(await _repository.GetById(id));

    public IActionResult Create() => View();

    [HttpPost] 
    public async Task<IActionResult> Create(User user) { 
        await _repository.Add(user); 
        return RedirectToAction("Index"); 
    }

    public async Task<IActionResult> Edit(int id) => View(await _repository.GetById(id));

    [HttpPost] 
    public async Task<IActionResult> Edit(User user) { 
        await _repository.Update(user); 
        return RedirectToAction("Index"); 
    }

    public async Task<IActionResult> Delete(int id) => View(await _repository.GetById(id));

    [HttpPost] 
    public async Task<IActionResult> DeleteConfirmed(int id) { 
        await _repository.Delete(id); 
        return RedirectToAction("Index"); 
    }
}