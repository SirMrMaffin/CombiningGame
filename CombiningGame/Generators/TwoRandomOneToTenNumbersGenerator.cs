using System;
using System.Windows.Controls;

namespace CombiningGame.Generators
{
    class TwoRandomOneToTenNumbersGenerator
    {

        public int RightAnswer { get; set; }
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        private readonly int minNum = 1;
        private readonly int maxNum = 10;

        public void GenerateRandomNumbers()
        {
            var random = new Random();
            FirstNumber = random.Next(minNum, maxNum);
            SecondNumber = random.Next(minNum, maxNum);
            RightAnswer = FirstNumber * SecondNumber;
        }
    }
}
