using _10_UtilitiesProject;

var numbers = new int[] { 1, 2, 3 };
Console.WriteLine(numbers.AsString());

//not accessible here - only in PublicClass's assembly or derived classes
//new PublicClass().ProtectedInternal();

Console.WriteLine("Press any key to close.");
Console.ReadKey();

public class DerivedFromPublicClass : PublicClass
{
    public void Test()
    {
        ProtectedInternal();

        //not accessible here - only in derived classes in PublicClass's assembly
        //PrivateProtected();
    }
}
