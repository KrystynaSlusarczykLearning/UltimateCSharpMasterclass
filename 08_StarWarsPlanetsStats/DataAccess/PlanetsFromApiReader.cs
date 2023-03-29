using StarWarsPlanetsStats.ApiDataAccess;
using StarWarsPlanetsStats.DTOs;
using StarWarsPlanetsStats.Model;
using StarWarsPlanetsStats.UserInteraction;
using System.Text.Json;

namespace StarWarsPlanetsStats.DataAccess;

public class PlanetsFromApiReader : IPlanetsReader
{
    private readonly IApiDataReader _apiDataReader;
    private readonly IApiDataReader _secondaryApiDataReader;
    private readonly IUserInteractor _userInteractor;

    public PlanetsFromApiReader(
        IApiDataReader apiDataReader,
        IApiDataReader secondaryApiDataReader,
        IUserInteractor userInteractor)
    {
        _apiDataReader = apiDataReader;
        _secondaryApiDataReader = secondaryApiDataReader;
        _userInteractor = userInteractor;
    }

    public async Task<IEnumerable<Planet>> Read()
    {
        string? json = null;
        try
        {
            json = await _apiDataReader.Read(
                "https://swapi.dev/", "api/planets");
        }
        catch (HttpRequestException ex)
        {
            _userInteractor.ShowMessage(
                "API request was unsuccessful. " +
                "Switching to mock data. " +
                "Exception message: " + ex.Message);
        }
        json ??= await _secondaryApiDataReader.Read(
                "https://swapi.dev/", "api/planets");

        var root = JsonSerializer.Deserialize<Root>(json);

        return ToPlanets(root);
    }

    private static IEnumerable<Planet> ToPlanets(Root? root)
    {
        if (root is null)
        {
            throw new ArgumentNullException(nameof(root));
        }

        return root.results.Select(
            planetDto => (Planet)planetDto);
    }
}