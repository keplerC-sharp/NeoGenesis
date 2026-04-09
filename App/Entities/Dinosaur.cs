using System.ComponentModel.DataAnnotations;

namespace App.Entities;

public class Dinosaur
{
    public int Id { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string Username { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    public string Password { get; set; }
    public int Age { get; set; }
    public string Type { get; set; }
    public string Zone { get; set; }
    public string Sector { get; set; }
    public string Phone { get; set; }
    
    // Auto Set
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;

}