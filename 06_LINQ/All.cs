using _6_LINQ.SampleData;

static class All
{
    //System.Linq.Enumerable.All
    public static void Run()
    {
        var numbers = new[] { 10, 1, 4, 17, 122 };

        //All is used to check if all elements in the collection meet the specific criteria
        var areAllNumbersLargerThanZero = numbers.All(n => n > 0);
        Console.WriteLine($"areAllNumbersLargerThanZero: {areAllNumbersLargerThanZero}");

        var doAllPetsHaveNonEmptyName = Data.Pets.All(pet => !string.IsNullOrEmpty(pet.Name));
        Console.WriteLine($"doAllPetsHaveNonEmptyName: {doAllPetsHaveNonEmptyName}");

        var areAllPetsCats = Data.Pets.All(pet => pet.PetType == PetType.Cat);
        Console.WriteLine($"areAllPetsCats: {areAllPetsCats}");

        //please note that we can achieve the same result by using Any
        //and reversing the condition
        var doAllPetsHaveNonEmptyName_WithAny = 
            !(Data.Pets.Any(pet => string.IsNullOrEmpty(pet.Name))); //note the "!"
        Console.WriteLine($"doAllPetsHaveNonEmptyName_WithAny: {doAllPetsHaveNonEmptyName_WithAny}");
    }
}
