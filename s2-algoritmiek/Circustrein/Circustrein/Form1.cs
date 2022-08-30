namespace Circustrein;

public partial class CircusTrein : Form
{
    private Train train = new Train();
    private Circus circus = new Circus();

    public CircusTrein()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        cmbFood.DataSource = Enum.GetValues(typeof(Food));
        cmbSize.DataSource = Enum.GetValues(typeof(Size));
    }

    private void btnAddAnimal_Click(object sender, EventArgs e)
    {
        circus.AnimalsInCircus.Add(new Animal((Food)cmbFood.SelectedValue, (Size)cmbSize.SelectedValue));
        UpdateAnimalListBox();
    }

    private void UpdateAnimalListBox()
    {
        ltbAnimals.Items.Clear();

        foreach (var animal in circus.AnimalsInCircus)
        {
            ltbAnimals.Items.Add("Animal, " + animal.Food.ToString() + ", " + animal.Size.ToString());
        }
    }

    private void btnSortAnimal_Click(object sender, EventArgs e)
    {
        train.SortAnimals(circus.AnimalsInCircus);
        circus.AnimalsInCircus.Clear();
        UpdateAnimalListBox();
        UpdateWagonListBox();
    }

    private void UpdateWagonListBox()
    {
        ltbWagonList.Items.Clear();

        foreach (var wagon in train.GetWagons())
        {
            ltbWagonList.Items.Add("Wagon " + wagon.GetPoints());
        }
    }

    private void ltbWagonList_SelectedIndexChanged(object sender, EventArgs e)
    {
        MessageBox.Show(train.GetWagons()[ltbWagonList.SelectedIndex].GetPoints().ToString());
    }
}