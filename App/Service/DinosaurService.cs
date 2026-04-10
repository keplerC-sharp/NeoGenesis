using App.Data;
using App.Entities;
using App.Validators;

namespace App.Service;

public class DinosaurService
{
    private readonly NeoGenesisContext _context;
    private readonly DinosaurValidator _validator;

    public DinosaurService(NeoGenesisContext context, DinosaurValidator validator)
    {
        _context = context;
        _validator = validator;
    }

    public string Register(Dinosaur dinosaur)
    {
        if (!_validator.UniqueEmail(dinosaur.Email))
            return "Sorry, this email is already registered";

        if (!_validator.UniqueUserName(dinosaur.Username))
            return "Sorry, the username is already in use";

        _context.Dinosaurs.Add(dinosaur);
        _context.SaveChanges();
        return "Successfully registered dinosaur";
    }
}