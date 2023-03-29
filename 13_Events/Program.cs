//Classic Observer design pattern - without events
Console.WriteLine("Observer design pattern without events");
const int threshold = 30_000;

var emailPriceChangeNotifierNoEvents = new EmailPriceChangeNotifierNoEvents(
    threshold);
var pushPriceChangeNotifierNoEvents = new PushPriceChangeNotifierNoEvents(
    threshold);
var goldPriceReaderNoEvents = new GoldPriceReaderNoEvents();
goldPriceReaderNoEvents .AttachObserver(emailPriceChangeNotifierNoEvents);
goldPriceReaderNoEvents.AttachObserver(pushPriceChangeNotifierNoEvents);

for (int i = 0; i < 3; ++i)
{
    goldPriceReaderNoEvents.ReadCurrentPrice();
}

Console.WriteLine("Turning push notifications off");
goldPriceReaderNoEvents.DetachObserver(pushPriceChangeNotifierNoEvents);
for (int i = 0; i < 3; ++i)
{
    goldPriceReaderNoEvents.ReadCurrentPrice();
}


Console.WriteLine("The same behavior, but using events");
var goldPriceReader = new GoldPriceReader();

bool areNotificationsEnabled = true;
if (areNotificationsEnabled)
{
    var emailPriceChangeNotifier = new EmailPriceChangeNotifier(
        threshold);
    var pushPriceChangeNotifier = new PushPriceChangeNotifier(
        threshold);
    goldPriceReader.PriceRead += emailPriceChangeNotifier.Update;
    goldPriceReader.PriceRead += pushPriceChangeNotifier.Update;

    for (int i = 0; i < 3; ++i)
    {
        goldPriceReader.ReadCurrentPrice();
    }

    goldPriceReader.PriceRead -= emailPriceChangeNotifier.Update;
    goldPriceReader.PriceRead -= pushPriceChangeNotifier.Update;
}

Console.ReadKey();

public class PriceReadEventArgs : EventArgs
{
    public decimal Price { get; }

    public PriceReadEventArgs(decimal price)
    {
        Price = price;
    }
}

public class GoldPriceReader
{
    public event EventHandler<PriceReadEventArgs>? PriceRead;

    public void ReadCurrentPrice()
    {
        var currentGoldPrice = new Random().Next(
            20_000, 50_000);

        OnPriceRead(currentGoldPrice);
    }

    private void OnPriceRead(decimal price)
    {
        PriceRead?.Invoke(
            this, 
            new PriceReadEventArgs(price));
    }
}

public class EmailPriceChangeNotifier
{
    private readonly decimal _notificationThreshold;

    public EmailPriceChangeNotifier(
        decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(
        object? sender, PriceReadEventArgs eventArgs)
    {
        if (eventArgs.Price > _notificationThreshold)
        {
            //imagine this is actually sending an email
            Console.WriteLine(
                $"Sending an email saying that " +
                $"the gold price exceeded {_notificationThreshold} " +
                $"and is now {eventArgs.Price}\n");
        }
    }
}

public class PushPriceChangeNotifier
{
    private readonly decimal _notificationThreshold;

    public PushPriceChangeNotifier(
        decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(
        object? sender, PriceReadEventArgs eventArgs)
    {
        if (eventArgs.Price > _notificationThreshold)
        {
            //imagine this is actually sending a push notification
            Console.WriteLine(
                $"Sending a push notification saying that " +
                $"the gold price exceeded {_notificationThreshold} " +
                $"and is now {eventArgs.Price}\n");
        }
    }
}

//Classic Observer design pattern - without events
public class GoldPriceReaderNoEvents : IObservable<decimal>
{
    private int _currentGoldPrice;
    private readonly List<IObserver<decimal>> _observers = new();

    public void ReadCurrentPrice()
    {
        _currentGoldPrice = new Random().Next(
            20_000, 50_000);

        NotifyObservers();
    }

    public void AttachObserver(IObserver<decimal> observer)
    {
        _observers.Add(observer);
    }

    public void DetachObserver(IObserver<decimal> observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_currentGoldPrice);
        }
    }
}

public class EmailPriceChangeNotifierNoEvents : IObserver<decimal>
{
    private readonly decimal _notificationThreshold;

    public EmailPriceChangeNotifierNoEvents(
        decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(decimal price)
    {
        if (price > _notificationThreshold)
        {
            //imagine this is actually sending an email
            Console.WriteLine(
                $"Sending an email saying that " +
                $"the gold price exceeded {_notificationThreshold} " +
                $"and is now {price}\n");
        }
    }
}

public class PushPriceChangeNotifierNoEvents : IObserver<decimal>
{
    private readonly decimal _notificationThreshold;

    public PushPriceChangeNotifierNoEvents(
        decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(decimal price)
    {
        if (price > _notificationThreshold)
        {
            //imagine this is actually sending a push notification
            Console.WriteLine(
                $"Sending a push notification saying that " +
                $"the gold price exceeded {_notificationThreshold} " +
                $"and is now {price}\n");
        }
    }
}

public interface IObserver<TData>
{
    void Update(TData data);
}

public interface IObservable<TData>
{
    void AttachObserver(IObserver<TData> observer);
    void DetachObserver(IObserver<TData> observer);
    void NotifyObservers();
}