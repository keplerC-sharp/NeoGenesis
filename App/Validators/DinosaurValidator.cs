using App.Repository;

namespace App.Validators;

public class DinosaurValidator
{
    private readonly DinosaurRepository _repository;

    public DinosaurValidator(DinosaurRepository repository)
    {
        _repository = repository;
    }

    public void UsernameValidator(string username)
    {
        if (_repository.ExistsByUsername(username))
            throw new Exception("Username already registered.");
    }
}