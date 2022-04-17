using GelatoGuide.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GelatoGuide.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
        => View();


    public IActionResult Privacy()
        => View();


    public IActionResult About()
        => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
        => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

}
