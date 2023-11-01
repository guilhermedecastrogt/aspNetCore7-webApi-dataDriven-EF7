using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi_dataDriven.Data;
using webApi_dataDriven.Models;
using webApi_dataDriven.Services;

namespace webApi_dataDriven.Controllers;

[Route("users")]
public class UserController : Controller
{
    [HttpPost]
    [Route("")]
    [AllowAnonymous]
    public async Task<ActionResult<UserModel>> Post(
        [FromServices] DataContext context,
        [FromBody] UserModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            model.Role = "employee";
            
            context.Users.Add(model);
            await context.SaveChangesAsync();

            model.Password = "";
            return Ok(model);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                message = $"Error to save User, try again. Error details: {ex}"
            });
        }
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<dynamic>> Authenticate(
        [FromServices] DataContext context,
        [FromBody] UserModel model)
    {
        var user = await context.Users
            .AsNoTracking()
            .Where(x =>
                x.Username == model.Username &&
                x.Password == model.Password
            ).FirstOrDefaultAsync();
        if (user == null)
            return NotFound(new { message = "Invalid user or password" });

        var token = TokenService.TokenGenerate(user);
        user.Password = "";
        return new
        {
            user = user,
            token = token
        };
    }

    [HttpPut]
    [Route("{id:int}")]
    [Authorize(Roles = "manager")]
    public async Task<ActionResult<UserModel>> Put(
        [FromServices] DataContext context,
        [FromBody] UserModel model,
        int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != model.Id)
            return NotFound(new { message = "User not found" });

        try
        {
            context.Entry(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            
            return model;
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                message = $"Error to put user. Details: {ex}"
            });
        }
    }
}