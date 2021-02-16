using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TheGooseGame.Square;

namespace TheGooseGame
{
    public partial class MainWindow : Window
    {
        private IDice _dice;
        private IGameboard _gameboard;
        private IList<IPlayer> _playerList;
        private IPlayerRepo _playerRepo;

        public MainWindow()
        {
            InitializeComponent();
            _dice = new Dice();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _gameboard.GameLoop();
            UpdateScreen();
        }

        private void ChoosePlayers_Click(object sender, RoutedEventArgs e)
        {
            _playerRepo = new PlayerRepo();
            _playerList = _playerRepo.ListOfPlayers(2);
            _gameboard = new Gameboard(_playerList, _dice);
            UpdateScreen();
        }

        private Grid GenerateGrid(IList<ISquare> squares, int numOfCols = 8)
        {
            var dynamicGrid = new Grid();
            int amountOfRows = squares.Count / numOfCols;

            for (int i = 0; i < amountOfRows; i++)
            {
                var row = new RowDefinition { Height = new GridLength(80) };
                dynamicGrid.RowDefinitions.Add(row);
            }

            for (int i = 0; i < numOfCols; i++)
            {
                var column = new ColumnDefinition();
                dynamicGrid.ColumnDefinitions.Add(column);
            }

            dynamicGrid = SetGridParameters(dynamicGrid, squares, numOfCols);
            return dynamicGrid;
        }

        private Grid SetGridParameters(Grid grid, IList<ISquare> squares, int numOfCols)
        {
            for (int i = 0; i < grid.RowDefinitions.Count; i++)
            {
                // Generate a row X amount of times with Y amount of columns
                ISquare[] squaresInRow = squares.Skip(i * numOfCols).Take(numOfCols).ToArray();

                for (int j = 0; j < grid.ColumnDefinitions.Count; j++)
                {
                    var cellPanel = new Grid();

                    ISquare square = squaresInRow[j];
                    cellPanel.Children.Add(GenerateLabel(square));

                    // Add players on field if any are in List
                    if (square.PlayersOnSquare.Any())
                    {
                        var playerPanel = GeneratePlayerIcon(square.PlayersOnSquare);
                        cellPanel.Children.Add(playerPanel);
                    }

                    Grid.SetRow(cellPanel, i);
                    Grid.SetColumn(cellPanel, j);
                    grid.Children.Add(cellPanel);
                }
            }

            return grid;
        }

        private StackPanel GeneratePlayerIcon(IList<IPlayer> players)
        {
            var playerPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };

            foreach (IPlayer player in players)
            {
                var pawnImage = new Image
                {
                    Source = new BitmapImage(new Uri(player.Pawn)),
                    Height = 50,
                    Width = 50,
                };

                playerPanel.Children.Add(pawnImage);
            }

            return playerPanel;
        }

        private Label GenerateLabel(ISquare square)
        {
            return new Label
            {
                Content = square.Id,
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(1, 1, 1, 1),
                Background = new SolidColorBrush(square.BackColor)
            };
        }

        // BAD PRACTICE !!! Everything is redrawn every call
        private void UpdateScreen()
        {
            if (MyBoard.Children.Count > 0)
            {
                MyBoard.Children.RemoveAt(0);
            }

            MyBoard.Children.Add(GenerateGrid(_gameboard.Squares));
        }
    }
}