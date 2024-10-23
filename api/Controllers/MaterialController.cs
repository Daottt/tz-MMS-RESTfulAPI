using data;
using data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/materials")]
[ApiController, Authorize]
public class MaterialController : ControllerBase
{
    private MaterialRepository repository;
    public MaterialController(Context context)
    {
        repository = new MaterialRepository(context);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(repository.GetAll());
    }
    [HttpGet]
    [Route("{Id:int}")]
    public IActionResult Get(int Id)
    {
        var model = repository.Get(Id);
        if (model != null)
            return Ok(model);
        else return NotFound();
    }
    [HttpPost]
    public IActionResult Create(AddMaterialDto dto)
    {
        var model = dto.ToModel();
        bool result = repository.Create(model);
        if (result) return Ok(model);
        else return NotFound();
    }
    [HttpPut]
    [Route("{Id:int}")]
    public IActionResult Update(int Id, int Quantity)
    {
        bool result = repository.UpdateQuantity(Id, Quantity);
        if (result) return Ok();
        else return NotFound();
    }
    [HttpDelete]
    [Route("{Id:int}")]
    public IActionResult Delete(int Id)
    {
        bool result = repository.Delete(Id);
        if (result) return Ok();
        else return NotFound();
    }
}