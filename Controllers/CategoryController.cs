namespace backend.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using backend.Models.Category;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;


[ApiController]
[Route("[controller]/[action]")]
public class CategoriesController : ControllerBase
{
    private ICategoryService _categoryService;

    private ICommonService _commonService;
    private IMapper _mapper;

    public CategoriesController(
        ICategoryService categoryService,
        ICommonService commonService,
        IMapper mapper)
    {
        _categoryService = categoryService;
        _commonService = commonService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var categories = _categoryService.GetAll();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var category = _categoryService.GetById(id);
        return Ok(category);
    }


    [HttpPost]
    public IActionResult Create(CreateRequestCategory model)
    {

        if (!HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
        {
            // Authorization header is not present
            return Unauthorized();
        }
        else
        {
            // Authorization header is present, split the value to remove the "Bearer " prefix
            // e.g. "Bearer token-value" -> "token-value"
            var tokenValue = authHeader.ToString().Split(" ")[1];

            if (_commonService.IsValid(tokenValue))
            {
                _categoryService.Create(model);
                return Ok(new { message = "Category created" });
            }
            else
            {
                return BadRequest(new { message = "Session expired!" });
            }

        }
        //  Console.WriteLine(model);

    }


    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _categoryService.Delete(id);
        return Ok(new { message = "Category deleted" });
    }
}
