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
        // Обработка случаев, когда x и y равны null
        if (x == null && y == null) return 0;
        if (x == null) return -1; // null считается меньше любого значения
        if (y == null) return 1;

        // Обработка случаев, когда EntityBus равен null
        if (x.EntityBus == null && y.EntityBus == null) return 0;
        if (x.EntityBus == null) return -1;
        if (y.EntityBus == null) return 1;

        // Сравнение по BodyColor.Name
        int colorComparison = string.Compare(x.EntityBus.BodyColor.Name, y.EntityBus.BodyColor.Name, StringComparison.Ordinal);
        if (colorComparison != 0)
        {
            return colorComparison;
        }

        // Сравнение по типу (с использованием полного имени)
        if (x.GetType() != y.GetType())
        {
            return string.Compare(x.GetType().FullName, y.GetType().FullName, StringComparison.Ordinal);
        }

        // Если оба объекта являются DrawningAccordionBus, сравниваем AdditionalColor
        if (x is DrawningAccordionBus && y is DrawningAccordionBus)
        {
            var entityX = x.EntityBus as EntityAccordionBus;
            var entityY = y.EntityBus as EntityAccordionBus;

            if (entityX != null && entityY != null)
            {
                int additionalColorComparison = string.Compare(entityX.AdditionalColor.Name, entityY.AdditionalColor.Name, StringComparison.Ordinal);
                if (additionalColorComparison != 0)
                {
                    return additionalColorComparison;
                }
            }
        }

        // Сравнение по скорости
        int speedComparison = x.EntityBus.Speed.CompareTo(y.EntityBus.Speed);
        if (speedComparison != 0)
        {
            return speedComparison;
        }

        // Сравнение по весу
        return x.EntityBus.Weight.CompareTo(y.EntityBus.Weight);
    }

}
