using App.Data;
using App.Entities;

namespace App.LINKQ;

public class DinosaurQueryService
{
    private readonly NeoGenesisContext _context;
    public void ViewDinosaurById(NeoGenesisContext context)
    {
        _context = context;
    }

    public var found(string regCode)
    {
        var found = _context.Dinosaurs.where(code => code regCode)
    }
    
}