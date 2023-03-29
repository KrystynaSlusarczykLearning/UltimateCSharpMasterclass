//Try-catch-finally. DivideNumbers
public static class TryCatchFinallyDivideNumbersExercise
{
    public static int DivideNumbers(int a, int b)
    {
        try
        {
            return a / b;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Division by zero.");
            return 0;
        }
        finally
        {
            Console.WriteLine($"The {nameof(DivideNumbers)} method ends.");
        }
    }
}

//Rethrowing exceptions
public static class RethrowingExceptionsExercise
{
    public static int GetMaxValue(List<int> numbers)
    {
        try
        {
            return numbers.Max();
        }
        catch (ArgumentNullException ex)
        {
            throw new ArgumentNullException(
                "The numbers list cannot be null.", ex);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("The numbers list cannot be empty.");
            throw;
        }
    }
}

//Custom exception - InvalidTransactionException
public class TransactionData
{
    public string Sender { get; init; }
    public string Receiver { get; init; }
    public decimal Amount { get; init; }
}

public class InvalidTransactionException : Exception
{
    public TransactionData TransactionData { get; }

    public InvalidTransactionException()
    {
    }

    public InvalidTransactionException(string message) : base(message)
    {
    }

    public InvalidTransactionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidTransactionException(
        string message, TransactionData transactionData) : base(message)
    {
        TransactionData = transactionData;
    }

    public InvalidTransactionException(
        string message,
        TransactionData transactionData,
        Exception innerException) : base(message, innerException)
    {
        TransactionData = transactionData;
    }
}