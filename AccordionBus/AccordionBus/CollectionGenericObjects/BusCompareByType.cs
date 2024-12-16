using AccordionBus.Drawnings;

namespace AccordionBus.CollectionGenericObjects;

/// <summary>
/// Сравнение по типу, скорости, весу
/// </summary>
public class BusCompareByType : IComparer<DrawningBus?>
{
    public int Compare(DrawningBus? x, DrawningBus? y)
    {
        if (x == null || x.EntityBus == null)
        {
            throw new ArgumentNullException(nameof(x));
        }

        if (y == null || y.EntityBus == null)
        {
            throw new ArgumentNullException(nameof(y));
        }

        if (x.GetType().Name != y.GetType().Name)
        {
            return x.GetType().Name.CompareTo(y.GetType().Name);
        }

        var speedCompare = x.EntityBus.Speed.CompareTo(y.EntityBus.Speed);

        if (speedCompare != 0)
        {
            return speedCompare;
        }

        return x.EntityBus.Weight.CompareTo(y.EntityBus.Weight);
    }

}