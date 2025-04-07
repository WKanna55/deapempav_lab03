using Lab03_WillianKana.Entities;
using Lab03_WillianKana.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lab03_WillianKana.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userRepository.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var user = await _userRepository.GetById(id);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpGet("username/{username}")]
    public async Task<IActionResult> GetByUsername([FromRoute] string username)
    {
        var user = await _userRepository.GetByUser(username);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User user)
    {
        await _userRepository.Add(user);
        return Ok(user);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] User user)
    {
        await _userRepository.Update(user, user.Password);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _userRepository.Delete(id);
        return NoContent();
    }

    [HttpGet("check/{username}")]
    public async Task<IActionResult> CheckUser([FromRoute] string username)
    {
        var isAvailable = _userRepository.IsAvailableUser(username);
        return Ok(isAvailable);
    }
    
}