//###################
//Variables
//###################
//Console.WriteLine(name); //will not compile, because  is not yet declared and initialized

using System.Windows.Markup;

string name = "Nisha"; //variable initialization at declaration
int number; //variable declaration
number = 5; //variable initialization
number = 10; //assigning new value to a variable
Console.WriteLine(number); //10 will be printed
//int lastName = "Smith"; //will not compile, we can't assign string to int



//###################
//Naming variables
//###################
//string class = "First"; //will not compile, class is reserved keyword
string @class = "First"; //we can use a reserved keyword if we precede it with @
int _number = 10;
int also_some_number = 5; //valid name, but not in line with C# convention
int alsoSomeNumber = 5; //C# uses lower camel case
//int 1number = 1; //will not compile, digit cannot be the first character
string name1 = "Anna"; //digit is fine if it is not the first character
int age, Age; //they are two different variables, C# is case-sensitive 
              //int number-one = 10; //will not compile, we can't use '-'


//###################
//Operators
//###################
int sum = 5 + 10;
int resultNoParenthesis = 5 + 2 * 3;
int resultParenthesis = 5 + (2 * 3);
var stringAndInt = "abc" + 5;



//###################
//Implicitly typed variables
//###################
string word1 = "text"; //explicitly typed variable
var word2 = "text"; //implicitly typed variable
//var invalidVariable; //will not compile; implicitly typed variables must be initialized



//###################
//Comments
//###################

//this is a single-line comment
/*
this is
a multiline
comment
*/



//###################
//Boolean type.
//Logical negation, equality,
//comparison and modulo operators
//###################
Console.WriteLine("Enter a word:");
var userInput = Console.ReadLine();
bool isUserInputAbc = userInput == "ABC";
bool isUserInputNotAbc = userInput != "ABC";
bool isUserInputNotAbc2 = !(userInput == "ABC"); //will be the same as above
var isLargerThan5 = number > 5;
var isSmallerThan10 = number <= 10;
var isLargerOrEqualTo10 = number >= 10;
var isSmallerOrEqualTo6 = number <= 6;
var is10Modulo3EqualTo1 = 10 % 3 == 1;
var isEven = number % 2 == 0;
var isOdd = number % 2 != 0;



//###################
//Boolean type.
//Logical negation, equality,
//comparison and modulo operators
//###################
var isLargerThan4AndSmallerThan9 = number > 4 && number < 9;
var isEqualTo2OrLargerThan6 = number == 2 || number > 6;
var isEqualTo2OrLargerThan6OrSmallerThan200 =
    number == 2 || number > 6 || number < 200;
var isEqualto123OrEvenAndSmallerThan20 =
    number == 123 || (number % 2 == 0 && number < 20);
var isLargerThan5OrSmallerThan0 = number > 5 || number < 5; //the second conditin will not be evaluated due to short-circuiting
var isSmallerThanZeroAndEven = number < 0 && number % 2 == 0; //the second conditin will not be evaluated due to short-circuiting



//###################
//if/else statements
//###################
if (userInput.Length <= 3)
{
    Console.WriteLine("Short answer");
}
else if (userInput.Length < 10)
{
    Console.WriteLine("Medium answer");
}
else
{
    Console.WriteLine("Long answer");
}



//###################
//Scopes
//###################
if (userInput.Length == 0)
{
    Console.WriteLine("Empty choice");
    var word = "ABC";
    int someNumber = 5;
    if (word.Length > 0)
    {
        Console.WriteLine(someNumber); //someNumber is available here
    }
}
else
{
    int someNumber = 6; //named the same as the variable inside the "if". It is fine, because those variables live in different scopes
    Console.WriteLine("Your choice is: " + userInput);
    //Console.WriteLine(someNumber); //will not compile; someNumber is not available here
}
Console.WriteLine("Your choice is: " + userInput);



//###################
//Methods - part 1 - void methods
//###################
//See 1_TodoList project for more about methods
void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}



//###################
//Methods - part 2 - non-void methods
//###################
//See 1_TodoList project for more about methods
int Add(int a, int b)
{
    return a + b;
}

bool IsLong(string input)
{
    return input.Length > 10;
}



//###################
//Parsing a string to an int
//###################
string numberAsText = "123";
int parsedToInt = int.Parse(numberAsText); //would not work if input was, for example, "abc"



//###################
//String interpolation
//###################
int a = 4, b = 2, c = 10;
Console.WriteLine(
    "First is: " + a + ", second is: " + b + ", third is: " + c);

Console.WriteLine(
    $"First is: {a}, second is: {b}, third is: {c}");

Console.WriteLine(
    $"Sum is: {a + b + c}, second is: {b}, third is: {c}");



