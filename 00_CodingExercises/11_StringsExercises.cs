using System.Text;

//StringBuilder - The Reverse method
public static class StringBuilderExercise
{
    public static string Reverse(string input)
    {
        StringBuilder stringuilder = new StringBuilder();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            stringuilder.Append(input[i]);
        }

        return stringuilder.ToString();
    }
}