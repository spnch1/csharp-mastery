using System.Text.Json.Serialization;

namespace QuoteFinder.DTOs;

// todo fix throwing stuff like this 
// ===
// Exception thrown: The JSON value could not be converted to QuoteFinder.DTOs.RootDto. Path: $.lastItemIndex | LineNumber: 0 | BytePositionInLine: 75.
// ===
// (2026-01-26) -- spnch1
public record RootDto(
    [property: JsonPropertyName("count")] int Count,
    [property: JsonPropertyName("totalCount")] int TotalCount,
    [property: JsonPropertyName("page")] int Page,
    [property: JsonPropertyName("totalPages")] int TotalPages,
    [property: JsonPropertyName("lastItemIndex")] int LastItemIndex,
    [property: JsonPropertyName("results")] IReadOnlyList<ResultDto> Results
);