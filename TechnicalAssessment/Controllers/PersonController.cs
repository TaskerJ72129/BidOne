using Microsoft.AspNetCore.Mvc;
using TechnicalAssessment.Models;

namespace TechnicalAssessment.Controllers;

public class PersonController : Controller
{   
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Person person)
    {
        return View();
    }

}
