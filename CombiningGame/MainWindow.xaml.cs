using CombiningGame.Generators;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace CombiningGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TwoRandomOneToTenNumbersGenerator NumbersGenerator = new TwoRandomOneToTenNumbersGenerator();
        private readonly Stopwatch stopWatch = new Stopwatch();
        private bool isRunning;
        private int rightAnswersScore;
        private int wrongAnswersScore;
        private int rightAnswer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnStartGameButtonClicked(object sender, RoutedEventArgs e)
        {
            rightAnswersScore = 0;
            wrongAnswersScore = 0;
            stopWatch.Start();
            isRunning = true;
            NumbersGenerator.GenerateRandomNumbers();
            UpdateNumbers();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (isRunning)
                {
                    CheckAnswer(rightAnswer, AnswerInputTextBox.Text);
                    NumbersGenerator.GenerateRandomNumbers();
                    UpdateNumbers();
                    CheckStopWatch();
                }
            }
        }

        private void CheckStopWatch()
        {
            var stopWatchElapsedMilliseconds = stopWatch.ElapsedMilliseconds;
            var timeInput = int.Parse(TimeInputTextBox.Text) * 60 * 1000;

            if (stopWatchElapsedMilliseconds > timeInput)
            {
                isRunning = false;
                stopWatch.Stop();
                MessageBox.Show($"Right: {rightAnswersScore}\nWrong: {wrongAnswersScore}");
            }
        }

        private void CheckAnswer(int rightAnswer, string userAnswer)
        {
            if (rightAnswer.Equals(int.Parse(userAnswer)))
            {
                rightAnswersScore++;
            }
            else
            {
                wrongAnswersScore++;
            }
        }

        private void UpdateNumbers()
        {
            NumbersDisplayLabel.Content = $"{NumbersGenerator.FirstNumber} * {NumbersGenerator.SecondNumber} =";
            rightAnswer = NumbersGenerator.RightAnswer;
        }
    }
}
