namespace ContainerVervoer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCreateShip = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudShipWidth = new System.Windows.Forms.NumericUpDown();
            this.lblShipLength = new System.Windows.Forms.Label();
            this.nudShipLength = new System.Windows.Forms.NumericUpDown();
            this.grbShipsReady = new System.Windows.Forms.GroupBox();
            this.ltbShipsReadyForLoad = new System.Windows.Forms.ListBox();
            this.grbConfigureContainers = new System.Windows.Forms.GroupBox();
            this.btnSortContainers = new System.Windows.Forms.Button();
            this.lblCoolableContainer = new System.Windows.Forms.Label();
            this.nudCool = new System.Windows.Forms.NumericUpDown();
            this.lblValuableContainer = new System.Windows.Forms.Label();
            this.nudNormal = new System.Windows.Forms.NumericUpDown();
            this.nudVal = new System.Windows.Forms.NumericUpDown();
            this.lblNormalContainer = new System.Windows.Forms.Label();
            this.grbSortedContainers = new System.Windows.Forms.GroupBox();
            this.ltbSortedContainers = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShipWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShipLength)).BeginInit();
            this.grbShipsReady.SuspendLayout();
            this.grbConfigureContainers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVal)).BeginInit();
            this.grbSortedContainers.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCreateShip);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nudShipWidth);
            this.groupBox1.Controls.Add(this.lblShipLength);
            this.groupBox1.Controls.Add(this.nudShipLength);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configure ship";
            // 
            // btnCreateShip
            // 
            this.btnCreateShip.Location = new System.Drawing.Point(6, 115);
            this.btnCreateShip.Name = "btnCreateShip";
            this.btnCreateShip.Size = new System.Drawing.Size(123, 23);
            this.btnCreateShip.TabIndex = 6;
            this.btnCreateShip.Text = "Create ship";
            this.btnCreateShip.UseVisualStyleBackColor = true;
            this.btnCreateShip.Click += new System.EventHandler(this.btnCreateShip_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ship width (Y)";
            // 
            // nudShipWidth
            // 
            this.nudShipWidth.Location = new System.Drawing.Point(6, 86);
            this.nudShipWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudShipWidth.Name = "nudShipWidth";
            this.nudShipWidth.Size = new System.Drawing.Size(123, 23);
            this.nudShipWidth.TabIndex = 4;
            this.nudShipWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblShipLength
            // 
            this.lblShipLength.AutoSize = true;
            this.lblShipLength.Location = new System.Drawing.Point(6, 22);
            this.lblShipLength.Name = "lblShipLength";
            this.lblShipLength.Size = new System.Drawing.Size(85, 15);
            this.lblShipLength.TabIndex = 3;
            this.lblShipLength.Text = "Ship length (X)";
            // 
            // nudShipLength
            // 
            this.nudShipLength.Location = new System.Drawing.Point(6, 40);
            this.nudShipLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudShipLength.Name = "nudShipLength";
            this.nudShipLength.Size = new System.Drawing.Size(123, 23);
            this.nudShipLength.TabIndex = 2;
            this.nudShipLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // grbShipsReady
            // 
            this.grbShipsReady.Controls.Add(this.ltbShipsReadyForLoad);
            this.grbShipsReady.Location = new System.Drawing.Point(153, 12);
            this.grbShipsReady.Name = "grbShipsReady";
            this.grbShipsReady.Size = new System.Drawing.Size(342, 149);
            this.grbShipsReady.TabIndex = 1;
            this.grbShipsReady.TabStop = false;
            this.grbShipsReady.Text = "Ships ready to be loaded";
            // 
            // ltbShipsReadyForLoad
            // 
            this.ltbShipsReadyForLoad.FormattingEnabled = true;
            this.ltbShipsReadyForLoad.ItemHeight = 15;
            this.ltbShipsReadyForLoad.Location = new System.Drawing.Point(6, 20);
            this.ltbShipsReadyForLoad.Name = "ltbShipsReadyForLoad";
            this.ltbShipsReadyForLoad.Size = new System.Drawing.Size(330, 124);
            this.ltbShipsReadyForLoad.TabIndex = 0;
            // 
            // grbConfigureContainers
            // 
            this.grbConfigureContainers.Controls.Add(this.btnSortContainers);
            this.grbConfigureContainers.Controls.Add(this.lblCoolableContainer);
            this.grbConfigureContainers.Controls.Add(this.nudCool);
            this.grbConfigureContainers.Controls.Add(this.lblValuableContainer);
            this.grbConfigureContainers.Controls.Add(this.nudNormal);
            this.grbConfigureContainers.Controls.Add(this.nudVal);
            this.grbConfigureContainers.Controls.Add(this.lblNormalContainer);
            this.grbConfigureContainers.Location = new System.Drawing.Point(12, 167);
            this.grbConfigureContainers.Name = "grbConfigureContainers";
            this.grbConfigureContainers.Size = new System.Drawing.Size(277, 142);
            this.grbConfigureContainers.TabIndex = 2;
            this.grbConfigureContainers.TabStop = false;
            this.grbConfigureContainers.Text = "Configure containers of selected ship";
            // 
            // btnSortContainers
            // 
            this.btnSortContainers.Location = new System.Drawing.Point(6, 113);
            this.btnSortContainers.Name = "btnSortContainers";
            this.btnSortContainers.Size = new System.Drawing.Size(258, 23);
            this.btnSortContainers.TabIndex = 15;
            this.btnSortContainers.Text = "Sort containers";
            this.btnSortContainers.UseVisualStyleBackColor = true;
            this.btnSortContainers.Click += new System.EventHandler(this.btnSortContainers_Click);
            // 
            // lblCoolableContainer
            // 
            this.lblCoolableContainer.AutoSize = true;
            this.lblCoolableContainer.Location = new System.Drawing.Point(141, 20);
            this.lblCoolableContainer.Name = "lblCoolableContainer";
            this.lblCoolableContainer.Size = new System.Drawing.Size(115, 15);
            this.lblCoolableContainer.TabIndex = 12;
            this.lblCoolableContainer.Text = "Coolable containers:";
            // 
            // nudCool
            // 
            this.nudCool.Location = new System.Drawing.Point(141, 38);
            this.nudCool.Name = "nudCool";
            this.nudCool.Size = new System.Drawing.Size(123, 23);
            this.nudCool.TabIndex = 11;
            // 
            // lblValuableContainer
            // 
            this.lblValuableContainer.AutoSize = true;
            this.lblValuableContainer.Location = new System.Drawing.Point(6, 66);
            this.lblValuableContainer.Name = "lblValuableContainer";
            this.lblValuableContainer.Size = new System.Drawing.Size(112, 15);
            this.lblValuableContainer.TabIndex = 10;
            this.lblValuableContainer.Text = "Valuable containers:";
            // 
            // nudNormal
            // 
            this.nudNormal.Location = new System.Drawing.Point(6, 38);
            this.nudNormal.Name = "nudNormal";
            this.nudNormal.Size = new System.Drawing.Size(123, 23);
            this.nudNormal.TabIndex = 7;
            // 
            // nudVal
            // 
            this.nudVal.Location = new System.Drawing.Point(6, 84);
            this.nudVal.Name = "nudVal";
            this.nudVal.Size = new System.Drawing.Size(123, 23);
            this.nudVal.TabIndex = 9;
            // 
            // lblNormalContainer
            // 
            this.lblNormalContainer.AutoSize = true;
            this.lblNormalContainer.Location = new System.Drawing.Point(6, 20);
            this.lblNormalContainer.Name = "lblNormalContainer";
            this.lblNormalContainer.Size = new System.Drawing.Size(108, 15);
            this.lblNormalContainer.TabIndex = 8;
            this.lblNormalContainer.Text = "Normal containers:";
            // 
            // grbSortedContainers
            // 
            this.grbSortedContainers.Controls.Add(this.ltbSortedContainers);
            this.grbSortedContainers.Location = new System.Drawing.Point(295, 167);
            this.grbSortedContainers.Name = "grbSortedContainers";
            this.grbSortedContainers.Size = new System.Drawing.Size(396, 142);
            this.grbSortedContainers.TabIndex = 3;
            this.grbSortedContainers.TabStop = false;
            this.grbSortedContainers.Text = "Sorted containers";
            // 
            // ltbSortedContainers
            // 
            this.ltbSortedContainers.FormattingEnabled = true;
            this.ltbSortedContainers.ItemHeight = 15;
            this.ltbSortedContainers.Location = new System.Drawing.Point(6, 20);
            this.ltbSortedContainers.Name = "ltbSortedContainers";
            this.ltbSortedContainers.Size = new System.Drawing.Size(381, 109);
            this.ltbSortedContainers.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 314);
            this.Controls.Add(this.grbSortedContainers);
            this.Controls.Add(this.grbConfigureContainers);
            this.Controls.Add(this.grbShipsReady);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShipWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShipLength)).EndInit();
            this.grbShipsReady.ResumeLayout(false);
            this.grbConfigureContainers.ResumeLayout(false);
            this.grbConfigureContainers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVal)).EndInit();
            this.grbSortedContainers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button btnCreateShip;
        private GroupBox grbShipsReady;
        private ListBox ltbShipsReadyForLoad;
        private Label label1;
        private NumericUpDown nudShipWidth;
        private Label lblShipLength;
        private NumericUpDown nudShipLength;
        private GroupBox grbConfigureContainers;
        private Label lblValuableContainer;
        private NumericUpDown nudNormal;
        private NumericUpDown nudVal;
        private Label lblNormalContainer;
        private Label lblCoolableContainer;
        private NumericUpDown nudCool;
        private Button btnSortContainers;
        private GroupBox grbSortedContainers;
        private ListBox ltbSortedContainers;
    }
}