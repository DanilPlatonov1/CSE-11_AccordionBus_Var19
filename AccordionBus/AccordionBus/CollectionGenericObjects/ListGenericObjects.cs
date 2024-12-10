using ProjectAccordionBus.CollectionGenericObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

    }

    public int Insert(T obj)
    {
        if (Count == _maxCount) { return -1; }
        _collection.Add(obj);
        return Count;
    }

    public int Insert(T obj, int position)
    {
        if (position < 0 || position >= Count || Count == _maxCount)
        {
            return -1;
        }
        _collection.Insert(position, obj);
        return position;

    }

    public T? Remove(int position)
    {
        if (position >= Count || position < 0) return null;
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
}