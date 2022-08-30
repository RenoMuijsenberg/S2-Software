namespace ContainerVervoer
{
    public partial class Form1 : Form
    {
        private Dock dock = new();
        private Random rnd = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateShip_Click(object sender, EventArgs e)
        {
            dock.AddShip((int)nudShipLength.Value, (int)nudShipWidth.Value);

            UpdateListboxForShipsReady();
        }

        private void UpdateListboxForShipsReady()
        {
            ltbShipsReadyForLoad.Items.Clear();

            foreach (var ship in dock.Ships)
            {
                ltbShipsReadyForLoad.Items.Add(string.Format("Ship max weight: {0}, length: {1}, width: {2}", ship.MaxWeight, ship.MaxLength, ship.MaxWidth));
            }
        }

        private void btnSortContainers_Click(object sender, EventArgs e)
        {
            int shipIndex = ltbShipsReadyForLoad.SelectedIndex;

            //Add all containers to dock so they can be sorted.
            for (int i = 0; i < nudNormal.Value; i++)
            {
                dock.AddContainers(ContainerVervoer.Container.ContainerType.Normal, rnd.Next(4,31));
            }
            for (int i = 0; i < nudVal.Value; i++)
            {
                dock.AddContainers(ContainerVervoer.Container.ContainerType.Valuable, rnd.Next(4,31));   
            }
            for (int i = 0; i < nudCool.Value; i++)
            {
                dock.AddContainers(ContainerVervoer.Container.ContainerType.Cool, rnd.Next(4,31));
            }

            //Sort containers
            dock.Ships[shipIndex].SortContainers(dock.ContainersOnDock);

            //Update listbox with data of where containers are located
            ltbSortedContainers.Items.Clear();
            foreach (var container in dock.Ships[shipIndex].Containers)
            {
                ltbSortedContainers.Items.Add(string.Format("containers ({4}): X:{0}, Y:{1}, Z:{2}, Weight:{3}", container.XLocation, container.YLocation, container.ZLocation, container.Weight, container.Type.ToString()));
            }
        }
    }
}