using System.Diagnostics;
using System.Text.Json;

//Plain threads
Console.WriteLine("Cores count: " + Environment.ProcessorCount);
Console.WriteLine("Main thread's ID: " + Thread.CurrentThread.ManagedThreadId);

Thread thread1 = new Thread(() => PrintPluses(200));
Thread thread2 = new Thread(() => PrintMinuses(200));

thread1.Start();
thread2.Start();


//Thread pool
const int iterations = 100;
Stopwatch stopwatch = Stopwatch.StartNew();

for (int i = 0; i < iterations; i++)
{
    ThreadPool.QueueUserWorkItem(PrintA);
}
stopwatch.Stop();
Console.WriteLine("Took: " + stopwatch.ElapsedMilliseconds);


//void Tasks
Task task1 = Task.Run(() => PrintPluses(200));
Task task2 = Task.Run(() => PrintMinuses(200));


//WaitAll
var task3 = Task.Run(() =>
{
    Thread.Sleep(1000);
    Console.WriteLine("Task 1 is finished.");
});
var task4 = Task.Run(() =>
{
    Thread.Sleep(1000);
    Console.WriteLine("Task 2 is finished.");
});

Task.WaitAll(task3, task4);


//Continuations
Task taskContinuation =
    Task.Run(() => CalculateLength("Hello there"))
    .ContinueWith(taskWithResult =>
    Console.WriteLine("Length is " + taskWithResult.Result))
    .ContinueWith(completedTask =>
    {
        Thread.Sleep(500);
        Console.WriteLine("The second continuation.");
    });

var tasks = new[]
{
    Task.Run(() => CalculateLength("hello there")),
    Task.Run(() => CalculateLength("hi")),
    Task.Run(() => CalculateLength("hola")),
};

var continuationTask = Task.Factory.ContinueWhenAll(
    tasks,
    completedTasks => Console.WriteLine(
        string.Join(", ", completedTasks.Select(task => task.Result))));


//child tasks
var parent = Task.Run(() =>
{
    Console.WriteLine("Parent task executing.");

    var child = Task.Run(() =>
    {
        Console.WriteLine("Child task starting.");
    });
});


//Task created from result
Task<int> taskFromResult = Task.FromResult(10);


//cancelling tasks
var cancellationTokenSource = new CancellationTokenSource();
var task = Task.Run(
    () => NeverendingMethod(cancellationTokenSource),
    cancellationTokenSource.Token)
    .ContinueWith(canceledTask =>
        Console.WriteLine($"Task with ID {canceledTask.Id} has been canceled."),
        TaskContinuationOptions.OnlyOnCanceled);


//Handling AggregateException
var taskThatMayFault = Task.Run(() => Divide(2, 0))
    .ContinueWith(
    faultedTask =>
    {
        faultedTask.Exception.Handle(ex =>
        {
            Console.WriteLine("Division task finished");
            if (ex is ArgumentNullException)
            {
                Console.WriteLine("Arguments can't be null.");
                return true;
            }
            if (ex is DivideByZeroException)
            {
                Console.WriteLine("Can't divide by zero.");
                return true;
            }
            Console.WriteLine("Unexpected exception type.");
            return false;
        });
    },
    TaskContinuationOptions.OnlyOnFaulted);


//multiple continuations to one task
var taskWithMultipleContinuations = new Task(() => Divide(10, 2));

taskWithMultipleContinuations.ContinueWith(faultedTask =>
    Console.WriteLine("Success"),
    TaskContinuationOptions.OnlyOnRanToCompletion);

taskWithMultipleContinuations.ContinueWith(faultedTask =>
    Console.WriteLine("Exception thrown: " + faultedTask.Exception.Message),
    TaskContinuationOptions.OnlyOnFaulted);

taskWithMultipleContinuations.Start();


//lock
var counter = new Counter();

var tasksAccessingTheSameResource = new List<Task>();

for (int i = 0; i < 10; i++)
{
    tasksAccessingTheSameResource.Add(Task.Run(() => counter.Increment()));
}
for (int i = 0; i < 10; i++)
{
    tasksAccessingTheSameResource.Add(Task.Run(() => counter.Decrement()));
}

Task.WaitAll(tasksAccessingTheSameResource.ToArray());
Console.WriteLine("Counter value is: " + counter.Value);

//async/await
var taskFromAsyncMethod = Process(null);

string userInput;
do
{
    Console.WriteLine("Enter a command:");
    userInput = Console.ReadLine();
    //process the command
} while (userInput != "stop");

static void PrintPluses(int n)
{
    Console.WriteLine("\nPrintPluses thread's ID: " + Thread.CurrentThread.ManagedThreadId);
    for (int i = 0; i < n; i++)
    {
        Console.Write("+");
    }
}

static void PrintMinuses(int n)
{
    Console.WriteLine("\nPrintMinuses thread's ID: " + Thread.CurrentThread.ManagedThreadId);
    for (int i = 0; i < n; i++)
    {
        Console.Write("-");
    }
}

static void PrintA(object obj)
{
    Console.Write("A");
}

static int CalculateLength(string input)
{
    Console.WriteLine("Starting the CalculateLength method");
    Thread.Sleep(2000);
    return input.Length;
}

static async Task<int> CalculateLengthAsync(string input)
{
    Console.WriteLine("Starting the CalculateLength method");
    await Task.Delay(2000);
    return input.Length;
}

static void NeverendingMethod(
    CancellationTokenSource cancellationTokenSource)
{
    while (true)
    {
        cancellationTokenSource.Token.ThrowIfCancellationRequested();
        Console.WriteLine("Working...");
        Thread.Sleep(1500);
    }
}

static float Divide(int? a, int? b)
{
    if (a is null || b is null)
    {
        throw new ArgumentNullException("Arguments cannot be null");
    }
    if (b == 0)
    {
        throw new DivideByZeroException("Division by zero is not allowed.");
    }

    return a.Value / (float)b.Value;
}

static async Task Process(string input)
{
    try
    {
        var length = await CalculateLengthAsync(input);
        await PrintAsync(length);
        Console.WriteLine("The process is finished.");
    }
    catch (NullReferenceException ex)
    {
        Console.WriteLine("The input can't be null.");
    }
}

static void Print(int result)
{
    Console.WriteLine("Starting the Print method");
    Thread.Sleep(2000);
    Console.WriteLine("The result is " + result);
}

static async Task PrintAsync(int result)
{
    Console.WriteLine("Starting the Print method");
    await Task.Delay(2000);
    Console.WriteLine("The result is " + result);
}

//HttpClient
async Task<IEnumerable<Datum>> GetQuotes(int limit, int page)
{
    using var httpClient = new HttpClient();

    var endpoint = $"https://quote-garden.onrender.com/api/v3/quotes?limit={limit}&page={page}";

    HttpResponseMessage response = await httpClient.GetAsync(endpoint);
    response.EnsureSuccessStatusCode();
    string json = await response.Content.ReadAsStringAsync();

    var root = JsonSerializer.Deserialize<Root>(json);

    return root.data;
}

public record Datum(
string _id,
string quoteText,
string quoteAuthor,
string quoteGenre,
int __v
   );

public record Pagination(
int currentPage,
int nextPage,
int totalPages
);

public record Root(
int statusCode,
string message,
Pagination pagination,
int totalQuotes,
IReadOnlyList<Datum> data
);

class Counter
{
    private object _valueLock = new object();
    public int Value { get; private set; }

    public void Increment()
    {
        lock (_valueLock)
        {
            Value++;
        }
    }

    public void Decrement()
    {
        lock (_valueLock)
        {
            Value--;
        }
    }
}
