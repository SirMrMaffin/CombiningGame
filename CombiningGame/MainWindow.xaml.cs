using System;
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
        private int RightAnswersScore;
        private int WrongAnswersScore;
        private int RightAnswer;
        private readonly Stopwatch StopWatch = new Stopwatch();
        private bool running;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnStartGameButtonClicked(object sender, RoutedEventArgs e)
        {
            RightAnswersScore = 0;
            WrongAnswersScore = 0;
            StopWatch.Start();
            running = true;
        }

        private void CheckStopWatch()
        {
            var stopWatchElapsedMilliseconds = StopWatch.ElapsedMilliseconds;
            var timeInput = int.Parse(TimeInputTextBox.Text) * 60 * 1000;

            if (stopWatchElapsedMilliseconds > timeInput)
            {
                running = false;
                StopWatch.Stop();
                MessageBox.Show($"Right: {RightAnswersScore}\nWrong: {WrongAnswersScore}");
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (running == true)
                {
                    CheckAnswer(RightAnswer, AnswerInputTextBox.Text);
                    GenerateRandomNumbers();
                    CheckStopWatch();
                }
            }
        }

        private void GenerateRandomNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(1, 10);
            var secondNumber = random.Next(1, 10);
            NumbersDisplayLabel.Content = $"{firstNumber} * {secondNumber} =";
            RightAnswer = firstNumber * secondNumber;
        }

        private void CheckAnswer(int rightAnswer, string userAnswer)
        {
            if (rightAnswer.Equals(int.Parse(userAnswer)))
            {
                RightAnswersScore++;
            }
            else
            {
                WrongAnswersScore++;
            }
        }
    }
}
