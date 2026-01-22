public class Cache<TKey, TData> where TKey : notnull
{
    private readonly Dictionary<TKey, TData> _items = new();

    public TData GetOrAdd(TKey key, Func<TKey, TData> valueFactory)
    {
        ArgumentNullException.ThrowIfNull(valueFactory);

        if (_items.TryGetValue(key, out var existing))
            return existing;

        var value = valueFactory(key);
        _items[key] = value;
        return value;
    }
}