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
        if(EntityBus == null || EntityBus is not EntityAccordionBus accordionBus || !_startPosX.HasValue || !_startPosY.HasValue) 
            return;
        base.DrawTransport(g);
        //гармошка
        if (accordionBus.BodyGarmoshka)
        {
            g.FillRectangle(new HatchBrush(HatchStyle.Vertical, Color.Black, EntityBus.BodyColor), _startPosX.Value + 90, _startPosY.Value, 40, 30);
            g.DrawRectangle(new Pen(Color.Black), _startPosX.Value, _startPosY.Value, 90, 30);
            g.DrawRectangle(new Pen(Color.Black), _startPosX.Value + 90, _startPosY.Value, 40, 30);
            g.FillRectangle(new SolidBrush(accordionBus.BodyColor), _startPosX.Value + 130, _startPosY.Value, 70, 30);
            g.DrawRectangle(new Pen(Color.Black), _startPosX.Value + 130, _startPosY.Value, 70, 30);
            g.FillRectangle(new SolidBrush(Color.Black), _startPosX.Value + 155, _startPosY.Value + 10, 5, 20);
            g.FillRectangle(new SolidBrush(Color.Black), _startPosX.Value + 175, _startPosY.Value + 10, 5, 20);
            g.DrawEllipse(new Pen(Color.Black), _startPosX.Value + 130, _startPosY.Value + 25, 20, 15);
            g.DrawEllipse(new Pen(Color.Black), _startPosX.Value + 180, _startPosY.Value + 25, 20, 15);
            g.FillEllipse(new SolidBrush(Color.Black), _startPosX.Value + 130, _startPosY.Value + 25, 20, 15);
            g.FillEllipse(new SolidBrush(Color.Black), _startPosX.Value + 180, _startPosY.Value + 25, 20, 15);
            g.FillEllipse(new SolidBrush(Color.Black), _startPosX.Value + 130, _startPosY.Value + 25, 20, 15);
            g.FillEllipse(new SolidBrush(Color.Black), _startPosX.Value + 180, _startPosY.Value + 25, 20, 15);
        }
        //стекла
        if (accordionBus.BodyGlass)
        {
            Brush brBlue = new SolidBrush(accordionBus.AdditionalColor);
            g.FillEllipse(brBlue, _startPosX.Value + 10, _startPosY.Value + 5, 10, 15);
            g.FillEllipse(brBlue, _startPosX.Value + 65, _startPosY.Value + 5, 10, 15);
            Pen penGlass = new Pen(Color.Black);
            g.DrawEllipse(penGlass, _startPosX.Value + 10, _startPosY.Value + 5, 10, 15);
            g.DrawEllipse(penGlass, _startPosX.Value + 65, _startPosY.Value + 5, 10, 15);
            if (accordionBus.BodyGarmoshka)
            {
                g.FillEllipse(brBlue, _startPosX.Value + 135, _startPosY.Value + 5, 10, 15);
                g.FillEllipse(brBlue, _startPosX.Value + 185, _startPosY.Value + 5, 10, 15);
                g.DrawEllipse(penGlass, _startPosX.Value + 135, _startPosY.Value + 5, 10, 15);
                g.DrawEllipse(penGlass, _startPosX.Value + 185, _startPosY.Value + 5, 10, 15);
            }
        }
    }
}
 
