using System.Text.Json;
using System.Text.RegularExpressions;

///Tic tac toe
var board = new char[3, 3]
{
    {'X', 'O', 'X'},
    {'O', 'X', 'O'},
    {'X', 'X', 'O'}
};

var ticTacToe = new TicTacToe(board);
Console.WriteLine("Is won by X? " + ticTacToe.IsWonBy('X'));
Console.WriteLine("Is won by O? " + ticTacToe.IsWonBy('O'));

//Reducing the number of parameters - Splitting the method
var gameSaver = new GameSaver();
var gameData = new GameData();

string saveFileName = "game";
string saveFileExtension = "gdf";

var saveFileFinalPath = gameSaver.BuildFileName(
    saveFileName,
    saveFileExtension);

gameSaver.Save(gameData, saveFileFinalPath);

//Reducing the number of parameters - Removing a boolean parameter
var point1 = new Point(0, 0);
var point2 = new Point(10, 30);

var distance1 = CalculateDistance(point1, point2, true);
var distance2 = CalculateDistance(point1, point2, false);

var distanceInKm = CalculateDistanceInKilometers(point1, point2);
var distanceInMiles = UnitConverter.KilometersToMiles(distanceInKm);

//PersonalDataFormatter - composition approach
bool shallReadFromDatabase = false;

IPersonalDataReader personalDataReader = shallReadFromDatabase ?
    new DatabaseSourcedPersonalDataReader() :
    new ExcelSourcedPersonalDataReader();

var personalDataFormatter = new PersonalDataFormatter(
    personalDataReader);

Console.WriteLine(personalDataFormatter.Format());

Console.ReadKey();

//Reducing the number of parameters - bundling parameters together

//here are too many parameters - better to aggregate them, as below
//IDatabaseConnection ConnectToDatabase(
//    string userName,
//    string password,
//    string databaseName,
//    string databaseServerName,
//    string databaseClusterName)
//{
//    throw new NotImplementedException();
//}

IDatabaseConnection ConnectToDatabase(
    UserCredentials userCredentials,
    DatabaseIdentity databaseIdentity)
{
    throw new NotImplementedException();
}

//poor design - this method does two things instead of one
double CalculateDistance(
    Point point1, Point point2, bool shouldBeAsMiles)
{
    double deltaX = point2.X - point1.X;
    double deltaY = point2.Y - point1.Y;

    var distanceInKm = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

    if (shouldBeAsMiles)
    {
        const double kilometersToMilesConversionFactor = 0.621371;
        return distanceInKm * kilometersToMilesConversionFactor;
    }
    return distanceInKm;
}

//better design - two seaprate methods, no need for a boolean parameter
double CalculateDistanceInKilometers(
    Point point1, Point point2)
{
    double deltaX = point2.X - point1.X;
    double deltaY = point2.Y - point1.Y;

    return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
}

var _authorizedUsers = new HashSet<string> { "user1", "user2" };

//reasonable usage of boolean parameter
bool IsAuthorized(string userName, bool isAdmin)
{
    if (isAdmin)
    {
        return true;
    }
    return _authorizedUsers.Contains(userName);
}

//methods with one job only
float Power(float number)
{
    return number * number;
}

void Greet(string name)
{
    Console.WriteLine("Hello, " + name);
}

bool IsEven(int number)
{
    return number % 2 == 0;
}

//this one also does one task only, but it is composed of substeps
List<User> ReadUsersData()
{
    var apiConnection = ConnectToApi("https://someApi/", "api/users");
    var usersAsJson = apiConnection.ReadAll();
    return JsonSerializer.Deserialize<List<User>>(usersAsJson);
}

//two responsibilities instead of one - should be refactored
void SaveToFile(List<string> words, string filePath)
{
    var nonEmptyWords = new List<string>();
    foreach (var word in words)
    {
        if (!string.IsNullOrEmpty(word))
        {
            nonEmptyWords.Add(word);
        }
    }

    string text = string.Join(Environment.NewLine, nonEmptyWords);
    File.WriteAllText(filePath, text);
}

