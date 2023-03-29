using _6_LINQ.SampleData;

static class Average
{
    //System.Linq.Enumerable.Average
    public static void Run()
    {
        var numbers = new[] { 10, 1, 4, 17, 122 };

        //Average calculates the average of the values
        var averageOfNumbers = numbers.Average();
        Console.WriteLine($"averageOfNumbers: {averageOfNumbers}");

        var averagePetWeight = Data.Pets.Average(pet => pet.Weight);
        Console.WriteLine($"averagePetWeight: {averagePetWeight}");

        //Average only works for numbers
        //so the below will not work
        //var averagePet = Data.Pets.Average();

        //if the collection is empty, Average will throw an exception
        //var emptyNumbers = new int[0];
        //var emptyCollectionAverage = emptyNumbers.Average();
    }
}
