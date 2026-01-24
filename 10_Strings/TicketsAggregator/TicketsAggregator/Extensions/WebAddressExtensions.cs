namespace TicketsAggregator.Extensions;

internal static class WebAddressExtensions
{
    public static string ExtractDomain(this string address) =>
        address[address.LastIndexOf('.')..];
}