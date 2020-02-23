using System;
using System.Linq;

namespace Mastermind
{
    public class TargetNumber
    {
        private int[] GeneratedNumber { get; }
        public const int SequenceLength = 4;
        public const int NumberMax = 6;
        public const int NumberMin = 1;

        private TargetNumber()
        {
            var r = new Random();

            GeneratedNumber = new int[SequenceLength];

            for (var i = 0; i < SequenceLength; i++)
            {
                GeneratedNumber[i] = r.Next(NumberMin, NumberMax + 1);
            }
        }

        public PositionFeedback CheckDigit(int position, int number)
        {
            if(position >= SequenceLength || position < 0 || number > NumberMax || number < NumberMin)
            {
                throw new ArgumentException("Invalid position " + position.ToString());
            }

            if(GeneratedNumber[position] == number)
            {
                return PositionFeedback.Correct;
            }
            else if (GeneratedNumber.Contains(number))
            {
                return PositionFeedback.Contains;
            }
            else
            {
                return PositionFeedback.None;
            }
        }

        public static TargetNumber CreateNew()
        {
            return new TargetNumber();
        }
    }
}