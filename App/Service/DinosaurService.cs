namespace App.Service;

public class DinosaurService
{
    readonly App.Repository.DinosaurRepository _repo;
    readonly App.LINKQ.DinosaurQueryService _queries;

    public DinosaurService(App.Repository.DinosaurRepository repo, App.LINKQ.DinosaurQueryService queries)
    {
        _repo = repo;
        _queries = queries;
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

    public IEnumerable<App.Entities.Dinosaur> FilterByDiet(App.Entities.DietType diet)
    {
        return _queries.FilterByDiet(diet);
    }

    public bool DeleteByEmail(string email)
    {
        return _repo.DeleteByEmail(email);
    }

    public App.Entities.Dinosaur? GetByEmail(string email)
    {
        return _repo.GetByEmail(email);
    }
}
