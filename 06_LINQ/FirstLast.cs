using _6_LINQ.SampleData;
using _6_LINQ.Utilities;

static class FirstLast
{
    //System.Linq.Enumerable.First
    //System.Linq.Enumerable.FirstOrDefault
    //System.Linq.Enumerable.Last
    //System.Linq.Enumerable.LastOrDefault
    public static void Run()
    {
        //First & Last
        var numbers = new[] { 10, 1, 4, 17, 122 };

        var firstNumber = numbers.First();
        Printer.Print(firstNumber, nameof(firstNumber));

        var lastNumber = numbers.Last();
        Printer.Print(lastNumber, nameof(lastNumber));

        //we can also use First with a predicate
        var firstOddNumber = numbers.First(n => n % 2 != 0);
        Printer.Print(firstOddNumber, nameof(firstOddNumber));

        var lastOddNumber = numbers.Last(n => n % 2 != 0);
        Printer.Print(lastOddNumber, nameof(lastOddNumber));

        //an exception will be thrown if the collection is empty
        //or if there are no elements in the collection
        //that match the given predicate
        //var firstNumberLargerThan1000 = numbers.First(n => n > 1000);
        //var lastNumberLargerThan1000 = numbers.Last(n => n > 1000);

        //the First and Last methods are often used with OrderBy
        var heaviestPet = Data.Pets.OrderByDescending(pet => pet.Weight).First();
        Printer.Print(heaviestPet, nameof(heaviestPet));

        var lastPetAlphabetically = Data.Pets.OrderBy(pet => pet.Name).Last();
        Printer.Print(lastPetAlphabetically, nameof(lastPetAlphabetically));
    }
}
