using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AccordionBus.Exeptions;

/// <summary>
/// Класс, описывающий ошибку переполнения коллекции
/// </summary>
[Serializable]
internal class CollectionOverflowException : ApplicationException
{
    public CollectionOverflowException(int count) : base("В коллекции превышено допустимое количество: " + count) { }

    public CollectionOverflowException() : base() { }

    public CollectionOverflowException(string message) : base(message) { }

    public CollectionOverflowException(string message, Exception exception) : base(message, exception) { }

    protected CollectionOverflowException(SerializationInfo info, StreamingContext contex) : base(info, contex) { }
}
