using Microsoft.AspNetCore.Mvc;

namespace Simple_Asp.Net_Core.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public UserController()
    {

    }

    [HttpGet(Name ="GetUsers")]
    public async Task<IActionResult> Get()
    {
        return Ok("all good");
    }
}
