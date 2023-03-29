using _6_LINQ.SampleData;

static class Contains
{
    //System.Linq.Enumerable.Contains
    public static void Run()
    {
        var numbers = new[] { 10, 1, 4, 17, 122 };

        //Contains checks if given element is present in the collection
        var contains10 = numbers.Contains(10);
        Console.WriteLine($"contains10: {contains10}");

        var contains11 = numbers.Contains(11);
        Console.WriteLine($"contains11: {contains11}");

        //the below will return false, because pets are compares by reference
        //and we create a new reference here
        var containsAnthony = Data.Pets.Contains(new Pet(2, "Anthony", PetType.Cat, 2f));
        Console.WriteLine($"containsAnthony: {containsAnthony}");

        //let's store the reference to Hannibal pet
        var hannibal = Data.Pets.First(); //selects the first element in the collection
        var containsHannibal = Data.Pets.Contains(hannibal);
        Console.WriteLine($"containsHannibal: {containsHannibal}");

        //we can use any EqualityComparer we like
        var containsAnthonyWithEqualityComparer = Data.Pets.Contains(
            new Pet(2, "Anthony", PetType.Cat, 2f), new PetEqualityByIdComparer());
        Console.WriteLine($"containsAnthonyWithEqualityComparer: " +
            $"{containsAnthonyWithEqualityComparer}");
    }
}
