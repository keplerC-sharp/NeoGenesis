using System;
using App.Service;
using App.Entities;

namespace App.UI;

public class ParkMenu
{
    private readonly DinosaurService _service;

    public ParkMenu(DinosaurService service)
    {
        _service = service;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n=== NeoGenesis Park ===");
            Console.WriteLine("1. Register dinosaur");
            Console.WriteLine("2. Queries");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    RegisterDinosaur();
                    break;
                case "2":
                    QueryMenu();
                    break;
                case "3":
                    UpdateMenu();
                    break;
                case "4":
                    DeleteMenu();
                    break;
                case "5":
                    Console.Write("Are you sure you want to exit? (Y/N): ");
                    var confirm = Console.ReadLine()?.Trim().ToUpperInvariant();
                    if (confirm == "Y") return;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private void RegisterDinosaur()
    {
        try
        {
            Console.WriteLine("\n=== Register Dinosaur ===");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine() ?? string.Empty;

            Console.Write("Last Name (Species): ");
            string lastName = Console.ReadLine() ?? string.Empty;

            Console.Write("Username: ");
            string username = Console.ReadLine() ?? string.Empty;

            Console.Write("Email: ");
            string email = Console.ReadLine() ?? string.Empty;

            Console.Write("Password: ");
            string password = Console.ReadLine() ?? string.Empty;

            Console.Write("Age: ");
            string ageInput = Console.ReadLine() ?? "0";
            int age = int.TryParse(ageInput, out var a) ? a : 0;

            Console.Write("Type (Carnivore/Herbivore): ");
            string type = Console.ReadLine() ?? string.Empty;

            Console.Write("Zone: ");
            string zone = Console.ReadLine() ?? string.Empty;

            Console.Write("Sector: ");
            string sector = Console.ReadLine() ?? string.Empty;

            Console.Write("Phone (tracking device): ");
            string phone = Console.ReadLine() ?? string.Empty;

            var dino = new Dinosaur
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Email = email,
                Password = password,
                Age = age,
                Type = type,
                Zone = zone,
                Sector = sector,
                Phone = phone,
                CreationDate = DateTime.UtcNow
            };

            _service.Register(dino);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void QueryMenu()
    {
        while (true)
        {
            Console.WriteLine("\n=== Queries ===");
            Console.WriteLine("1.  List all dinosaurs");
            Console.WriteLine("2.  View detail by ID");
            Console.WriteLine("3.  View detail by registration code (email)");
            Console.WriteLine("4.  Filter by zone and sector");
            Console.WriteLine("5.  Filter by age and diet type");
            Console.WriteLine("6.  Full names and registration codes report");
            Console.WriteLine("7.  Count by zone and sector");
            Console.WriteLine("8.  List dinosaurs without tracking device or location");
            Console.WriteLine("9.  List sorted by registration date");
            Console.WriteLine("10. List sorted alphabetically by species");
            Console.WriteLine("0.  Back");
            Console.Write("Select an option: ");

            var input = Console.ReadLine();

            try
            {
                switch (input)
                {
                    case "1":
                        Console.WriteLine("\n=== All Dinosaurs ===");
                        ShowList(_service.GetAll());
                        break;
                    case "2":
                        Console.Write("Enter ID: ");
                        var idInput = Console.ReadLine();
                        if (int.TryParse(idInput, out var id))
                        {
                            ShowOne(_service.GetById(id));
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter email: ");
                        var emailInput = Console.ReadLine() ?? string.Empty;
                        ShowOne(_service.GetByEmail(emailInput));
                        break;
                    case "4":
                        FilterByZoneAndSector();
                        break;
                    case "5":
                        FilterByAgeOrType();
                        break;
                    case "6":
                        ShowNameAndEmailReport(_service.GetNameAndEmailReport());
                        break;
                    case "7":
                        Console.WriteLine("\n=== Count by Zone ===");
                        foreach (var item in _service.CountByZone())
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("\n=== Count by Sector ===");
                        foreach (var item in _service.CountBySector())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "8":
                        GetWithoutTracking();
                        break;
                    case "9":
                        Console.WriteLine("\n=== Sorted by Registration Date (newest first) ===");
                        ShowList(_service.GetOrderedByCreatedDesc());
                        break;
                    case "10":
                        Console.WriteLine("\n=== Sorted Alphabetically by Species ===");
                        ShowList(_service.GetOrderedBySpecies());
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private void FilterByAgeOrType()
    {
        Console.WriteLine("\n=== Filter ===");
        Console.WriteLine("1. Filter by minimum age");
        Console.WriteLine("2. Filter by diet type");
        Console.Write("Select: ");

        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Console.Write("Enter minimum age: ");
                var ageInput = Console.ReadLine();
                if (int.TryParse(ageInput, out var age) && age >= 0)
                {
                    Console.WriteLine($"\n=== Dinosaurs with age >= {age} ===");
                    ShowList(_service.FilterByMinAge(age));
                }
                else
                {
                    Console.WriteLine("Invalid age. Must be a non-negative integer.");
                }
                break;
            case "2":
                Console.Write("Enter type (Carnivore/Herbivore): ");
                var type = Console.ReadLine() ?? string.Empty;
                Console.WriteLine($"\n=== Dinosaurs of type: {type} ===");
                ShowList(_service.FilterByType(type));
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    private void UpdateMenu()
    {
        while (true)
        {
            Console.WriteLine("\n=== Update ===");
            Console.WriteLine("1. Update dinosaur data fields");
            Console.WriteLine("2. Update security code");
            Console.WriteLine("0. Back");
            Console.Write("Select an option: ");

            var input = Console.ReadLine();

            try
            {
                switch (input)
                {
                    case "1":
                        UpdateFields();
                        break;
                    case "2":
                        UpdatePassword();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private void UpdateFields()
    {
        Console.Write("Enter dinosaur ID: ");
        var idInput = Console.ReadLine();
        if (!int.TryParse(idInput, out var id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        var existing = _service.GetById(id);
        if (existing == null)
        {
            Console.WriteLine("Dinosaur not found.");
            return;
        }

        Console.WriteLine("Current data:");
        ShowOne(existing);
        Console.WriteLine("\nPress Enter to keep current value.");

        Console.Write($"First Name ({existing.FirstName}): ");
        var firstName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(firstName)) existing.FirstName = firstName;

        Console.Write($"Last Name ({existing.LastName}): ");
        var lastName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(lastName)) existing.LastName = lastName;

        Console.Write($"Username ({existing.Username}): ");
        var username = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(username)) existing.Username = username;

        Console.Write($"Email ({existing.Email}): ");
        var email = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(email)) existing.Email = email;

        Console.Write($"Age ({existing.Age}): ");
        var ageInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(ageInput) && int.TryParse(ageInput, out var age))
            existing.Age = age;

        Console.Write($"Type ({existing.Type}): ");
        var type = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(type)) existing.Type = type;

        Console.Write($"Zone ({existing.Zone}): ");
        var zone = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(zone)) existing.Zone = zone;

        Console.Write($"Sector ({existing.Sector}): ");
        var sector = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(sector)) existing.Sector = sector;

        Console.Write($"Phone ({existing.Phone}): ");
        var phone = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(phone)) existing.Phone = phone;

        _service.Update(existing);
    }

    private void UpdatePassword()
    {
        Console.Write("Enter dinosaur ID: ");
        var idInput = Console.ReadLine();
        if (!int.TryParse(idInput, out var id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        var existing = _service.GetById(id);
        if (existing == null)
        {
            Console.WriteLine("Dinosaur not found.");
            return;
        }

        Console.Write("Enter new password: ");
        var newPassword = Console.ReadLine() ?? string.Empty;

        Console.Write("Confirm new password: ");
        var confirmPassword = Console.ReadLine() ?? string.Empty;

        if (newPassword != confirmPassword)
        {
            Console.WriteLine("Passwords do not match.");
            return;
        }

        _service.ChangePassword(id, newPassword);
    }

    private void DeleteMenu()
    {
        while (true)
        {
            Console.WriteLine("\n=== Delete ===");
            Console.WriteLine("1. Delete by ID");
            Console.WriteLine("2. Delete by registration code (email)");
            Console.WriteLine("0. Back");
            Console.Write("Select an option: ");

            var input = Console.ReadLine();

            try
            {
                switch (input)
                {
                    case "1":
                        DeleteById();
                        break;
                    case "2":
                        DeleteByEmail();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private void DeleteById()
    {
        Console.Write("Enter dinosaur ID: ");
        var idInput = Console.ReadLine();
        if (!int.TryParse(idInput, out var id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        var dino = _service.GetById(id);
        if (dino == null)
        {
            Console.WriteLine("No dinosaur found with that ID.");
            return;
        }

        Console.WriteLine("Dinosaur found:");
        ShowOne(dino);

        Console.Write("Are you sure you want to delete this dinosaur? (Y/N): ");
        var confirm = Console.ReadLine()?.Trim().ToUpperInvariant();

        if (confirm == "Y")
        {
            var ok = _service.DeleteById(id);
            if (ok) Console.WriteLine("Dinosaur deleted successfully.");
            else Console.WriteLine("Could not delete the dinosaur.");
        }
        else
        {
            Console.WriteLine("Operation cancelled. No changes were made.");
        }
    }

    private void DeleteByEmail()
    {
        Console.Write("Enter the registration code (email) to delete: ");
        var email = Console.ReadLine() ?? string.Empty;

        var dino = _service.GetByEmail(email);
        if (dino == null)
        {
            Console.WriteLine("No dinosaur exists with that email.");
            return;
        }

        Console.WriteLine("Dinosaur found:");
        ShowOne(dino);

        Console.Write("Are you sure you want to delete this dinosaur? (Y/N): ");
        var confirm = Console.ReadLine()?.Trim().ToUpperInvariant();

        if (confirm == "Y")
        {
            var ok = _service.DeleteByEmail(email);
            if (ok) Console.WriteLine("Dinosaur deleted successfully.");
            else Console.WriteLine("Could not delete the dinosaur.");
        }
        else
        {
            Console.WriteLine("Operation cancelled. No changes were made.");
        }
    }

    private void FilterByZoneAndSector()
    {
        Console.Write("Enter zone: ");
        var zone = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter sector: ");
        var sector = Console.ReadLine() ?? string.Empty;

        Console.WriteLine($"\n=== Dinosaurs in Zone: {zone}, Sector: {sector} ===");
        ShowList(_service.FilterByZoneAndSector(zone, sector));
    }

    private void GetWithoutTracking()
    {
        Console.WriteLine("\n=== Dinosaurs without tracking device or location ===");
        ShowList(_service.GetWithoutTracking());
    }

    private void ShowList(IEnumerable<Dinosaur> list)
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

    private void ShowOne(Dinosaur? dino)
    {
        if (dino == null)
            Console.WriteLine("Dinosaur not found.");
        else
            Console.WriteLine($"{dino.Id} | {dino.FirstName} | {dino.LastName} | {dino.Username} | {dino.Email} | Age: {dino.Age} | Type: {dino.Type} | Created: {dino.CreationDate:yyyy-MM-dd HH:mm:ss} UTC");
    }

    private void ShowNameAndEmailReport(IEnumerable<Dinosaur> list)
    {
        Console.WriteLine("\n=== Dinosaur Report (Name & Email) ===");
        var data = list.Select(d => new
        {
            FullName = d.FirstName + " " + d.LastName,
            d.Email
        }).ToList();

        foreach (var item in data)
        {
            Console.WriteLine($"Name: {item.FullName} | Email: {item.Email}");
        }

        Console.WriteLine($"Total dinosaurs: {data.Count}");
    }
}
