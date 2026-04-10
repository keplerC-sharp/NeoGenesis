using App.Data;
using App.Entities;

namespace App.Repository;

public class DinosaurRepository
{
    private readonly NeoGenesisContext _context;

    public DinosaurRepository(NeoGenesisContext context)
    {
        _context = context;
    }

    public bool ExistsByUsername(string username)
    {
        return _context.Dinosaurs.Any(d => d.Username == username);
    }

    public void Add(Dinosaur dino)
    {
        _context.Dinosaurs.Add(dino);
        _context.SaveChanges();
    }
}