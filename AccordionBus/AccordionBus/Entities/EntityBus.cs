using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordionBus.Entities;


/// <summary>
/// Класс-сущность автобус
/// </summary>

public class EntityBus
{
    /// <summary>
    /// Скорость
    /// </summary>
    public int Speed { get; private set; }
    /// <summary>
    /// Вес
    /// </summary>
    public double Weight { get; private set; }
    /// <summary>
    /// Основной цвет
    /// </summary>
    public Color BodyColor { get; private set; }

    /// <summary>
    /// Шаг перемещения автомобиля
    /// </summary>
    public double Step => Speed * 100 / Weight;
    /// <summary>
    /// Конструктор сущности
    /// </summary>
    /// <param name="speed">Скорость</param>
    /// <param name="weight">Вес автомобиля</param>
    /// <param name="bodyColor">Основной цвет</param>
    public EntityBus(int speed, double weight, Color bodyColor)
    {
        Speed = speed;
        Weight = weight;
        BodyColor = bodyColor;
    }
    public void SetBody(Color color)
    {
        BodyColor = color;
    }
}