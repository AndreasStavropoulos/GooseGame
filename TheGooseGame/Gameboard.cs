using System;
using System.Collections.Generic;
using System.Linq;
using TheGooseGame.Intefaces;
using TheGooseGame.Square;

namespace TheGooseGame
{
    public class Gameboard
    {
        private IList<IPlayer> _players;
        private IList <ISquare> _squares;
        private ISquare _square = new MySquare();
        private PlayerRepo _playerRepo = new PlayerRepo();
        private Dice _dice = new Dice(); //Here

        private int[] GooseSquares = new int[] { 5, 9, 14, 18, 23, 27, 32, 36, 41, 45, 50, 54, 59 };

        private int Bridge = 6;

        private int Inn = 19;

        private int Well = 31;

        private int Maze = 42;

        private int Prison = 52;

        private int Death = 58;

        private int End = 63;

        public Gameboard(IList<IPlayer> players, IList <ISquare> squares, PlayerRepo playerRepo, Dice dice, ISquare square)
        {
            _players = players;
            _squares = squares;
            _playerRepo = playerRepo;
            _dice = dice;
            _square = square;
        }

        public Gameboard()
        {

        }

        public void GameLoop()
        {
            _players = _playerRepo.ListOfPlayers(4);
            int turn = 0;
            bool gameOver = false;
            while (!gameOver)
            {
                turn++;
                foreach (IPlayer player in _players)
                {
                    List<int> dices = _dice.Throw();
                    //int amountOfDices = dice.SumOfTwoDices(dices);
                    int amountOfDices = dices.Sum();

                    if (turn == 1)
                    {
                        FirstTurnThrow(player, dices);
                        break;
                    }
                    if (player.TurnsToStayStill != 0)
                    {
                        player.TurnsToStayStill--;
                    }
                    else
                    {
                        MovePlayer(player, amountOfDices);
                    }

                    if (player.PlayerWon)
                    {
                        gameOver = true;
                        //Code for End Game
                    }
                }
            }
        }

        public void MovePlayer(IPlayer player, int diceAmount)
        {
            player.Move(diceAmount);

            if (IsPlayerInGoose(player))
            {
                //Reflection -- a method that calls itself
                MovePlayer(player, diceAmount);
            }

            if (IsPlayerOnBridge(player))
            {
                //InBridge(player);

                _square.Action(player);
                var x = player.Position;
            }

            if (IsPlayerInMaze(player))
            {
                InMaze(player);
            }

            if (IsPlayerDeath(player))
            {

                InDeath(player);
            }

            if (IsPlayerInPrison(player))
            {
                player.TurnsToStayStill = 3;
            }

            if (IsPlayerInInn(player))
            {
                player.TurnsToStayStill = 1;
            }

            if (IsPlayerInWell(player))
            {
                // If you are in well, you need to wait until another player arrives. 
                // The one who was there first can continue 
            }

            if (IsPlayerAtEnd(player))
            {
                player.PlayerWon = true;
            }
        }

        private void FirstTurnThrow(IPlayer player, List<int> dices)
        {
            
            if (dices[0]==4 && dices[1]==5 || dices[0] == 5 && dices[1] == 4)
            {
                player.Position = 26;
            }
            if (dices[0] == 6 && dices[1] == 3 || dices[0] == 3 && dices[1] == 6)
            {
                player.Position = 53;
            }
            //else
            //{
            //    //MovePlayer(player, (dices[0]+dices[1]));
            //}
        }

        #region IsPlayerInASpecialSquare

        public bool IsPlayerInGoose(IPlayer player)
        {
            if (GooseSquares.Contains(player.Position))
            {
                player.IsOnGoose = true;
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
        private bool IsPlayerInMaze(IPlayer player)
        {
            if (Maze == player.Position)
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

        private bool IsPlayerInPrison(IPlayer player)
        {
            if (player.Position == Prison)
            {
                return true;
            }
            return false;
        }

        private bool IsPlayerInInn(IPlayer player)
        {
            if (player.Position== Inn)
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

        private bool IsPlayerAtEnd(IPlayer player)
        {
            if (player.Position == End)
            {
                return true;
            }
            return false;
        }

        #endregion 

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