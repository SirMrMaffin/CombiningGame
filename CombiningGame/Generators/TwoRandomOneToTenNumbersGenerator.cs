using System;

namespace CombiningGame.Generators
{
    public class TwoRandomOneToTenNumbersGenerator
    {

        public int RightAnswer { get => FirstNumber * SecondNumber; }
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        private readonly int _minNum;
        private readonly int _maxNum;

        public TwoRandomOneToTenNumbersGenerator(int minNum, int maxNum)
        {
            _minNum = minNum;
            _maxNum = maxNum;
        }

        public void GenerateRandomNumbers()
        {
            var random = new Random();
            FirstNumber = random.Next(_minNum, _maxNum);
            SecondNumber = random.Next(_minNum, _maxNum);
        }
    }
}
