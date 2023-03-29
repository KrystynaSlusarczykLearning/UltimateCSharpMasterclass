public class CSharpFundamentalsExercises
{
    //Variables and operators
    public static int VariablesAndOperators()
    {
        var a = 5;
        var b = 10;
        var c = -4;

        int result = (a + b) / c;

        return result;
    }

    //Boolean type and operators
    public static bool BooleanTypesAndOperators()
    {
        int a = 5;
        int b = 12;

        bool isSumLargerOrEqualTo10 = (a + b) >= 17;
        return isSumLargerOrEqualTo10;
    }

    //if/else conditional statement
    public static string IsElseConditionalStatement()
    {
        int number = 0;
        string result;

        if (number < 0)
        {
            result = "negative";
        }
        else if (number == 0)
        {
            result = "zero";
        }
        else
        {
            result = "positive";
        }

        return result;
    }

    //Methods - AbsoluteOfSum method
    public static int AbsoluteOfSum(int a, int b)
    {
        var sum = a + b;
        if (sum >= 0)
        {
            return sum;
        }
        return -sum;

        //Alternative solution:
        //return Math.Abs(a + b);
    }

    //String interpolation - FormatDate
    public static string FormatDate(int year, int month, int day)
    {
        return $"{year}/{month}/{day}";
    }

    //Switch statement - DescribeDay
    public static string DescribeDay(int dayNumber)
    {
        switch (dayNumber)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                return "Working day";
            case 6:
            case 7:
                return "Weekend";
            default:
                return "Invalid day number";
        }
    }

    //While loop - CalculateSumOfNumbersBetween
    public static int CalculateSumOfNumbersBetween(
        int firstNumber, int lastNumber)
    {
        if (lastNumber < firstNumber)
        {
            return 0;
        }

        int currentNumber = firstNumber;
        int sum = 0;
        while (currentNumber <= lastNumber)
        {
            sum += currentNumber;
            currentNumber++;
        }
        return sum;
    }

    //Do-while loop - RepeatCharacter
    public static string RepeatCharacter(char character, int targetLength)
    {
        string result = "";
        do
        {
            result += character;
        }
        while (result.Length < targetLength);

        return result;
    }

    //For loop - Factorial
    public static int Factorial(int number)
    {
        var result = 1;
        for (int i = 1; i <= number; ++i)
        {
            result *= i;
        }
        return result;
    }

    //Arrays (1) - BuildHelloString
    public static string BuildHelloString()
    {
        var letters = new char[] { 'h', 'e', 'l', 'l', 'o' };
        var result = "";
        for (int i = 0; i < letters.Length; ++i)
        {
            result += letters[i];
        }
        return result;
    }

    //Arrays (2) - IsWordPresentInCollection
    public static bool IsWordPresentInCollection(
        string[] words, string wordToBeChecked)
    {
        for (var i = 0; i < words.Length; ++i)
        {
            if (words[i] == wordToBeChecked)
            {
                return true;
            }
        }
        return false;
    }

    //Multi-dimensional arrays - FindMax
    public static int FindMax(int[,] numbers)
    {
        int height = numbers.GetLength(0);
        if (height == 0)
        {
            return -1;
        }

        int width = numbers.GetLength(1);
        if (width == 0)
        {
            return -1;
        }

        int max = numbers[0, 0];

        for (var i = 0; i < height; ++i)
        {
            for (var j = 0; j < width; ++j)
            {
                var number = numbers[i, j];
                if (number > max)
                {
                    max = number;
                }
            }
        }
        return max;
    }

    //Foreach loop - IsAnyWordLongerThan
    public static bool IsAnyWordLongerThan(int length, string[] words)
    {
        foreach (var word in words)
        {
            if (word.Length > length)
            {
                return true;
            }
        }
        return false;
    }

    //Lists - GetOnlyUpperCaseWords
    public List<string> GetOnlyUpperCaseWords(List<string> words)
    {
        var result = new List<string>();
        foreach (var word in words)
        {
            if (result.Contains(word))
            {
                continue;
            }
            if (IsUpperCase(word))
            {
                result.Add(word);
            }
        }
        return result;
    }

    bool IsUpperCase(string word)
    {
        foreach (char letter in word)
        {
            if (!char.IsUpper(letter))
            {
                return false;
            }
        }
        return true;
    }
}