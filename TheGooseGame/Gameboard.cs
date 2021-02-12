using System;
using System.Collections.Generic;
using System.Linq;
using TheGooseGame.Intefaces;
using TheGooseGame.Square;

namespace TheGooseGame
{
    public class Gameboard
    {
        private IList<IPlayer> players;
        private IList <ISquare> squares;

        private int[] GooseSquares = new int[] { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 };

        private int Bridge = 6;

        private int Inn = 19;

        private int Maze = 42;

        public Gameboard(IList<IPlayer> players, IList <ISquare> squares)
        {
            this.players = players;
            this.squares = squares;
        }

        public Gameboard()
        {
            //square = new MySquare();
        }

        //Dummy method to be expanded ...

        public void GameLoop()
        {
            var currentPlayer = players[0];
            //foreach (IPlayer player in players)
            int diceAmount = 40;
            MovePlayer(currentPlayer, diceAmount);
        }

        public void MovePlayer(IPlayer currentPlayer, int diceAmount)
        {
            currentPlayer.IsInReverse = IsPlayerInReverse(currentPlayer, diceAmount);
            currentPlayer.Move(diceAmount);
            //int turn = 0;


            if (currentPlayer.IsInReverse)
            {
                if (IsPlayerInGoose(currentPlayer))
                {
                    currentPlayer.Position -= diceAmount;
                    // TODO: this doesnt work = need to find 
                }
            }

            if (IsPlayerInGoose(currentPlayer))
            {
                //Reflection a method that calls itself
                MovePlayer(currentPlayer, diceAmount);
            }

            if (IsPlayerInMaze(currentPlayer))
            {
                InMaze(currentPlayer);
                //squares[currentPlayer.Position].Action(currentPlayer);
            }

            if (IsPlayerOnBridge(currentPlayer))
            {

            }

            if (IsPlayerInInn(currentPlayer))
            {

            }

        }

        public bool IsPlayerInGoose(IPlayer player)
        {
            if (GooseSquares.Contains(player.Position))
            {
                player.IsOnGoose = true;
                return true;
            }
            return false;
        }

        private bool IsPlayerInReverse(IPlayer player, int diceAmount)
        {
            if (player.Position + diceAmount > 63)
            {
                return true;
            }
            return false;
        }

        private bool IsPlayerInMaze(IPlayer player)
        {
            if (Maze == player.Position)
            {
                return true;
            }
            return false;
        }

        private bool IsPlayerOnBridge(IPlayer player)
        {
            if (Bridge == player.Position)
            {
                return true;
            }
            return false;
        }


        private bool IsPlayerInInn(IPlayer player)
        {
            if (Inn == player.Position)
            {
                return true;
            }
            return false;
        }


        #region Special Squears Actions

        private void InMaze(IPlayer player)
        {
            player.Position = 39;
        }


        #endregion Special Squears Actions
    }
}