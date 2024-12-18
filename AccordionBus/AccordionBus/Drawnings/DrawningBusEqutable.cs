using AccordionBus.Entities;
using System.Diagnostics.CodeAnalysis;

namespace AccordionBus.Drawnings;

public class DrawiningBusEqutables : IEqualityComparer<DrawningBus?>
{
    public bool Equals(DrawningBus? x, DrawningBus? y)
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
            EntityAccordionBus entityX = (EntityAccordionBus)x.EntityBus;
            EntityAccordionBus entityY = (EntityAccordionBus)y.EntityBus;
            if (entityX.AdditionalColor != entityY.AdditionalColor)
            {
                return false;
            }
            if (entityX.BodyGarmoshka != entityY.BodyGarmoshka)
            {
                return false;
            }
            if (entityX.BodyGlass != entityY.BodyGlass)
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
