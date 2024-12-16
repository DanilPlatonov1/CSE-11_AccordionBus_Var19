using AccordionBus.Drawnings;

namespace AccordionBus.CollectionGenericObjects;

/// <summary>
/// Сравнение по цвету
/// </summary>
public class BusCompareByColor : IComparer<DrawningBus?>
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

        var bodycolorCompare = x.EntityBus.BodyColor.Name.CompareTo(y.EntityBus.BodyColor.Name);

        if (bodycolorCompare != 0)
        {
            return bodycolorCompare;
        }

        var speedCompare = x.EntityBus.Speed.CompareTo(y.EntityBus.Speed);

        if (speedCompare != 0)
        {
            return speedCompare;
        }

        return x.EntityBus.Weight.CompareTo(y.EntityBus.Weight);
    }
}
