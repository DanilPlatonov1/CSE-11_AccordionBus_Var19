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

    public DrawningBus(EntityBus bus)
    {
        EntityBus = bus;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="speed">Скорость</param>
    /// <param name="weight">Вес</param>
    /// <param name="bodyColor">Основной цвет</param>
    public DrawningBus(int speed, double weight, Color bodyColor) : this()
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

    // Кузов
    Brush bodyBrush = new SolidBrush(EntityBus.BodyColor);
    g.FillRectangle(bodyBrush, _startPosX.Value, _startPosY.Value, 90, 30);
    Pen bodyPen = new Pen(Color.Black, 2);
    g.DrawRectangle(bodyPen, _startPosX.Value, _startPosY.Value, 90, 30);

    // Полосы на кузове
    Pen stripePen = new Pen(Color.DarkGray, 1);
    g.DrawLine(stripePen, _startPosX.Value + 5, _startPosY.Value + 10, _startPosX.Value + 85, _startPosY.Value + 10);
    g.DrawLine(stripePen, _startPosX.Value + 5, _startPosY.Value + 20, _startPosX.Value + 85, _startPosY.Value + 20);

    // Диски с декоративной обводкой
    int diskDiameter = 20; // Диаметр круга
    Brush diskBrush = new SolidBrush(Color.Gray);
    g.FillEllipse(diskBrush, _startPosX.Value + 5, _startPosY.Value + 25, diskDiameter, diskDiameter);
    g.FillEllipse(diskBrush, _startPosX.Value + 65, _startPosY.Value + 25, diskDiameter, diskDiameter);

    Pen diskOutlinePen = new Pen(Color.Black, 1);
    g.DrawEllipse(diskOutlinePen, _startPosX.Value + 5, _startPosY.Value + 25, diskDiameter, diskDiameter);
    g.DrawEllipse(diskOutlinePen, _startPosX.Value + 65, _startPosY.Value + 25, diskDiameter, diskDiameter);

    Brush tireBrush = new SolidBrush(Color.Black);
    int tireDiameter = 16; // Диаметр круга
    g.FillEllipse(tireBrush, _startPosX.Value + 7, _startPosY.Value + 27, tireDiameter, tireDiameter);
    g.FillEllipse(tireBrush, _startPosX.Value + 67, _startPosY.Value + 27, tireDiameter, tireDiameter);

    // Одна дверь по центру
    LinearGradientBrush doorBrush = new LinearGradientBrush(
        new Rectangle(_startPosX.Value + 40, _startPosY.Value + 10, 10, 20),
        Color.Black,
        Color.Gray,
        LinearGradientMode.Vertical
    );
    g.FillRectangle(doorBrush, _startPosX.Value + 40, _startPosY.Value + 10, 10, 20);

    // Обводка двери
    g.DrawRectangle(new Pen(Color.Black, 1), _startPosX.Value + 40, _startPosY.Value + 10, 10, 20);
}
}
