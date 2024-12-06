using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordionBus.Entities;
public class EntityAccordionBus: EntityBus
{
    /// <summary>
    /// Дополнительный цвет (для опциональных элементов)
    /// </summary>
    public Color AdditionalColor { get; private set; }
    /// <summary>
    /// Признак (опция) наличия стёкол
    /// </summary>
    public bool BodyGlass { get; private set; }
    /// <summary>
    /// признак наличия гармошки
    /// </summary>
    public bool BodyGarmoshka { get; private set; }

    /// <summary>
    /// Инициализация полей объекта-класса автобуса с гармошкой
    /// </summary>
    /// <param name="additionalColor">Дополнительный цвет</param>
    /// <param name="glass">наличие стекла</param>
    /// <param name="garmoshka">наличие гармошки</param>

    public EntityAccordionBus(int speed, double weigth, Color bodyColor, Color additionalColor, bool glass, bool garmoshka) : base (speed,weigth,bodyColor)
    {
        AdditionalColor = additionalColor;
        BodyGlass = glass;
        BodyGarmoshka = garmoshka;
    }
    /// <summary>
    /// Перегрузка конструктора для создания базового автобуса в коллекцию
    /// </summary>
    /// <param name="speed">скрость</param>
    /// <param name="weigth">вес</param>
    /// <param name="bodyColor">основной цвет</param>
    public EntityAccordionBus(int speed, double weigth, Color bodyColor) : base(speed, weigth, bodyColor){}

    public void SetAdditional(Color color)
    {
        AdditionalColor = color;
    }
}
