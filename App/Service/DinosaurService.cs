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
    
    public void Update(Dinosaur updatedDino)
    {
        var existing = _repository.GetById(updatedDino.Id);

        if (existing == null)
            throw new Exception("Dinosaur not found.");

        // Validar campos obligatorios
        if (string.IsNullOrWhiteSpace(updatedDino.FirstName) ||
            string.IsNullOrWhiteSpace(updatedDino.LastName) ||
            string.IsNullOrWhiteSpace(updatedDino.Username) ||
            string.IsNullOrWhiteSpace(updatedDino.Email))
        {
            throw new Exception("Required fields cannot be empty.");
        }

        // Validar email formato
        _validator.ValidateEmail(updatedDino.Email);

        // Validar duplicados (si cambian)
        if (existing.Email != updatedDino.Email &&
            _repository.GetByEmail(updatedDino.Email) != null)
        {
            throw new Exception("Email already registered.");
        }

        if (existing.Username != updatedDino.Username &&
            _repository.GetByUsername(updatedDino.Username) != null)
        {
            throw new Exception("Username already registered.");
        }

        // Permitir actualizar TODOS los campos
        existing.FirstName = updatedDino.FirstName;
        existing.LastName = updatedDino.LastName;
        existing.Username = updatedDino.Username;
        existing.Email = updatedDino.Email;
        existing.Password = updatedDino.Password;
        existing.Age = updatedDino.Age;
        existing.Type = updatedDino.Type;
        existing.Zone = updatedDino.Zone;
        existing.Sector = updatedDino.Sector;
        existing.Phone = updatedDino.Phone;

        // Guardar cambios
        _repository.Update(existing);

        // Confirmación
        Console.WriteLine("Dinosaur updated successfully!");
    }
    
    public IEnumerable<App.Entities.Dinosaur> GetAll()
    {
        return _queries.GetAll();
    }
    
    
    // Get By Id
    public Dinosaur? GetById(int id)
    {
        return _queries.GetById(id);
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

    public IEnumerable<App.Entities.Dinosaur> FilterByType(string Type)
    {
<<<<<<< HEAD
        return _queries.FilterByDiet(diet);
    }*/
    
    public IEnumerable<Dinosaur> FilterByZoneAndSector(string zone, string sector)
    {
        return _queries.FilterByZoneAndSector(zone, sector);
    }
    
    public IEnumerable<Dinosaur> GetWithoutTracking()
    {
        return _queries.GetWithoutTracking();
    }
    
    public bool DeleteById(int id)
    {
        return _repository.Delete(id);
=======
        return _queries.FilterByType(Type);
>>>>>>> origin/Develop
    }

    public bool DeleteByEmail(string email)
    {
        return _repository.DeleteByEmail(email);
    }

    public App.Entities.Dinosaur? GetByEmail(string email)
    {
        return _repository.GetByEmail(email);
    }

    public void ChangePassword(int id, string newPassword)
    {
        var existing = _repository.GetById(id);

        if (existing == null)
            throw new Exception("Dinosaur not found.");

        existing.Password = newPassword;
        _repository.Update(existing);

        Console.WriteLine("Password updated successfully!");
    }

    public IEnumerable<App.Entities.Dinosaur> GetNameAndEmailReport()
    {
        return _queries.GetNameAndEmailReport();
    }

    public IEnumerable<object> CountByZone()
    {
        return _queries.CountByZone();
    }

    public IEnumerable<object> CountBySector()
    {
        return _queries.CountBySector();
    }
}
