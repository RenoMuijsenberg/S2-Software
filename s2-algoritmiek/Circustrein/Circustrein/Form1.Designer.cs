namespace Circustrein;

partial class CircusTrein
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
            this.grbAnimal = new System.Windows.Forms.GroupBox();
            this.btnAddAnimal = new System.Windows.Forms.Button();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblFood = new System.Windows.Forms.Label();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.cmbFood = new System.Windows.Forms.ComboBox();
            this.grbAnimalList = new System.Windows.Forms.GroupBox();
            this.btnSortAnimal = new System.Windows.Forms.Button();
            this.ltbAnimals = new System.Windows.Forms.ListBox();
            this.ltbWagonList = new System.Windows.Forms.ListBox();
            this.grbWagonList = new System.Windows.Forms.GroupBox();
            this.grbAnimal.SuspendLayout();
            this.grbAnimalList.SuspendLayout();
            this.grbWagonList.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbAnimal
            // 
            this.grbAnimal.Controls.Add(this.btnAddAnimal);
            this.grbAnimal.Controls.Add(this.lblSize);
            this.grbAnimal.Controls.Add(this.lblFood);
            this.grbAnimal.Controls.Add(this.cmbSize);
            this.grbAnimal.Controls.Add(this.cmbFood);
            this.grbAnimal.Location = new System.Drawing.Point(10, 9);
            this.grbAnimal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbAnimal.Name = "grbAnimal";
            this.grbAnimal.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbAnimal.Size = new System.Drawing.Size(162, 138);
            this.grbAnimal.TabIndex = 0;
            this.grbAnimal.TabStop = false;
            this.grbAnimal.Text = "Add animal";
            // 
            // btnAddAnimal
            // 
            this.btnAddAnimal.Location = new System.Drawing.Point(5, 104);
            this.btnAddAnimal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddAnimal.Name = "btnAddAnimal";
            this.btnAddAnimal.Size = new System.Drawing.Size(151, 22);
            this.btnAddAnimal.TabIndex = 4;
            this.btnAddAnimal.Text = "Add animal";
            this.btnAddAnimal.UseVisualStyleBackColor = true;
            this.btnAddAnimal.Click += new System.EventHandler(this.btnAddAnimal_Click);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(5, 61);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(30, 15);
            this.lblSize.TabIndex = 3;
            this.lblSize.Text = "Size:";
            // 
            // lblFood
            // 
            this.lblFood.AutoSize = true;
            this.lblFood.Location = new System.Drawing.Point(5, 20);
            this.lblFood.Name = "lblFood";
            this.lblFood.Size = new System.Drawing.Size(37, 15);
            this.lblFood.TabIndex = 2;
            this.lblFood.Text = "Food:";
            // 
            // cmbSize
            // 
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Location = new System.Drawing.Point(5, 78);
            this.cmbSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(152, 23);
            this.cmbSize.TabIndex = 1;
            // 
            // cmbFood
            // 
            this.cmbFood.FormattingEnabled = true;
            this.cmbFood.Location = new System.Drawing.Point(5, 38);
            this.cmbFood.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFood.Name = "cmbFood";
            this.cmbFood.Size = new System.Drawing.Size(152, 23);
            this.cmbFood.TabIndex = 0;
            // 
            // grbAnimalList
            // 
            this.grbAnimalList.Controls.Add(this.btnSortAnimal);
            this.grbAnimalList.Controls.Add(this.ltbAnimals);
            this.grbAnimalList.Location = new System.Drawing.Point(178, 9);
            this.grbAnimalList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbAnimalList.Name = "grbAnimalList";
            this.grbAnimalList.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbAnimalList.Size = new System.Drawing.Size(162, 138);
            this.grbAnimalList.TabIndex = 1;
            this.grbAnimalList.TabStop = false;
            this.grbAnimalList.Text = "Animal list";
            // 
            // btnSortAnimal
            // 
            this.btnSortAnimal.Location = new System.Drawing.Point(5, 104);
            this.btnSortAnimal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSortAnimal.Name = "btnSortAnimal";
            this.btnSortAnimal.Size = new System.Drawing.Size(151, 22);
            this.btnSortAnimal.TabIndex = 5;
            this.btnSortAnimal.Text = "Sort animals";
            this.btnSortAnimal.UseVisualStyleBackColor = true;
            this.btnSortAnimal.Click += new System.EventHandler(this.btnSortAnimal_Click);
            // 
            // ltbAnimals
            // 
            this.ltbAnimals.FormattingEnabled = true;
            this.ltbAnimals.ItemHeight = 15;
            this.ltbAnimals.Location = new System.Drawing.Point(5, 20);
            this.ltbAnimals.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ltbAnimals.Name = "ltbAnimals";
            this.ltbAnimals.Size = new System.Drawing.Size(152, 79);
            this.ltbAnimals.TabIndex = 0;
            // 
            // ltbWagonList
            // 
            this.ltbWagonList.FormattingEnabled = true;
            this.ltbWagonList.ItemHeight = 15;
            this.ltbWagonList.Location = new System.Drawing.Point(5, 20);
            this.ltbWagonList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ltbWagonList.Name = "ltbWagonList";
            this.ltbWagonList.Size = new System.Drawing.Size(152, 109);
            this.ltbWagonList.TabIndex = 0;
            this.ltbWagonList.SelectedIndexChanged += new System.EventHandler(this.ltbWagonList_SelectedIndexChanged);
            // 
            // grbWagonList
            // 
            this.grbWagonList.Controls.Add(this.ltbWagonList);
            this.grbWagonList.Location = new System.Drawing.Point(345, 10);
            this.grbWagonList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbWagonList.Name = "grbWagonList";
            this.grbWagonList.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbWagonList.Size = new System.Drawing.Size(162, 138);
            this.grbWagonList.TabIndex = 6;
            this.grbWagonList.TabStop = false;
            this.grbWagonList.Text = "Wagon list";
            // 
            // CircusTrein
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 158);
            this.Controls.Add(this.grbWagonList);
            this.Controls.Add(this.grbAnimalList);
            this.Controls.Add(this.grbAnimal);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CircusTrein";
            this.Text = "CircusTrein";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbAnimal.ResumeLayout(false);
            this.grbAnimal.PerformLayout();
            this.grbAnimalList.ResumeLayout(false);
            this.grbWagonList.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private GroupBox grbAnimal;
    private ComboBox cmbFood;
    private ComboBox cmbSize;
    private Label lblSize;
    private Label lblFood;
    private Button btnAddAnimal;
    private GroupBox grbAnimalList;
    private ListBox ltbAnimals;
    private Button btnSortAnimal;
    private ListBox ltbWagonList;
    private GroupBox grbWagonList;
}