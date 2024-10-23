using data;
using data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/productionlines")]
[ApiController, Authorize]
public class ProductionLineController : ControllerBase
{
    private ProductionLineRepository repository;
    public ProductionLineController(Context context) 
    {
        repository = new ProductionLineRepository(context);
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
    public IActionResult Create(AddProductionLineDto dto)
    {
        if(!Enum.IsDefined(dto.Status)) return BadRequest(dto.Status);

        var model = dto.ToModel();
        bool result = repository.Create(model);
        if (result) return Ok(model);
        else return NotFound();
    }
    [HttpPut]
    [Route("{Id:int}")]
    public IActionResult Update(int Id, ProductionLineStatus Status)
    {
        if (!Enum.IsDefined(Status)) return BadRequest(Status);

        bool result = repository.UpdateStaus(Id, Status);
        if (result) return Ok();
        else return NotFound();
    }
    [HttpDelete]
    [Route("{Id:int}")]
    public IActionResult Delete(int Id)
    {
        bool result = repository.Delete(Id);
        if(result) return Ok();
        else return NotFound();
    }
}
