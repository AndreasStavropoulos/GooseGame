using System.Collections.ObjectModel;
using System.Windows;
using TheGooseGame.Interfaces;
using TheGooseGame.Square;

namespace TheGooseGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MySquare Square;
        public ObservableCollection<ISquare> Squares;
        
        public MainWindow()
        {
            InitializeComponent();
            Squares = GenarateSquares();
            ListOfBlocks.ItemsSource = Squares;
        }

        private ObservableCollection<ISquare> GenarateSquares()
        {
            var result = new ObservableCollection<ISquare>
            {
               new NormalSquare(0),
               new NormalSquare(1),
               new NormalSquare(2),
               new NormalSquare(3),
               new Bridge()
            };

            return result;
        }



    }
}