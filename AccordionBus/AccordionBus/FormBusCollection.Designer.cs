namespace AccordionBus
{
    partial class FormBusCollection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxTools = new GroupBox();
            panelCompanyTools = new Panel();
            buttonAddBus = new Button();
            maskedTextBoxPosition = new MaskedTextBox();
            buttonRefresh = new Button();
            buttonDelBus = new Button();
            buttonGoToCheck = new Button();
            buttonCreateCompany = new Button();
            panelStorage = new Panel();
            buttonCollectionDel = new Button();
            listBoxCollection = new ListBox();
            buttonCollectionAdd = new Button();
            radioButtonList = new RadioButton();
            radioButtonMassive = new RadioButton();
            textBoxCollectionName = new TextBox();
            labelCollectionName = new Label();
            comboBoxSelectorCompany = new ComboBox();
            pictureBox = new PictureBox();
            colorDialog = new ColorDialog();
            menuStrip = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            buttonSortByColor = new Button();
            buttonSortByType = new Button();
            groupBoxTools.SuspendLayout();
            panelCompanyTools.SuspendLayout();
            panelStorage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxTools
            // 
            groupBoxTools.Controls.Add(panelCompanyTools);
            groupBoxTools.Controls.Add(buttonCreateCompany);
            groupBoxTools.Controls.Add(panelStorage);
            groupBoxTools.Controls.Add(comboBoxSelectorCompany);
            groupBoxTools.Dock = DockStyle.Right;
            groupBoxTools.Location = new Point(813, 24);
            groupBoxTools.Name = "groupBoxTools";
            groupBoxTools.Size = new Size(231, 487);
            groupBoxTools.TabIndex = 0;
            groupBoxTools.TabStop = false;
            groupBoxTools.Text = "Инструменты";
            // 
            // panelCompanyTools
            // 
            panelCompanyTools.Controls.Add(buttonSortByColor);
            panelCompanyTools.Controls.Add(buttonSortByType);
            panelCompanyTools.Controls.Add(buttonAddBus);
            panelCompanyTools.Controls.Add(maskedTextBoxPosition);
            panelCompanyTools.Controls.Add(buttonRefresh);
            panelCompanyTools.Controls.Add(buttonDelBus);
            panelCompanyTools.Controls.Add(buttonGoToCheck);
            panelCompanyTools.Dock = DockStyle.Bottom;
            panelCompanyTools.Enabled = false;
            panelCompanyTools.Location = new Point(3, 276);
            panelCompanyTools.Name = "panelCompanyTools";
            panelCompanyTools.Size = new Size(225, 208);
            panelCompanyTools.TabIndex = 10;
            // 
            // buttonAddBus
            // 
            buttonAddBus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonAddBus.Location = new Point(4, 3);
            buttonAddBus.Name = "buttonAddBus";
            buttonAddBus.Size = new Size(212, 29);
            buttonAddBus.TabIndex = 1;
            buttonAddBus.Text = "Добавление автобуса";
            buttonAddBus.UseVisualStyleBackColor = true;
            buttonAddBus.Click += ButtonAddBus_Click;
            // 
            // maskedTextBoxPosition
            // 
            maskedTextBoxPosition.Location = new Point(4, 38);
            maskedTextBoxPosition.Mask = "00";
            maskedTextBoxPosition.Name = "maskedTextBoxPosition";
            maskedTextBoxPosition.Size = new Size(212, 23);
            maskedTextBoxPosition.TabIndex = 4;
            maskedTextBoxPosition.ValidatingType = typeof(int);
            // 
            // buttonRefresh
            // 
            buttonRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonRefresh.Location = new Point(4, 125);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(212, 22);
            buttonRefresh.TabIndex = 7;
            buttonRefresh.Text = "Обновить";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += ButtonRefresh_Click;
            // 
            // buttonDelBus
            // 
            buttonDelBus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonDelBus.Location = new Point(4, 67);
            buttonDelBus.Name = "buttonDelBus";
            buttonDelBus.Size = new Size(212, 23);
            buttonDelBus.TabIndex = 5;
            buttonDelBus.Text = "Удалить автомобиль";
            buttonDelBus.UseVisualStyleBackColor = true;
            buttonDelBus.Click += ButtonRemoveBus_Click;
            // 
            // buttonGoToCheck
            // 
            buttonGoToCheck.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonGoToCheck.Location = new Point(4, 96);
            buttonGoToCheck.Name = "buttonGoToCheck";
            buttonGoToCheck.Size = new Size(212, 23);
            buttonGoToCheck.TabIndex = 6;
            buttonGoToCheck.Text = "Передать на тесты";
            buttonGoToCheck.UseVisualStyleBackColor = true;
            buttonGoToCheck.Click += ButtonGoToCheck_Click;
            // 
            // buttonCreateCompany
            // 
            buttonCreateCompany.Location = new Point(7, 243);
            buttonCreateCompany.Name = "buttonCreateCompany";
            buttonCreateCompany.Size = new Size(213, 23);
            buttonCreateCompany.TabIndex = 9;
            buttonCreateCompany.Text = "Создать компанию";
            buttonCreateCompany.UseVisualStyleBackColor = true;
            buttonCreateCompany.Click += buttonCreateCompany_Click;
            // 
            // panelStorage
            // 
            panelStorage.Controls.Add(buttonCollectionDel);
            panelStorage.Controls.Add(listBoxCollection);
            panelStorage.Controls.Add(buttonCollectionAdd);
            panelStorage.Controls.Add(radioButtonList);
            panelStorage.Controls.Add(radioButtonMassive);
            panelStorage.Controls.Add(textBoxCollectionName);
            panelStorage.Controls.Add(labelCollectionName);
            panelStorage.Dock = DockStyle.Top;
            panelStorage.Location = new Point(3, 19);
            panelStorage.Name = "panelStorage";
            panelStorage.Size = new Size(225, 184);
            panelStorage.TabIndex = 8;
            // 
            // buttonCollectionDel
            // 
            buttonCollectionDel.Location = new Point(4, 156);
            buttonCollectionDel.Name = "buttonCollectionDel";
            buttonCollectionDel.Size = new Size(212, 23);
            buttonCollectionDel.TabIndex = 6;
            buttonCollectionDel.Text = "Удалить коллекцию";
            buttonCollectionDel.UseVisualStyleBackColor = true;
            buttonCollectionDel.Click += buttonCollectionDel_Click;
            // 
            // listBoxCollection
            // 
            listBoxCollection.FormattingEnabled = true;
            listBoxCollection.ItemHeight = 15;
            listBoxCollection.Location = new Point(4, 101);
            listBoxCollection.Name = "listBoxCollection";
            listBoxCollection.Size = new Size(212, 49);
            listBoxCollection.TabIndex = 5;
            // 
            // buttonCollectionAdd
            // 
            buttonCollectionAdd.Location = new Point(3, 72);
            buttonCollectionAdd.Name = "buttonCollectionAdd";
            buttonCollectionAdd.Size = new Size(213, 23);
            buttonCollectionAdd.TabIndex = 4;
            buttonCollectionAdd.Text = "Добавить коллекцию";
            buttonCollectionAdd.UseVisualStyleBackColor = true;
            buttonCollectionAdd.Click += buttonCollectionAdd_Click;
            // 
            // radioButtonList
            // 
            radioButtonList.AutoSize = true;
            radioButtonList.Location = new Point(150, 47);
            radioButtonList.Name = "radioButtonList";
            radioButtonList.Size = new Size(66, 19);
            radioButtonList.TabIndex = 3;
            radioButtonList.TabStop = true;
            radioButtonList.Text = "Список";
            radioButtonList.UseVisualStyleBackColor = true;
            // 
            // radioButtonMassive
            // 
            radioButtonMassive.AutoSize = true;
            radioButtonMassive.Location = new Point(4, 47);
            radioButtonMassive.Name = "radioButtonMassive";
            radioButtonMassive.Size = new Size(67, 19);
            radioButtonMassive.TabIndex = 2;
            radioButtonMassive.TabStop = true;
            radioButtonMassive.Text = "Массив";
            radioButtonMassive.UseVisualStyleBackColor = true;
            // 
            // textBoxCollectionName
            // 
            textBoxCollectionName.Location = new Point(3, 18);
            textBoxCollectionName.Name = "textBoxCollectionName";
            textBoxCollectionName.Size = new Size(213, 23);
            textBoxCollectionName.TabIndex = 1;
            // 
            // labelCollectionName
            // 
            labelCollectionName.AutoSize = true;
            labelCollectionName.Location = new Point(3, 0);
            labelCollectionName.Name = "labelCollectionName";
            labelCollectionName.Size = new Size(125, 15);
            labelCollectionName.TabIndex = 0;
            labelCollectionName.Text = "Название коллекции:";
            // 
            // comboBoxSelectorCompany
            // 
            comboBoxSelectorCompany.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxSelectorCompany.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSelectorCompany.FormattingEnabled = true;
            comboBoxSelectorCompany.Items.AddRange(new object[] { "Автовокзал" });
            comboBoxSelectorCompany.Location = new Point(7, 214);
            comboBoxSelectorCompany.Name = "comboBoxSelectorCompany";
            comboBoxSelectorCompany.Size = new Size(213, 23);
            comboBoxSelectorCompany.TabIndex = 0;
            // 
            // pictureBox
            // 
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(0, 24);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(813, 487);
            pictureBox.TabIndex = 3;
            pictureBox.TabStop = false;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1044, 24);
            menuStrip.TabIndex = 4;
            menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(181, 22);
            saveToolStripMenuItem.Text = "Сохранение";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            loadToolStripMenuItem.Size = new Size(181, 22);
            loadToolStripMenuItem.Text = "Загрузка";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "txt file | *.txt";
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            openFileDialog.Filter = "txt file | *.txt";
            // 
            // buttonSortByColor
            // 
            buttonSortByColor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonSortByColor.Location = new Point(4, 182);
            buttonSortByColor.Name = "buttonSortByColor";
            buttonSortByColor.Size = new Size(212, 22);
            buttonSortByColor.TabIndex = 9;
            buttonSortByColor.Text = "Сортировать по цвету";
            buttonSortByColor.UseVisualStyleBackColor = true;
            buttonSortByColor.Click += ButtonSortByColor_Click;
            // 
            // buttonSortByType
            // 
            buttonSortByType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonSortByType.Location = new Point(4, 153);
            buttonSortByType.Name = "buttonSortByType";
            buttonSortByType.Size = new Size(212, 23);
            buttonSortByType.TabIndex = 8;
            buttonSortByType.Text = "Сортировать по типу";
            buttonSortByType.UseVisualStyleBackColor = true;
            buttonSortByType.Click += ButtonSortByType_Click;
            // 
            // FormBusCollection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 511);
            Controls.Add(pictureBox);
            Controls.Add(groupBoxTools);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "FormBusCollection";
            Text = "Коллекция автобусов";
            groupBoxTools.ResumeLayout(false);
            panelCompanyTools.ResumeLayout(false);
            panelCompanyTools.PerformLayout();
            panelStorage.ResumeLayout(false);
            panelStorage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxTools;
        private ComboBox comboBoxSelectorCompany;
        private Button buttonDelBus;
        private MaskedTextBox maskedTextBoxPosition;
        private Button buttonAddBus;
        private PictureBox pictureBox;
        private Button buttonRefresh;
        private Button buttonGoToCheck;
        private ColorDialog colorDialog;
        private Panel panelStorage;
        private TextBox textBoxCollectionName;
        private Label labelCollectionName;
        private RadioButton radioButtonList;
        private RadioButton radioButtonMassive;
        private Button buttonCollectionDel;
        private ListBox listBoxCollection;
        private Button buttonCollectionAdd;
        private Button buttonCreateCompany;
        private Panel panelCompanyTools;
        private MenuStrip menuStrip;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private Button buttonSortByColor;
        private Button buttonSortByType;
    }
}