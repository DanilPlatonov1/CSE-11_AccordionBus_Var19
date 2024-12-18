using AccordionBus.Drawnings;

namespace AccordionBus.MovementStrategy;

public class MoveableBus:IMoveableObject
{
    /// <summary>
    /// Поле-объект класса DrawningBus или его наследника
    /// </summary>
    private readonly DrawningBus? _bus = null;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="bus">Объект класса DrawningBus</param>
    public MoveableBus(DrawningBus bus)
    {
        _bus = bus;
    }
    public ObjectParameters? GetObjectPosition
    {
        get
        {
            if (_bus == null || _bus.EntityBus == null || !_bus.GetPosX.HasValue || !_bus.GetPosY.HasValue)
            {
                return null;
            }
            return new ObjectParameters(_bus.GetPosX.Value, _bus.GetPosY.Value, _bus.GetWidth, _bus.GetHeight);
        }
    }

    public int GetStep => (int)(_bus?.EntityBus?.Step ?? 0);

    public bool TryMoveObject(MovementDirection direction)
    {
        if (_bus == null || _bus.EntityBus == null)
        {
            return false;
        }
        return _bus.MoveTransport(GetDirectionType(direction));
    }

    /// <summary>
    /// Конвертация из MovementDirection в DirectionType
    /// </summary>
    /// <param name="direction">MovementDirection</param>
    /// <returns>DirectionType</returns>
    private static DirectionType GetDirectionType(MovementDirection direction)
    {
        return direction switch
        {
            MovementDirection.Left => DirectionType.Left,
            MovementDirection.Right => DirectionType.Right,
            MovementDirection.Up => DirectionType.Up,
            MovementDirection.Down => DirectionType.Down,
            _ => DirectionType.Unknow,
        };
    }
}
