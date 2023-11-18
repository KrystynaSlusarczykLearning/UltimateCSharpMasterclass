using _6_LINQ.SampleData;
using _6_LINQ.Utilities;

namespace LinqTutorial
{
    static class OrderBy
    {
        //System.Linq.Enumerable.OrderBy
        //System.Linq.Enumerable.OrderByDescending
        //System.Linq.Enumerable.ThenBy
        //System.Linq.Enumerable.ThenByDescending
        //System.Linq.Enumerable.Reverse
        public static void Run()
        {
            //OrderBy creates a copy of the collection,
            //which is ordered by the given criteria
            var petsOrderedByName = Data.Pets.OrderBy(pet => pet.Name);
            Printer.Print(petsOrderedByName, nameof(petsOrderedByName));

            var petsOrderedByIdDescending = Data.Pets.OrderByDescending(pet => pet.Id);
            Printer.Print(petsOrderedByIdDescending, nameof(petsOrderedByIdDescending));

            //numbers of words we can simply order by themselves
            var numbers = new[] { 16, 8, 9, -1, 2 };
            var orderedNumbers = numbers.OrderBy(number => number);
            Printer.Print(orderedNumbers, nameof(orderedNumbers));

            var words = new[] { "lion", "tiger", "snow leopard" };
            var orderedWords = words.OrderBy(word => word);
            Printer.Print(orderedWords, nameof(orderedWords));

            //we can order by some criteria, and then by other criteria
            var petsOrderedByTypeThenName = Data.Pets
                .OrderBy(pet => pet.PetType)
                .ThenBy(pet => pet.Name);
            Printer.Print(petsOrderedByTypeThenName, nameof(petsOrderedByTypeThenName));

            var petsOrderedByTypeDescendingThenIdDescending = Data.Pets
                .OrderByDescending(pet => pet.PetType)
                .ThenByDescending(pet => pet.Id);
            Printer.Print(petsOrderedByTypeDescendingThenIdDescending,
                nameof(petsOrderedByTypeDescendingThenIdDescending));

            //we can use the Reverse method to Reverse the order of the collection
            var petsReversed = Data.Pets.Reverse();
            Printer.Print(petsReversed, nameof(petsReversed));
        }
    }
}
