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
            buttonRefresh = new Button();
            buttonGoToCheck = new Button();
            buttonDelBus = new Button();
            maskedTextBoxPosition = new MaskedTextBox();
            buttonAddAccordionBus = new Button();
            buttonAddBus = new Button();
            comboBoxSelectorCompany = new ComboBox();
            pictureBox = new PictureBox();
            colorDialog1 = new ColorDialog();
            groupBoxTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // groupBoxTools
            // 
            groupBoxTools.Controls.Add(buttonRefresh);
            groupBoxTools.Controls.Add(buttonGoToCheck);
            groupBoxTools.Controls.Add(buttonDelBus);
            groupBoxTools.Controls.Add(maskedTextBoxPosition);
            groupBoxTools.Controls.Add(buttonAddAccordionBus);
            groupBoxTools.Controls.Add(buttonAddBus);
            groupBoxTools.Controls.Add(comboBoxSelectorCompany);
            groupBoxTools.Dock = DockStyle.Right;
            groupBoxTools.Location = new Point(1275, 0);
            groupBoxTools.Name = "groupBoxTools";
            groupBoxTools.Size = new Size(152, 543);
            groupBoxTools.TabIndex = 0;
            groupBoxTools.TabStop = false;
            groupBoxTools.Text = "Инструменты";
            // 
            // buttonRefresh
            // 
            buttonRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonRefresh.Location = new Point(6, 232);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(134, 22);
            buttonRefresh.TabIndex = 7;
            buttonRefresh.Text = "Обновить";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += ButtonRefresh_Click;
            // 
            // buttonGoToCheck
            // 
            buttonGoToCheck.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonGoToCheck.Location = new Point(6, 203);
            buttonGoToCheck.Name = "buttonGoToCheck";
            buttonGoToCheck.Size = new Size(134, 23);
            buttonGoToCheck.TabIndex = 6;
            buttonGoToCheck.Text = "Передать на тесты";
            buttonGoToCheck.UseVisualStyleBackColor = true;
            buttonGoToCheck.Click += ButtonGoToCheck_Click;
            // 
            // buttonDelBus
            // 
            buttonDelBus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonDelBus.Location = new Point(6, 175);
            buttonDelBus.Name = "buttonDelBus";
            buttonDelBus.Size = new Size(134, 22);
            buttonDelBus.TabIndex = 5;
            buttonDelBus.Text = "Удалить автомобиль";
            buttonDelBus.UseVisualStyleBackColor = true;
            buttonDelBus.Click += ButtonRemoveBus_Click;
            // 
            // maskedTextBoxPosition
            // 
            maskedTextBoxPosition.Location = new Point(6, 146);
            maskedTextBoxPosition.Mask = "00";
            maskedTextBoxPosition.Name = "maskedTextBoxPosition";
            maskedTextBoxPosition.Size = new Size(134, 23);
            maskedTextBoxPosition.TabIndex = 4;
            maskedTextBoxPosition.ValidatingType = typeof(int);
            // 
            // buttonAddAccordionBus
            // 
            buttonAddAccordionBus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonAddAccordionBus.Location = new Point(6, 99);
            buttonAddAccordionBus.Name = "buttonAddAccordionBus";
            buttonAddAccordionBus.Size = new Size(134, 41);
            buttonAddAccordionBus.TabIndex = 2;
            buttonAddAccordionBus.Text = "Добавление автобуса с гармошкой";
            buttonAddAccordionBus.UseVisualStyleBackColor = true;
            buttonAddAccordionBus.Click += ButtonAddAccordionBus_Click;
            // 
            // buttonAddBus
            // 
            buttonAddBus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonAddBus.Location = new Point(6, 51);
            buttonAddBus.Name = "buttonAddBus";
            buttonAddBus.Size = new Size(134, 42);
            buttonAddBus.TabIndex = 1;
            buttonAddBus.Text = "Добавление автобуса";
            buttonAddBus.UseVisualStyleBackColor = true;
            buttonAddBus.Click += ButtonAddBus_Click;
            // 
            // comboBoxSelectorCompany
            // 
            comboBoxSelectorCompany.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxSelectorCompany.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSelectorCompany.FormattingEnabled = true;
            comboBoxSelectorCompany.Items.AddRange(new object[] { "Автовокзал" });
            comboBoxSelectorCompany.Location = new Point(6, 22);
            comboBoxSelectorCompany.Name = "comboBoxSelectorCompany";
            comboBoxSelectorCompany.Size = new Size(134, 23);
            comboBoxSelectorCompany.TabIndex = 0;
            comboBoxSelectorCompany.SelectedIndexChanged += ComboBoxSelectorCompany_SelectedIndexChanged;
            // 
            // pictureBox
            // 
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(0, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1275, 543);
            pictureBox.TabIndex = 3;
            pictureBox.TabStop = false;
            // 
            // FormBusCollection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1427, 543);
            Controls.Add(pictureBox);
            Controls.Add(groupBoxTools);
            Name = "FormBusCollection";
            Text = "Коллекция автобусов";
            groupBoxTools.ResumeLayout(false);
            groupBoxTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxTools;
        private ComboBox comboBoxSelectorCompany;
        private Button buttonDelBus;
        private MaskedTextBox maskedTextBoxPosition;
        private Button buttonAddAccordionBus;
        private Button buttonAddBus;
        private PictureBox pictureBox;
        private Button buttonRefresh;
        private Button buttonGoToCheck;
        private ColorDialog colorDialog1;
    }
}