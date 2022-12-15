using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filters;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login() => View();

    [HttpPost]
    [UniqueUsersCountLoggerFilter]
    public IActionResult Login([FromForm] UserLogin userLogin) => View();
}
