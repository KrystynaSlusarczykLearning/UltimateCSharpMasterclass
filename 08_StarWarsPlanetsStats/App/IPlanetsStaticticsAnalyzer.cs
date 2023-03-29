using StarWarsPlanetsStats.Model;

namespace StarWarsPlanetsStats.App;

public interface IPlanetsStatisticsAnalyzer
{
    void Analyze(IEnumerable<Planet> planets);
}