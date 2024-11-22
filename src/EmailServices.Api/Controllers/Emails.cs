using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailServices.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class Emails : ControllerBase
{
    //[HttpPost]
    ////[ProducesResponseType(typeof(), StatusCodes.Status201Created)]
    ////[ProducesResponseType(typeof(), StatusCodes.Status400BadRequest)]
    //public async Task<IActionResult> Register(
    //[FromServices]  useCase,
    //[FromBody]  request)
    //{
    //    var response = await useCase.Execute(request);

    //    return Created(string.Empty, response);
    //}
}
