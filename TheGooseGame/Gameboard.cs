using System;
using System.Collections.Generic;
using System.Text;
using TheGooseGame.Intefaces;
using TheGooseGame.Square;

namespace TheGooseGame
{
    public class Gameboard
    {
        IList<IPlayer> players;
        ISquare square;
        
        int[] GooseSquares = new int[] {5,9,14,18,23,27,32,36,41,45,50,54,59};

        int Maze = 42;
        

        public Gameboard(IList<IPlayer> players)
        {
            this.players = players;
        }

        public Gameboard()
        {

        }

        //Dummy method to be expanded ...
        
        public void GameLoop()
        {
            var currentPlayer = players[0];
            //foreach (IPlayer player in players)
            int diceAmount = 9;
            MovePlayer(currentPlayer, diceAmount);
        }

        public void MovePlayer(IPlayer currentPlayer, int diceAmount)
        {
            currentPlayer.Move(diceAmount);
            //int turn = 0;

            if (IsPlayerInGoose(currentPlayer))
            {
                //Reflection a method that calls itself
                MovePlayer(currentPlayer, diceAmount);
            }
            
            else if (currentPlayer.IsInMaze)
            {
                //if in 42 go to 39
                square.Action(currentPlayer);
            }
        }

        private bool IsPlayerInGoose(IPlayer player)
        {
            if (true) //This we have to make working 
            {
                return true;
            }
            return false;
        }
    }
}
