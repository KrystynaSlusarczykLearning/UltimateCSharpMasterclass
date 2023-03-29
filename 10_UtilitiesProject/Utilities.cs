namespace _10_UtilitiesProject;

public class PublicClass
{
    public int SomeMethod()
    {
        var someVariable = new InternalClass();
        return 0;
    }

    protected internal void ProtectedInternal() { }
    private protected void PrivateProtected() { }
}

internal class DerivedFromPublicClass : PublicClass
{
    void Test()
    {
        PrivateProtected();
    }
}

internal class InternalClass
{
    public static void SomeMethod()
    {
        new PublicClass().ProtectedInternal();
    }
}

file class AccessibleOnlyInThisFile
{

}

public class Outer
{
    private class Inner
    {

    }
}

public static class EnumerableExtensions
{
    public static string AsString<T>(
        this IEnumerable<T> items)
    {
        return string.Join(
            Environment.NewLine,
            items);
    }
}
