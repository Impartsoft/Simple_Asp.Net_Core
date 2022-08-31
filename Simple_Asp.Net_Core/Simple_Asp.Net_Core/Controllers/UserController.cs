using Microsoft.AspNetCore.Mvc;

namespace Simple_Asp.Net_Core.Controllers;

public class UserController : ControllerBase
{
    public UserController()
    {

    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok("all good");
    }
}
