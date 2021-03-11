using CombiningGame.Generators;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace CombiningGame.Managers
{
    public class GameManager
    {
        private readonly RandomNumbersGenerator numbersGenerator = new RandomNumbersGenerator(1, 10);
        private readonly Stopwatch stopWatch = new Stopwatch();

        private readonly Label numsLabel;
        private readonly int timeInput = 0;
        
        private int rightAnswersScore = 0;
        private int wrongAnswersScore = 0;

        public GameManager(string timeString, Label numsLabel)
        {
            timeInput = int.Parse(timeString) * 60 * 1000;
            this.numsLabel = numsLabel;
        }

        public void StartGame()
        {
            rightAnswersScore = 0;
            wrongAnswersScore = 0;
            stopWatch.Start();
            numbersGenerator.Generate();
            UpdateNumbers();
        }

        public void ProcessAnswer(string answer)
        {
            if (stopWatch.IsRunning)
            {
                CheckAnswer(answer);
                numbersGenerator.Generate();
                UpdateNumbers();
                CheckStopWatch();
            }
        }

        private void CheckStopWatch()
        {
            var stopWatchElapsedMilliseconds = stopWatch.ElapsedMilliseconds;

            if (stopWatchElapsedMilliseconds > timeInput)
            {
                stopWatch.Stop();
                MessageBox.Show($"Game over!\nRight: {rightAnswersScore}\nWrong: {wrongAnswersScore}");
            }
        }

        private void CheckAnswer(string userAnswer)
        {
            if (numbersGenerator.RightAnswer.Equals(int.Parse(userAnswer)))
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
            numsLabel.Content = $"{numbersGenerator.FirstNumber} * {numbersGenerator.SecondNumber} =";
        }
    }
}
