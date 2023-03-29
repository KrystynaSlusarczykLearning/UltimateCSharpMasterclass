using StarWarsPlanetsStats.Model;

namespace StarWarsPlanetsStats.UserInteraction;

public interface IPlanetsStatsUserInteractor
{
    void Show(IEnumerable<Planet> planets);
    string? ChooseStaticticsToBeShown(
        IEnumerable<string> propertiesThatCanBeChosen);
    void ShowMessage(string message);
}