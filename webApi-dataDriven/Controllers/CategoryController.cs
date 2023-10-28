using Microsoft.AspNetCore.Mvc;
using webApi_dataDriven.Data;
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
    public async Task<ActionResult<List<CategoryModel>>> Post(
        [FromBody] CategoryModel model,
        [FromServices] DataContext context)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            context.Categories.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Erro to save category" });
        }
    }
    

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<List<CategoryModel>>> Put(int id, [FromBody] CategoryModel model)
    {
        if (model.Id != id)
            return NotFound(new { message = "Category not found" });

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(model);
    }

    /*[HttpDelete]
    [Route("{id:int")]
    public async Task<ActionResult<List<CategoryModel>>> Delete()
    {
        return Ok();
    }*/
}