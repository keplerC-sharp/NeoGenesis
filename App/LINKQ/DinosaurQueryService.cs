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

    public IEnumerable<App.Entities.Dinosaur> FilterByType(string Type)
    {
        return _repository.GetAll().Where(d => d.Type == Type);
    }

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

    public IEnumerable<Dinosaur> GetWithoutTracking()
    {
        return _repository.GetWithoutTracking();
    }

    public IEnumerable<Dinosaur> FilterByZoneAndSector(string zone, string sector)
    {
        return _repository.GetAll()
            .Where(d => d.Zone.ToLower() == zone.ToLower() &&
                        d.Sector.ToLower() == sector.ToLower());
    }

    public IEnumerable<object> CountByZone()
    {
        return _repository.GetAll()
            .GroupBy(d => d.Zone)
            .Select(g => new { Zone = g.Key, Count = g.Count() })
            .ToList();
    }

    public IEnumerable<object> CountBySector()
    {
        return _repository.GetAll()
            .GroupBy(d => d.Sector)
            .Select(g => new { Sector = g.Key, Count = g.Count() })
            .ToList();
    }
}
