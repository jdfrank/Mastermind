using System;
using System.Linq;

namespace Mastermind
{
    public class TargetNumber
    {
        private int[] generatedNumber;
        private int sequenceLength = 4;
        private int numberMax = 6;
        private int numberMin = 1;

        public TargetNumber(int sLength, int nMax, int nMin)
        {
            sequenceLength = sLength;
            numberMax = nMax;
            numberMin = nMin;

            var r = new Random();

            generatedNumber = new int[sequenceLength];

            for (var i = 0; i < sequenceLength; i++)
            {
                generatedNumber[i] = r.Next(numberMin, numberMax + 1);
            }
        }

        public PositionFeedback CheckDigit(int position, int number)
        {
            if (position >= sequenceLength || position < 0 || number > numberMax || number < numberMin)
            {
                throw new ArgumentException("Invalid position " + position.ToString());
            }

            if (generatedNumber[position] == number)
            {
                return PositionFeedback.Correct;
            }
            else if (generatedNumber.Contains(number))
            {
                return PositionFeedback.Contains;
            }
            else
            {
                return PositionFeedback.None;
            }
        }
    }
}