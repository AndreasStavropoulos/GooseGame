using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TheGooseGame.Square;

namespace TheGooseGame
{
    public partial class MainWindow : Window
    {
        Dice dice;
        PlayerRepo playerRepo;
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dicesList = dice.Throw();

        }

        private void ChoosePlayers_Click(object sender, RoutedEventArgs e)
        {
            playerList = playerRepo.ListOfPlayers(2);
        }
    }
}