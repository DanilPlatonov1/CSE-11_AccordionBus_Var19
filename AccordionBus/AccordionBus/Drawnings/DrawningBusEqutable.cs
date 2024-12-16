using AccordionBus.Entities;
using System.Diagnostics.CodeAnalysis;

namespace AccordionBus.Drawnings;

public class DrawiningBusEqutables : IEqualityComparer<DrawningBus?>
{
    public bool Equals(DrawningBus? x, DrawningBus? y)
    {
        if (x == null || x.EntityBus == null)
        {
            return false;
        }

        if (y == null || y.EntityBus == null)
        {
            return false;
        }

        if (x.GetType().Name != y.GetType().Name)
        {
            return false;
        }

        if (x.EntityBus.Speed != y.EntityBus.Speed)
        {
            return false;
        }

        if (x.EntityBus.Weight != y.EntityBus.Weight)
        {
            return false;
        }

        if (x.EntityBus.BodyColor != y.EntityBus.BodyColor)
        {
            return false;
        }

        if (x is DrawningAccordionBus && y is DrawningAccordionBus)
        {
            EntityAccordionBus _x = (EntityAccordionBus)x.EntityBus;
            EntityAccordionBus _y = (EntityAccordionBus)x.EntityBus;
            if (_x.AdditionalColor != _y.AdditionalColor)
            {
                return false;
            }

            if (_x.BodyGarmoshka != _y.BodyGarmoshka)
            {
                return false;
            }

            if (_x.BodyGlass != _y.BodyGlass)
            {
                return false;
            }
        }

        return true;
    }

    public int GetHashCode([DisallowNull] DrawningBus obj)
    {
        return obj.GetHashCode();
    }
}
