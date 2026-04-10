using App.Data;
using App.Entities;
using App.Repository;
using App.Service;
using App.Validators;

using var db = new NeoGenesisContext();
db.Database.EnsureCreated();

var repository = new DinosaurRepository(db);
var validator = new DinosaurValidator(repository);
var service = new DinosaurService(repository, validator);

var dino = new Dinosaur
{
    FirstName = "Rex",
    LastName = "Tyrannosaurus",
    Username = "rex01",
    Email = "rex@neogenesis.com"
};

try
{
    service.Register(dino);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}