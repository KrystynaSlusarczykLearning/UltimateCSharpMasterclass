using _6_LINQ.SampleData;
using _6_LINQ.Utilities;

static class Distinct
{
    //System.Linq.Enumerable.Distinct
    public static void Run()
    {
        var numbers = new[] { 10, 1, 10, 4, 17, 17, 122 };

        //Distinct removes all duplicated values from the collection
        //returning a collaction of unique elements

        //duplicates of 10 and 17 will be removed
        var distinctNumbers = numbers.Distinct();
        Printer.Print(distinctNumbers, nameof(distinctNumbers));

        //below pets seem like duplicates, but they are not 
        //those objects are compared by reference
        //in this case pets[0] == pets[1] will return false
        //that's why Distinct will not remove any of those items
        var pets = new[]
        {
            new Pet(1, "Hannibal", PetType.Fish, 1.1f),
            new Pet(1, "Hannibal", PetType.Fish, 1.1f)
        };
        var distinctPets = pets.Distinct();
        Printer.Print(distinctPets, nameof(distinctPets));

        //we can use custom EqualityComparer
        //in this case Distinct will consider them duplicates
        //and remove one of them
        var petsDistinctById = pets.Distinct(new PetEqualityByIdComparer());
        Printer.Print(petsDistinctById, nameof(petsDistinctById));
    }
}
