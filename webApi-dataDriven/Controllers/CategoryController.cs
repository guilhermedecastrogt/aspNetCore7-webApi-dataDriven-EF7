using Microsoft.AspNetCore.Mvc;
using webApi_dataDriven.Models;

namespace webApi_dataDriven.Controllers;

[Route("categories")]
public class CategoryController : ControllerBase
{
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<CategoryModel>> GetById(Guid id)
    {   
        return new CategoryModel();
    }
    
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<CategoryModel>>> Get()
    {
        return new List<CategoryModel>();
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<List<CategoryModel>>> Post([FromBody] CategoryModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(model);
    }

    /*[HttpPost]
    [Route("")]
    public async Task<ActionResult<CategoryModel>> Post(
        [FromBody]CategoryModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(model);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<List<CategoryModel>>> Put(int id, [FromBody] CategoryModel model)
    {
        if (model.Id == id)
            return Ok(model);
        
        return NotFound();
    }

    [HttpDelete]
    [Route("{id:int")]
    public async Task<ActionResult<List<CategoryModel>>> Delete()
    {
        return Ok();
    }*/
}