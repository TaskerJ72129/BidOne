using Microsoft.AspNetCore.Mvc;
using TechnicalAssessment.Models;
using System.Text.Json;

namespace TechnicalAssessment.Controllers;

public class PersonController : Controller
{   
    private static readonly string FilePath =
        Path.Combine(Directory.GetCurrentDirectory(), "data.json");

    [HttpGet]
    public IActionResult Index()
    {
        return View(new Person());
    }

    [HttpPost]
    public IActionResult Index(Person person)
    {
        if (!ModelState.IsValid)
        {
            return View(person);
        }

        var people = LoadPeople();

        people.Add(person);

        SavePeople(people);

        TempData["Success"] = "Person saved successfully";

        return RedirectToAction("Index");
    }

    private List<Person> LoadPeople()
    {
        if (!System.IO.File.Exists(FilePath))
        {
            return new List<Person>();
        }

        var json = System.IO.File.ReadAllText(FilePath);

        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<Person>();
        }

        return JsonSerializer.Deserialize<List<Person>>(json) ?? new List<Person>();
    }

    private void SavePeople(List<Person> people)
    {
        var json = JsonSerializer.Serialize(people, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        System.IO.File.WriteAllText(FilePath, json);
    }
}