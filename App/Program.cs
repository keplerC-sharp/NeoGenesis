using App.Data;
using App.Entities;
using App.LINKQ;
using App.Repository;
using App.Service;
using App.Validators;

var ctx = new NeoGenesisContext();
var repo = new DinosaurRepository(ctx);
var queries = new DinosaurQueryService(repo);
var service = new DinosaurService(repo, queries);
var validator = new DinosaurValidator();

void ShowMenu()
{
    Console.WriteLine(
@"NeoGenesis • Dinosaur Registry
1) List all
2) Sort by created date (descending)
3) Sort alphabetically by species
4) Filter by minimum age
5) Filter by diet type (Carnivore/Herbivore)
6) Delete by registration code (email)
0) Exit
> Select an option: ");
}

void ShowList(IEnumerable<Dinosaur> list)
{
    var hasAny = false;
    foreach (var d in list)
    {
        hasAny = true;
        Console.WriteLine($"{d.Id} | {d.FirstName} | {d.LastName} | {d.UserName} | {d.Email} | Age: {d.Age} | Diet: {d.Diet} | Created: {d.CreatedAt:yyyy-MM-dd HH:mm:ss} UTC");
    }
    if (!hasAny)
    {
        Console.WriteLine("No dinosaurs registered.");
    }
}

void ListAll()
{
    var list = service.GetAll();
    Console.WriteLine("Full list:");
    ShowList(list);
}

void SortByDate()
{
    var list = service.GetOrderedByCreatedDesc();
    Console.WriteLine("Sorted by created date (newest first):");
    ShowList(list);
}

void SortBySpecies()
{
    var list = service.GetOrderedBySpecies();
    Console.WriteLine("Sorted alphabetically by species:");
    ShowList(list);
}

void FilterByAge()
{
    Console.Write("Enter minimum age: ");
    var input = Console.ReadLine();
    if (!validator.TryParseNonNegativeInt(input, out var age))
    {
        Console.WriteLine("Invalid age. Must be a non-negative integer.");
        return;
    }
    var list = service.FilterByMinAge(age);
    Console.WriteLine($"Dinosaurs with age >= {age}:");
    ShowList(list);
}

void FilterByDiet()
{
    Console.Write("Diet type (Carnivore=C / Herbivore=H): ");
    var input = Console.ReadLine();
    if (!validator.TryParseDiet(input, out var diet))
    {
        Console.WriteLine("Invalid diet type. Use C or H.");
        return;
    }
    var list = service.FilterByDiet(diet);
    Console.WriteLine($"Dinosaurs with diet {diet}:");
    ShowList(list);
}

void DeleteByEmail()
{
    Console.Write("Enter the registration code (email) to delete: ");
    var email = Console.ReadLine() ?? string.Empty;
    var d = service.GetByEmail(email);
    if (d == null)
    {
        Console.WriteLine("No dinosaur exists with that email.");
        return;
    }
    Console.Write($"Are you sure you want to delete this dinosaur? (Y/N): ");
    var confirm = Console.ReadLine()?.Trim().ToUpperInvariant();
    if (confirm == "Y")
    {
        var ok = service.DeleteByEmail(email);
        if (ok) Console.WriteLine("Dinosaur deleted successfully.");
        else Console.WriteLine("Could not delete the dinosaur.");
    }
    else
    {
        Console.WriteLine("Operation cancelled. No changes were made.");
    }
}

while (true)
{
    Console.WriteLine();
    ShowMenu();
    var option = Console.ReadLine();
    Console.WriteLine();
    switch (option)
    {
        case "1":
            ListAll();
            break;
        case "2":
            SortByDate();
            break;
        case "3":
            SortBySpecies();
            break;
        case "4":
            FilterByAge();
            break;
        case "5":
            FilterByDiet();
            break;
        case "6":
            DeleteByEmail();
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}
