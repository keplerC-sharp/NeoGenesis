using App.Repository;
using App.Validators;
using App.Entities;

namespace App.Service;

public class DinosaurService
{
    private readonly DinosaurRepository _repository;
    private readonly DinosaurValidator _validator;

    public DinosaurService(DinosaurRepository repository, DinosaurValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }
    
    public void Register(Dinosaur dino)
    {
        _validator.ValidateFields(dino);

        if (_repository.GetByEmail(dino.Email) != null)
            throw new Exception("Email already registered.");

        if (_repository.GetByUsername(dino.Username) != null)
            throw new Exception("Username already registered.");

        _repository.Add(dino);

        Console.WriteLine("Dinosaur registered successfully!");
    }
}