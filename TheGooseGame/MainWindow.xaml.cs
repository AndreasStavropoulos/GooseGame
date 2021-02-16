using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TheGooseGame.Square;

namespace TheGooseGame
{
    public partial class MainWindow : Window
    {
        IDice dice;
        IPlayerRepo playerRepo;
        IList<int> dicesList;
        IList<IPlayer> playerList;
        Gameboard gameboard;
        
        public MainWindow()
        {
            InitializeComponent();
            dice = new Dice();
            playerRepo = new PlayerRepo();
            dicesList = new List<int>();
            playerList = new List<IPlayer>();
            gameboard = new Gameboard(playerList, dice);

            MyBoard.Children.Add(GenerateGrid(gameboard.Squares));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dicesList = dice.Throw();

        }

        private void ChoosePlayers_Click(object sender, RoutedEventArgs e)
        {
            playerList = playerRepo.ListOfPlayers(2);

            // Test to see if we can update colours at runtime
            gameboard.GetSquare(1).BackColor = Colors.DeepPink;

            var grid = MyBoard.Children[0] as Grid;

            
        }

        private Grid GenerateGrid(IList<ISquare> squares, int numOfCols = 8)
        {
            var dynamicGrid = new Grid();
            int amountOfRows = squares.Count() / numOfCols;

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
                ISquare[] squaresInRow = squares.Skip(i * numOfCols).Take(numOfCols).ToArray();

                for (int j = 0; j < grid.ColumnDefinitions.Count; j++)
                {
                    var square = squaresInRow[j];

                    var myLabel = new Label { Content = square.Id };
                    myLabel.BorderBrush = new SolidColorBrush(Colors.Black);
                    myLabel.BorderThickness = new Thickness(1, 1, 1, 1);

                    myLabel.Background = new SolidColorBrush(square.BackColor);

                    Grid.SetRow(myLabel, i);
                    Grid.SetColumn(myLabel, j);

                    grid.Children.Add(myLabel);
                }
            }

            return grid;
        }
    }
}