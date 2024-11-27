using EmailServices.Application.UseCase.Tenants.Register;
using EmailServices.Communication.Requests.Tenants;
using Microsoft.AspNetCore.Mvc;

namespace EmailServices.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class Tenants : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterTenantUseCase useCase,
        [FromBody] RequestRegisterTenant request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
}
