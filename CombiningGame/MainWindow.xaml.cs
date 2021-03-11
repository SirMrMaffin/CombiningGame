using CombiningGame.Managers;
using System.Windows;
using System.Windows.Input;

namespace CombiningGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameManager gameManager;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnStartGameButtonClicked(object sender, RoutedEventArgs e)
        {
            gameManager = new GameManager(TimeInputTextBox.Text, NumbersDisplayLabel);
            gameManager.StartGame();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                gameManager.ProcessAnswer(AnswerInputTextBox.Text);
            }
        }
    }
}
