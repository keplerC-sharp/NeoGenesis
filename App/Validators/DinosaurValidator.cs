namespace App.Validators;

public class DinosaurValidator
{
    public bool TryParseNonNegativeInt(string? input, out int value)
    {
        value = 0;
        if (string.IsNullOrWhiteSpace(input)) return false;
        if (!int.TryParse(input, out var v)) return false;
        if (v < 0) return false;
        value = v;
        return true;
    }

    public bool TryParseDiet(string? input, out App.Entities.DietType diet)
    {
        diet = App.Entities.DietType.Carnivoro;
        if (string.IsNullOrWhiteSpace(input)) return false;
        var norm = input.Trim().ToLowerInvariant();
        if (norm is "c" or "car" or "carnivoro" or "carnívoro")
        {
            diet = App.Entities.DietType.Carnivoro;
            return true;
        }
        if (norm is "h" or "her" or "herbivoro" or "herbívoro")
        {
            diet = App.Entities.DietType.Herbivoro;
            return true;
        }
        return false;
    }
}
