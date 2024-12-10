using ProjectAccordionBus.CollectionGenericObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                // Создаем новый массив с заданной длиной и копируем существующие элементы
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
        _collection = new T?[0]; // Начальная длина 0
    }

    public T? Get(int position) // получение с позиции
    {
        if (position < 0 || position >= _collection.Length) // если позиция передана неправильно
            return null;
        return _collection[position];
    }

    public int Insert(T obj) // вставка объекта на свободное место
    {
        for (int i = 0; i < _collection.Length; ++i)
        {
            if (_collection[i] == null)
            {
                _collection[i] = obj;
                return i;
            }
        }
        return -1; // Нет свободного места
    }

    public int Insert(T obj, int position) // вставка объекта на место
    {
        if (position < 0 || position >= _collection.Length) // если позиция передана неправильно
            return -1;

        if (_collection[position] == null) // если позиция пуста
        {
            _collection[position] = obj;
            return position;
        }
        else
        {
            // Ищем свободное место справа
            for (int i = position; i < _collection.Length; ++i)
            {
                if (_collection[i] == null)
                {
                    _collection[i] = obj;
                    return i;
                }
            }
            // Ищем свободное место слева
            for (int i = 0; i < position; ++i)
            {
                if (_collection[i] == null)
                {
                    _collection[i] = obj;
                    return i;
                }
            }
        }
        return -1; // Нет свободного места
    }

    public T? Remove(int position) // удаление объекта, зануляя его
    {
        if (position < 0 || position >= _collection.Length || _collection[position] == null)
            return null;

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
}