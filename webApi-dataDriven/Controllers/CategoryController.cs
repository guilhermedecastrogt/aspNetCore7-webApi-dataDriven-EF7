using Microsoft.AspNetCore.Mvc;
using webApi_dataDriven.Models;

namespace webApi_dataDriven.Controllers;

[Route("categories")]
public class CategoryController : ControllerBase
{
    [Route("{id:guid}")]
    public string GetById(string id)
    {   
        return "Hello World!" + id.ToString();
    }

    [HttpPost]
    [Route("")]
    public CategoryModel Post([FromBody]CategoryModel model)
    {
        model.Id = Guid.NewGuid();
        return model;
    }

    [HttpPut]
    [Route("{id:guid}")]
    public CategoryModel PUT(Guid id, [FromBody] CategoryModel model)
    {
        if (model.Id == id)
            return model;
        
        return null;
    }

    [HttpDelete]
    [Route("{id:guid")]
    public string Delete()
    {
        return "Delete";
    }
}