//after refactoring:
void SaveNonEmptyToFile(List<string> words, string filePath)
{
    List<string> nonEmptyWords = GetNonEmptyOnly(words);
    string textToBeSaved = string.Join(Environment.NewLine, nonEmptyWords);
    File.WriteAllText(filePath, textToBeSaved);
}

List<string> GetNonEmptyOnly(List<string> words)
{
    var strings = "some,strings,split,with,commas";
    var split = strings.Split(',');

    var nonEmptyWords = new List<string>();
    foreach (var word in words)
    {
        if (!string.IsNullOrEmpty(word))
        {
            nonEmptyWords.Add(word);
        }
    }

    return nonEmptyWords;
}

IApiConnection ConnectToApi(string baseAddress, string requestUri)
{
    throw new NotImplementedException();
}

//this method will be hard to test,
//because static Now property cannot be mocked
string GetCurrentDayDescription()
{
    DateTime today = DateTime.Now;
    return $"Today is {today.DayOfWeek}";
}

//solution: a wrapper class + interface
//the interface can be mocked
interface IDateTime
{
    DateTime Now { get; }
}

class DateTimeWrapper : IDateTime
{
    public DateTime Now
    {
        get
        {
            return DateTime.Now;
        }
    }
}

public static class UnitConverter
{
    public static double KilometersToMiles(double kilometers)
    {
        const double kilometersToMilesConversionFactor = 0.621371;
        return kilometers * kilometersToMilesConversionFactor;
    }
}

public struct Circle
{
    public Point Center { get; }
    public float Radius { get; }

    //public Circle(float x, float y, float radius)
    //better to bundle X and Y together as Point
    public Circle(Point center, float radius)
    {
        Center = center;
        Radius = radius;
    }
}

public struct Point
{
    public float X { get; }
    public float Y { get; }
    public Point(float x, float y)
    {
        X = x;
        Y = y;
    }
}

public interface IDatabaseConnection
{

}

public struct DatabaseIdentity
{
    public string DatabaseName;
    public string DatabaseServerName;
    public string DatabaseClusterName;
}

public struct UserCredentials
{
    public string Username;
    public string Password;
}

public class User
{

}

public interface IApiConnection
{
    string ReadAll();
}

public class AdaptiveHeapSort
{
    //reasonable comment example:
    //Implements the Adaptive Heap Sort algorithm
    // https://en.wikipedia.org/wiki/Adaptive_heap_sort
    public static void Sort(int[] input)
    {
        int length = input.Length;

        // Build the initial max-heap
        for (int i = length / 2 - 1; i >= 0; i--)
        {
            Heapify(input, length, i);
        }

        for (int i = length - 1; i > 0; i--)
        {
            // Swap the root element (maximum) with the last element
            int temp = input[0];
            input[0] = input[i];
            input[i] = temp;

            // Call heapify on the reduced heap
            Heapify(input, i, 0);
        }
    }

    private static void Heapify(int[] input, int n, int i)
    {
        int largest = i;
        int leftChild = 2 * i + 1;
        int rightChild = 2 * i + 2;

        // Find the largest element among the root, left child, and right child
        if (leftChild < n && input[leftChild] > input[largest])
        {
            largest = leftChild;
        }

        if (rightChild < n && input[rightChild] > input[largest])
        {
            largest = rightChild;
        }

        // If the largest element is not the root, swap them and recursively heapify the affected sub-tree
        if (largest != i)
        {
            int swap = input[i];
            input[i] = input[largest];
            input[largest] = swap;

            Heapify(input, n, largest);
        }
    }
}

public class EmailValidator
{
    public static bool IsValidEmail(string email)
    {
        // reasonable comment example: 
        // Simple email validation pattern
        // This pattern checks for valid characters,
        // the "@" symbol, domain names, and top-level domains (TLDs).

        // Examples of matching strings:
        // somebody@gmail.com
        // someone@yahoo.fr
        //
        // Examples of non-matching strings:
        // somebody@gmail
        // @yahoo.fr
        string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";

        return Regex.IsMatch(email, pattern);
    }
}
