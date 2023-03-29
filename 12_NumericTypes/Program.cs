using System.Diagnostics;


//numeric overflow
var twoBillion = 2_000_000_000;
Console.WriteLine(
    "Two billion plus two billion is " + (twoBillion + twoBillion));

//this method will throw a NumericOverflow exception
//SomeMethodWithCheckedContext(twoBillion, twoBillion);

//Example when numeric overflow is dangerous
int sumSoFar = 1_900_000_000;
int nextTransaction = 1_000_000_000;
int sumAfterTransaction =
    sumSoFar + nextTransaction;

//to avoid the overflow, we could use long
//long sumAfterTransaction =
//    (long)sumSoFar + (long)nextTransaction;
if (sumAfterTransaction > twoBillion)
{
    Console.WriteLine("Transaction blocked.");
}
else
{
    Console.WriteLine("Transaction executed.");
}

checked
{
    //will be checked
    unchecked
    {
        //will not be checked
    }
}

//floating point numbers

Console.WriteLine(0.3d == (0.2d + 0.1d));
Console.WriteLine(AreEqual(0.3d, 0.2d + 0.1d, 0.000001d));

Console.WriteLine(0d / 0d);
var result = 10d / 0d;

bool AreEqual(double a, double b, double tolerance) =>
    Math.Abs(a - b) < tolerance;

//double vs decimal - performance test

int iterations = 30_000_000;
var resultForDouble = DoubleTest(iterations);
var resultForDecimal = DecimalTest(iterations);

Console.WriteLine($"Calculation of {iterations} elements.");
Console.WriteLine($"For double it took {resultForDouble} ticks.");
Console.WriteLine($"For decimal it took {resultForDecimal} ticks.");
var differenceScaled = (double)resultForDecimal / (double)resultForDouble;
Console.WriteLine($"Decimal took {differenceScaled:00.00} times as much time");

Console.ReadKey();


void SomeMethodWithCheckedContext(int a, int b)
{
    var result = Add(a, b);
}

int Add(int a, int b)
{
    checked
    {
        return a + b;
    }
}

long DoubleTest(int iterations)
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    double z = 0;
    for (int i = 0; i < iterations; i++)
    {
        double x = i;
        double y = x * i;
        z += y;
    }
    stopwatch.Stop();
    return stopwatch.ElapsedTicks;
}

long DecimalTest(int iterations)
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    decimal z = 0;
    for (int i = 0; i < iterations; i++)
    {
        decimal x = i;
        decimal y = x * i;
        z += y;
    }
    stopwatch.Stop();
    return stopwatch.ElapsedTicks;
}
Console.ReadKey();









