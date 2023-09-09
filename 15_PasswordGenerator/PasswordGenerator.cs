public class PasswordGenerator
{
    private readonly IRandom _random;

    public PasswordGenerator(IRandom random)
    {
        _random = random;
    }

    public string Generate(
        int minLength, int maxLength, bool shallUseSpecialCharacters)
    {
        Validate(minLength, maxLength);

        var passwordLength = GeneratePasswordLength(minLength, maxLength);

        var charactersToBeIncluded = shallUseSpecialCharacters ?
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=" :
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        return GenerateRandomString(passwordLength, charactersToBeIncluded);
    }

    private static void Validate(int minLength, int maxLength)
    {
        if (minLength < 1)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(minLength)} must be greater than 0");
        }
        if (maxLength < minLength)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(minLength)} must be smaller than {nameof(maxLength)}");
        }
    }

    private int GeneratePasswordLength(int minLength, int maxLength)
    {
        return _random.Next(minLength, maxLength + 1);
    }

    private string GenerateRandomString(
        int length,
        string charactersToBeIncluded)
    {
        var passwordCharacters =
            Enumerable.Repeat(charactersToBeIncluded, length)
            .Select(characters => characters[_random.Next(characters.Length)])
            .ToArray();

        return new string(passwordCharacters);
    }
}
