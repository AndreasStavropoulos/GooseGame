using System.Collections.Generic;
using System.Linq;
using TheGooseGame.Square;

namespace TheGooseGame
{
    public class Gameboard
    {
        private IList<IPlayer> _players;
        private IList<ISquare> _squares;
        private Dice _dice; //Here

        public Gameboard(IList<IPlayer> players, Dice dice)
        {
            _players = players;
            _squares = GenerateBoard();
            _dice = dice;
        }

        public void GameLoop()
        {
          
            int turn = 0;
            bool gameOver = false;
            while (!gameOver)
            {
                turn++;
                foreach (IPlayer player in _players)
                {
                    List<int> dices = _dice.Throw();
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
                        int squareToMoveTo = player.Position + amountOfDices;
                        ISquare square = GetSquare(squareToMoveTo);
                        MovePlayer(player, amountOfDices, square);
                    }

                    if (player.PlayerWon)
                    {
                        gameOver = true;
                        //Code for End Game
                    }
                }
            }
        }

        private ISquare GetSquare(int id)
        {
            return _squares.FirstOrDefault(x => x.Id == id);
        }

        public void MovePlayer(IPlayer player, int diceAmount, ISquare square)
        {
            player.Move(diceAmount);
            square.Action(player);
        }


        //public void MovePlayer(IPlayer player, int diceAmount)
        //{
        //    player.Move(diceAmount);

        //    if (IsPlayerInGoose(player))
        //    {
        //        //Reflection -- a method that calls itself
        //        MovePlayer(player, diceAmount);
        //    }

        //    if (IsPlayerOnBridge(player))
        //    {
        //        //InBridge(player);
        //        var xa = player.Position;
        //        _square.Action(player);
        //        var x = player.Position;
        //    }

        //    if (IsPlayerInMaze(player))
        //    {
        //        //InMaze(player);
        //    }

        //    if (IsPlayerDeath(player))
        //    {

        //        InDeath(player);
        //    }

        //    if (IsPlayerInPrison(player))
        //    {
        //        player.TurnsToStayStill = 3;
        //    }

        //    if (IsPlayerInInn(player))
        //    {
        //        player.TurnsToStayStill = 1;
        //    }

        //    if (IsPlayerInWell(player))
        //    {
        //        // If you are in well, you need to wait until another player arrives. 
        //        // The one who was there first can continue 
        //    }

        //    if (IsPlayerAtEnd(player))
        //    {
        //        player.PlayerWon = true;
        //    }
        //}

        private void FirstTurnThrow(IPlayer player, IList<int> dices)
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

        private IList<ISquare> GenerateBoard()
        {
            var list = new List<ISquare>
            {
                new NormalSquare(0),
                new NormalSquare(1),
                new NormalSquare(2),
                new NormalSquare(3),
                new NormalSquare(4),
                new Goose(5),
                new Bridge(6),
                new NormalSquare(7),
                new NormalSquare(8),
                new Goose(9),
                new NormalSquare(10),
                new NormalSquare(11),
                new NormalSquare(12),
                new NormalSquare(13),
                new Goose(14),
                new NormalSquare(15),
                new NormalSquare(16),
                new NormalSquare(17),
                new Goose(18),
                new Inn(19),
                new NormalSquare(20),
                new NormalSquare(21),
                new NormalSquare(22),
                new Goose(23),
                new NormalSquare(24),
                new NormalSquare(25),
                new NormalSquare(26),
                new Goose(27),
                new NormalSquare(28),
                new NormalSquare(29),
                new NormalSquare(20),
                new Well(31),
                new Goose(32),
                new NormalSquare(33),
                new NormalSquare(34),
                new NormalSquare(35),
                new Goose(36),
                new NormalSquare(37),
                new NormalSquare(38),
                new NormalSquare(39),
                new NormalSquare(40),
                new Goose(41),
                new Maze(42),
                new NormalSquare(43),
                new NormalSquare(44),
                new Goose(45),
                new NormalSquare(46),
                new NormalSquare(47),
                new NormalSquare(48),
                new NormalSquare(49),
                new Goose(50),
                new NormalSquare(51),
                new Prison(52),
                new NormalSquare(53),
                new NormalSquare(54),
                new NormalSquare(55),
                new NormalSquare(56),
                new NormalSquare(57),
                new Death(58),
                new Goose(59),
                new NormalSquare(60),
                new NormalSquare(61),
                new NormalSquare(62),
                new End(63),
            };


            return list;
        }
    }
}