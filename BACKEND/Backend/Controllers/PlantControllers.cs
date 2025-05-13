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

    // POST: api/plant
    [HttpPost]
    public IActionResult CreatePlants([FromBody] List<Plant> plants)
    {
        _repo.Create(plants);
        return Ok("Növények elmentve memóriába.");
    }

    // GET: api/plant
    [HttpGet]
    public IActionResult GetPlants()
    {
        var allPlants = _repo.Read();
        return Ok(allPlants);
    }

    // DELETE: api/plant/{name}
    [HttpDelete("{name}")]
    public IActionResult DeletePlant(string name)
    {
        _repo.Delete(name);
        return Ok($"Törölve: {name}");
    }

    // DELETE: api/plant
    [HttpDelete]
    public IActionResult DeleteAll()
    {
        _repo.DeleteAll();
        return Ok("Minden növény törölve.");
    }
}
