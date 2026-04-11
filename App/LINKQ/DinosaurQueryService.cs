using System;
using App.Data;
using App.Entities;
using App.Repository;


namespace App.LINKQ;

public class DinosaurQueryService
{
    private readonly NeoGenesisContext _context;
    private readonly DinosaurRepository _repository;

    public DinosaurQueryService(NeoGenesisContext context, DinosaurRepository repository)
    {
        _context = context;
        _repository = repository;
    }
    public IEnumerable<App.Entities.Dinosaur> OrderByCreatedDesc()
    {
        return _repository.GetAll().OrderByDescending(d => d.CreationDate);
    }

    public IEnumerable<App.Entities.Dinosaur> OrderBySpecies()
    {
        return _repository.GetAll().OrderBy(d => d.LastName);
    }

    public IEnumerable<App.Entities.Dinosaur> FilterByMinAge(int minAge)
    {
        return _repository.GetAll().Where(d => d.Age >= minAge);
    }

    // public IEnumerable<App.Entities.Dinosaur> FilterByDiet(App.Entities.Type diet)
    // {
    //     return _repository.GetAll().Where(d => d.Diet == diet);
    // }

    public IEnumerable<App.Entities.Dinosaur> GetAll()
    {
        return _repository.GetAll();
    }
    
    public Dinosaur? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public IEnumerable<Dinosaur> GetNameAndEmailReport()
    {
        return _repository.GetAll();
    }

    // public var found(string regCode)
    // {
    //     var found = _context.Dinosaurs.where(code => code.regCode);
    // }
    
}
