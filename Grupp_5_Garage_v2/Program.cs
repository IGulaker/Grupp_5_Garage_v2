using System;
using static System.Console;
using System.Collections.Generic;

namespace Grupp_5_Garage_v2
{
    class Program
    {
        private static GarageManager GarageManager;
        private static Dictionary<int, string> Choices;
        private static int CurrentChoice;

        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            Introduction();
            
        }

        private static void Introduction()
        {
            string tab = "\t\t\t";
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"{tab}    ____________________________________________________________             _______");
            WriteLine($"{tab}   |                  GRUPP FEMS GARAGEPROJEKT                  |           |   ____|");
            WriteLine($"{tab}   |                        SKAPAT AV                           |           |  |");
            WriteLine($"{tab}   |        AHMAD, ANDREAS, ISAC, MARIE, NESIM, VIKTOR          |           |  |___");
            WriteLine($"{tab}   |____________________________________________________________|           |___   |");
            WriteLine($"{tab}                                                                                |  |");
            WriteLine($"{tab}                                                                            ____|  |");
            WriteLine($"{tab}                                                                           |______/");
            ForegroundColor = ConsoleColor.White;
            ReadKey();
        }
    }
}
