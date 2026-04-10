namespace App.Data;

public class NeoGenesisContext
{
    public List<App.Entities.Dinosaur> Dinosaurs { get; } = new();

    public NeoGenesisContext()
    {
        Seed();
    }

    void Seed()
    {
        if (Dinosaurs.Count > 0) return;
        Dinosaurs.AddRange(new[]
        {
            new App.Entities.Dinosaur
            {
                Id = 1,
                FirstName = "Rex",
                LastName = "Tyrannosaurus",
                UserName = "t-rex",
                Email = "rex@park.com",
                Age = 12,
                Diet = App.Entities.DietType.Carnivoro,
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            },
            new App.Entities.Dinosaur
            {
                Id = 2,
                FirstName = "Blue",
                LastName = "Velociraptor",
                UserName = "raptor-blue",
                Email = "blue@park.com",
                Age = 8,
                Diet = App.Entities.DietType.Carnivoro,
                CreatedAt = DateTime.UtcNow.AddDays(-5)
            },
            new App.Entities.Dinosaur
            {
                Id = 3,
                FirstName = "Leaf",
                LastName = "Triceratops",
                UserName = "tri-leaf",
                Email = "leaf@park.com",
                Age = 15,
                Diet = App.Entities.DietType.Herbivoro,
                CreatedAt = DateTime.UtcNow.AddHours(-6)
            }
        });
    }
}
