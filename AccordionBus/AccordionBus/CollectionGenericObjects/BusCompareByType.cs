using AccordionBus.Drawnings;

namespace AccordionBus.CollectionGenericObjects;

/// <summary>
/// Сравнение по типу, скорости, весу
/// </summary>
public class BusCompareByType : IComparer<DrawningBus?>
{
    public int Compare(DrawningBus? x, DrawningBus? y)
    {
        // Обработка случаев, когда x и y равны null
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;

        // Обработка случаев, когда EntityBus равен null
        if (x.EntityBus == null && y.EntityBus == null) return 0;
        if (x.EntityBus == null) return -1;
        if (y.EntityBus == null) return 1;

        // Сравнение типов объектов
        var typeComparison = string.Compare(x.GetType().FullName, y.GetType().FullName, StringComparison.Ordinal);
        if (typeComparison != 0)
        {
            return typeComparison;
        }

        // Сравнение по скорости
        var speedComparison = x.EntityBus.Speed.CompareTo(y.EntityBus.Speed);
        if (speedComparison != 0)
        {
            return speedComparison;
        }

        // Сравнение по весу
        return x.EntityBus.Weight.CompareTo(y.EntityBus.Weight);
    }
}