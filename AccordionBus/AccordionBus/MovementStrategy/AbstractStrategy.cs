namespace AccordionBus.MovementStrategy;
public abstract class AbstractStrategy
{
    /// <summary>
    /// Перемещаемый объект
    /// </summary>
    private IMoveableObject? _moveableObject;

    /// <summary>
    /// Статус перемещения
    /// </summary>
    private StrategyStatus _state = StrategyStatus.NotInit;

    /// <summary>
    /// Ширина поля
    /// </summary>
    protected int FieldWidth { get; private set; }

    /// <summary>
    /// Высота поля
    /// </summary>
    protected int FieldHeight { get; private set; }

    /// <summary>
    /// Статус перемещения
    /// </summary>
    public StrategyStatus GetStatus() { return _state; }

    /// <summary>
    /// Установка данных
    /// </summary>
    /// <param name="moveableObject">Перемещаемый объект</param>
    /// <param name="width">Ширина поля</param>
    /// <param name="height">Высота поля</param>
    public void SetData(IMoveableObject moveableObject, int width, int height)
    {
        if (moveableObject == null)
        {
            _state = StrategyStatus.NotInit;
            return;
        }
        _state = StrategyStatus.InProgress;
        _moveableObject = moveableObject;
        FieldWidth = width;
        FieldHeight = height;
    }

    /// <summary>
    /// Шаг перемещения
    /// </summary>
    public void MakeStep()
    {
        if (_state != StrategyStatus.InProgress)
        {
            return;
        }
        if (IsTargetDestinaion())
        {
            _state = StrategyStatus.Finish;
            return;
        }
        MoveToTarget();
    }
    /// <summary>
    /// Перемещение влево
    /// </summary>
    /// <returns>Результат перемещения (true - удалось переместиться, false - неудача)</returns>
    protected bool MoveLeft() => MoveTo(MovementDirection.Left);

    /// <summary>
    /// Перемещение вправо
    /// </summary>
    /// <returns>Результат перемещения (true - удалось переместиться, false - неудача)</returns>
    protected bool MoveRight() => MoveTo(MovementDirection.Right);

    /// <summary>
    /// Перемещение вверх
    /// </summary>
    /// <returns>Результат перемещения (true - удалось переместиться, false - неудача)</returns>
    protected bool MoveUp() => MoveTo(MovementDirection.Up);

    /// <summary>
    /// Перемещение вниз
    /// </summary>
    /// <returns>Результат перемещения (true - удалось переместиться, false -неудача)</returns>
    protected bool MoveDown() => MoveTo(MovementDirection.Down);

    /// <summary>
    /// Параметры объекта
    /// </summary>
    protected ObjectParameters? GetObjectParameters => _moveableObject?.GetObjectPosition;

    /// <summary>
    /// Шаг объекта
    /// </summary>
    /// <returns></returns>
    protected int? GetStep()
    {
        if (_state != StrategyStatus.InProgress)
        {
            return null;
        }
        return _moveableObject?.GetStep;
    }

    /// <summary>
    /// Перемещение к цели
    /// </summary>
    protected abstract void MoveToTarget();

    /// <summary>
    /// Достигнута ли цель
    /// </summary>
    /// <returns></returns>
    protected abstract bool IsTargetDestinaion();
        
    /// <summary>
    /// Попытка перемещения в требуемом направлении
    /// </summary>
    /// <param name="movementDirection">Направление</param>
    /// <returns>Результат попытки (true - удалось переместиться, false - неудача)</returns>
    private bool MoveTo(MovementDirection movementDirection)
    {
        if (_state != StrategyStatus.InProgress)
        {
            return false;
        }
        return _moveableObject?.TryMoveObject(movementDirection) ?? false;
    }
}
