public static class CleanCodeExercises
{
    public static string Reverse_Refactored(string input)
    {
        var resultCharacters = new char[input.Length];

        var currentIndex = input.Length - 1;
        foreach (var character in input)
        {
            resultCharacters[currentIndex] = character;
            --currentIndex;
        }

        return new string(resultCharacters);
    }

    public static string Reverse(string str)
    {
        var arr = new char[str.Length];

        var i = str.Length - 1;
        foreach (var _char in str)
        {
            arr[i] = _char;
            --i;
        }

        return new string(arr);
    }

    public static string BuildFilePathFrom_Refactored(
        DateTime dateTime, Extension extension)
    {
        var day = dateTime.Day;
        var dayOfWeek = dateTime.DayOfWeek;
        var month = dateTime.Month;
        var year = dateTime.Year;

        var fileExtension = extension.ToString().ToLower();
        var result = $"{dayOfWeek}_{day}_{month}_{year}.{fileExtension}";

        return result;
    }

    public static string BuildFilePathFrom(DateTime d, Extension ex)
    {
        var d1 = d.Day;
        var d2 = d.DayOfWeek;
        var m = d.Month;
        var y = d.Year;

        var format = ex.ToString().ToLower();
        var format2 = $"{d2}_{d1}_{m}_{y}.{format}";

        return format2;
    }

    public enum Extension
    {
        Txt,
        Json
    }

    public static List<int>? ChooseBetterPath_Refactored(
        List<int> primaryPathSectionsLengths,
        List<int> secondaryPathSectionLengths,
        int maxAcceptableSectionLength)
    {
        if (IsAnySectionLengthNegative(primaryPathSectionsLengths) ||
            IsAnySectionLengthNegative(secondaryPathSectionLengths))
        {
            throw new ArgumentException(
                "The input collections can't contain negative lengths.");
        }

        bool isPrimaryPathAcceptable = IsAcceptable(
            primaryPathSectionsLengths, maxAcceptableSectionLength);

        bool isSecondaryPathAcceptable = IsAcceptable(
            secondaryPathSectionLengths, maxAcceptableSectionLength);

        return ChooseBetterPath(
            primaryPathSectionsLengths, 
            secondaryPathSectionLengths, 
            isPrimaryPathAcceptable, 
            isSecondaryPathAcceptable);
    }

    private static bool IsAnySectionLengthNegative(List<int> pathSectionsLengths)
    {
        return pathSectionsLengths.Any(length => length < 0);
    }

    private static bool IsAcceptable(
        List<int> pathSectionsLengths, int maxAcceptableSectionLength)
    {
        return !pathSectionsLengths.Any(
            length => length > maxAcceptableSectionLength);
    }

    private static List<int>? ChooseBetterPath(
        List<int> primaryPathSectionsLengths,
        List<int> secondaryPathSectionLengths, 
        bool isPrimaryPathAcceptable, 
        bool isSecondaryPathAcceptable)
    {
        if (!isPrimaryPathAcceptable && !isSecondaryPathAcceptable)
        {
            return null;
        }
        if (isPrimaryPathAcceptable && isSecondaryPathAcceptable)
        {
            return SelectShorter(primaryPathSectionsLengths, secondaryPathSectionLengths);
        }
        if (isPrimaryPathAcceptable)
        {
            return primaryPathSectionsLengths;
        }
        return secondaryPathSectionLengths;
    }

    private static List<int> SelectShorter(
        List<int> primaryPathSectionsLengths,
        List<int> secondaryPathSectionLengths)
    {
        return primaryPathSectionsLengths.Sum() <= secondaryPathSectionLengths.Sum()
            ? primaryPathSectionsLengths
            : secondaryPathSectionLengths;
    }

    public static List<int>? ChooseBetterPath(
        List<int> lengths1,
        List<int> lengths2,
        int maxLength)
    {
        foreach (var number in lengths1)
        {
            if (number < 0)
            {
                throw new ArgumentException(
                    "The input collections can't contain negative lengths.");
            }
        }

        foreach (var number in lengths2)
        {
            if (number < 0)
            {
                throw new ArgumentException(
                    "The input collections can't contain negative lengths.");
            }
        }

        bool isLengths1Ok = true;
        foreach (var number in lengths1)
        {
            if (number > maxLength)
            {
                isLengths1Ok = false;
            }
        }

        bool isLengths2Ok = true;
        foreach (var number in lengths2)
        {
            if (number > maxLength)
            {
                isLengths2Ok = false;
            }
        }

        if (!isLengths1Ok && !isLengths2Ok)
        {
            return null;
        }
        else if (isLengths1Ok && isLengths2Ok)
        {
            if (lengths1.Sum() <= lengths2.Sum())
            {
                return lengths1;
            }
            return lengths2;
        }
        else if (isLengths1Ok)
        {
            return lengths1;
        }
        return lengths2;
    }

    public static (bool, string) IsValidName_Refactored(string name)
    {
        if (!IsLongEnough(name))
        {
            return (false, "The name is too short.");
        }
        if (!IsShortEnough(name))
        {
            return (false, "The name is too long.");
        }
        if (!DoesStartWithUppercase(name))
        {
            return (false, "The name starts with a lowercase letter.");
        }
        if (!ContainsLettersOnly(name))
        {
            return (false, "The name contains non-letter characters.");
        }
        if(!AllExceptFirstAreLowercase(name))
        {
            return (false, "The name contains uppercase letters after the first character.");
        }
        return (true, "The name is valid.");
    }

    private static bool IsShortEnough(string name)
    {
        const int MaxValidLength = 25;
        return name.Length <= MaxValidLength;
    }

    private static bool IsLongEnough(string name)
    {
        const int MinValidLength = 3;
        return name.Length >= MinValidLength;
    }

    private static bool DoesStartWithUppercase(string name)
    {
        return char.IsUpper(name.First());
    }

    private static bool ContainsLettersOnly(string name)
    {
        return name.All(character => char.IsLetter(character));
    }

    private static bool AllExceptFirstAreLowercase(string name)
    {
        return name.Skip(1).All(character => char.IsLower(character));
    }

    public static (bool, string) IsValidName(string name)
    {
        if (name.Length < 3)
        {
            return (false, "The name is too short.");
        }
        if (IsLong(name))
        {
            return (false, "The name is too long.");
        }
        if (name[0] == char.ToLower(name[0]))
        {
            return (false, "The name starts with a lowercase letter.");
        }
        foreach (var c in  name)
        {
            if (!char.IsLetter(c))
            {
                return (false, "The name contains non-letter characters.");
            }
        }
        for (int i = 1; i < name.Length; i++)
        {
            char c = name[i];
            if (c == char.ToUpper(c))
            {
                return (false, "The name contains uppercase letters after the first character.");
            }
        }
        return (true, "The name is valid.");
    }

    private static bool IsLong(string name)
    {
        return name.Length > 25;
    }
}