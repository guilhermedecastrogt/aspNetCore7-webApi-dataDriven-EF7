using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi_dataDriven.Data;
using webApi_dataDriven.Models;

namespace webApi_dataDriven.Controllers;

[Route("products")]
public class ProductController : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<ProductModel>>> Get([FromServices] DataContext context)
    {
        var product = await context.Products.Include(x => x.Category)
            .AsNoTracking().ToListAsync();
        
        return Ok(product);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ProductModel>> GetById(int id, [FromServices] DataContext context)
    {
        var product = await context.Products.Include(x => x.Category)
            .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return Ok(product);
    }

    [HttpGet]
    [Route("categories/{id:int}")]
    public async Task<ActionResult<List<ProductModel>>> GetByCategory(
        int id, [FromServices] DataContext context)
    {
        var products = await context.Products
            .Include(x => x.Category)
            .AsNoTracking()
            .Where(x => x.CategoryId == id)
            .ToListAsync();
        
        return Ok(products);
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<ProductModel>> Post(
        [FromBody] ProductModel model,
        [FromServices] DataContext context)
    {
        if (ModelState.IsValid)
        {
            context.Products.Add(model);
            await context.SaveChangesAsync();
            return model;
        }

        return BadRequest(ModelState);
    }
    
}