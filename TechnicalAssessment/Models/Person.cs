using System.ComponentModel.DataAnnotations;

namespace TechnicalAssessment.Models;

public class Person
{   
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }
}