using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Data;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlantController : ControllerBase
{
    private readonly IPlantRepository _repo;

    public PlantController(IPlantRepository repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public IActionResult CreatePlants([FromBody] Plant plant)
    {
        _repo.Create(plant);
        return Ok("Növények elmentve memóriába.");
    }

    [HttpGet]
    public IActionResult GetPlants()
    {
        var allPlants = _repo.Read();
        return Ok(allPlants);
    }
    
    [HttpDelete("{name}")]
    public IActionResult DeletePlant(string name)
    {
        _repo.Delete(name);
        return Ok($"Törölve: {name}");
    }

    [HttpDelete]
    public IActionResult DeleteAll()
    {
        _repo.DeleteAll();
        return Ok("Minden növény törölve.");
    }

    [HttpGet("schedule")]
    public IActionResult GetSchedule()
    {
        var schedule = _repo.GenerateSchedule();
        return Ok(schedule);
    }
}
