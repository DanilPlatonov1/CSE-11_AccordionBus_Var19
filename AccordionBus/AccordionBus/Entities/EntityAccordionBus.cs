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

    public override string[] GetStringRepresentation()
    {
        return new[] { nameof(EntityAccordionBus), Speed.ToString(), Weight.ToString(), BodyColor.Name,
                AdditionalColor.Name, BodyGlass.ToString(), BodyGarmoshka.ToString() };
    }
    public static EntityAccordionBus? CreateEntityAccordionBus(string[] strs)
    {
        if (strs.Length != 7 || strs[0] != nameof(EntityAccordionBus)) { return null; }

        return new EntityAccordionBus(Convert.ToInt32(strs[1]), Convert.ToDouble(strs[2]),
            Color.FromName(strs[3]), Color.FromName(strs[4]), Convert.ToBoolean(strs[5]), Convert.ToBoolean(strs[6]));
    }
}
