using StarWarsPlanetsStats.DataAccess;
using StarWarsPlanetsStats.UserInteraction;

namespace StarWarsPlanetsStats.App;

public class StarWarsPlanetsStatsApp
{
    private readonly IPlanetsReader _planetsReader;
    private readonly IPlanetsStatisticsAnalyzer _planetsStatisticsAnalyzer;
    private readonly IPlanetsStatsUserInteractor _planetsStatsUserInteractor;

    public StarWarsPlanetsStatsApp(
        IPlanetsReader planetsReader,
        IPlanetsStatisticsAnalyzer planetsStaticticsAnalyzer,
        IPlanetsStatsUserInteractor planetsStatsUserInteractor)
    {
        _planetsReader = planetsReader;
        _planetsStatisticsAnalyzer = planetsStaticticsAnalyzer;
        _planetsStatsUserInteractor = planetsStatsUserInteractor;
    }

    public async Task Run()
    {
        var planets = await _planetsReader.Read();

        _planetsStatsUserInteractor.Show(planets);

        _planetsStatisticsAnalyzer.Analyze(planets);
    }
}