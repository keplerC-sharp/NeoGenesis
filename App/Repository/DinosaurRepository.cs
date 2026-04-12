using System.Collections.Generic;
using System.Linq;
using App.Data;
using App.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App.Repository;

public class DinosaurRepository
{
    private readonly NeoGenesisContext _context;

    public DinosaurRepository(NeoGenesisContext context)
    {
        _context = context;
    }

    // Obtener todos
    public List<Dinosaur> GetAll()
    {
        return _context.Dinosaurs.ToList();
    }

    // Obtener por Id
    public Dinosaur? GetById(int id)
    {
        return _context.Dinosaurs.FirstOrDefault(d => d.Id == id);
    }

    // Obtener por Email
    public Dinosaur? GetByEmail(string email)
    {
        return _context.Dinosaurs.FirstOrDefault(d => d.Email == email);
    }

    // Obtener por Username
    public Dinosaur? GetByUsername(string username)
    {
        return _context.Dinosaurs.FirstOrDefault(d => d.Username == username);
    }

    // Agregar
    public void Add(Dinosaur dino)
    {
        _context.Dinosaurs.Add(dino);
        _context.SaveChanges();
    }

    // Actualizar
    public void Update(Dinosaur dino)
    {
        _context.Dinosaurs.Update(dino);
        _context.SaveChanges();
    }
    
    // Filtrar por Zone y Sector
    public IEnumerable<Dinosaur> GetByZoneAndSector(string zone, string sector)
    {
        return _context.Dinosaurs
            .Where(d => d.Zone.ToLower() == zone.ToLower() &&
                        d.Sector.ToLower() == sector.ToLower())
            .ToList();
    }
    
    // Listar sin tener tracking o location
    public IEnumerable<Dinosaur> GetWithoutTracking()
    {
        return _context.Dinosaurs
            .Where(d => d.TrackingDevice == null && d.Location == null)
            .ToList();
    }

    // Eliminar por Id
    public bool Delete(int id)
    {
        var dino = GetById(id);

        if (dino == null)
            return false;

        _context.Dinosaurs.Remove(dino);
        _context.SaveChanges();
        return true;
    }

    // Eliminar por Email (útil para tu Service)
    public bool DeleteByEmail(string email)
    {
        var dino = GetByEmail(email);

        if (dino == null)
            return false;

        _context.Dinosaurs.Remove(dino);
        _context.SaveChanges();
        return true;
    }
}