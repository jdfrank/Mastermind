using System;

namespace Mastermind
{
    public class Program
    {
        static void Main(string[] args)
        {
            var g = new Game();

            do
            {
                if (g.RemainingAttempts == Game.Attempts)
                {
                    Console.Clear();
                    g.GetIntroText().ForEach(x => Console.WriteLine(x));
                }

                var guess = Console.ReadLine();

                var msgs = g.TakeTurn(guess);

                msgs.ForEach(x => Console.WriteLine(x));

                if (g.IsWon || g.RemainingAttempts == 0)
                {
                    Console.WriteLine("Press Y to play again, or any other key to exit.");

                    var yn = Console.ReadLine();

                    if (yn == "Y" || yn == "y")
                    {
                        g = new Game();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }

                }
            }
            while (true);
        }
    }
}
