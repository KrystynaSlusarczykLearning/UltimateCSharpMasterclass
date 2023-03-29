using TicketsDataAggregator.FileAccess;
using TicketsDataAggregator.TicketsAggregation;

const string TicketsFolder = @"C:\OurCinema\Tickets";

try
{
    var ticketsAggregator = new TicketsAggregator(
        TicketsFolder,
        new FileWriter(),
        new DocumentsFromPdfsReader());

    ticketsAggregator.Run();
}
catch (Exception ex)
{
    Console.WriteLine("An exception occurred. " +
        "Exception message: " + ex.Message);
}

Console.WriteLine("Press any key to close.");
Console.ReadKey();
