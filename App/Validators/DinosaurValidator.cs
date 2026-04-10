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
}