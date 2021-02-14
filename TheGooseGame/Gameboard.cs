using System;
using System.Collections.Generic;
using System.Linq;
using TheGooseGame.Interfaces;
using TheGooseGame.Square;

namespace TheGooseGame
{
    public class Gameboard
    {
        private IList<IPlayer> players;
        private IList <ISquare> squares;
        private PlayerRepo playerRepo;
        private Dice dice;
       
       


        private int[] GooseSquares = new int[] { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 };

        private int Bridge = 6;

        private int Inn = 19;

        private int Well = 31;

        private int Maze = 42;

        private int Prison = 52;

        private int Death = 58;

        private int End = 63;

        public Gameboard(IList<IPlayer> players, IList <ISquare> squares, PlayerRepo playerRepo, Dice dice)
        {
            this.players = players;
            this.squares = squares;
            this.playerRepo = playerRepo;
            this.dice = dice;
        }

        public Gameboard()
        {
            //square = new MySquare();
        }

        //Dummy method to be expanded ...

        public void GameLoop()
        {
            players = playerRepo.ListOfPlayers(2);

            foreach (IPlayer player in players)
            {
                List<int>throws = dice.Throw();
                int diceAmount = throws.Sum();

                MovePlayer(player, diceAmount);
            }
            // choose the player
            // start turn
            //throw the dice
//            int diceAmount = 40;
            // check if its first turn of player => throw exceptions
            // check if player is ABLE to play (<> prison)
            
        }

        public void MovePlayer(IPlayer currentPlayer, int diceAmount)
        {
            currentPlayer.IsInReverse = CheckIfPlayerInReverse(currentPlayer, diceAmount);
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

            if (IsPlayerOnBridge(currentPlayer))
            {
                InBridge(currentPlayer);
            }

            if (IsPlayerInInn(currentPlayer))
            {
                //skip 1 turn
            }

            if (IsPlayerInWell(currentPlayer))
            {
                // If you come here, you need to wait until another player arrives. The one who was there first can continue playing
            }

            if (IsPlayerInMaze(currentPlayer))
            {
                InMaze(currentPlayer);
                //squares[currentPlayer.Position].Action(currentPlayer);
            }

            if (IsPlayerInPrison(currentPlayer))
            {
                // Skip 3 turns
            }

            if (IsPlayerDeath(currentPlayer))
            {

                InDeath(currentPlayer);
            }

            if (IsPlayerAtEnd(currentPlayer))
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

        private bool CheckIfPlayerInReverse(IPlayer player, int diceAmount)
        {
            if (player.Position + diceAmount > 63)
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

        private bool IsPlayerInWell(IPlayer player)
        {
            if (Inn == player.Position)
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

        private bool IsPlayerInPrison(IPlayer player)
        {
            if (Inn == player.Position)
            {
                return true;
            }
            return false;
        }

        private bool IsPlayerDeath(IPlayer player)
        {
            if (Death == player.Position)
            {
                return true;
            }
            return false;
        }

        private bool IsPlayerAtEnd(IPlayer player)
        {
            if (End == player.Position)
            {
                return true;
            }
            return false;
        }



        #region Special Squares Actions
        
        private void InMaze(IPlayer player) 
        {
            player.Position = 39;
        }

        private void InBridge (IPlayer player)
        {
            player.Position = 12;
        }

        private void InDeath(IPlayer player)
        {
            player.Position = 0;
        }

        #endregion Special Squares Actions

    }
}