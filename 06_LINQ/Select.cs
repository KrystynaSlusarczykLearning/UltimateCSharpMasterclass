using _6_LINQ.SampleData;
using _6_LINQ.Utilities;

static class Select
{
    //System.Linq.Enumerable.Select
    public static void Run()
    {
        //Select projects each element of a sequence into a new form
        //it simply applies a method defined in lambda 
        //to each of the collection's elements, creating a new collection
        var numbers = new[] { 10, 1, 4, 17, 122 };
        var doubledNumbers = numbers.Select(n => n * 2);
        Printer.Print(doubledNumbers, nameof(doubledNumbers));

        var words = new[] { "little", "brown", "fox" };
        var wordsToUpper = words.Select(word => word.ToUpper());
        Printer.Print(wordsToUpper, nameof(wordsToUpper));

        //it's often used to extract some data from objects in the collection
        var petsWeights = Data.Pets.Select(pet => pet.Weight);
        Printer.Print(petsWeights, nameof(petsWeights));

        //let's use Select with some other methods
        //let's select those PetTypes, for which
        //Pets lighter than 4 kilos exist
        var smallPetTypes = Data.Pets.Where(
            pet => pet.Weight < 4).Select(pet => pet.PetType).Distinct();
        Printer.Print(smallPetTypes, nameof(smallPetTypes));

        //let's create a list of Pets initials, ordered alphabetically
        var petsInitials = Data.Pets
            .OrderBy(pet => pet.Name)
            .Select(pet => pet.Name.First() + ".");
        Printer.Print(petsInitials, nameof(petsInitials));

        //let's convert all pets' crucial data to a single string
        var petsDescription = string.Join("\n",
            Data.Pets.Select(
                pet => $"This pet's name is {pet.Name}, it's a {pet.PetType}," +
                $" and it weights {pet.Weight} kilos"));
        Console.WriteLine(petsDescription);
    }
}

