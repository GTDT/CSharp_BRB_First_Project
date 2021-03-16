// specifying modules that the script is using...
using System.Runtime.InteropServices;
using System.Threading;
using System;


namespace BrbFromPyToCS
{
    class BRB_SCRIPT_CLASS
    {
        static void ContinueYN()
        {
            try
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Do you want to run this application again?\n | Y or n | >> ");
                char ContinueCondition = Convert.ToChar(Console.ReadLine().ToUpper());
                if (ContinueCondition == 'Y')
                {
                    Console.Clear();
                    Calculating();
                }
            }
            catch
            {
                Console.Clear();
                ContinueYN();
            }
        }

        static void Calculating()
        {
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                Console.Write("\nPlease provide your name:\n >> ");
                string Name = Console.ReadLine().ToUpper();

                Console.Write("\nPlease provide a time count as a integer (1, 2, 3...):\n >> ");
                int TimeCount = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nPlease provide time type:\n  s = seconds\n  m = minutes\n  h = hours\n  d = days:\n >> ");
                char TimeType = Convert.ToChar(Console.ReadLine().ToLower());

                int TimeTypeMultiplyer = 0;

                if (TimeType == 's')
                {
                    TimeTypeMultiplyer = 1;
                }
                else if (TimeType == 'm')
                {
                    TimeTypeMultiplyer = 60;
                }
                else if (TimeType == 'h')
                {
                    TimeTypeMultiplyer = 3600;
                }
                else if (TimeType == 'd')
                {
                    TimeTypeMultiplyer = 86400;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\n     Option does not exist. Please try again!!     \n");
                    Calculating();
                }

                // {Name} is BRB in {T}s - {Time} {TYPE} or {Time*M} Seconds")

                int LoopTimes = TimeCount * TimeTypeMultiplyer;
                while (LoopTimes >= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Name + " Will be BRB in " + TimeCount + TimeType + "\nTime Left: " + LoopTimes + "s");
                    Thread.Sleep(1000);

                    // If loop times is less or equal to 0
                    if (LoopTimes <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n\n    " + Name + " IS BACK    \n\n");
                    }
                    LoopTimes -= 1;
                }
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n     You typed something wrong...\n     Try again...\n");
                Calculating();
            }

            ContinueYN();
        }
        public static void Main(String[] args)
        {
            ConsoleHelper.SetConsoleFont(5);
            Calculating();
        }
    }
}