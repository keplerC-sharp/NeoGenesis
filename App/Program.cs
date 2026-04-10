using App.Data;
using App.Service;
using App.Entities;
using App.Validators;

using var db = new NeoGenesisContext();
db.Database.EnsureCreated();

using (var context = new NeoGenesisContext())
{
    var validator = new DinosaurValidator(context);
    var service = new DinosaurService(context, validator);

    var dinosaur = new Dinosaur()
    {
        FirstName = "Khalid",
        LastName = "Kashimiri",
        Email = "khalidkashimiri@uae.com",
        Username = "theultraKhalidKashimiri",
        Password = "password123",
        Type = "Carnivore",
        Zone = "A",
        Sector = "1",
        Phone = "7376174321"
    };

    string result = service.Register(dinosaur);
    Console.WriteLine(result);
}