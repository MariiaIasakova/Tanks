
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Pacman.Objects;
using Pacman.Objects.Items.MoveItems;

namespace Pacman
{
    public partial class GameForm : Form
    {
        Graphics canvas;
        GameConfiguration config;
        GameController controller;

        public GameForm()
        {
            InitializeComponent();
            config = new GameConfiguration(5, 1, Speed.High);
            this.PreviewKeyDown += KeyPressDown;
            DoubleBuffered = false;
        }

        private void GameForm_Load(object sender, System.EventArgs e)
        {
            BegginerForm fbegin = new BegginerForm();
            if (fbegin.ShowDialog() == DialogResult.OK)
            {
                config.Ghosts = fbegin.Ghosts;
                config.Apples = fbegin.Apples;
                config.Speed = fbegin.Speed;
            }
            var map = ReadMap();
            this.Width = map.GetLength(0) * Point.CellSize + 16;
            this.Height = map.GetLength(1) * Point.CellSize + 60;
            canvas = ctlPanel.CreateGraphics();
            controller = new GameController(this);
            var game = controller.CreateGame(map, config);
            controller.OnGameOver(GameOverHandler);
            controller.StartGame();
        }

        public void Update(IEnumerable<Item> map, Player player)
        {
            foreach (var item in map)
            {
                if (item.IsDirty)
                {
                    canvas.DrawImage(Properties.Resources.empty, item.OldPosition.AbsX, item.OldPosition.AbsY, Point.CellSize, Point.CellSize);
                    canvas.DrawImage(item.Picture, item.Position.AbsX, item.Position.AbsY, Point.CellSize, Point.CellSize);
                    item.IsDirty = false;
                }
            }
            lblValueY.Text = player.Position.AbsY.ToString();
            lblValueX.Text = player.Position.AbsX.ToString();
            lblValueScore.Text = player.Score.ToString();
        }

        private void KeyPressDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Right:
                case Keys.Up:
                case Keys.Left:
                    HandlePlayerMove(e.KeyCode);
                    break;
                case Keys.Space:
                    HandlePlayerAtеack();
                    break;
            }
        }

        private void HandlePlayerMove(Keys key)
        {
            Direction direction = Direction.Up;
            switch (key)
            {
                case Keys.Down:
                    direction = Direction.Down;
                    break;
                case Keys.Right:
                    direction = Direction.Right;
                    break;
                case Keys.Up:
                    direction = Direction.Up;
                    break;
                case Keys.Left:
                    direction = Direction.Left;
                    break;
            }
            controller.MovePlayer(direction);
        }

        private void HandlePlayerAtеack()
        {
            controller.Attack();
        }

        private int[,] ReadMap()
        {
            var readed = Properties.Resources.Map1.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var width = readed[0].Length;
            var height = readed.Length;
            var map = new int[width, height];
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    map[j, i] = int.Parse(readed[i][j].ToString());
                }
            }
            return map;
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.StopGame();
        }

        private void GameOverHandler(object sender, EventArgs e)
        {
            // show message mox with yes-no buttons "Game Over. Do you want to continue?"
        }
    }
}
