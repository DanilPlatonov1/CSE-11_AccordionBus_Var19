using AccordionBus.CollectionGenericObjects;
using AccordionBus.Drawnings;
using AccordionBus.Exeptions;
using Microsoft.Extensions.Logging;
using ProjectAccordionBus.CollectionGenericObjects;

namespace AccordionBus;

public partial class FormBusCollection : Form
{
    private readonly StorageCollection<DrawningBus> _storageCollection;

    /// <summary>
    /// Компания
    /// </summary>
    private AbstractCompany? _company = null;

    /// <summary>
    /// Логер
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Конструктор
    /// </summary>
    public FormBusCollection(ILogger<FormBusCollection> logger)
    {
        InitializeComponent();
        _storageCollection = new();
        _logger = logger;
    }

    private void SetBus(DrawningBus bus)
    {
        try
        {
            if (_company == null || bus == null) return;
            if (_company + bus)
            {
                MessageBox.Show("Объект добавлен");
                pictureBox.Image = _company.Show();
            }
        }
        catch (Exception ex)
        {
            if (ex is CollectionOverflowException)
            {
                MessageBox.Show("Не удалось добавить объект");
                _logger.LogError("Ошибка: {Message}", ex.Message);
            }
            else if (ex is PositionOutOfCollectionException)
            {
                MessageBox.Show("Выход за пределы коллекции");
                _logger.LogError("Ошибка: {Message}", ex.Message);
            }
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
        try
        {
            if (_company - pos != null)
            {
                MessageBox.Show("Объект удален");
                _logger.LogInformation("Удален объект - " + pos);
                pictureBox.Image = _company.Show();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось удалить объект");
            _logger.LogError("Ошибка: {Message}", ex.Message);
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
            string? colName = _storageCollection.Keys?[i].Name;
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
        try
        {
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
            _logger.LogInformation("Коллекция добавлена " + textBoxCollectionName.Text);
        }
        catch (Exception ex)
        {
            _logger.LogError("Ошибка: {Message}", ex.Message);
        }
    }
    private void buttonCollectionDel_Click(object sender, EventArgs e)
    {
        if (listBoxCollection.SelectedIndex < 0 || listBoxCollection.SelectedItems == null)
        {
            MessageBox.Show("Коллекция не выбрана");
            return;
        }
        try
        {
            if (MessageBox.Show("Удалить коллекцию?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            _storageCollection.DelCollection(listBoxCollection.SelectedItem.ToString());
            RefreshListBoxItems();
            _logger.LogInformation("Коллекция " + listBoxCollection.SelectedItem.ToString() + " удалена");
        }
        catch (Exception ex)
        {
            _logger.LogError("Ошибка: {Message}", ex.Message);
        }
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
            try
            {
                _storageCollection.LoadData(openFileDialog.FileName);
                RefreshListBoxItems();
                MessageBox.Show("Загрузка прошла успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _logger.LogInformation("Загрузка из файла: {filename}",
                openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Результат",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.LogError("Ошибка: {Message}", ex.Message);
            }
        }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                _storageCollection.SaveData(saveFileDialog.FileName);
                MessageBox.Show("Сохранение прошло успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _logger.LogInformation("Сохранение в файл: {filename}", saveFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.LogError("Ошибка: {Message}", ex.Message);
            }
        }
    }

    /// <summary>
    /// Сортировка по типу
    /// </summary>
    private void ButtonSortByType_Click(object sender, EventArgs e)
    {
        CompareCars(new BusCompareByType());
    }

    /// <summary>
    /// Сортировка по цвету
    /// </summary>
    private void ButtonSortByColor_Click(object sender, EventArgs e)
    {
        CompareCars(new BusCompareByColor());
    }

    /// <summary>
    /// Сортировка по сравнителю
    /// </summary>
    /// <param name="comparer">Сравнитель объектов</param>
    private void CompareCars(IComparer<DrawningBus?> comparer)
    {
        if (_company == null)
        {
            return;
        }
        _company.Sort(comparer);
        pictureBox.Image = _company.Show();
    }
}
