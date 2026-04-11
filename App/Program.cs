using System;

using App.Data;
using App.Entities;
using App.LINKQ;
using App.Repository;
using App.Service;
using App.Validators;

var context = new NeoGenesisContext();
var repository = new DinosaurRepository(context);
var validator = new DinosaurValidator();
var query = new DinosaurQueryService(context, repository);
var service = new DinosaurService(repository, validator, query);

// try
// {
//     Console.WriteLine("=== Register Dinosaur ===");
//
//     Console.Write("First Name: ");
//     string firstName = Console.ReadLine();
//
//     Console.Write("Last Name (Species): ");
//     string lastName = Console.ReadLine();
//
//     Console.Write("Username: ");
//     string username = Console.ReadLine();
//
//     Console.Write("Email: ");
//     string email = Console.ReadLine();
//
//     var dino = new Dinosaur
//     {
//         FirstName = firstName,
//         LastName = lastName,
//         Username = username,
//         Email = email,
//         Password = "",
//         Type = "",
//         Zone = "",
//         Sector = "",
//         Phone = "",
//         Age = 0,
//         CreationDate = DateTime.UtcNow
//     };
//
//     service.Register(dino);
// }
// catch (Exception ex)
// {
//     Console.WriteLine($"Error: {ex.Message}");
//
//     if (ex.InnerException != null)
//     {
//         Console.WriteLine($"Inner Error: {ex.InnerException.Message}");
//     }
// }

void ShowList(IEnumerable<Dinosaur> list)
{
    var hasAny = false;
    foreach (var d in list)
    {
        hasAny = true;
        Console.WriteLine($"{d.Id} | {d.FirstName} | {d.LastName} | {d.Username} | {d.Email} | Age: {d.Age} | Type: {d.Type} | Created: {d.CreationDate:yyyy-MM-dd HH:mm:ss} UTC");
    }
    if (!hasAny)
    {
        Console.WriteLine("No dinosaurs registered.");
    }
}

void ShowOne(Dinosaur dino)
{
    if (dino == null)
        Console.WriteLine("Dino not found.");
    else
        Console.WriteLine($"{dino.Id} | {dino.FirstName} | {dino.LastName} | {dino.Username} | {dino.Email} | Age: {dino.Age} | Type: {dino.Type} | Created: {dino.CreationDate:yyyy-MM-dd HH:mm:ss} UTC");
    
}

void ShowGetNameAndEmailReport(IEnumerable<Dinosaur> dino)
{
    dino.Select(d => new
        {
            FullName = d.FirstName + " " + d.LastName,
            d.Email
        })
        .ToList();
    
    Console.WriteLine("=== Dinosaur Report (Name & Email) ===");
    
    foreach (var item in dino)
    {
        Console.WriteLine($"Name: {item.FirstName} | Email: {item.Email}");
    }
    
    Console.WriteLine($"Total dinosaurs: {dino.Count()}");
}
//
//     void ListAll()
//     {
//         var list = service.GetAll();
//         Console.WriteLine("Full list:");
//         ShowList(list);
//     }


// void SortByDate()
// {
//     var list = service.GetOrderedByCreatedDesc();
//     Console.WriteLine("Sorted by created date (newest first):");
//     ShowList(list);
// }
//
// void SortBySpecies()
// {
//     var list = service.GetOrderedBySpecies();
//     Console.WriteLine("Sorted alphabetically by species:");
//     ShowList(list);
// }
//
// try
// {
//     SortByDate();
// }
// catch (Exception e)
// {
//     Console.WriteLine(e);
//     throw;
// }
// try
// {
//     SortBySpecies();
// }
// catch (Exception e)
// {
//     Console.WriteLine(e);
//     throw;
// }

// void FilterByAge()
// {
//     Console.Write("Enter minimum age: ");
//     var input = Console.ReadLine();
//     if (!validator.TryParseNonNegativeInt(input, out var age))
//     {
//         Console.WriteLine("Invalid age. Must be a non-negative integer.");
//         return;
//     }
//     var list = service.FilterByMinAge(age);
//     Console.WriteLine($"Dinosaurs with age >= {age}:");
//     ShowList(list);
// }
//
// try
// {
//     FilterByAge();
// }
// catch (Exception e)
// {
//     Console.WriteLine(e);
//     throw;
// }

// void DeleteByEmail()
// {
//     Console.Write("Enter the registration code (email) to delete: ");
//     var email = Console.ReadLine() ?? string.Empty;
//     var d = service.GetByEmail(email);
//     if (d == null)
//     {
//         Console.WriteLine("No dinosaur exists with that email.");
//         return;
//     }
//     Console.Write($"Are you sure you want to delete this dinosaur? (Y/N): ");
//     var confirm = Console.ReadLine()?.Trim().ToUpperInvariant();
//     if (confirm == "Y")
//     {
//         var ok = service.DeleteByEmail(email);
//         if (ok) Console.WriteLine("Dinosaur deleted successfully.");
//         else Console.WriteLine("Could not delete the dinosaur.");
//     }
//     else
//     {
//         Console.WriteLine("Operation cancelled. No changes were made.");
//     }
// }
//
// try
// {
//     DeleteByEmail();
// }
// catch (Exception e)
// {
//     Console.WriteLine(e);
//     throw;
// }


// void DinoById(int id)
// { 
//     var dino = service.GetById(id);
//     Console.WriteLine("Full list:");
//     ShowOne(dino);
// }

// try
// {
    // DinoById(10);
// }
// catch (Exception e)
// {
//     Console.WriteLine(e);
//     throw;
// }

void GetNameAndEmailReport()
{
    var result = query.GetNameAndEmailReport();
    ShowGetNameAndEmailReport(result);
}

GetNameAndEmailReport();


// UPDATE DINO
//     Console.WriteLine("=== Update Dinosaur ===");
//
//     Console.Write("Enter ID: ");
//     int id = int.Parse(Console.ReadLine());
//
//     var existing = repository.GetById(id);
//
//     if (existing == null)
//     {
//         Console.WriteLine("Dinosaur not found.");
//         return;
//     }
//
// // Pedir nuevos valores
//     Console.Write("First Name: ");
//     existing.FirstName = Console.ReadLine();
//
//     Console.Write("Last Name: ");
//     existing.LastName = Console.ReadLine();
//
//     Console.Write("Username: ");
//     existing.Username = Console.ReadLine();
//
//     Console.Write("Email: ");
//     existing.Email = Console.ReadLine();
//
//     Console.Write("Password: ");
//     existing.Password = Console.ReadLine();
//
//     Console.Write("Age: ");
//     existing.Age = int.Parse(Console.ReadLine());
//
//     Console.Write("Type: ");
//     existing.Type = Console.ReadLine();
//
//     Console.Write("Zone: ");
//     existing.Zone = Console.ReadLine();
//
//     Console.Write("Sector: ");
//     existing.Sector = Console.ReadLine();
//
//     Console.Write("Phone: ");
//     existing.Phone = Console.ReadLine();
//
//     try
//     {
//         service.Update(existing);
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine($"Error: {ex.Message}");
//     }


