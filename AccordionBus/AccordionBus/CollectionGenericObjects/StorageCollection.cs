using AccordionBus.Drawnings;
using ProjectAccordionBus.CollectionGenericObjects;
using System.Text;

namespace AccordionBus.CollectionGenericObjects;
/// <summary>
/// Класс-хранилище коллекций
/// </summary>
/// <typeparam name="T"></typeparam>
public class StorageCollection<T> where T : DrawningBus
{
    /// <summary>
    /// Словарь (хранилище) с коллекциями
    /// </summary>
    readonly Dictionary<string, ICollectionGenericObjects<T>> _storages;

    /// <summary>
    /// Возвращение списка названий коллекций
    /// </summary>
    public List<string> Keys => _storages.Keys.ToList();

    /// <summary>
    /// Конструктор
    /// </summary>
    public StorageCollection()
    {
        _storages = new Dictionary<string, ICollectionGenericObjects<T>>();
    }

    /// <summary>
    /// Добавление коллекции в хранилище
    /// </summary>
    /// <param name="name">Название коллекции</param>
    /// <param name="collectionType">тип коллекции</param>
    public void AddCollection(string name, CollectionType collectionType)
    {
        if (string.IsNullOrEmpty(name) || _storages.ContainsKey(name))
        {
            return;
        }
        switch (collectionType)
        {
            case CollectionType.Massive:
                _storages[name] = new MassiveGenericObjects<T>();
                break;
            case CollectionType.List:
                _storages[name] = new ListGenericObjects<T>();
                break;
            default:
                return;
        }
    }

    /// <summary>
    /// Удаление коллекции
    /// </summary>
    /// <param name="name">Название коллекции</param>
    public void DelCollection(string name)
    {
        if (_storages.ContainsKey(name))
        {
            _storages.Remove(name);
        }

    }

    /// <summary>
    /// Доступ к коллекции
    /// </summary>
    /// <param name="name">Название коллекции</param>
    /// <returns></returns>
    public ICollectionGenericObjects<T>? this[string name]
    {
        get
        {
            if (_storages.ContainsKey(name))
            {
                return _storages[name];
            }
            return null;
        }
    }
    /// <summary>
    /// Ключевое слово, с которого должен начинаться файл
    /// </summary>
    private readonly string _collectionKey = "CollectionsStorage";
    /// <summary>
    /// Разделитель для записи ключа и значения элемента словаря
    /// </summary>
    private readonly string _separatorForKeyValue = "|";
    /// <summary>
    /// Разделитель для записей коллекции данных в файл
    /// </summary>
    private readonly string _separatorItems = ";";
    /// <summary>
    /// Сохранение информации по самолетам в хранилище в файл
    /// </summary>
    /// <param name="filename">Путь и имя файла</param>
    /// <returns>true - сохранение прошло успешно, false - ошибка при сохранении данных</returns>
    public bool SaveData(string filename)
    {
        if (_storages.Count == 0)
            return false;

        if (File.Exists(filename))
            File.Delete(filename);

        using FileStream fs = new(filename, FileMode.Create);
        using StreamWriter sw = new(fs);
        sw.Write(_collectionKey);
        foreach (KeyValuePair<string, ICollectionGenericObjects<T>> value in _storages)
        {
            sw.Write(Environment.NewLine);
            if (value.Value.Count == 0)
            {
                continue;
            }

            sw.Write(value.Key);
            sw.Write(_separatorForKeyValue);
            sw.Write(value.Value.GetCollectionType);
            sw.Write(_separatorForKeyValue);
            sw.Write(value.Value.MaxCount);
            sw.Write(_separatorForKeyValue);

            foreach (T? item in value.Value.GetItems())
            {
                string data = item?.GetDataForSave() ?? string.Empty;
                if (string.IsNullOrEmpty(data))
                {
                    continue;
                }

                sw.Write(data);
                sw.Write(_separatorItems);
            }
        }
        return true;
    }

    /// <summary>
    /// Загрузка информации по самолетам в хранилище из файла
    /// </summary>
    /// <param name="filename">Путь и имя файла</param>
    /// <returns>true - загрузка прошла успешно, false - ошибка при загрузке данных</returns>
    public bool LoadData(string filename)
    {
        if (!File.Exists(filename))
        {
            return false;
        }

        using FileStream fs = new(filename, FileMode.Open);
        using StreamReader sr = new(fs);

        string str = sr.ReadLine();
        if (str == null || str.Length == 0)
        {
            return false;
        }

        if (!str.Equals(_collectionKey))
        {
            return false;
        }
        _storages.Clear();

        while (!sr.EndOfStream)
        {
            string[] record = sr.ReadLine().Split(_separatorForKeyValue, StringSplitOptions.RemoveEmptyEntries);
            if (record.Length != 4)
            {
                continue;
            }
            CollectionType collectionType = (CollectionType)Enum.Parse(typeof(CollectionType), record[1]);
            ICollectionGenericObjects<T>? collection = StorageCollection<T>.CreateCollection(collectionType);
            if (collection == null)
            {
                return false;
            }
            collection.MaxCount = Convert.ToInt32(record[2]);

            string[] set = record[3].Split(_separatorItems, StringSplitOptions.RemoveEmptyEntries);
            foreach (string elem in set)
            {
                if (elem?.CreateDrawningBus() is T drawningBus)
                {
                    if (collection.Insert(drawningBus) == -1)
                        return false;
                }
            }
            _storages.Add(record[0], collection);
        }
        return true;
    }

    /// <summary>
    /// Создание коллекции по типу
    /// </summary>
    /// <param name="collectionType"></param>
    /// <returns></returns>
    private static ICollectionGenericObjects<T>? CreateCollection(CollectionType collectionType)
    {
        return collectionType switch
        {
            CollectionType.Massive => new MassiveGenericObjects<T>(),
            CollectionType.List => new ListGenericObjects<T>(),
            _ => null,
        };
    }
}
