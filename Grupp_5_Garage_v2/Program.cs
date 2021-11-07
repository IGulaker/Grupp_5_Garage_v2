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
            while (true)
            {
                if (CurrentChoice > 0) Clear();
                AskUserWhatTheyWantToDo();
                ListChoices();
                ConsoleKeyInfo key = RecieveUserChoiceSelection();
                HandleUserInput(key);
            }
        }

        private static void HandleUserInput(ConsoleKeyInfo key)
        {
            if (char.IsDigit(key.KeyChar))
            {
                CurrentChoice = (ChoiceID)key.KeyChar - 48;
                WriteLine("");
                string error = "";
                switch (CurrentChoice)
                {
                    case ChoiceID.CreateGarage:
                        string sendBus = "TRO623_Mörkblå_4_36_1_Stora Bussbyggarna_1997_X-Trafik_N";
                        WriteLine(GarageManager.ReadUIInfo(ChoiceID.CreateGarage, sendBus, out error));
                        break;
                    case ChoiceID.LoadGarage:
                        //WriteLine("Skriv Färg: ");
                        //string search = ReadLine();
                        //WriteLine(GarageManager.SearchByColor(search));
                        //ReadKey();
                        string sendTruck = "RIT691_Mörkblå_4_2_3_Scania_2001_N_J";
                        WriteLine(GarageManager.ReadUIInfo(ChoiceID.LoadGarage, sendTruck, out error));
                        break;
                    case ChoiceID.AddVehicle:
                        string sendthis = "ABC123_Röd_5_3_2_Hemma AB_1993_4_J";

                        WriteLine(GarageManager.ReadUIInfo(ChoiceID.AddVehicle, sendthis, out error));
                        break;
                    case ChoiceID.RemoveVehicle:
                        //WriteLine("Skriv RegNr: ");
                        //string Search = ReadLine();
                        //WriteLine(GarageManager.SearchVehicle(Search));
                        //ReadKey();
                        string sendMotorcycle = "JAS561_Mörkblå_2_2_1_Motorcykeln 101_2011_1_2";
                        WriteLine(GarageManager.ReadUIInfo(ChoiceID.RemoveVehicle, sendMotorcycle, out error));
                        break;
                    case ChoiceID.ListAllVehicles:
                        WriteLine(GarageManager.ReadUIInfo(ChoiceID.ListAllVehicles, "", out error));
                        ReadKey();
                        break;
                    case ChoiceID.ListCars:
                    case ChoiceID.ListBuses:
                    case ChoiceID.ListTrucks:
                    case ChoiceID.ListMotorCycles:
                    case ChoiceID.ListMopeds:
                        WriteLine(GarageManager.ReadUIInfo(CurrentChoice, "", out error));
                        ReadKey();
                        break;
                    default:
                        break;
                }
                if (!string.IsNullOrEmpty(error))
                {
                    WriteLine(error);
                    ReadKey();
                }
            }



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
