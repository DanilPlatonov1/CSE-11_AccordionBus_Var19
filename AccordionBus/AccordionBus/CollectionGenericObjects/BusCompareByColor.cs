using AccordionBus.Drawnings;
using AccordionBus.Entities;

namespace AccordionBus.CollectionGenericObjects;

/// <summary>
/// Сравнение по цвету
/// </summary>
public class BusCompareByColor : IComparer<DrawningBus?>
{
    public int Compare(DrawningBus? x, DrawningBus? y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;

        if (x.EntityBus == null && y.EntityBus == null) return 0;
        if (x.EntityBus == null) return -1;
        if (y.EntityBus == null) return 1;

        int colorComparison = string.Compare(x.EntityBus.BodyColor.Name, y.EntityBus.BodyColor.Name, StringComparison.Ordinal);

        if (colorComparison != 0)
        {
            return colorComparison;
        }

        if (x.GetType() != y.GetType())
        {
            return string.Compare(x.GetType().FullName, y.GetType().FullName, StringComparison.Ordinal);
        }

        if (x is DrawningAccordionBus && y is DrawningAccordionBus)
        {
            var entityX = x.EntityBus as EntityAccordionBus;
            var entityY = y.EntityBus as EntityAccordionBus;

            if (entityX != null && entityY != null)
            {
                int additionalColorComparison = string.Compare(entityX.AdditionalColor.Name, entityY.AdditionalColor.Name, StringComparison.Ordinal);
                {
                    return additionalColorComparison;
                }
            }
        }

        int speedComparison = x.EntityBus.Speed.CompareTo(y.EntityBus.Speed);

        if (speedComparison != 0)
        {
            return speedComparison;
        }

        return x.EntityBus.Weight.CompareTo(y.EntityBus.Weight);
    }
}
