using System.Text.Json.Serialization;

namespace StarWarsPlanetsStats.DTOs;

public record Result(
        [property: JsonPropertyName("name")] string name,
        [property: JsonPropertyName("rotation_period")] string rotation_period,
        [property: JsonPropertyName("orbital_period")] string orbital_period,
        [property: JsonPropertyName("diameter")] string diameter,
        [property: JsonPropertyName("climate")] string climate,
        [property: JsonPropertyName("gravity")] string gravity,
        [property: JsonPropertyName("terrain")] string terrain,
        [property: JsonPropertyName("surface_water")] string surface_water,
        [property: JsonPropertyName("population")] string population,
        [property: JsonPropertyName("residents")] IReadOnlyList<string> residents,
        [property: JsonPropertyName("films")] IReadOnlyList<string> films,
        [property: JsonPropertyName("created")] DateTime created,
        [property: JsonPropertyName("edited")] DateTime edited,
        [property: JsonPropertyName("url")] string url
    );