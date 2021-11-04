using System;
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
            InputLoop();
        }


        private static void InputLoop()
        {
            if (CurrentChoice > 0) Clear();
            AskUserWhatTheyWantToDo();
            ListChoices();
            ConsoleKeyInfo key = RecieveUserChoiceSelection();
        }

        private static void ListChoices()
        {
            int index = 1;
            if (CurrentChoice == 0)
            {
                for (int i = 1; i <= 2; i++)
                {
                    WriteLine("{0}. {1}", index, Choices[(ChoiceID)i]);
                    index++;
                }
            }
            else
            {
                for (int i = 3; i <= Choices.Count; i++)
                {
                    WriteLine("{0}. {1}", index, Choices[(ChoiceID)i]);
                    index++;
                }
            }
        }

        private static void AskUserWhatTheyWantToDo()
        {
            WriteLine("Vad vill du göra?");
            WriteLine("-----------------");
        }

        private static ConsoleKeyInfo RecieveUserChoiceSelection()
        {
            return ReadKey();
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
            CurrentChoice = 0;

            Choices.Add(ChoiceID.CreateGarage, "Skapa ett nytt garage.");
            Choices.Add(ChoiceID.LoadGarage, "Ladda ett sparat garage.");
            Choices.Add(ChoiceID.AddVehicle, "Parkera ett fordon.");
            Choices.Add(ChoiceID.RemoveVehicle, "Hämta ut ett fordon.");
            Choices.Add(ChoiceID.ListAllVehicles, "Visa alla fordon som står i garaget.");
        }
    }
}
