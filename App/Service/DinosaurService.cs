using System;
using App.Repository;
using App.Validators;
using App.Entities;
using App.LINKQ;

namespace App.Service;

public class DinosaurService
{
    private readonly DinosaurRepository _repository;
    private readonly DinosaurValidator _validator;
    readonly DinosaurQueryService _queries;

    public DinosaurService(DinosaurRepository repository, 
        DinosaurValidator validator,
        DinosaurQueryService queries)
    {
        _repository = repository;
        _validator = validator;
        _queries = queries;
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
    
    public IEnumerable<App.Entities.Dinosaur> GetAll()
    {
        return _queries.GetAll();
    }

    public IEnumerable<App.Entities.Dinosaur> GetOrderedByCreatedDesc()
    {
        return _queries.OrderByCreatedDesc();
    }

    public IEnumerable<App.Entities.Dinosaur> GetOrderedBySpecies()
    {
        return _queries.OrderBySpecies();
    }

    public IEnumerable<App.Entities.Dinosaur> FilterByMinAge(int minAge)
    {
        return _queries.FilterByMinAge(minAge);
    }

    /*public IEnumerable<App.Entities.Dinosaur> FilterByDiet(App.Entities.DietType diet)
    {
        return _queries.FilterByDiet(diet);
    }*/

    public bool DeleteByEmail(string email)
    {
        return _repository.DeleteByEmail(email);
    }

    public App.Entities.Dinosaur? GetByEmail(string email)
    {
        return _repository.GetByEmail(email);
    }
}