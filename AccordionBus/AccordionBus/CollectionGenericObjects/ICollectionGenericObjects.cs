using AccordionBus.CollectionGenericObjects;

namespace ProjectAccordionBus.CollectionGenericObjects;
/// <summary>
/// Интерфейс описания действий для набора хранимых объектов
/// </summary>
/// <typeparam name="T">Параметр: ограничение - ссылочный тип</typeparam>
public interface ICollectionGenericObjects<T>
where T : class
{
    /// <summary>
    /// Количество объектов в коллекции
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Установка максимального количества элементов
    /// </summary>
    int MaxCount { get;  set; }

    /// <summary>
    /// Добавление объекта в коллекцию
    /// </summary>
    /// <param name="obj">Добавляемый объект</param>
    /// <returns>true - вставка прошла удачно, false - вставка не удалась</returns>
    int Insert(T obj);

    /// <summary>
    /// Добавление объекта в коллекцию на конкретную позицию
    /// </summary>
    /// <param name="obj">Добавляемый объект</param>
    /// <param name="position">Позиция</param>
    /// <returns>true - вставка прошла удачно, false - вставка не удалась</returns>
    int Insert(T obj, int position);

    /// <summary>
    /// Удаление объекта из коллекции с конкретной позиции
    /// </summary>
    /// <param name="position">Позиция</param>
    /// <returns>true - удаление прошло удачно, false - удаление не  удалось</returns>
    T? Remove(int position);

    /// <summary>
    /// Получение объекта по позиции
    /// </summary>
    /// <param name="position">Позиция</param>
    /// <returns>Объект</returns>
    T? Get(int position);

    /// <summary>
    /// Получение типа коллекции
    /// </summary>
    CollectionType GetCollectionType { get; }

    /// <summary>
    /// Получение объектов коллекции по одному
    /// </summary>
    /// <returns>Поэлементый вывод элементов коллекции</returns>
    IEnumerable<T?> GetItems();
}
