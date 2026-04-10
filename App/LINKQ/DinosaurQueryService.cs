namespace App.LINKQ;

public class DinosaurQueryService
{
    readonly App.Repository.DinosaurRepository _repo;

    public DinosaurQueryService(App.Repository.DinosaurRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<App.Entities.Dinosaur> OrderByCreatedDesc()
    {
        return _repo.GetAll().OrderByDescending(d => d.CreatedAt);
    }

    public IEnumerable<App.Entities.Dinosaur> OrderBySpecies()
    {
        return _repo.GetAll().OrderBy(d => d.LastName);
    }

    public IEnumerable<App.Entities.Dinosaur> FilterByMinAge(int minAge)
    {
        return _repo.GetAll().Where(d => d.Age >= minAge);
    }

    public IEnumerable<App.Entities.Dinosaur> FilterByDiet(App.Entities.DietType diet)
    {
        return _repo.GetAll().Where(d => d.Diet == diet);
    }

    public IEnumerable<App.Entities.Dinosaur> GetAll()
    {
        return _repo.GetAll();
    }
}
