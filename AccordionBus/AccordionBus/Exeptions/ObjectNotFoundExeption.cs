using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AccordionBus.Exeptions;

/// <summary>
/// Класс, описывающий ошибку, что по указанной позиции нет элемента
/// </summary>
[Serializable]
internal class ObjectNotFoundException : ApplicationException
{
    public ObjectNotFoundException(int i) : base("Не найден объект по позиции " + i) { }

    public ObjectNotFoundException() : base() { }

    public ObjectNotFoundException(string message) : base(message) { }

    public ObjectNotFoundException(string message, Exception exception) : base(message, exception) { }

    protected ObjectNotFoundException(SerializationInfo info, StreamingContext contex) : base(info, contex) { }
}

