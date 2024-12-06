using AccordionBus.CollectionGenericObjects;
using AccordionBus.Drawnings;
using AccordionBus.MovementStrategy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccordionBus;

public partial class FormBusCollection : Form
{
    /// <summary>
    /// Компания
    /// </summary>
    private AbstractCompany? _company = null;
    /// <summary>
    /// Конструктор
    /// </summary>
    public FormBusCollection()
    {
        InitializeComponent();
    }
    /// <summary>
    /// Выбор компании
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ComboBoxSelectorCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (comboBoxSelectorCompany.Text)
        {
            case "Автовокзал":
                _company = new BusStation(pictureBox.Width,
                pictureBox.Height, new MassiveGenericObjects<DrawningBus>());
                break;
        }
    }
    /// <summary>
    /// Добавление обычного автомобиля
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonAddBus_Click(object sender, EventArgs e) => CreateObject(nameof(DrawningBus));
    /// <summary>
    /// Добавление спортивного автомобиля
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonAddAccordionBus_Click(object sender, EventArgs e) => CreateObject(nameof(DrawningAccordionBus));
    /// <summary>
    /// Создание объекта класса-перемещения
    /// </summary>
    /// <param name="type">Тип создаваемого объекта</param>
    private void CreateObject(string type)
    {
        if (_company == null)
        {
            return;
        }
        Random random = new();
        DrawningBus drawningBus;
        switch (type)
        {
            case nameof(DrawningBus):
                drawningBus = new DrawningBus(random.Next(100, 300), random.Next(1000, 3000), GetColor(random));
                break;
            case nameof(DrawningAccordionBus):
                drawningBus = new DrawningAccordionBus(random.Next(100, 300), random.Next(1000, 3000), GetColor(random), GetColor(random), Convert.ToBoolean(random.Next(0, 2)), Convert.ToBoolean(random.Next(0, 2)));
                break;
            default:
                return;
        }
        if (_company + drawningBus !=-1)
        {
            MessageBox.Show("Объект добавлен");
            pictureBox.Image = _company.Show();
        }
        else
        {
            MessageBox.Show("Не удалось добавить объект");
        }
    }
    /// <summary>
    /// Получение цвета
    /// </summary>
    /// <param name="random">Генератор случайных чисел</param>
    /// <returns></returns>
    private static Color GetColor(Random random)
    {
        Color color = Color.FromArgb(random.Next(0, 256), random.Next(0,
        256), random.Next(0, 256));
        ColorDialog dialog = new();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            color = dialog.Color;
        }
        return color;
    }
    /// <summary>
    /// Удаление объекта
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonRemoveBus_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(maskedTextBoxPosition.Text) || _company == null)
        {
            return;
        }
        if (MessageBox.Show("Удалить объект?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }
        int pos = Convert.ToInt32(maskedTextBoxPosition.Text);
        if (_company - pos != null)
        {
            MessageBox.Show("Объект удален");
            pictureBox.Image = _company.Show();
        }
        else
        {
            MessageBox.Show("Не удалось удалить объект");
        }
    }
    /// <summary>
    /// Передача объекта в другую форму
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonGoToCheck_Click(object sender, EventArgs e)
    {
        if (_company == null)
        {
            return;
        }
        DrawningBus? bus = null;
        int counter = 100;
        while (bus == null)
        {
            bus = _company.GetRandomObject();
            counter--;
            if (counter <= 0)
            {
                break;
            }
        }
        if (bus == null)
        {
            return;
        }
        FormAccordionBus form = new()
        {
            SetBus = bus
        };
        form.ShowDialog();
    }
    /// <summary>
    /// Перерисовка коллекции
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonRefresh_Click(object sender, EventArgs e)
    {
        if (_company == null)
        {
            return;
        }
        pictureBox.Image = _company.Show();
    }
}
