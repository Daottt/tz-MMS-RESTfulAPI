using data;
using data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/orders")]
[ApiController, Authorize]
public class OrderController : ControllerBase
{
    private readonly OrderRepository repository;
    public OrderController(Context context)
    {
        repository = new OrderRepository(context);
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
    public IActionResult Create(AddOrderDto dto)
    {
        var model = dto.ToModel();
        bool result = repository.Create(model);
        if (result) return Ok(model);
        else return NotFound();
    }
    [HttpPut]
    [Route("{Id:int}")]
    public IActionResult Update(int Id, OrderStatus Status)
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
        if (result) return Ok();
        else return NotFound();
    }
    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilterByStatus(DateTime? date ,OrderStatus? status)
    {
        return Ok(repository.GetByFilter(date, status));
    }
}