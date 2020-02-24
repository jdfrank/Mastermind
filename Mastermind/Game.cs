using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mastermind
{
    public class Game
    {
        public const int Attempts = 10;
        public const int NumberMax = 6;
        public const int NumberMin = 1;
        public const int SequenceLength = 4;

        public int RemainingAttempts { get; private set; }
        public bool IsWon { get; private set;}

        private List<PositionFeedback> currentResults;
        private TargetNumber targetNumber;
        private List<string> messages;


        public Game()
        {
            RemainingAttempts = Attempts;
            IsWon = false;
            currentResults = new List<PositionFeedback>();
            targetNumber = new TargetNumber(SequenceLength, NumberMax, NumberMin);
            messages = new List<string>();
        }

        public List<string> TakeTurn(string guess)
        {
            RemainingAttempts--;

            currentResults.Clear();
            messages.Clear();

            messages.AddRange(ValidateGuess(guess));

            if (messages.Count() != 0)
            {
                messages.Add("You lose a turn!");

                if (RemainingAttempts == 0)
                {
                    messages.Add("You are not the Mastermind. Sorry.");
                }
                else
                {
                    messages.Add(string.Format("You have {0} remaining!", RemainingAttempts));
                }
            }
            else
            {
                for (var i = 0; i < guess.Length; i++)
                {
                    currentResults.Add(targetNumber.CheckDigit(i, int.Parse(guess[i].ToString())));
                }

                if (currentResults.All(x => x == PositionFeedback.Correct))
                {
                    IsWon = true;
                    messages.Add("Correct! You are the Mastermind!");

                }
                else
                {
                    currentResults.Sort(); // randomizes enough

                    messages.Add(DisplayResults(currentResults));

                    if(RemainingAttempts == 0)
                    {
                        messages.Add("You are not the Mastermind. Sorry.");
                    }
                    else
                    {
                        messages.Add(string.Format("Not there yet, you have {0} more chances.", RemainingAttempts));
                    }
                }
            }

            return messages;
        }

        private List<string> ValidateGuess(string guess)
        {
            var l = new List<string>();

            if (string.IsNullOrWhiteSpace(guess))
            {
                l.Add("Nothing entered.");
            }
            else if (guess.Length > 4)
            {
              l.Add("Input is too long, 4 numbers only!");
            }
            else if (guess.Length < 4)
            {
                l.Add("Input is too short, must be 4 numbers!");
            }
            else if (guess.Any(x => x < '1' || x > '6'))
            {
                l.Add("Numbers between 1 and 6 only!");
            }

            return l;
        }

        private string DisplayResults(List<PositionFeedback> results)
        {
            var sb = new StringBuilder();
            foreach (var r in results)
            {
                if (r == PositionFeedback.Contains)
                {
                    sb.Append("-");
                }
                else if (r == PositionFeedback.Correct)
                {
                    sb.Append("+");
                }
            }
            return sb.ToString();
        }

        public List<string> GetIntroText()
        {
            return new List<string>() { "Welcome To Mastermind!", "Do you have what it takes to break the code?", "Enter 4 digits, if you dare!" };
        }
    }
}
