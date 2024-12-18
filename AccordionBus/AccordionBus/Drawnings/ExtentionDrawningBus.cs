using AccordionBus.Entities;
using System;
namespace AccordionBus.Drawnings;

public static class ExtentionDrawningBus
{
    /// <summary>
    /// Разделитель для записи информации по объекту в файл
    /// </summary>
    private static readonly string _separatorForObject = ":";

    /// <summary>
    /// Создание объекта из строки
    /// </summary>
    /// <param name="info">Строка с данными для создания объекта</param>
    /// <returns>Объект</returns>
    public static DrawningBus? CreateDrawningBus(this string info)
    {
        string[] strs = info.Split(_separatorForObject);
        EntityBus? bus = EntityAccordionBus.CreateEntityAccordionBus(strs);
        if (bus != null && bus is EntityAccordionBus bus1)
        {
            return new DrawningAccordionBus(bus1);
        }
        bus = EntityBus.CreateEntityBus(strs);
        if (bus != null)
        {
            return new DrawningBus(bus);
        }
        return null;
    }

    /// <summary>
    /// Получение данных для сохранения в файл
    /// </summary>
    /// <param name="drawningBus">Сохраняемый объект</param>
    /// <returns>Строка с данными по объекту</returns>
    public static string GetDataForSave(this DrawningBus drawningBus)
    {
        string[]? array = drawningBus?.EntityBus?.GetStringRepresentation();
        if (array == null)
        {
            return string.Empty;
        }
        return string.Join(_separatorForObject, array);
    }
}
