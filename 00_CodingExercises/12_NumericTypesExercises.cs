//Checked - Fibonacci sequence
public static class CheckedFibonacciExercise
{
    public static IEnumerable<int> GetFibonacci(int n)
    {
        checked
        {
            int a = -1;
            int b = 1;
            for (int i = 0; i < n; i++)
            {
                int sum = a + b;
                yield return sum;
                a = b;
                b = sum;
            }
        }
    }
}

//Floating point numbers - The IsAverageEqualTo method
public static class FloatingPointNumbersExercise
{
    public static bool IsAverageEqualTo(
            this IEnumerable<double> input, double valueToBeChecked)
    {
        double sum = 0.0;
        int count = 0;
        foreach (double number in input)
        {
            if (double.IsNaN(number) || double.IsInfinity(number))
            {
                throw new ArgumentException(
                    "Input contains NaN or Infinity values.");
            }
            sum += number;
            count++;
        }
        var average = sum / count;
        const double tolerance = 0.00001;
        return Math.Abs(average - valueToBeChecked) < tolerance;
    }
}