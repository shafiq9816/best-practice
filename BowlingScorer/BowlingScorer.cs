using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRMA.BowlingScorer.Core;
using System.Collections;

namespace NRMA.BowlingScorer.BowlingScorer
{
    class BowlingScorer
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter series of number of pins down in frames serperated by space....");
            string input = string.Empty;
            int val = 0;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Spacebar || int.TryParse(key.KeyChar.ToString(), out val))
                {
                    Console.Write(key.KeyChar);
                    input += key.KeyChar;
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter );

            var engine = new ScoreEngine();
            Console.WriteLine();
            try
            {
                Console.WriteLine("Final Score: " + engine.Score(input));
            }
            catch (Exception ex)
            {   
                // TODO: Log error message in log file. Show user friendly message instead of technical message to user.
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
