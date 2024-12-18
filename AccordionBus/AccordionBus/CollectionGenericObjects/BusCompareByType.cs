using AccordionBus.Drawnings;

namespace AccordionBus.CollectionGenericObjects;

/// <summary>
/// Сравнение по типу, скорости, весу
/// </summary>
public class BusCompareByType : IComparer<DrawningBus?>
{
    public int Compare(DrawningBus? x, DrawningBus? y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;

        if (x.EntityBus == null && y.EntityBus == null) return 0;
        if (x.EntityBus == null) return -1;
        if (y.EntityBus == null) return 1;

        var typeComparison = string.Compare(x.GetType().FullName, y.GetType().FullName, StringComparison.Ordinal);

        if (typeComparison != 0)
        {
            return typeComparison;
        }

        var speedComparison = x.EntityBus.Speed.CompareTo(y.EntityBus.Speed);

        if (speedComparison != 0)
        {
            return speedComparison;
        }

        return x.EntityBus.Weight.CompareTo(y.EntityBus.Weight);
    }
}