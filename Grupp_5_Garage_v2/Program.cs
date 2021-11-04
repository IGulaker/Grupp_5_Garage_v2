﻿using System;
using static System.Console;
using System.Collections.Generic;

namespace Grupp_5_Garage_v2
{
    class Program
    {
        private static GarageManager GarageManager;
        private static Dictionary<ChoiceID, string> Choices;
        private static ChoiceID CurrentChoice;

        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            Introduction();
            UISetup();
            GarageManager.Setup();
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
        }

        private static void UISetup()
        {
            GarageManager = new GarageManager();
            Choices = new Dictionary<ChoiceID, string>();
        }
    }
}
