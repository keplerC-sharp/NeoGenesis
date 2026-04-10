namespace App.Service;

public class DinosaurService
{
    readonly App.Repository.DinosaurRepository _repository;
    readonly App.LINKQ.DinosaurQueryService _queries;

    private readonly App.Validators.DinosaurValidator _validator;


    public DinosaurService(App.Repository.DinosaurRepository repository, 
    App.LINKQ.DinosaurQueryService queries,
    App.Validators.DinosaurValidator validator
    )
    {
        _repository = repository;
        _queries = queries;
        _validator = validator;

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
