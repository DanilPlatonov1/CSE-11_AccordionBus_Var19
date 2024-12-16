using AccordionBus.Drawnings;
using AccordionBus.Exeptions;
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
    readonly Dictionary<CollectionInfo, ICollectionGenericObjects<T>> _storages;

    /// <summary>
    /// Возвращение списка названий коллекций
    /// </summary>
    public List<CollectionInfo> Keys => _storages.Keys.ToList();

    /// <summary>
    /// Конструктор
    /// </summary>
    public StorageCollection()
    {
        _storages = new Dictionary<CollectionInfo, ICollectionGenericObjects<T>>();
    }

    /// <summary>
    /// Добавление коллекции в хранилище
    /// </summary>
    /// <param name="name">Название коллекции</param>
    /// <param name="collectionType">тип коллекции</param>
    public void AddCollection(string name, CollectionType collectionType)
    {
        CollectionInfo collectionInfo = new CollectionInfo(name, collectionType, string.Empty);

        if (_storages.ContainsKey(collectionInfo)) return;

        if (collectionType == CollectionType.None) return;

        else if (collectionType == CollectionType.Massive)
            _storages[collectionInfo] = new MassiveGenericObjects<T>();

        else if (collectionType == CollectionType.List)
            _storages[collectionInfo] = new ListGenericObjects<T>();
    }

    /// <summary>
    /// Удаление коллекции
    /// </summary>
    /// <param name="name">Название коллекции</param>
    public void DelCollection(string name)
    {
        CollectionInfo collectionInfo = new CollectionInfo(name, CollectionType.None, string.Empty);
        if (_storages.ContainsKey(collectionInfo))
            _storages.Remove(collectionInfo);
    }

    /// <summary>
    /// Доступ к коллекции
    /// </summary>
    /// <param name="name">Название коллекции</param>
    /// <returns></returns>
    public ICollectionGenericObjects<T> this[string name]
    {
        get
        {
            CollectionInfo collectionInfo = new CollectionInfo(name, CollectionType.None, string.Empty);
            if (_storages.ContainsKey(collectionInfo))
                return _storages[collectionInfo];

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
    /// Сохранение информации в файл
    /// </summary>
    /// <param name="filename">Путь и имя файла</param>
    /// <returns>true - сохранение прошло успешно, false - ошибка при сохранении данных</returns>
    public void SaveData(string filename)
    {
        if (_storages.Count == 0)
            throw new Exception("В хранилище отсутствуют коллекции для сохранения");

        if (File.Exists(filename))
            File.Delete(filename);

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.Write(_collectionKey);
            foreach (KeyValuePair<CollectionInfo, ICollectionGenericObjects<T>> value in _storages)
            {
                StringBuilder sb = new();
                sb.Append(Environment.NewLine);
                if (value.Value.Count == 0)
                    continue;
                sb.Append(value.Key);
                sb.Append(_separatorForKeyValue);
                sb.Append(value.Value.MaxCount);
                sb.Append(_separatorForKeyValue);
                foreach (T? item in value.Value.GetItems())
                {
                    string data = item?.GetDataForSave() ?? string.Empty;
                    if (string.IsNullOrEmpty(data))
                        continue;
                    sb.Append(data);
                    sb.Append(_separatorItems);
                }
                writer.Write(sb);
            }

        }
    }

    /// <summary>
    /// Загрузка информации из файла
    /// </summary>
    /// <param name="filename">Путь и имя файла</param>
    /// <returns>true - загрузка прошла успешно, false - ошибка при загрузке данных</returns>
    public void LoadData(string filename)
    {
        if (!File.Exists(filename))
            throw new Exception("Файл не существует");

        using (StreamReader fs = File.OpenText(filename))
        {
            string str = fs.ReadLine();
            if (str == null || str.Length == 0)
                throw new Exception("В файле нет данных");

            if (!str.StartsWith(_collectionKey))
                throw new Exception("В файле неверные данные");

            _storages.Clear();
            string strs = "";
            while ((strs = fs.ReadLine()) != null)
            {
                string[] record = strs.Split(_separatorForKeyValue, StringSplitOptions.RemoveEmptyEntries);
                if (record.Length != 3)
                    continue;
                CollectionInfo? collectionInfo = CollectionInfo.GetCollectionInfo(record[0]) ?? throw new Exception("Не удалось определить информацию коллекции: " + record[0]);

                ICollectionGenericObjects<T>? collection = StorageCollection<T>.CreateCollection(collectionInfo.CollectionType);
                if (collection == null)
                    throw new Exception("Не удалось создать коллекцию");
                collection.MaxCount = Convert.ToInt32(record[1]);
                string[] set = record[2].Split(_separatorItems, StringSplitOptions.RemoveEmptyEntries);
                foreach (string elem in set)
                {
                    if (elem?.CreateDrawningBus() is T bus)
                    {
                        try
                        {
                            if (collection.Insert(bus) == -1)
                            {
                                throw new Exception("Объект не удалось добавить в коллекцию: " + record[3]);
                            }
                        }
                        catch (CollectionOverflowException ex)
                        {
                            throw new Exception("Коллекция переполнена", ex);
                        }
                    }
                }
                _storages.Add(collectionInfo, collection);
            }
        }
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
