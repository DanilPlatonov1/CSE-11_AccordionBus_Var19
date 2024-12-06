using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordionBus.MovementStrategy;

public interface IMoveableObject
{
    /// <summary>
    /// Получение координаты объекта
    /// </summary>
    ObjectParameters? GetObjectPosition { get; }
    /// <summary>
    /// Шаг объекта
    /// </summary>
    int GetStep { get; }
    /// <summary>
    /// Попытка переместить объект в указанном направлении
    /// </summary>
    /// <param name="direction">Направление</param>
    /// <returns>true - объект перемещен, false - перемещение невозможно</returns>
    bool TryMoveObject(MovementDirection direction);
}
