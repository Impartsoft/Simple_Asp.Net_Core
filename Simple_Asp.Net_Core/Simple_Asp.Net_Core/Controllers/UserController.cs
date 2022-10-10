using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Simple_Asp.Net_Core.Data;
using Simple_Asp.Net_Core.Dtos;

namespace Simple_Asp.Net_Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepo _userRepo;
    private readonly IMapper _mapper;
    public UserController(IUserRepo userRepo, IMapper mapper)
    {
        _userRepo = userRepo;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get()
    {
        var users = _userRepo.GetAllUsers();

        return Ok(_mapper.Map<List<UserReadDto>>(users));
    }

    [HttpGet("{id}", Name = "GetUserById")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = _userRepo.GetUserById(id);

        return Ok(_mapper.Map<UserReadDto>(user));
    }

}
