using System.Collections;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")] //no api/[controller], just [controller] because we know it is an api
public class FridgeController:ControllerBase
{
    public readonly IFridgeRepository _fridgeRepository; //readonly: can only be set in a contructor 
    public FridgeController(IFridgeRepository ifridgeRepository)
    {
        _fridgeRepository = ifridgeRepository;
    }

    [HttpGet]
    public async Task <ActionResult<IEnumerable<Item>>> GetItems() //do not GetFridge3s but make it GetITems (more meaningful)
    { 
        //make the scelethon
        var result = await _fridgeRepository.GetItems();//TO DO: change the name to GetItems (more info)
        return Ok(result);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<ActionResult<Item>> GetItemById(Guid id) // meaningful names
    {
        var result = await _fridgeRepository.GetItemById(id);
        if(result == null)
            return NotFound();
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Item>> CreateItem(Item item)//meaningful name
    {
        var result = await _fridgeRepository.CreateItem(item);

        return CreatedAtAction(nameof(GetItemById), result);
    }

    [HttpPut] 
    //[Route("id:Guid")] // we already have the Id in the body  - not required - Id is something I control. 
    public async Task<ActionResult<bool>> UpdateItem(ItemDto itemDto)
    {
        //if(id != itemDto.Id)
        //    return NotFound();
        
        var result = await _fridgeRepository.UpdateItem(itemDto);
        return result?NoContent():NotFound();
    }
}