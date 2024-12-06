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
    /// <summary>
    /// Массив объектов, которые храним
    /// </summary>
    private T?[] _collection;
    public int Count => _collection.Length;
    public int SetMaxCount
    {
        set
        {
            if (value > 0)
            {
                if (_collection.Length > 0)
                {
                    Array.Resize(ref _collection, value);
                }
                else
                {
                    _collection = new T?[value];
                }
            }
        }
    }
    /// <summary>
    /// Конструктор
    /// </summary>
    public MassiveGenericObjects()
    {
        _collection = Array.Empty<T?>();
    }
    public T? Get(int position) // получение с позиции
    {
        if (position < 0 || position >= _collection.Length) // если позиция передано неправильно
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
        return -1;
    }
    public int Insert(T obj, int position) // вставка объекта на место
    {
        if (position < 0 || position >= _collection.Length) // если позиция переданна неправильно
            return -1;
        if (_collection[position] == null)//если позиция пуста
        {
            _collection[position] = obj;
            return position;
        }
        else
        {
            for (int i = position; i < _collection.Length; ++i) //ищем свободное место справа
            {
                if (_collection[i] == null)
                {
                    _collection[i] = obj;
                    return i;
                }
            }
            for (int i = 0; i < position; ++i) // иначе слева
            {
                if (_collection[i] == null)
                {
                    _collection[i] = obj;
                    return i;
                }
            }
        }
        return -1;
    }
    public T? Remove(int position) // удаление объекта, зануляя его
    {
        if (position < 0 || position >= _collection.Length || _collection[position] == null)
            return null;
        T? temp = _collection[position];
        _collection[position] = null;
        return temp;
    }

}