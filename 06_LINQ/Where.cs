using _6_LINQ.SampleData;
using _6_LINQ.Utilities;

static class Where
{
    //System.Linq.Enumerable.Where
    public static void Run()
    {
        var numbers = new[] { 10, 1, 4, 17, 122 };

        //where filters the collection by the given predicate
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        Printer.Print(evenNumbers, nameof(evenNumbers));

        //remember that we can use method's name only 
        //if it is not ambiguous which method to call
        var evenNumbers2 = numbers.Where(IsEven);

        var allPetsHeavierThan10Kilos = Data.Pets.Where(pet => pet.Weight > 10);
        Printer.Print(allPetsHeavierThan10Kilos, nameof(allPetsHeavierThan10Kilos));

        //sometimes the result is empty...
        var allPetsHeavierThan100Kilos = Data.Pets.Where(pet => pet.Weight > 100);
        Printer.Print(allPetsHeavierThan100Kilos, nameof(allPetsHeavierThan100Kilos));

        //we can, of course, use more complex conditions:
        var verySpecificPets = Data.Pets.Where(pet =>
            (pet.PetType == PetType.Dog || pet.PetType == PetType.Cat) &&
            pet.Name.Length > 4 &&
            pet.Weight > 10 &&
            pet.Id % 2 == 0);
        Printer.Print(verySpecificPets, nameof(verySpecificPets));

        //we can access the index in the Where method
        //let's say the user selected some Pets in the UI:
        var indexesSelectedByUser = new[] { 0, 2, 4 };
        var petsSelectedByUserLighterThan5Kilos = Data.Pets.Where((pet, index) =>
            indexesSelectedByUser.Contains(index) && pet.Weight < 5);
        Printer.Print(petsSelectedByUserLighterThan5Kilos,
            nameof(petsSelectedByUserLighterThan5Kilos));

        // in LINQ we can often achieve one result in two ways. 
        // for example, to count all dogs heavier than 30 kilos we can do:
        // A
        var countOfDogsHeavierThan30KilosA = Data.Pets.Count(
            pet => pet.PetType == PetType.Dog && pet.Weight > 30);
        //B
        var countOfDogsHeavierThan30KilosB = Data.Pets.Where(
            pet => pet.PetType == PetType.Dog && pet.Weight > 30).Count();
    }

    static bool IsEven(int number) => number % 2 == 0;
}
