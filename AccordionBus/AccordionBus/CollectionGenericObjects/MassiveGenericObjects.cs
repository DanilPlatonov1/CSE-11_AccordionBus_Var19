using AccordionBus.Drawnings;
using AccordionBus.Exeptions;
using ProjectAccordionBus.CollectionGenericObjects;
using System.Collections.Generic;

namespace AccordionBus.CollectionGenericObjects;
public class MassiveGenericObjects<T> : ICollectionGenericObjects<T>
where T : class
{
    public CollectionType GetCollectionType => CollectionType.Massive;

    /// <summary>
    /// Массив объектов, которые храним
    /// </summary>
    private T?[] _collection;

    public int Count => _collection.Length;

    public int MaxCount
    {
        get => _collection.Length;
        set
        {
            if (value > 0)
            {
                T?[] newCollection = new T?[value];
                for (int i = 0; i < Math.Min(_collection.Length, value); i++)
                {
                    newCollection[i] = _collection[i];
                }
                _collection = newCollection;
            }
        }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public MassiveGenericObjects()
    {
        _collection = new T?[24];
    }

    public T? Get(int position)
    {
        if (position < 0 || position >= _collection.Length)
            throw new PositionOutOfCollectionException();

        return _collection[position];
    }

    public int Insert(T obj, IEqualityComparer<DrawningBus?>? comparer = null)
    {
        for (int i = 0; i < _collection.Length; i++)
        {
            if (_collection[i] == null)
            {
                _collection[i] = obj;
                return i;
            }
        }
        throw new CollectionOverflowException(Count);
    }

    public int Insert(T obj, int position, IEqualityComparer<DrawningBus?>? comparer = null)
    {
        if (position < 0 || position >= _collection.Length)
            throw new PositionOutOfCollectionException(position);

        if (_collection[position] == null)
        {
            _collection[position] = obj;
            return position;
        }
        else
        {
            for (int i = position; i < _collection.Length; ++i)
            {
                if (_collection[i] == null)
                {
                    _collection[i] = obj;
                    return i;
                }
            }
            for (int i = 0; i < position; ++i)
            {
                if (_collection[i] == null)
                {
                    _collection[i] = obj;
                    return i;
                }
            }
        }
        throw new CollectionOverflowException(Count);
    }

    public T? Remove(int position)
    {
        if (_collection[position] == null)
        {
            throw new ObjectNotFoundException(position);
        }

        if (position < 0 || position >= _collection.Length || _collection[position] == null)
            throw new PositionOutOfCollectionException(position);

        T? temp = _collection[position];
        _collection[position] = null;

        return temp;
    }

    public IEnumerable<T?> GetItems()
    {
        foreach (var item in _collection)
        {
            yield return item;
        }
    }

    public void CollectionSort(IComparer<T?> comparer)
    {
        Array.Sort(_collection, comparer);
        Array.Reverse(_collection);
    }
}