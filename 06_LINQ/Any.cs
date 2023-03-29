using _6_LINQ.SampleData;

static class Any
{
    //System.Linq.Enumerable.Any
    public static void Run()
    {
        var numbers = new[] { 10, 1, 4, 17, 122 };

        //Any is used to check if any element in the collection meets the given criteria
        var isAnyNumberLargerThan100 = numbers.Any(n => n > 100);
        Console.WriteLine($"isAnyNumberLargerThan100: {isAnyNumberLargerThan100}");

        var isAnyPetNamedBruce = Data.Pets.Any(pet => pet.Name == "Bruce");
        Console.WriteLine($"isAnyPetNamedBruce: {isAnyPetNamedBruce}");

        var isAnyPetNamedHannibal = Data.Pets.Any(pet => pet.Name == "Hannibal");
        Console.WriteLine($"isAnyPetNamedHannibal: {isAnyPetNamedHannibal}");

        //we can of course use more complex conditions
        //for example, to check if there is any pet with an even Id
        //and name longer than 6 letters
        var isThereASpecificPet = Data.Pets.Any(
            pet => pet.Name.Length > 6 && pet.Id % 2 == 0);
        Console.WriteLine($"isThereASpecificPet: {isThereASpecificPet}");

        //we can use Any without parameter to check if the collection is not empty:
        var isNotEmpty = Data.Pets.Any();
        Console.WriteLine($"isNotEmpty: {isNotEmpty}");
    }
}
