namespace StarWarsPlanetsStats.ApiDataAccess;

public class ApiDataReader : IApiDataReader
{
    public async Task<string> Read(
        string baseAddress, string requestUri)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseAddress);
        HttpResponseMessage response = await client.GetAsync(
            requestUri);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}











//struct FishyStruct
//{
//    public List<int> Numbers { get; init; }
//}


//string text = null;

//int? numberOrNull = null;
//Nullable<bool> boolOrNull = true;

//if (numberOrNull.HasValue)
//{
//    int number = numberOrNull.Value;
//    Console.WriteLine("not null");
//}
//if (boolOrNull is not null)
//{
//    var someBool = boolOrNull.Value;
//    Console.WriteLine(someBool);
//}



//Console.WriteLine(object.ReferenceEquals(null, null));
//Console.WriteLine("Are references equal? " + 
//    object.ReferenceEquals(john, theSameAsJohn));

//var point1 = new Point(1, 5);
//var point2 = new Point(1, 5);
//Console.WriteLine("point1.Equals(point2): " +
//    point1.Equals(point2));

//Console.WriteLine("1.Equals(1): " + 1.Equals(1));
//Console.WriteLine("1.Equals(2): " + 1.Equals(2));
//Console.WriteLine("1.Equals(null): " + 1.Equals(null));
//Console.WriteLine(
//    "\"abc\".Equals(\"abc\"): " + "abc".Equals("abc"));
//Console.WriteLine();

//var john = new Person(1, "John");
//var theSameAsJohn = new Person(1, "John");
//var marie = new Person(2, "Marie");
//Console.WriteLine(
//    "john.Equals(theSameAsJohn): " + john.Equals(theSameAsJohn));

//Console.WriteLine("john.Equals(marie): " + john.Equals(marie));
//Console.WriteLine("john.Equals(null): " + john.Equals(null));

//var point1 = new Point(27, 1);
//var point2 = new Point(27, 1);
//var point3 = new Point(6, -1);
//Console.WriteLine(point1.GetHashCode());
//Console.WriteLine(point2.GetHashCode());
//Console.WriteLine(point3.GetHashCode());

//var person1 = new Person(6, "Martin");
//var person2 = new Person(6, "Martin");
//var person3 = new Person(7, "Bella");
//Console.WriteLine(person1.GetHashCode());
//Console.WriteLine(person2.GetHashCode());
//Console.WriteLine(person3.GetHashCode());

//var tuple1 = new Tuple<string, bool>("aaa", false);
//var tuple2 = Tuple.Create(10, true);
//var tuple3 = Tuple.Create(10, true);
//Console.WriteLine(tuple2 == tuple3);
//Console.WriteLine(tuple2.Equals(tuple3));
//Console.WriteLine(tuple2.GetHashCode());
//Console.WriteLine(tuple3.GetHashCode());

//var number = tuple2.Item1;
//tuple2.Item1 = 20;

//var valueTuple1 = new ValueTuple<int, string>(1, "bbb");
//var valueTuple2 = (Number: 5, Text: "ccc");
//valueTuple2.Item1 = 20;
//valueTuple2.Text = "ddd";

//var dictionary = new Dictionary<Person, string>();
//var person = new Person(1, "Karim");
//dictionary[person] = "abc";
//person.Id = 5;

////this will throw
//Console.WriteLine(dictionary[person]);
