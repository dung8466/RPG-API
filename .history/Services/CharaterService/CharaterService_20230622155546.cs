global using AutoMapper;
using System.Security.Claims;

namespace dotnet_api.Services.CharaterService;

public class CharaterService : ICharaterService
{
    private readonly IMapper mapper;
    private readonly DataContext context;
    private readonly IHttpContextAccessor httpContextAccessor;

    public CharaterService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
    {
        this.context = context;
        this.mapper = mapper;
        this.httpContextAccessor = httpContextAccessor;
    }

    private int GetUserId() =>
        int.Parse(httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);
    public async Task<ServiceResponse<List<GetCharaterDto>>> AddCharater(AddCharaterDto newCharater)
    {
        var serviceResponse = new ServiceResponse<List<GetCharaterDto>>();
        var charater = mapper.Map<Charater>(newCharater);
        charater.User = await context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
        context.Charaters.Add(charater);
        await context.SaveChangesAsync();

        serviceResponse.Data = await context.Charaters.Where(c => c.User!.Id == GetUserId())
            .Select(c => mapper.Map<GetCharaterDto>(c)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharaterDto>>> DeleteCharater(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetCharaterDto>>();
        try
        {
            var charater = await context.Charaters.FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserId());
            if (charater is null)
                throw new Exception($"Charater with Id '{id}' not found");

            context.Charaters.Remove(charater);
            await context.SaveChangesAsync();
            serviceResponse.Data = await context.Charaters.Where(c => c.User!.Id == GetUserId())
                .Select(c => mapper.Map<GetCharaterDto>(c)).ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharaterDto>>> GetAllCharaters()
    {
        var serviceResponse = new ServiceResponse<List<GetCharaterDto>>();
        var dbCharaters = await context.Charaters.Where(c => c.User!.Id == GetUserId()).ToListAsync();
        serviceResponse.Data = dbCharaters.Select(c => mapper.Map<GetCharaterDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharaterDto>> GetCharaterById(int id)
    {
        var serviceResponse = new ServiceResponse<GetCharaterDto>();
        var dbCharater = await context.Charaters.FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserId());
        serviceResponse.Data = mapper.Map<GetCharaterDto>(dbCharater);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharaterDto>> UpdateCharater(UpdateCharaterDto updateCharater)
    {
        var serviceResponse = new ServiceResponse<GetCharaterDto>();
        try
        {
            var charater = await context.Charaters.Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == updateCharater.Id);
            if (charater is null || charater.User!.Id != GetUserId())
                throw new Exception($"Charater with Id '{updateCharater.Id}' not found");
            mapper.Map(updateCharater, charater);
            charater.Name = updateCharater.Name;
            charater.HitPoints = updateCharater.HitPoints;
            charater.Strength = updateCharater.Strength;
            charater.Defense = updateCharater.Defense;
            charater.Intelligence = updateCharater.Intelligence;
            charater.Class = updateCharater.Class;
            await context.SaveChangesAsync();
            serviceResponse.Data = mapper.Map<GetCharaterDto>(charater);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharaterDto>> AddCharaterSkill(AddCharaterSkillDto newCharaterSkill)
    {
        var response = new ServiceResponse<GetCharaterDto>();
        try
        {
            var charater = await context.Charaters
                .Include(c => c.Weapon)
                .Include(c => c.Skills)
                .FirstOrDefaultAsync(c => c.Id == newCharaterSkill.CharaterId
                    && c.User!.Id == GetUserId());
            if (charater is null)
            {
                response.Success = false;
                response.Message = "Charater not found.";
                return response;
            }
            var skill = await context.Skills.FirstOrDefaultAsync(s => s.Id == newCharaterSkill.SkillId);
            if (skill is null)
            {
                response.Success = false;
                response.Message = "Skill not found.";
                return response;
            }
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }
}