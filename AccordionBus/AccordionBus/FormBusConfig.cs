using AccordionBus.Drawnings;
using AccordionBus.Entities;

namespace AccordionBus;

public partial class FormBusConfig : Form
{
    private DrawningBus? _bus;

    private event Action<DrawningBus>? _busDelegate;
    public FormBusConfig()
    {
        InitializeComponent();
        panelRed.MouseDown += Panel_MouseDown;
        panelGreen.MouseDown += Panel_MouseDown;
        panelBlue.MouseDown += Panel_MouseDown;
        panelYellow.MouseDown += Panel_MouseDown;
        panelWhite.MouseDown += Panel_MouseDown;
        panelGray.MouseDown += Panel_MouseDown;
        panelBlack.MouseDown += Panel_MouseDown;
        panelPurple.MouseDown += Panel_MouseDown;
        buttonCancel.Click += (sender, e) => Close();
    }
    private void DrawObject()
    {
        Bitmap bmp = new(pictureBoxObject.Width, pictureBoxObject.Height);
        Graphics gr = Graphics.FromImage(bmp);
        _bus?.SetPictureSize(pictureBoxObject.Width,
        pictureBoxObject.Height);
        _bus?.SetPosition(15, 15);
        _bus?.DrawTransport(gr);
        pictureBoxObject.Image = bmp;
    }

    public void AddEvent(Action<DrawningBus> busDelegate)
    {
        _busDelegate += busDelegate;
    }

    private void LabelObject_MouseDown(object sender, MouseEventArgs e)
    {
        (sender as Label)?.DoDragDrop((sender as Label)?.Name, DragDropEffects.Move | DragDropEffects.Copy);
    }

    private void PanelObject_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = e.Data?.GetDataPresent(DataFormats.Text) ?? false ? e.Effect = DragDropEffects.Copy : e.Effect = DragDropEffects.None;
    }

private void PanelObject_DragDrop(object sender, DragEventArgs e)
{
    switch (e.Data?.GetData(DataFormats.Text)?.ToString())
    {
        case "labelSimpleObject":
            _bus = new DrawningBus(
                (int)numericUpDownSpeed.Value,
                (double)numericUpDownWeight.Value, 
                Color.White);
            break;
        case "labelModifiedObject":
            _bus = new DrawningAccordionBus(
                (int)numericUpDownSpeed.Value, 
                (double)numericUpDownWeight.Value,
                Color.White,
                Color.Black, 
                checkBoxGlass.Checked, 
                checkBoxGarmoshka.Checked);
            break;
    }
    DrawObject();
}

    private void Panel_MouseDown(object? sender, MouseEventArgs e)
    {
        (sender as Control)?.DoDragDrop((sender as Control)?.BackColor!, DragDropEffects.Move | DragDropEffects.Copy);
    }

    private void ButtonAdd_Click(object sender, EventArgs e)
    {
        if (_bus != null) { 
            _busDelegate?.Invoke(_bus);
            Close();
        }
    }
    private void labelBodyColor_DragDrop(object sender, DragEventArgs? e)
    {
        if (_bus == null) return;
        _bus.EntityBus?.SetBody((Color)e.Data.GetData(typeof(Color)));
        DrawObject();
    }
    private void labelBodyColor_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(Color))) e.Effect = DragDropEffects.Copy;
        else e.Effect = DragDropEffects.None;
    }

    private void labelAdditionalColor_DragEnter(object sender, DragEventArgs e)
    {
        if (_bus is DrawningAccordionBus)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
    private void labelAdditionalColor_DragDrop(object sender, DragEventArgs e)
    {
        if (_bus?.EntityBus is EntityAccordionBus _accordionBus)
        {
            _accordionBus.SetAdditional((Color)e.Data.GetData(typeof(Color)));
        }
        DrawObject();
    }
}
