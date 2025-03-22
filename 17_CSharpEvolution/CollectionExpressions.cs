namespace _17_CSharpEvolution;

class CollectionExpressions
{
    public void Example()
    {
        //the old way
        var numbers1 = new int[] { 1, 2, 3 };


        //collection expressions
        int[] numbers2 = [1, 2, 3];
        int[] numbers3 = [4, 5];

        //the syntax is the same for arrays, Lists, and other collections
        List<string> words = ["cat", "dog", "horse"];

        //won't work, because the type of the collection is unknown
        //var numbers = [1,2,3];

        //using the spread operator
        List<int> combined = [.. numbers2, .. numbers3, 6, 7];
    }

    //collection expressions shorten the code the best
    //when the type is already known
    List<int> GetDefaultCoordinatesA() => new List<int> { 0, 0, 0 };
    List<int> GetDefaultCoordinatesB() => [0, 0, 0];
}
