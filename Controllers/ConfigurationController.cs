namespace backend.Controllers;

using Microsoft.AspNetCore.Mvc;
using backend.Models.Configuration;
using backend.Services;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]/[action]")]
public class ConfigurationController : ControllerBase
{
    private readonly IConfigurationService _configurationService;

    public ConfigurationController(IConfigurationService configurationService)
    {
        _configurationService = configurationService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var configurations = _configurationService.GetAll();
        return Ok(configurations);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var configuration = _configurationService.GetById(id);
        return Ok(configuration);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create(CreateRequestConfiguration model)
    {
        var configuration = _configurationService.Create(model);
        return Ok(configuration);
    }


    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        _configurationService.Delete(id);
        return Ok(new { message = "Configuration deleted" });
    }
}
