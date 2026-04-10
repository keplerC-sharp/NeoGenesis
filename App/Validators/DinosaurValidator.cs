using App.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Validators;

public class DinosaurValidator
{
    private readonly NeoGenesisContext _context;

    public DinosaurValidator(NeoGenesisContext context)
    {
        _context = context;
    }

    public bool UniqueEmail(string email)
    {
        return !_context.Dinosaurs
            .Any(d => d.Email.ToLower() == email.ToLower());
    }

    public bool UniqueUserName(String username)
    {
        return !_context.Dinosaurs
            .Any(d => d.Username.ToLower() == username.ToLower());
    }

}

