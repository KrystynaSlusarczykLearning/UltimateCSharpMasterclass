using System.Text.Json.Serialization;

public record Annotations(
       [property: JsonPropertyName("source_name")] string source_name,
       [property: JsonPropertyName("source_description")] string source_description,
       [property: JsonPropertyName("dataset_name")] string dataset_name,
       [property: JsonPropertyName("dataset_link")] string dataset_link,
       [property: JsonPropertyName("table_id")] string table_id,
       [property: JsonPropertyName("topic")] string topic,
       [property: JsonPropertyName("subtopic")] string subtopic
   );

public record Datum(
    [property: JsonPropertyName("ID Nation")] string IDNation,
    [property: JsonPropertyName("Nation")] string Nation,
    [property: JsonPropertyName("ID Year")] int IDYear,
    [property: JsonPropertyName("Year")] string Year,
    [property: JsonPropertyName("Population")] int Population,
    [property: JsonPropertyName("Slug Nation")] string SlugNation
);

public record Root(
    [property: JsonPropertyName("data")] IReadOnlyList<Datum> data,
    [property: JsonPropertyName("source")] IReadOnlyList<Source> source
);

public record Source(
    [property: JsonPropertyName("measures")] IReadOnlyList<string> measures,
    [property: JsonPropertyName("annotations")] Annotations annotations,
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("substitutions")] IReadOnlyList<object> substitutions
);





