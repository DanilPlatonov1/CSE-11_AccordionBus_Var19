using AccordionBus.Entities;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordionBus.Drawnings;

public class DrawningBus
{
    /// <summary>
    /// Класс-сущность
    /// </summary>
    public EntityBus? EntityBus { get; protected set; }
    /// <summary>
    /// Ширина окна
    /// </summary>
    private int? _pictureWidth;
    /// <summary>
    /// Высота окна
    /// </summary>
    private int? _pictureHeight;
    /// <summary>
    /// Левая координата прорисовки автомобиля
    /// </summary>
    protected int? _startPosX;
    /// <summary>
    /// Верхняя кооридната прорисовки автомобиля
    /// </summary>
    protected int? _startPosY;
    /// <summary>
    /// Ширина прорисовки автомобиля
    /// </summary>
    private readonly int _drawningBusWidth = 180;
    /// <summary>
    /// Высота прорисовки автомобиля
    /// </summary>
    private readonly int _drawningBusHeight = 40;
    /// <summary>
    /// Координата X
    /// </summary>
    public int? GetPosX=>_startPosX;
    /// <summary>
    /// Координата Y
    /// </summary>
    public int? GetPosY => _startPosY;
    /// <summary>
    /// Ширина объекта
    /// </summary>
    public int GetWidth => _drawningBusWidth;
    /// <summary>
    /// Высота объекта
    /// </summary>
    public int GetHeight => _drawningBusHeight;

    /// <summary>
    /// Пустой конструктор
    /// </summary>
    private DrawningBus()
    {
        _pictureWidth = null;
        _pictureHeight = null;
        _startPosX = null;
        _startPosY = null;
    }
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="speed">Скорость</param>
    /// <param name="weight">Вес</param>
    /// <param name="bodyColor">Основной цвет</param>
    public DrawningBus(int speed, double weight, Color bodyColor):this()
    {
        EntityBus = new EntityBus(speed, weight, bodyColor);
    }
    /// <summary>
    /// Конструктор для наследования
    /// </summary>
    /// <param name="drawningBusWidth">ширина автобуса</param>
    /// <param name="drawningBusHeight">высота автобуса</param>
    protected DrawningBus(int drawningBusWidth, int drawningBusHeight):this()
    {
        _drawningBusWidth = drawningBusWidth;
        _drawningBusHeight = drawningBusHeight;
    }

    /// <summary>
    /// Установка границ поля
    /// </summary>
    /// <param name="width">Ширина поля</param>
    /// <param name="height">Высота поля</param>
    /// <returns>true - границы заданы, false - проверка не пройдена, нельзя 
    public bool SetPictureSize(int width, int height)
    {
        if (_drawningBusWidth <= width && _drawningBusHeight <= height)
        {
            _pictureWidth = width;
            _pictureHeight = height;
            if (_startPosX.HasValue && _startPosY.HasValue)
            {
                if (_startPosX + _drawningBusWidth > _pictureWidth)
                {
                    _startPosX = _pictureWidth - _drawningBusWidth;
                }

                if (_startPosY + _drawningBusHeight > _pictureHeight)
                {
                    _startPosY = _pictureHeight - _drawningBusHeight;
                }
            }
            return true;
        }
        return false;
    }
    /// <summary>
    /// Установка позиции
    /// </summary>
    /// <param name="x">Координата X</param>
    /// <param name="y">Координата Y</param>
    public void SetPosition(int x, int y)
    {
        if (!_pictureHeight.HasValue || !_pictureWidth.HasValue)
        {
            return;
        }
        if (x < 0) x = 0;
        else if (x + _drawningBusWidth > _pictureWidth) x = _pictureWidth.Value - _drawningBusWidth;

        if (y < 0) y = 0;
        else if (y + _drawningBusHeight > _pictureHeight) y = _pictureHeight.Value - _drawningBusHeight;
        _startPosX = x;
        _startPosY = y;
    }
    public bool MoveTransport(DirectionType direction)
    {
        if (EntityBus == null || !_startPosX.HasValue || !_startPosY.HasValue)
            return false;
        switch (direction)
        {
            //влево
            case DirectionType.Left:
                if (_startPosX.Value - EntityBus.Step > 0)
                    _startPosX -= (int)EntityBus.Step;
                return true;
            //вверх
            case DirectionType.Up:
                if (_startPosY.Value - EntityBus.Step > 0)
                    _startPosY -= (int)EntityBus.Step;
                return true;
            // вправо
            case DirectionType.Right:
                if (_startPosX.Value + _drawningBusWidth + EntityBus.Step < _pictureWidth)
                    _startPosX += (int)EntityBus.Step;
                return true;
            //вниз
            case DirectionType.Down:
                if (_startPosY.Value + _drawningBusHeight + EntityBus.Step < _pictureHeight)
                    _startPosY += (int)EntityBus.Step;
                return true;
            default:
                return false;
        }
    }
    /// <summary>
    /// Прорисовка объекта
    /// </summary>
    /// <param name="g"></param>
    public virtual void DrawTransport(Graphics g)
    {
        if (EntityBus == null || !_startPosX.HasValue || !_startPosY.HasValue)
            return;
        //кузов
        Brush br = new SolidBrush(EntityBus.BodyColor);
        g.FillRectangle(br, _startPosX.Value, _startPosY.Value, 90, 30);
        g.DrawRectangle(new Pen(Color.Black), _startPosX.Value, _startPosY.Value, 90, 30);
        //диски
        Brush brWhite = new SolidBrush(Color.White);
        g.FillEllipse(brWhite, _startPosX.Value, _startPosY.Value + 25, 20, 15);
        g.FillEllipse(brWhite, _startPosX.Value + 70, _startPosY.Value + 25, 20, 15);
        Brush brWheel = new SolidBrush(Color.Black);
        g.FillEllipse(brWheel, _startPosX.Value, _startPosY.Value + 25, 20, 15);
        g.FillEllipse(brWheel, _startPosX.Value + 70, _startPosY.Value + 25, 20, 15);

        Pen penWheel = new Pen(Color.Black);
        g.DrawEllipse(penWheel, _startPosX.Value, _startPosY.Value + 25, 20, 15);
        g.DrawEllipse(penWheel, _startPosX.Value + 70, _startPosY.Value + 25, 20, 15);


        //двери
        Brush brDoor = new SolidBrush(Color.Black);
        g.FillRectangle(brDoor, _startPosX.Value + 55, _startPosY.Value + 10, 5, 20);
        g.FillRectangle(brDoor, _startPosX.Value + 25, _startPosY.Value + 10, 5, 20);
    }
}
