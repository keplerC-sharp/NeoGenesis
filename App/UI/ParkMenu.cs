using App.Service;

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
                    // call _service.Register(...)
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
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
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

            switch (input)
            {
                case "1":
                    // call _service.GetAll(...)
                    break;
                case "2":
                    // call _service.GetById(...)
                    break;
                case "3":
                    // call _service.GetByEmail(...)
                    break;
                case "4":
                    // call _service.FilterByZoneAndSector(...)
                    break;
                case "5":
                    // call _service.FilterByAgeAndDiet(...)
                    break;
                case "6":
                    // call _service.GetFullNamesReport(...)
                    break;
                case "7":
                    // call _service.CountByZoneAndSector(...)
                    break;
                case "8":
                    // call _service.GetWithoutTrackingOrLocation(...)
                    break;
                case "9":
                    // call _service.GetSortedByDate(...)
                    break;
                case "10":
                    // call _service.GetSortedBySpecies(...)
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
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

            switch (input)
            {
                case "1":
                    // call _service.UpdateFields(...)
                    break;
                case "2":
                    // call _service.UpdateSecurityCode(...)
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
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

            switch (input)
            {
                case "1":
                    // call _service.DeleteById(...)
                    break;
                case "2":
                    // call _service.DeleteByEmail(...)
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
