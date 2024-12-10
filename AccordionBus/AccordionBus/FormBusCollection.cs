using AccordionBus.CollectionGenericObjects;
using AccordionBus.Drawnings;
using AccordionBus.MovementStrategy;
using ProjectAccordionBus.CollectionGenericObjects;
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
    private readonly StorageCollection<DrawningBus> _storageCollection;
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
        _storageCollection = new();
    }

    private void SetBus(DrawningBus bus)
    {
        if (_company == null || bus == null) return;
        if (_company + bus)
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
    /// Выбор компании
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void comboBoxSelectorCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        panelCompanyTools.Enabled = false;
    }
    /// <summary>
    /// Добавление обычного автомобиля
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonAddBus_Click(object sender, EventArgs e)
    {
        FormBusConfig form = new();
        form.Show();
        form.AddEvent(SetBus);
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
    private void RefreshListBoxItems()
    {
        listBoxCollection.Items.Clear();
        for (int i = 0; i < _storageCollection.Keys?.Count; ++i)
        {
            string? colName = _storageCollection.Keys?[i];
            if (!string.IsNullOrEmpty(colName))
            {
                listBoxCollection.Items.Add(colName);
            }
        }

    }
    private void buttonCollectionAdd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(textBoxCollectionName.Text) || (!radioButtonList.Checked && !radioButtonMassive.Checked))
        {
            MessageBox.Show("Не все данные заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        CollectionType collectionType = CollectionType.None;
        if (radioButtonMassive.Checked)
        {
            collectionType = CollectionType.Massive;
        }
        else if (radioButtonList.Checked)
        {
            collectionType = CollectionType.List;
        }

        _storageCollection.AddCollection(textBoxCollectionName.Text, collectionType);
        RefreshListBoxItems();
    }
    private void buttonCollectionDel_Click(object sender, EventArgs e)
    {
        if (listBoxCollection.SelectedIndex < 0 || listBoxCollection.SelectedItems == null)
        {
            MessageBox.Show("Коллекция не выбрана");
            return;
        }
        if (MessageBox.Show("Удалить коллекцию?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        {
            return;
        }
        _storageCollection.DelCollection(listBoxCollection.SelectedItem.ToString());
        RefreshListBoxItems();
    }
    private void buttonCreateCompany_Click(object sender, EventArgs e)
    {
        if (listBoxCollection.SelectedIndex < 0 || listBoxCollection.SelectedItem == null)
        {
            MessageBox.Show("Коллекция не выбрана");
            return;
        }

        ICollectionGenericObjects<DrawningBus>? collection = _storageCollection[listBoxCollection.SelectedItem.ToString() ?? string.Empty];
        if (collection == null)
        {
            MessageBox.Show("Коллекция не проинициализирована");
            return;
        }

        switch (comboBoxSelectorCompany.Text)
        {
            case "Автовокзал":
                _company = new BusStation(pictureBox.Width, pictureBox.Height, collection);
                break;
        }

        panelCompanyTools.Enabled = true;
        RefreshListBoxItems();
    }

    private void loadToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            if (_storageCollection.LoadData(openFileDialog.FileName))
            {
                MessageBox.Show("Загрузка прошла успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshListBoxItems();
            }
            else
            {
                MessageBox.Show("Не загрузилось", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            if (_storageCollection.SaveData(saveFileDialog.FileName))
            {
                MessageBox.Show("Сохранение прошло успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не сохранилось", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
