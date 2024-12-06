using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordionBus.MovementStrategy;

public enum StrategyStatus
{
    ///<summary>
    ///Всё готово к началу
    ///</summary>
    NotInit,

    ///<summary>
    ///Выполняется
    ///</summary>
    InProgress,

    ///<summary>
    ///Завершено
    ///</summary>
    Finish
}
