using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Controllers;

public class UserController : Controller
{
    public IActionResult CreatePremium()
        => View();
}