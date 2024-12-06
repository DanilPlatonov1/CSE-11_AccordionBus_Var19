namespace AccordionBus
{
    partial class FormAccordionBus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccordionBus));
            pictureBoxAccordionBus = new PictureBox();
            buttonUp = new Button();
            buttonLeft = new Button();
            buttonDown = new Button();
            buttonRight = new Button();
            comboBoxStrategy = new ComboBox();
            buttonStrategyStep = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAccordionBus).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxAccordionBus
            // 
            pictureBoxAccordionBus.Dock = DockStyle.Fill;
            pictureBoxAccordionBus.Location = new Point(0, 0);
            pictureBoxAccordionBus.Name = "pictureBoxAccordionBus";
            pictureBoxAccordionBus.Size = new Size(800, 450);
            pictureBoxAccordionBus.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxAccordionBus.TabIndex = 5;
            pictureBoxAccordionBus.TabStop = false;
            // 
            // buttonUp
            // 
            buttonUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonUp.BackgroundImage = (Image)resources.GetObject("buttonUp.BackgroundImage");
            buttonUp.BackgroundImageLayout = ImageLayout.Zoom;
            buttonUp.Location = new Point(712, 368);
            buttonUp.Name = "buttonUp";
            buttonUp.Size = new Size(35, 35);
            buttonUp.TabIndex = 7;
            buttonUp.Text = " ";
            buttonUp.UseVisualStyleBackColor = true;
            buttonUp.Click += ButtonMove_Click;
            // 
            // buttonLeft
            // 
            buttonLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonLeft.BackgroundImage = (Image)resources.GetObject("buttonLeft.BackgroundImage");
            buttonLeft.BackgroundImageLayout = ImageLayout.Zoom;
            buttonLeft.Location = new Point(671, 409);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(35, 35);
            buttonLeft.TabIndex = 8;
            buttonLeft.Text = " ";
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += ButtonMove_Click;
            // 
            // buttonDown
            // 
            buttonDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDown.BackgroundImage = (Image)resources.GetObject("buttonDown.BackgroundImage");
            buttonDown.BackgroundImageLayout = ImageLayout.Zoom;
            buttonDown.Location = new Point(712, 409);
            buttonDown.Name = "buttonDown";
            buttonDown.Size = new Size(35, 35);
            buttonDown.TabIndex = 9;
            buttonDown.Text = " ";
            buttonDown.UseVisualStyleBackColor = true;
            buttonDown.Click += ButtonMove_Click;
            // 
            // buttonRight
            // 
            buttonRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRight.BackgroundImage = (Image)resources.GetObject("buttonRight.BackgroundImage");
            buttonRight.BackgroundImageLayout = ImageLayout.Zoom;
            buttonRight.Location = new Point(753, 409);
            buttonRight.Name = "buttonRight";
            buttonRight.Size = new Size(35, 35);
            buttonRight.TabIndex = 10;
            buttonRight.Text = " ";
            buttonRight.UseVisualStyleBackColor = true;
            buttonRight.Click += ButtonMove_Click;
            // 
            // comboBoxStrategy
            // 
            comboBoxStrategy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxStrategy.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStrategy.FormattingEnabled = true;
            comboBoxStrategy.Items.AddRange(new object[] { "К центру", "К краю" });
            comboBoxStrategy.Location = new Point(667, 12);
            comboBoxStrategy.Name = "comboBoxStrategy";
            comboBoxStrategy.Size = new Size(121, 23);
            comboBoxStrategy.TabIndex = 12;
            // 
            // buttonStrategyStep
            // 
            buttonStrategyStep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonStrategyStep.Location = new Point(713, 41);
            buttonStrategyStep.Name = "buttonStrategyStep";
            buttonStrategyStep.Size = new Size(75, 23);
            buttonStrategyStep.TabIndex = 13;
            buttonStrategyStep.Text = "Шаг";
            buttonStrategyStep.UseVisualStyleBackColor = true;
            buttonStrategyStep.Click += ButtonStrategyStep_Click;
            // 
            // FormAccordionBus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonStrategyStep);
            Controls.Add(comboBoxStrategy);
            Controls.Add(buttonRight);
            Controls.Add(buttonDown);
            Controls.Add(buttonLeft);
            Controls.Add(buttonUp);
            Controls.Add(pictureBoxAccordionBus);
            Name = "FormAccordionBus";
            Text = "Автобус с гармошкой";
            ((System.ComponentModel.ISupportInitialize)pictureBoxAccordionBus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private PictureBox pictureBoxAccordionBus;
        private Button buttonUp;
        private Button buttonLeft;
        private Button buttonDown;
        private Button buttonRight;
        private ComboBox comboBoxStrategy;
        private Button buttonStrategyStep;
    }
}