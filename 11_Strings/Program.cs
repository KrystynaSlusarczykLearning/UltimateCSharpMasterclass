//char
using System.Diagnostics;
using System.Globalization;
using System.Text;

char letter = 'a';
char digit = '4';
char symbol = '!';
char newLine = '\n';

var isUppercase = char.IsUpper(letter); //will be false
var isLetter = char.IsLetter(digit); //will be false
var isDigit = char.IsDigit(letter); //will be false
var isWhitespace = char.IsWhiteSpace(newLine); //will give true
var aToUpper = char.ToUpper(letter); //will give 'A'

//chars and ints
char someChar = (char)100;
int asInt = (int)'t';

for (char c = 'A'; c < 'z'; ++c)
{
    Console.Write(c + ", ");
}
Console.WriteLine();

//encoding
Console.OutputEncoding = Encoding.Unicode;

Console.WriteLine("Greek omega letter:");
char omega = 'Ω';
Console.WriteLine(omega);
Console.WriteLine((int)omega);
Console.WriteLine("Arabic dal letter:");
char dal = 'د';
Console.WriteLine(dal);
Console.WriteLine((int)dal);

//immutability of strings
string text1 = "abc";

//the text1 will not be affected in this method
Modify(text1);
Console.WriteLine(text1);

string immutableText = "abc";
immutableText += "d"; //a new string is built here

var upperCase = immutableText.ToUpper();
Console.WriteLine(immutableText);
Console.WriteLine(upperCase);

//StringBuilder

Console.WriteLine("Please wait, testing performance of StringBuilder...");
const int Count = 100_000; //reduce this number if it takes too long

var text = string.Empty;
Stopwatch stopwatch = Stopwatch.StartNew();
for (int i = 0; i < Count; i++)
{
    text += "a";
}
stopwatch.Stop();
Console.WriteLine(
    $"Concatenation took {stopwatch.ElapsedMilliseconds} ms");

stopwatch.Restart();
var stringBuilder = new StringBuilder();
for (int i = 0; i < Count; i++)
{
    stringBuilder.Append("a");
}
var text2 = stringBuilder.ToString();
stopwatch.Stop();
Console.WriteLine(
    $"StringBuilder took {stopwatch.ElapsedMilliseconds} ms");

//String interning

string textA = "abc";
string textB = "abc";
Console.WriteLine(object.ReferenceEquals(textA, textB)); //will be true

//Formatting of strings
var number1 = 100;
var number2 = 200;

var formattedText = string.Format(
    "Number 1 is {0}, number 2 is {1,10:C}",
    number1,
    number2);

Console.WriteLine(formattedText);

decimal someDecimal = 1.46m;
Console.WriteLine(
    String.Format("Number is {0:C3}", someDecimal));
Console.WriteLine(
    String.Format("Number is {0:F1}", someDecimal));
Console.WriteLine(
    String.Format("Number is {0:P}", someDecimal));

Console.WriteLine();

DateTime someDate = new DateTime(2024, 5, 6, 12, 54, 12);
Console.WriteLine(
    $"Date is {someDate:d}");
Console.WriteLine(
    $"Date is {someDate:D}");
Console.WriteLine(
    String.Format("Date is {0:MM/yyyy}", someDate));

//Culture-specific string formatting
Console.WriteLine("Enter a number");
var userInput = Console.ReadLine();
decimal result = decimal.Parse(userInput); //uses current culture
Console.WriteLine("Number is " + result);

CultureInfo currentCulture = CultureInfo.CurrentCulture; 
Console.WriteLine("en-US culture"); //Current culture may not be en-US different on your machine!

var date = new DateTime(2025, 3, 2, 12, 16, 14);
var number = 1.9m;

Console.WriteLine(date.ToString("d"));
Console.WriteLine(number);

Console.WriteLine("pl-PL culture");
CultureInfo.CurrentCulture = new CultureInfo("pl-PL");
Console.WriteLine(date.ToString("d"));
Console.WriteLine(number);

Console.WriteLine(
    date.ToString(CultureInfo.InvariantCulture)); //should be the same for you as for me


Console.WriteLine("Press any key to close.");
Console.ReadKey();

void Modify(string input)
{
    input += "xyz";
}








