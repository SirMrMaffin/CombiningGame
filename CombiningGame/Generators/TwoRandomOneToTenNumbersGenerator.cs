using System;
using System.Windows.Controls;

namespace CombiningGame.Generators
{
    class TwoRandomOneToTenNumbersGenerator
    {
        public int RightAnswer;
        public int firstNumber;
        public int secondNumber;

        public void GenerateRandomNumbers()
        {
            var random = new Random();
            firstNumber = random.Next(1, 10);
            secondNumber = random.Next(1, 10);
            RightAnswer = firstNumber * secondNumber;
        }
    }
}
