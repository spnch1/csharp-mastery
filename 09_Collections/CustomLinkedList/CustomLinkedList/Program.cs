using System.Collections;

LinkedList<int> list = [];
list.Add(5);

public interface ILinkedList<T> : ICollection<T>
{
    void AddToFront(T item);
    void AddToEnd(T item);
}

public class SinglyLinkedList<T> : ILinkedList<T?>
{
    private class Node(T? value)
    {
        public T? Value { get; } = value;
        public Node? Next { get; set; }

        public override string ToString() =>
            $"Value: {Value}" +
            $"Next: {(Next is null ? "null" : Next.Value)}";
    }
    
    private Node? _head;

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    public IEnumerator<T?> GetEnumerator()
    {
        foreach (var node in GetNodes())
        {
            yield return node.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T? item)
    {
        AddToEnd(item);
    }

    public void Clear()
    {
        var current = _head;
        while (current is not null)
        {
            var temp = current;
            current = current.Next;
            temp.Next = null;
        }

        _head = null;
        Count = 0;
    }

    public bool Contains(T? item) =>
        GetNodes().Any(node => item != null && item.Equals(node.Value));

    public void CopyTo(T?[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);
        if (arrayIndex < 0 || arrayIndex > array.Length)
            throw new ArgumentOutOfRangeException(nameof(array));
        if (array.Length < Count + arrayIndex)
            throw new ArgumentException("The array isn't large enough");
        
        foreach (var node in GetNodes())
        {
            array[arrayIndex] = node.Value;
            ++arrayIndex;
        }
    }

    public bool Remove(T? item)
    {
        Node? prev = null;
        foreach (var node in GetNodes())
        {
            if ((node.Value is null && item is null) ||
                (node.Value is not null && node.Value.Equals(item)))
            {
                if (prev is null)
                    _head = node.Next;
                else
                    prev.Next = node.Next;
                --Count;
                return true;
            }

            prev = node;
        }

        return false;
    }

    public void AddToFront(T? item)
    {
        Node newHead = new(item) { Next = _head };
        _head = newHead;
        ++Count;
    }

    public void AddToEnd(T? item)
    {
        Node newNode = new(item);
        if (_head is null)
        {
            _head = newNode;
        }
        else
        {
            var tail = GetNodes().Last();
            tail.Next = newNode;
        }

        ++Count;
    }

    private IEnumerable<Node> GetNodes()
    {
        var current = _head;
        while (current is not null)
        {
            yield return current;
            current = current.Next;
        }
    }
}