
using App.Data;
using App.Entities;
using App.Repository;
using App.Service;
using App.Validators;

var context = new NeoGenesisContext();
var repository = new DinosaurRepository(context);
var validator = new DinosaurValidator();
var service = new DinosaurService(repository, validator);

try
{
    Console.WriteLine("=== Register Dinosaur ===");

    Console.Write("First Name: ");
    string firstName = Console.ReadLine();

    Console.Write("Last Name (Species): ");
    string lastName = Console.ReadLine();

    Console.Write("Username: ");
    string username = Console.ReadLine();

    Console.Write("Email: ");
    string email = Console.ReadLine();

    var dino = new Dinosaur
    {
        FirstName = firstName,
        LastName = lastName,
        Username = username,
        Email = email,
        Password = "",
        Type = "",
        Zone = "",
        Sector = "",
        Phone = "",
        Age = 0,
        CreationDate = DateTime.UtcNow
    };

    service.Register(dino);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");

    if (ex.InnerException != null)
    {
        Console.WriteLine($"Inner Error: {ex.InnerException.Message}");
    }
}