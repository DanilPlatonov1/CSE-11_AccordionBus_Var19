namespace AccordionBus.MovementStrategy;

public class MoveToBorder : AbstractStrategy
{
    protected override bool IsTargetDestinaion()
    {
        ObjectParameters? objParams = GetObjectParameters;
        if (objParams == null)
        {
            return false;
        }
        return objParams.RightBorder <= FieldWidth && objParams.RightBorder + GetStep() >= FieldWidth &&
        objParams.DownBorder <= FieldHeight && objParams.DownBorder + GetStep() >= FieldHeight;
    }

    protected override void MoveToTarget()
    {
        ObjectParameters? objParams = GetObjectParameters;
        if (objParams == null)
        {
            return;
        }

        int diffX = objParams.ObjectMiddleHorizontal - FieldWidth;

        if (Math.Abs(diffX) > GetStep())
        {
            if (diffX > 0)
            {
                MoveLeft();
            }
            else
            {
                MoveRight();
            }
        }

        int diffY = objParams.ObjectMiddleVertical - FieldHeight;

        if (Math.Abs(diffY) > GetStep())
        {
            if (diffY > 0)
            {
                MoveUp();
            }
            else
            {
                MoveDown();
            }
        }
    }

}
