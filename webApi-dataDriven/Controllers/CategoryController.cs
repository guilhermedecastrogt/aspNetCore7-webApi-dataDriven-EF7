using Microsoft.AspNetCore.Mvc;

namespace webApi_dataDriven.Controllers;

[Route("categories")]
public class CategoryController : ControllerBase
{
    [Route("")]
    public string MyMethod()
    {
        return "Hello World!";
    }

    [HttpPost]
    [Route("")]
    public string Post()
    {
        return "POST";
    }

    [HttpPut]
    [Route("")]
    public string PUT()
    {
        return "PUT";
    }

    [HttpDelete]
    [Route("")]
    public string Delete()
    {
        return "Delete";
    }
}