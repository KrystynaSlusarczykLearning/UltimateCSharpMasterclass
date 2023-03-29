//Events - User and BankAccount 

public delegate void OnBalanceDecreased(decimal balance);

public class BankAccount
{
    public decimal Balance { get; private set; }
    public BankAccount(decimal initialBalance)
    {
        Balance = initialBalance;
    }
    public event OnBalanceDecreased OnBalanceDecreased;

    public void DecreaseBalance(decimal price)
    {
        Balance -= price;
        OnBalanceDecreased(price);
    }
}

public class User
{
    public decimal Funds { get; private set; }

    public User(decimal cash, decimal moneyInBank)
    {
        Funds = cash + moneyInBank;
    }

    public void ReduceFunds(decimal balanceReduced)
    {
        Funds -= balanceReduced;
    }
}


//Events - WeatherDataAggregator
public record struct WeatherData(int? Temperature, int? Humidity);

public class WeatherDataAggregator
{
    public IEnumerable<WeatherData> WeatherHistory => _weatherHistory;
    private List<WeatherData> _weatherHistory = new();

    public void GetNotifiedAboutNewData(
        object? sender, WeatherDataEventArgs eventArgs)
    {
        _weatherHistory.Add(eventArgs.WeatherData);
    }
}

public class WeatherStation
{
    public event EventHandler<WeatherDataEventArgs>? WeatherMeasured;

    public void Measure()
    {
        int temperature = 25;

        OnWeatherMeasured(temperature);
    }

    private void OnWeatherMeasured(int temperature)
    {
        WeatherMeasured?.Invoke(
            this,
            new WeatherDataEventArgs(
                new WeatherData(temperature, null)));
    }
}

public class WeatherBaloon
{
    public event EventHandler<WeatherDataEventArgs>? WeatherMeasured;

    public void Measure()
    {
        int humidity = 50;

        OnWeatherMeasured(humidity);
    }

    private void OnWeatherMeasured(int humidity)
    {
        WeatherMeasured?.Invoke(
            this,
            new WeatherDataEventArgs(
                new WeatherData(null, humidity)));
    }
}

public class WeatherDataEventArgs : EventArgs
{
    public WeatherData WeatherData { get; }

    public WeatherDataEventArgs(WeatherData weatherData)
    {
        WeatherData = weatherData;
    }
}