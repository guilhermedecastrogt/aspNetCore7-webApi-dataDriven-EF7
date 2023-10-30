using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi_dataDriven.Data;
using webApi_dataDriven.Models;
using webApi_dataDriven.Services;

namespace webApi_dataDriven.Controllers;

[Route("v1/users")]
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
            context.Users.Add(model);
            await context.SaveChangesAsync();
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
            return NotFound(new { message = "User not found" });

        var token = TokenService.TokenGenerate(user);
        return new
        {
            user = user,
            token = token
        };
    }
}