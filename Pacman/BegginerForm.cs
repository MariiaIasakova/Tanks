using System;
using System.Windows.Forms;

namespace Pacman
{
    public partial class BegginerForm : Form
    {
        public int Ghosts { get; private set; }
        public int Apples { get; private set; }
        public Speed Speed { get; private set; }
        public BegginerForm()
        {
            InitializeComponent();
            ctlGhost.SelectedIndex = 0;
            ctlApples.SelectedIndex = 0;
            ctlSpeed.DataSource = Enum.GetValues(typeof(Speed));
            ctlSpeed.SelectedIndex = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Ghosts = int.Parse(ctlGhost.SelectedItem.ToString());
            Apples = int.Parse(ctlApples.SelectedItem.ToString());
            Speed = (Speed)ctlSpeed.SelectedValue;
            //GameConfiguration config = new GameConfiguration(ghosts, apples, speed);
            //GameForm game = new GameForm(config);
            //game.Show();

        }
    }
}
