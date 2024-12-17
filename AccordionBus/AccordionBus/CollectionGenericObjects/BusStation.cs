using ProjectAccordionBus.CollectionGenericObjects;
using AccordionBus.Drawnings;

namespace AccordionBus.CollectionGenericObjects;

public class BusStation : AbstractCompany
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="picWidth"></param>
    /// <param name="picHeight"></param>
    /// <param name="collection"></param>
    public BusStation(int picWidth, int picHeight, ICollectionGenericObjects<DrawningBus> collection) : base(picWidth, picHeight, collection){}
    protected override void DrawBackgound(Graphics g)
    {
        Pen pen = new(Color.Black, 3);
        int posX = 0;
        for (int i = 0; i < _pictureWidth / _placeSizeWidth; i++)
        {
            int posY = 0;
            g.DrawLine(pen, posX, posY, posX, posY + _placeSizeHeight * (_pictureHeight / _placeSizeHeight));
            for (int j = 0; j <= _pictureHeight / _placeSizeHeight; j++)
            {
                g.DrawLine(pen, posX, posY, posX + _placeSizeWidth - 30, posY);
                posY += _placeSizeHeight;
            }
            posX += _placeSizeWidth;
            
        }
    }

    protected override void SetObjectsPosition()
    {
        int posX = 0;
        int posY = _pictureHeight / _placeSizeHeight-1;
        for (int i = 0; i < _collection?.Count; i++)
        {
            if (_collection.Get(i) != null)
            {
                _collection?.Get(i)?.SetPictureSize(_pictureWidth, _pictureHeight);
                _collection?.Get(i)?.SetPosition(posX * _placeSizeWidth+5, posY * _placeSizeHeight+5);
            }
            if (posY > 0)
            {
                posY--;
            }
            else
            {
                posX++;
                posY = _pictureHeight / _placeSizeHeight-1;
            }
            if (posY < 0) { return; }
        }
    }
}
