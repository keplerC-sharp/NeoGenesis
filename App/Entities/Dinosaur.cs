namespace App.Entities;

public enum DietType
{
    Carnivoro,
    Herbivoro
}

public class Dinosaur
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty
        ;
    public string LastName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Age { get; set; }
    public DietType Diet { get; set; }
    public DateTime CreatedAt { get; set; }
}