//###################
//Switch statement
//###################
//See 1_TodoList project for more about switch
//###################
//Char
//###################
char ConvertPointsToGrade(int points)
{
    switch (points)
    {
        case 10:
        case 9:
            return 'A';
        case 8:
        case 7:
        case 6:
            return 'B';
        case 5:
        case 4:
        case 3:
            return 'C';
        case 2:
        case 1:
            return 'D';
        case 0:
            return 'E';
        default:
            return '!';
    }
}



//###################
//While loop
//###################
var numberWhileLoop = 0;
while (numberWhileLoop < 10)
{
    numberWhileLoop += 1;
    Console.WriteLine("Number is: " + numberWhileLoop);
}
Console.WriteLine("The loop is finished.");

var someText = "hello";
while (someText.Length < 15)
{
    someText += 'a';
    Console.WriteLine(someText);
}
Console.WriteLine("The loop is finished.");



//###################
//Do-while loop
//###################
string userInputLong;
do
{
    Console.WriteLine(
        "Enter input longer than 10 letters");
    userInputLong = Console.ReadLine();
} while (userInputLong.Length <= 10);



//###################
//For loop
//###################
for (int i = 0; i < 5; ++i)
{
    Console.WriteLine("Loop run " + i);
}
for (int i = 10; i >= 5; --i)
{
    Console.WriteLine("Loop run " + i);
}
Console.WriteLine("The loop is finished");



//###################
//Break and continue
//###################
for (int i = 0; i < 100; ++i)
{
    if (i > 25)
    {
        break;
    }
    //Console.WriteLine("Loop run " + i);
}

int userNumber;
do
{
    Console.WriteLine(
        "Enter a number larger than 10.");
    var input = Console.ReadLine();
    if (input == "stop")
    {
        break;
    }
    bool isParsableToInt = input.All(char.IsDigit);
    if (!isParsableToInt)
    {
        userNumber = 0;
        continue;
    }
    userNumber = int.Parse(input);
} while (userNumber <= 10);

for (int i = 0; i < 20; i++)
{
    if (i % 3 == 0)
    {
        continue;
    }
    //Console.WriteLine(i);
}



//###################
//Nested loops
//###################
for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.WriteLine(
            $"i is {i}, j is {j}");
    }
}



//###################
//Arrays
//###################
var numbers = new int[] { 1, 2, 4, 7, 2 };
numbers[2] = 10;
var firstFromEnd1 = numbers[numbers.Length - 1];
var firstFromEnd2 = numbers[^1];
var secondFromEnd1 = numbers[numbers.Length - 2];
var secondFromEnd2 = numbers[^2];

int sumOfNumbers = 0;
for (int i = 0; i < numbers.Length; i++)
{
    sumOfNumbers += numbers[i];
}



//###################
//Multi-dimensional arrays
//###################
char[,] letters = new char[2, 3];
letters[0, 0] = 'A';
letters[0, 1] = 'B';
letters[0, 2] = 'C';
letters[1, 0] = 'D';
letters[1, 1] = 'E';
letters[1, 2] = 'F';

var letters2 = new char[,]
{
    {'A', 'B','C' },
    {'D', 'E','F' },
};

var height = letters.GetLength(0);
var width = letters.GetLength(1);

for (int i = 0; i < height; i++)
{
    Console.WriteLine($"i is {i}");
    for (int j = 0; j < width; j++)
    {
        Console.WriteLine($"j is {j}");
        Console.WriteLine(
            $"element is {letters[i, j]}");
    }
}




//###################
//Foreach loop
//###################
var words = new string[] { "one", "two", "three" };
foreach (var word in words)
{
    Console.WriteLine(word);
}




//###################
//Lists
//###################
var someWords = new List<string>
{
    "one", "two"
};
someWords.Add("three");
someWords.AddRange(new[] { "four", "five" });
someWords.Remove("three");
someWords.RemoveAt(0);
var indexOfFive = someWords.IndexOf("five");
bool containsOne = someWords.Contains("one");
someWords.Clear();



//###################
//Out parameter
//###################
var variousNumbers = new int[] { 10, -8, 2, 12, -17 };
int countOfNonPositiveNumbers;
var onlyPositive = GetOnlyPositive(
    numbers, out countOfNonPositiveNumbers);

List<int> GetOnlyPositive(
    int[] numbers, out int countOfNonPositive)
{
    var result = new List<int>();
    countOfNonPositive = 0;
    foreach (var number in numbers)
    {
        if (number > 0)
        {
            result.Add(number);
        }
        else
        {
            ++countOfNonPositive;
        }
    }
    return result;
}

//###################
//Out parameter
//###################
bool isParsed = int.TryParse(
    userInput, out int userInputParsedToInt);
if (isParsed)
{
    Console.WriteLine(
        "Parsed successfully, the result is: " + userInputParsedToInt);
}
else
{
    Console.WriteLine(
        $"Could not parse '{userInput}' to int");
}


Console.WriteLine("Press any key to close");
Console.ReadKey();