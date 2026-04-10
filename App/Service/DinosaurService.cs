using App.Entities;
using App.Repository;
using App.Validators;

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

    public void Register(Dinosaur dinosaur)
    {
        _validator.UsernameValidator(dinosaur.Username);
        _repository.Add(dinosaur);
        Console.WriteLine("Dinosaur registered");
    }
}