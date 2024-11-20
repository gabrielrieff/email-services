using Microsoft.AspNetCore.Mvc;

namespace EmailServices.Api.Controllers;
public class Emails : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
