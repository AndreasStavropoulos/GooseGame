using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TheGooseGame.Square;

namespace TheGooseGame
{
    public class Gameboard : IGameboard
    {
        private IDice _dice;
        private int _turn;
        private bool _gameOver;
        private int _squareToMoveTo { get; set; }

        public IList<IPlayer> Players { get; set; }

        public IList<ISquare> Squares { get; set; }

        public Gameboard(IList<IPlayer> players, IDice dice)
        {
            Players = players;
            _dice = dice;
            Squares = GenerateBoard();
        }

        public void GameLoop()
        {
            _turn++;
            foreach (IPlayer player in Players)
            {
                List<int> dices = _dice.Throw();
                int amountOfDices = dices.Sum();
                MessageBox.Show(amountOfDices.ToString());

                player.AmountOfDice = amountOfDices;

                // TODO: Turn per player
                if (_turn == 1)
                {
                    FirstTurnThrow(player, dices, amountOfDices);
                    break;
                }

                if (player.TurnsToStayStill != 0)
                {
                    player.TurnsToStayStill--;
                }
                else
                {
                    if (player.Position + amountOfDices > 63 && !player.IsInReverse)
                    {
                        _squareToMoveTo = 63 - ((player.Position + amountOfDices) % 63);
                    }
                    else
                    {
                        _squareToMoveTo = player.Position + amountOfDices;
                    }

                    ISquare square = GetSquare(_squareToMoveTo);
                    MovePlayer(player, amountOfDices, square);


                    //int squareToMoveTo = player.Position + amountOfDices;
                    //ISquare square = GetSquare(squareToMoveTo);
                    //MovePlayer(player, amountOfDices, square);

                }

                if (player.PlayerWon)
                {
                    _gameOver = true;
                    MessageBox.Show("You have won!");
                }

                //Update the screen here for next player
            }
        }

        public ISquare GetSquare(int id)
        {
            return Squares.FirstOrDefault(x => x.Id == id);
        }

        public void MovePlayer(IPlayer player, int diceAmount, ISquare square)
        {
            // TODO -> Move back when > 63
            player.Move(diceAmount);
            square.Action(player);
        }

        private void FirstTurnThrow(IPlayer player, IList<int> dices, int amountOfDices)
        {
            if (dices[0] == 4 && dices[1] == 5 || dices[0] == 5 && dices[1] == 4)
            {
                player.MovePlayerToPosition(player, 26);
                _squareToMoveTo = 26;
            }

            if (dices[0] == 6 && dices[1] == 3 || dices[0] == 3 && dices[1] == 6)
            {
                player.MovePlayerToPosition(player, 53);
                _squareToMoveTo = 53;
            }
            else
            {
                _squareToMoveTo = player.Position + amountOfDices;
                ISquare square = GetSquare(_squareToMoveTo);
                MovePlayer(player, amountOfDices, square);
            }

            
            
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
                new NormalSquare(30),
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