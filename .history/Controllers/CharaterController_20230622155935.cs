global using dotnet_api.Models;
global using dotnet_api.Services.CharaterService;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CharaterController : ControllerBase
{

    private readonly ICharaterService charaterService;

    public CharaterController(ICharaterService charaterService)
    {
        this.charaterService = charaterService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<ServiceResponse<List<GetCharaterDto>>>> GetAllCharaters()
    {

        return Ok(await charaterService.GetAllCharaters());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetCharaterDto>>> GetSingleCharater(int id)
    {
        return Ok(await charaterService.GetCharaterById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<GetCharaterDto>>>> AddCharater(AddCharaterDto newCharater)
    {
        return Ok(await charaterService.AddCharater(newCharater));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<List<GetCharaterDto>>>> UpdateCharater(UpdateCharaterDto updateCharater)
    {
        var response = await charaterService.UpdateCharater(updateCharater);
        if (response.Data is null)
        {
            return NotFound(response);
        }
        return Ok(response);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<GetCharaterDto>>> DeleteCharater(int id)
    {
        var response = await charaterService.DeleteCharater(id);
        if (response.Data is null)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpPost("Skill")]
    public async Task<ServiceResponse<GetCharaterDto>> AddCharaterSkill(AddCharaterSkillDto )
}