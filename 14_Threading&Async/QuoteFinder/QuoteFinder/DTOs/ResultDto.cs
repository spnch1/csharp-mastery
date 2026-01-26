using System.Text.Json.Serialization;

namespace QuoteFinder.DTOs;

public record ResultDto(
    [property: JsonPropertyName("_id")] string Id,
    [property: JsonPropertyName("author")] string Author,
    [property: JsonPropertyName("content")] string Content,
    [property: JsonPropertyName("tags")] IReadOnlyList<string> Tags,
    [property: JsonPropertyName("authorSlug")] string AuthorSlug,
    [property: JsonPropertyName("length")] int Length,
    [property: JsonPropertyName("dateAdded")] string DateAdded,
    [property: JsonPropertyName("dateModified")] string DateModified
);