using AccordionBus.Drawnings;
using AccordionBus.Exeptions;
using ProjectAccordionBus.CollectionGenericObjects;

namespace AccordionBus.CollectionGenericObjects;

public class ListGenericObjects<T> : ICollectionGenericObjects<T> where T : class
{
    private readonly List<T?> _collection;
    private int _maxCount;
    public int Count => _collection.Count;
    public CollectionType GetCollectionType => CollectionType.List;

    public int MaxCount
    {
        get
        {
            return _maxCount;
        }
        set
        {
            if (value > 0) _maxCount = value;
        }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public ListGenericObjects()
    {
        _collection = new();
    }

    public T? Get(int position)
    {
        if (position >= 0 && position < Count)
        {
            return _collection[position];
        }
        else
        {
            return null;
            throw new PositionOutOfCollectionException(position);
        }

    }

    public int Insert(T obj, IEqualityComparer<DrawningBus?>? comparer = null)
    {
        if (Count == _maxCount)
            throw new CollectionOverflowException(Count);
        _collection.Add(obj);
        return Count;
    }

    public int Insert(T obj, int position, IEqualityComparer<DrawningBus?>? comparer = null)
    {
        if (position < 0 || position >= Count || Count == _maxCount)
            throw new PositionOutOfCollectionException(position);

        if (Count == _maxCount)
            throw new CollectionOverflowException(Count);

        _collection.Insert(position, obj);
        return position;

    }

    public T? Remove(int position)
    {
        if (position >= Count || position < 0)
            throw new PositionOutOfCollectionException(position);

        T? obj = _collection[position];
        _collection?.RemoveAt(position);
        return obj;
    }

    public IEnumerable<T?> GetItems()
    {
        for (int i = 0; i < _collection.Count; i++)
        {
            yield return _collection[i];
        }
    }

    void ICollectionGenericObjects<T>.CollectionSort(IComparer<T?> comparer)
    {
        _collection.Sort(comparer);
    }
}