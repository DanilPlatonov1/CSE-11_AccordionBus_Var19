using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccordionBus.Drawnings;
using AccordionBus.Entities;

namespace AccordionBus.Drawnings;
public class DrawningAccordionBus:DrawningBus
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="speed">Скорость</param>
    /// <param name="weight">Вес</param>
    /// <param name="bodyColor">Основной цвет</param>
    /// <param name="additionalColor">Дополнительный цвет</param>
    /// <param name="bodyGlass">Признак наличия стёкол</param>
    /// /// <param name="garmoshka">Признак наличия гармошки</param>
    public DrawningAccordionBus(int speed, double weight, Color bodyColor, Color
    additionalColor, bool bodyGlass,bool garmoshka): base(200, 40)
    {
        EntityBus = new EntityAccordionBus(speed, weight, bodyColor, additionalColor,
        bodyGlass, garmoshka);
    }

    public DrawningAccordionBus(EntityAccordionBus bus) : base(200, 40)
    {
        EntityBus = bus;
    }

    /// <summary>
    /// перегрузка для создания автобуса в коллекцию базового типа
    /// </summary>
    /// <param name="speed">скорость</param>
    /// <param name="weight">вес</param>
    /// <param name="bodyColor">основной цвет</param>
    public DrawningAccordionBus(int speed, double weight, Color bodyColor) : base(220, 50)
    {
        EntityBus = new EntityAccordionBus(speed, weight, bodyColor);
    }

    public override void DrawTransport(Graphics g)
    {
        if (EntityBus == null || EntityBus is not EntityAccordionBus accordionBus || !_startPosX.HasValue || !_startPosY.HasValue)
            return;

        // Вызов базового метода для отрисовки первого автобуса
        base.DrawTransport(g);

        // Окна и двери первого автобуса
        if (accordionBus.BodyGlass)
        {
            // Прямоугольные окна первого автобуса
            Brush glassBrush = new SolidBrush(accordionBus.AdditionalColor);
            g.FillRectangle(glassBrush, _startPosX.Value + 10, _startPosY.Value + 5, 10, 15);
            g.FillRectangle(glassBrush, _startPosX.Value + 70, _startPosY.Value + 5, 10, 15);

            Pen glassPen = new Pen(Color.Black);
            g.DrawRectangle(glassPen, _startPosX.Value + 10, _startPosY.Value + 5, 10, 15);
            g.DrawRectangle(glassPen, _startPosX.Value + 70, _startPosY.Value + 5, 10, 15);
        }

        // Двери первого автобуса
        LinearGradientBrush doorBrush = new LinearGradientBrush(
            new Rectangle(_startPosX.Value + 40, _startPosY.Value + 10, 10, 20), // Ширина двери
            Color.Black,
            Color.Gray,
            LinearGradientMode.Vertical
        );

        // Гармошка и второй автобус
        if (accordionBus.BodyGarmoshka)
        {
            int accordionWidth = 20;
            int accordionHeight = 25;

            // Отрисовка частой гармошки
            HatchBrush accordionBrush = new HatchBrush(HatchStyle.Vertical, Color.Black, EntityBus.BodyColor);
            g.FillRectangle(accordionBrush, _startPosX.Value + 90, _startPosY.Value + 2, accordionWidth, accordionHeight);
            g.DrawRectangle(new Pen(Color.Black, 1), _startPosX.Value + 90, _startPosY.Value + 2, accordionWidth, accordionHeight);

            // Отрисовка второго автобуса
            int secondBusStartX = _startPosX.Value + 90 + accordionWidth;
            int busWidth = 90;
            int busHeight = 30;

            Brush secondBusBrush = new SolidBrush(accordionBus.BodyColor);
            g.FillRectangle(secondBusBrush, secondBusStartX, _startPosY.Value, busWidth, busHeight);
            g.DrawRectangle(new Pen(Color.Black, 2), secondBusStartX, _startPosY.Value, busWidth, busHeight);

            // Полосы на втором автобусе
            Pen stripePen = new Pen(Color.DarkGray, 1);
            g.DrawLine(stripePen, secondBusStartX + 5, _startPosY.Value + 10, secondBusStartX + busWidth - 5, _startPosY.Value + 10);
            g.DrawLine(stripePen, secondBusStartX + 5, _startPosY.Value + 20, secondBusStartX + busWidth - 5, _startPosY.Value + 20);

            // Колеса второго автобуса
            int diskDiameter = 20;
            Brush wheelBrush = new SolidBrush(Color.Gray);
            g.FillEllipse(wheelBrush, secondBusStartX + 5, _startPosY.Value + 25, diskDiameter, diskDiameter);
            g.FillEllipse(wheelBrush, secondBusStartX + 65, _startPosY.Value + 25, diskDiameter, diskDiameter);

            Pen wheelOutlinePen = new Pen(Color.Black, 1);
            g.DrawEllipse(wheelOutlinePen, secondBusStartX + 5, _startPosY.Value + 25, diskDiameter, diskDiameter);
            g.DrawEllipse(wheelOutlinePen, secondBusStartX + 65, _startPosY.Value + 25, diskDiameter, diskDiameter);

            // Шины второго автобуса
            Brush tireBrush = new SolidBrush(Color.Black);
            int tireDiameter = 16;
            g.FillEllipse(tireBrush, secondBusStartX + 7, _startPosY.Value + 27, tireDiameter, tireDiameter);
            g.FillEllipse(tireBrush, secondBusStartX + 67, _startPosY.Value + 27, tireDiameter, tireDiameter);

            // Окна второго автобуса
            if (accordionBus.BodyGlass)
            {
                // Прямоугольные окна второго автобуса
                Brush glassBrush = new SolidBrush(accordionBus.AdditionalColor);
                g.FillRectangle(glassBrush, secondBusStartX + 10, _startPosY.Value + 5, 10, 15);
                g.FillRectangle(glassBrush, secondBusStartX + 70, _startPosY.Value + 5, 10, 15);

                Pen glassPen = new Pen(Color.Black);
                g.DrawRectangle(glassPen, secondBusStartX + 10, _startPosY.Value + 5, 10, 15);
                g.DrawRectangle(glassPen, secondBusStartX + 70, _startPosY.Value + 5, 10, 15);
            }

            // Широкая дверь второго автобуса
            g.FillRectangle(doorBrush, secondBusStartX + 40, _startPosY.Value + 10, 10, 20);
            g.DrawRectangle(new Pen(Color.Black, 1), secondBusStartX + 40, _startPosY.Value + 10, 10, 20);
        }
    }
}

