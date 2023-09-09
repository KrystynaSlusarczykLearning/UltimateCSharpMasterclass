//the class to be refactored as an assignment
public class Pwd
{
    private static readonly Random rand = new Random();

    public static string Generate(
        int left, int right, bool useSpecial)
    {
        //validate max and min length
        if (left < 1)
        {
            throw new ArgumentOutOfRangeException(
                $"leftRange must be greater than 0");
        }
        if (right < left)
        {
            throw new ArgumentOutOfRangeException(
                $"leftRange must be smaller than rightRange");
        }

        //randomly pick the length of password between left and right range
        var l = rand.Next(left, right + 1);

        //generate random string
        var chars = useSpecial ?
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=" :
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        return new string(Enumerable.Repeat(chars, l).Select(chars => chars[rand.Next(chars.Length)]).ToArray());
    }
}
