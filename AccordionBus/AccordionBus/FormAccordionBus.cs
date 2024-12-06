using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccordionBus.Drawnings;
using AccordionBus.MovementStrategy;

namespace AccordionBus;
public partial class FormAccordionBus : Form
{
    /// <summary>
    /// Поле-объект для прорисовки объекта
    /// </summary>

    private DrawningBus? _drawningBus;
    /// <summary>
    /// Стратегия перемещения
    /// </summary>
    private AbstractStrategy? _strategy;
    /// <summary>
	/// Получение объекта 
	/// </summary>
	public DrawningBus SetBus
    {
        set
        {
            _drawningBus = value;
            _drawningBus.SetPictureSize(pictureBoxAccordionBus.Width, pictureBoxAccordionBus.Height);
            comboBoxStrategy.Enabled = true;
            _strategy = null;
            Draw();
        }
    }
    /// <summary>
    /// Инициализация формы
    /// </summary>


    public FormAccordionBus()
    {
        InitializeComponent();
        _strategy = null;
    }


    /// <summary>
    /// Метод прорисовки машины
    /// </summary>

    private void Draw()
    {
        if (_drawningBus == null)
        {
            return;
        }

        Bitmap bmp = new(pictureBoxAccordionBus.Width, pictureBoxAccordionBus.Height);
        Graphics gr = Graphics.FromImage(bmp);
        _drawningBus.DrawTransport(gr);
        pictureBoxAccordionBus.Image = bmp;
    }


    /// <summary>
    /// Перемещение объекта по форме (нажатие кнопок навигации)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    private void ButtonMove_Click(object sender, EventArgs e)
    {
        if (_drawningBus == null)
        {
            return;
        }

        string name = ((Button)sender)?.Name ?? string.Empty;
        bool result = false;
        switch (name)
        {
            case "buttonUp":
                result = _drawningBus.MoveTransport(DirectionType.Up);
                break;
            case "buttonDown":
                result = _drawningBus.MoveTransport(DirectionType.Down);
                break;
            case "buttonLeft":
                result = _drawningBus.MoveTransport(DirectionType.Left);
                break;
            case "buttonRight":
                result = _drawningBus.MoveTransport(DirectionType.Right);
                break;
        }

        if (result)
        {
            Draw();
        }
    }
    /// <summary>
    /// Обработка нажатия кнопки "Шаг"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonStrategyStep_Click(object sender, EventArgs e)
    {
        if (_drawningBus == null)
        {
            return;
        }

        if (comboBoxStrategy.Enabled)
        {
            _strategy = comboBoxStrategy.SelectedIndex switch
            {
                0 => new MoveToCenter(),
                1 => new MoveToBorder(),
                _ => null,
            };
            if (_strategy == null)
            {
                return;
            }
            _strategy.SetData(new MoveableBus(_drawningBus), pictureBoxAccordionBus.Width, pictureBoxAccordionBus.Height);
        }

        if (_strategy == null)
        {
            return;
        }

        comboBoxStrategy.Enabled = false;
        _strategy.MakeStep();
        Draw();

        if (_strategy.GetStatus() == StrategyStatus.Finish)
        {
            comboBoxStrategy.Enabled = true;
            _strategy = null;
        }
    }
}
