using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository authRepository;
    public AuthController(IAuthRepository authRepository)
    {
        this.authRepository = authRepository;

    }
    public async Task
}