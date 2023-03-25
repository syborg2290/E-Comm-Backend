namespace backend.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using backend.Models.Users;
using backend.Models.Common;
using backend.Services;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]/[action]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;
    private IMapper _mapper;

    public UsersController(
        IUserService userService,
        IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }

    // POST: auth/login
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginUser user)
    {
        if (String.IsNullOrEmpty(user.Email))
        {
            return BadRequest(new { message = "Email address needs to entered" });
        }
        else if (String.IsNullOrEmpty(user.Password))
        {
            return BadRequest(new { message = "Password needs to entered" });
        }

        Tokens token = await _userService.Login(user.Email, user.Password);

        if (token != null)
        {
            return Ok(token);
        }

        return BadRequest(new { message = "User login unsuccessful" });
    }

    [HttpPost]
    public IActionResult Create(CreateRequest model)
    {
        //  Console.WriteLine(model);
        _userService.Create(model);
        return Ok(new { message = "User created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _userService.Update(id, model);
        return Ok(new { message = "User updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return Ok(new { message = "User deleted" });
    }
}