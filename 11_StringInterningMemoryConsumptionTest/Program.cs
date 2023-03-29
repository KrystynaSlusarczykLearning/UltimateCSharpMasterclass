//string interning
const int Count = 10000;
TestStringsMemoryConsumption(Count);
TestCharArraysMemoryConsumption(Count);
TestVariousStringsMemoryConsumption(Count);
Console.ReadKey();

void TestStringsMemoryConsumption(int count)
{
    var list = new List<string>(count);
    GC.Collect(2, GCCollectionMode.Default, true);
    var memoryBefore = GC.GetTotalMemory(false);

    for (int i = 0; i < Count; ++i)
    {
        list.Add($"aaaaa");
    }

    GC.Collect(2, GCCollectionMode.Default, true);
    var memoryAfter = GC.GetTotalMemory(false);
    Console.WriteLine(
        "(strings) difference in bytes is " + (memoryAfter - memoryBefore));
}

void TestCharArraysMemoryConsumption(int count)
{
    var list = new List<char[]>(count);
    GC.Collect(2, GCCollectionMode.Default, true);
    var memoryBefore = GC.GetTotalMemory(false);

    for (int i = 0; i < count; ++i)
    {
        list.Add(new char[] { 'a', 'a', 'a', 'a', 'a' });
    }
    GC.Collect(2, GCCollectionMode.Default, true);
    var memoryAfter = GC.GetTotalMemory(false);
    Console.WriteLine(
        "(char arrays) difference in bytes is " + (memoryAfter - memoryBefore));
}

void TestVariousStringsMemoryConsumption(int count)
{
    var list = new List<string>(count);
    GC.Collect(2, GCCollectionMode.Default, true);
    var memoryBefore = GC.GetTotalMemory(false);

    for (int i = 0; i < Count; ++i)
    {
        list.Add($"aaaaa{i}"); //noe wach string will be different, so they won't be interned
    }

    GC.Collect(2, GCCollectionMode.Default, true);
    var memoryAfter = GC.GetTotalMemory(false);
    Console.WriteLine(
        "(various strings) difference in bytes is " + (memoryAfter - memoryBefore));
}
