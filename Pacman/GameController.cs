﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    class GameController
    {
        private GameForm gameView;
        private Game game;
        private Timer timer;

        public GameController(GameForm gameForm)
        {
            gameView = gameForm;
        }
         
        public Game CreateGame(int[,] map, GameConfiguration configuration)
        {
            game = new Game(map, configuration);
            return game;
        }

        public void StartGame()
        {
            game.Start();
            timer = new Timer();
            timer.Tick += UpdateGame;
            timer.Interval = 1000 / 60;
            timer.Start();
        }

        public void StopGame()
        {
            timer.Stop();
            game.Stop();
        }


        private void UpdateGame(object sender, EventArgs e)
        {
            if (game.IsActive)
            {
                game.Process();
                gameView.Update(game.ItemsToDisplay, game.Player);
            }
            else
            {
                StopGame();
            }
        }

        public void MovePlayer(Direction direction)
        {
            game.SetDirectionToPlayer(direction);
        }

        public void Attack()
        {
            game.Player.Attack();
        }

        public void OnGameOver(EventHandler handler)
        {
            game.GameOver += handler;
        }
    }
}
