namespace App.Repository;

public class DinosaurRepository
{
    readonly App.Data.NeoGenesisContext _ctx;

    public DinosaurRepository(App.Data.NeoGenesisContext ctx)
    {
        _ctx = ctx;
    }

    public IEnumerable<App.Entities.Dinosaur> GetAll()
    {
        return _ctx.Dinosaurs;
    }

    public App.Entities.Dinosaur? GetByEmail(string email)
    {
        return _ctx.Dinosaurs.FirstOrDefault(d => d.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public bool DeleteByEmail(string email)
    {
        var d = GetByEmail(email);
        if (d == null) return false;
        return _ctx.Dinosaurs.Remove(d);
    }
}
