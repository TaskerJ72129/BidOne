using Microsoft.AspNetCore.Mvc;
using TechnicalAssessment.Models;
using System.Text.Json;

namespace TechnicalAssessment.Controllers;

public class PersonController : Controller
{   
    private static readonly string FilePath = "data.json";

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Person person)
    {
        var people = new List<Person>();

        if (System.IO.File.Exists(FilePath))
        {
            var currentJson = System.IO.File.ReadAllText(FilePath);

            if (!string.IsNullOrWhiteSpace(currentJson))
            {
                people = JsonSerializer.Deserialize<List<Person>>(currentJson) ?? new List<Person>();
            }
        }

        people.Add(person);

        var updatedJson = JsonSerializer.Serialize(people, new JsonSerializerOptions{
            WriteIndented = true
        });

        System.IO.File.WriteAllText(FilePath, updatedJson);

        return RedirectToAction("Index");
    }
}
