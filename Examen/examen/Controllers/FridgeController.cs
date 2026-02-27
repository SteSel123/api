using System;
using examen.Model;
using examen.Services;
using Microsoft.AspNetCore.Mvc;

namespace examen.Controllers;

[ApiController]
[Route("[Controller]")]
public class FridgeController:ControllerBase
{
    public readonly IfridgeRepository _fridgeRepository;
    public FridgeController(IfridgeRepository fridgeRepository)
    {
        _fridgeRepository = fridgeRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Item>> GetItems()
    {
        var result = _fridgeRepository.GetItems();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id: Guid}")]
    public ActionResult<Item> GetItemById(Guid id)
    {
        var result = _fridgeRepository.GetItemById(id);
        if(result == null)
            NotFound();
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Item> CreateItem(Item item)
    {
        var result = _fridgeRepository.CreateItem(item);
        return CreatedAtAction(nameof(GetItemById),item.Id,result);
    }

    [HttpPut]
    public ActionResult<bool> UpdateItem(Item item)
    {
        return _fridgeRepository.UpdateItem(item);
    }

    [HttpDelete]
    [Route("{id:Guid}")]
    public ActionResult<bool> DeleteItem(Guid id)
    {
         var result = _fridgeRepository.DeleteItem(id);
         if(result == false)
            NotFound();
        
        return Ok();
    }
    
}
