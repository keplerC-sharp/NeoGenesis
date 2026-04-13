using System;
using System.Text.RegularExpressions;
using App.Entities;

namespace App.Validators;

public class DinosaurValidator
{
    public void ValidateFields(Dinosaur dino)
    {
        if (string.IsNullOrWhiteSpace(dino.FirstName) ||
            string.IsNullOrWhiteSpace(dino.LastName) ||
            string.IsNullOrWhiteSpace(dino.Username) ||
            string.IsNullOrWhiteSpace(dino.Email))
        {
            throw new Exception("All fields are required.");
        }

        if (!ValidateEmail(dino.Email))
        {
            throw new Exception("Invalid email format.");
        }
    }

    public bool ValidateEmail(string email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
    
    public bool TryParseNonNegativeInt(string? input, out int value)
    {
        value = 0;
        if (string.IsNullOrWhiteSpace(input)) return false;
        if (!int.TryParse(input, out var v)) return false;
        if (v < 0) return false;
        value = v;
        return true;
    }
    
    // public bool TryParseDiet(string? input, out App.Entities.DietType diet)
    // {
    //     diet = App.Entities.DietType.Carnivoro;
    //     if (string.IsNullOrWhiteSpace(input)) return false;
    //     var norm = input.Trim().ToLowerInvariant();
    //     if (norm is "c" or "car" or "carnivoro" or "carnívoro")
    //     {
    //         diet = App.Entities.DietType.Carnivoro;
    //         return true;
    //     }
    //     if (norm is "h" or "her" or "herbivoro" or "herbívoro")
    //     {
    //         diet = App.Entities.DietType.Herbivoro;
    //         return true;
    //     }
    //     return false;
    // }
}
