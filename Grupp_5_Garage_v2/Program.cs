using System;
using static System.Console;
using System.Collections.Generic;

namespace Grupp_5_Garage_v2
{
    class Program
    {
        private static GarageManager garageManager;
        private static MenuID currentMenu;

        private static List<string> startUpChoices;
        private static List<string> mainChoices;
        private static List<string> addVehicleChoices;
        private static List<string> filterChoices;

        static void Main(string[] args)
        {
            StartUp();
            Menu();
        }

        private static void Menu()
        {
            while (true)
            {
                Clear();
                DisplayMenu();
                string choice = RecieveUserString();
                HandleChoice(choice);
            }
        }

        // Calls the appropriate methods and changes MenuIDs when a choice is picked.
        private static void HandleChoice(string choice)
        {
            if (currentMenu == MenuID.Main)
            {
                switch (choice)
                {
                    case "1":
                        currentMenu = MenuID.AddVehicle;
                        break;
                    case "2":
                        currentMenu = MenuID.GetVehicle;
                        CommunicateWithManager(ChoiceID.RemoveVehicle, RecieveSpecificValue());
                        currentMenu = MenuID.Main;
                        break;
                    case "3":
                        CommunicateWithManager(ChoiceID.ListAllVehicles, null);
                        break;
                    case "4":
                        CommunicateWithManager(ChoiceID.ListMopeds, null);
                        break;
                    case "5":
                        CommunicateWithManager(ChoiceID.ListMotorcycles, null);
                        break;
                    case "6":
                        CommunicateWithManager(ChoiceID.ListCars, null);
                        break;
                    case "7":
                        CommunicateWithManager(ChoiceID.ListBuses, null);
                        break;
                    case "8":
                        CommunicateWithManager(ChoiceID.ListTrucks, null);
                        break;
                    case "9":
                        currentMenu = MenuID.Filter;
                        break;
                    case "10":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            else if (currentMenu == MenuID.AddVehicle)
            {
                switch (choice)
                {
                    case "1":
                        CommunicateWithManager(ChoiceID.CreateMoped, CreateVehicleToAdd(ChoiceID.CreateMoped1, "moped"));
                        break;
                    case "2":
                        CommunicateWithManager(ChoiceID.CreateMoped, CreateVehicleToAdd(ChoiceID.CreateMoped2, "moped"));
                        break;
                    case "3":
                        CommunicateWithManager(ChoiceID.CreateMotorcycle, CreateVehicleToAdd(ChoiceID.CreateMotorcycle, "motorcykel"));
                        break;
                    case "4":
                        CommunicateWithManager(ChoiceID.CreateCar, CreateVehicleToAdd(ChoiceID.CreateCar, "bil"));
                        break;
                    case "5":
                        CommunicateWithManager(ChoiceID.CreateBus, CreateVehicleToAdd(ChoiceID.CreateBus, "buss"));
                        break;
                    case "6":
                        CommunicateWithManager(ChoiceID.CreateTruck, CreateVehicleToAdd(ChoiceID.CreateTruck, "lastbil"));
                        break;
                    case "7":
                        currentMenu = MenuID.Main;
                        break;
                    default:
                        break;
                }
            }
            else if (currentMenu == MenuID.Filter)
            {
                switch (choice)
                {
                    case "1":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByRegNr, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "2":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByColour, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "3":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByNrOfWheels, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "4":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByNrOfSeats, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "5":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByFuelType, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "6":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchBySize, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "7":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByManufacturer, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "8":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByYearModel, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "9":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByReceieptNr, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "10":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByClass, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "11":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByHelmetBox, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "12":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByWeightclass, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "13":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByType, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "14":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByRail, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "15":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByNrOfDoors, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "16":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByDoubleDecker, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "17":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByCompany, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "18":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByBogie, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "19":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchBySleepingCabin, RecieveSpecificValue());
                        currentMenu = MenuID.Filter;
                        break;
                    case "20":
                        currentMenu = MenuID.Main;
                        break;
                    default:
                        break;
                }
            }
        }

        #region garageManagerCommunication
        // Sends the input to garageManager, and then displays the output.
        private static void CommunicateWithManager(ChoiceID choiceID, string input)
        {
            string error = "";
            string output = "";
            output = garageManager.ReadUIInfo(choiceID, input, out error);
            if (error != "")
            {
                DisplayError(error);
                PauseForKeyPress();
            }
            else if (output != "")
            {
                DisplayOutput(output);
                PauseForKeyPress();
            }
        }

        private static void DisplayOutput(string output)
        {
            Clear();
            WriteLine(output);
        }

        private static void DisplayError(string error)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\n[ERROR]\n" + error);
            ForegroundColor = ConsoleColor.White;
        }
        #endregion

        #region Input
        private static string RecieveUserString()
        {
            return ReadLine();
        }

        // Returns a string that is used for vehicle removal, filtering.
        private static string RecieveSpecificValue()
        {
            Clear();
            WriteHeader();
            AddSeperatorLine();
            InputPrefix();
            return RecieveUserString();
        }

        // Returns a string that will be used for creating a vehicle.
        private static string CreateVehicleToAdd(ChoiceID choiceID, string vehicle)
        {
            string error;
            string vehicleSpecifications;
            string variableSeparator = "???";
            Clear();
            WriteHeader(vehicle);
            AddSeperatorLine();

            if (choiceID != ChoiceID.CreateMoped2)
            {
                Write("Registreringsnummer: ");
                vehicleSpecifications = RecieveUserString();
                bool isValidRegNr = InputValidation.IsValidLicenseNumber(vehicleSpecifications, out error);
                if (!isValidRegNr)
                {
                    DisplayError(error);
                    PauseForKeyPress();
                    Menu();
                }
                else vehicleSpecifications += variableSeparator;
            }
            else
            {
                vehicleSpecifications = "******";
                vehicleSpecifications += variableSeparator;
            }

            Write("\nFärg: ");
            vehicleSpecifications += RecieveUserString();
            vehicleSpecifications += variableSeparator;
            Write("\nAntal hjul: ");
            vehicleSpecifications += RecieveUserString();
            vehicleSpecifications += variableSeparator;
            Write("\nAntal säten: ");
            vehicleSpecifications += RecieveUserString();
            vehicleSpecifications += variableSeparator;
            WriteLine("\nBränsle:");
            WriteLine("1. Bensin");
            WriteLine("2. Diesel");
            WriteLine("3. Hybrid");
            WriteLine("4. Gas");
            WriteLine("5. El");
            Write("Val(1 - 5): ");
            vehicleSpecifications += char.GetNumericValue(RecieveUserString()[0]);
            vehicleSpecifications += variableSeparator;
            Write("\nTillverkare: ");
            vehicleSpecifications += RecieveUserString();
            vehicleSpecifications += variableSeparator;
            Write("\nÅrsmodell: ");
            vehicleSpecifications += RecieveUserString();
            vehicleSpecifications += variableSeparator;

            switch (choiceID)
            {
                case ChoiceID.CreateMoped1:
                    vehicleSpecifications += 'N';
                    vehicleSpecifications += variableSeparator;
                    Write("\nHar den hjälmförvaring? (J/N): ");
                    vehicleSpecifications += RecieveUserString().ToUpper()[0];
                    break;
                case ChoiceID.CreateMoped2:
                    vehicleSpecifications += 'J';
                    vehicleSpecifications += variableSeparator;
                    Write("\nHar den hjälmförvaring? (J/N): ");
                    vehicleSpecifications += RecieveUserString().ToUpper()[0];
                    break;
                case ChoiceID.CreateMotorcycle:
                    WriteLine("\nTyp:");
                    WriteLine("1. Basic");
                    WriteLine("2. Allroad");
                    WriteLine("3. Custom");
                    WriteLine("4. Offroad");
                    WriteLine("5. Sport");
                    WriteLine("6. Touring");
                    vehicleSpecifications += char.GetNumericValue(RecieveUserString()[0]);
                    vehicleSpecifications += variableSeparator;
                    WriteLine("\nViktklass:");
                    WriteLine("1. Lätt");
                    WriteLine("2. Mellan");
                    WriteLine("3. Tung");
                    vehicleSpecifications += char.GetNumericValue(RecieveUserString()[0]);
                    break;
                case ChoiceID.CreateCar:
                    Write("\nAntal dörrar: ");
                    vehicleSpecifications += RecieveUserString();
                    vehicleSpecifications += variableSeparator;
                    Write("\nHar den takräcke? (J/N): ");
                    vehicleSpecifications += RecieveUserString().ToUpper()[0];
                    break;
                case ChoiceID.CreateBus:
                    Write("\nFöretag: ");
                    vehicleSpecifications += RecieveUserString();
                    vehicleSpecifications += variableSeparator;
                    Write("\nÄr den en dubbeldäckare? (J/N): ");
                    vehicleSpecifications += RecieveUserString().ToUpper()[0];
                    break;
                case ChoiceID.CreateTruck:
                    Write("\nHar den boggi? (J/N): ");
                    vehicleSpecifications += RecieveUserString().ToUpper()[0];
                    vehicleSpecifications += variableSeparator;
                    Write("\nHar den sovplats? (J/N): ");
                    vehicleSpecifications += RecieveUserString().ToUpper()[0];
                    break;
                default:
                    break;
            }

            return vehicleSpecifications;
        }

        private static void PauseForKeyPress()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("\n[TRYCK PÅ VALFRI TANGENT FÖR ATT FORTSÄTTA]");
            ForegroundColor = ConsoleColor.White;
            ReadKey();
        }
        #endregion

        #region DisplayContext
        private static void DisplayMenu()
        {
            WriteHeader();
            AddSeperatorLine();
            ListChoices();
            AddSeperatorLine();
            InputPrefix();
        }

        // Writes out the top text for most menus.
        private static void WriteHeader()
        {
            ForegroundColor = ConsoleColor.Yellow;
            if (currentMenu == MenuID.StartUp) WriteLine("(START)");
            else if (currentMenu == MenuID.Main) WriteLine("(HUVUDMENY)");
            else if (currentMenu == MenuID.AddVehicle || currentMenu == MenuID.CreateVehicle) WriteLine("(PARKERA FORDON)");
            else if (currentMenu == MenuID.GetVehicle) WriteLine("(HÄMTA FORDON)");
            else if (currentMenu == MenuID.Filter || currentMenu == MenuID.FilterSearch) WriteLine("(FILTER)");

            if (currentMenu != MenuID.GetVehicle && currentMenu != MenuID.FilterSearch)
            {
                WriteLine("\nVAD VILL DU GÖRA?");
                WriteLine("[VÄLJ EN SIFFRA]");
            }
            else if(currentMenu == MenuID.GetVehicle)
            {
                WriteLine("\nHÄR KAN DU HÄMTA UT ETT FORDON.");
                WriteLine("[ANGE KVITTO/REGNUMMER FÖR DITT FORDON]");
            }
            else if(currentMenu == MenuID.FilterSearch)
            {
                WriteLine("\nHÄR KAN DU SÖKA EFTER ETT SPECIFIKT VÄRDE.");
                WriteLine("[MATA IN VÄRDET DU VILL SÖKA EFTER]");
            }
            ForegroundColor = ConsoleColor.White;
        }

        // Writes out the top text for the CreateVehicle menu.
        private static void WriteHeader(string vehicle)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("(PARKERA FORDON)");
            WriteLine($"\nBESKRIV DIN {vehicle.ToUpper()}.");
            WriteLine("[MATA IN INFORMATION]");
            ForegroundColor = ConsoleColor.White;
        }

        private static void AddSeperatorLine()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("-----------------------------------");
            ForegroundColor = ConsoleColor.White;
        }

        private static void ListChoices()
        {
            switch (currentMenu)
            {
                case MenuID.StartUp:
                    for (int i = 1; i <= startUpChoices.Count; i++) WriteLine($"{i}. {startUpChoices[i - 1]}");
                    break;
                case MenuID.Main:
                    for (int i = 1; i <= mainChoices.Count; i++) WriteLine($"{i}. {mainChoices[i - 1]}");
                    break;
                case MenuID.AddVehicle:
                    for (int i = 1; i <= addVehicleChoices.Count; i++) WriteLine($"{i}. {addVehicleChoices[i - 1]}");
                    break;
                case MenuID.Filter:
                    for (int i = 1; i <= filterChoices.Count; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                ForegroundColor = ConsoleColor.Yellow;
                                WriteLine("[DELADE EGENSKAPER]");
                                ForegroundColor = ConsoleColor.White;
                                break;
                            case 10:
                                ForegroundColor = ConsoleColor.Yellow;
                                WriteLine("[MOPED]");
                                ForegroundColor = ConsoleColor.White;
                                break;
                            case 12:
                                ForegroundColor = ConsoleColor.Yellow;
                                WriteLine("[MOTORCYKEL]");
                                ForegroundColor = ConsoleColor.White;
                                break;
                            case 14:
                                ForegroundColor = ConsoleColor.Yellow;
                                WriteLine("[BIL]");
                                ForegroundColor = ConsoleColor.White;
                                break;
                            case 16:
                                ForegroundColor = ConsoleColor.Yellow;
                                WriteLine("[BUSS]");
                                ForegroundColor = ConsoleColor.White;
                                break;
                            case 18:
                                ForegroundColor = ConsoleColor.Yellow;
                                WriteLine("[TRUCK]");
                                ForegroundColor = ConsoleColor.White;
                                break;
                            default:
                                break;
                        }
                        WriteLine($"{i}. {filterChoices[i - 1]}");
                    }
                    break;
                default:
                    break;
            }
        }

        private static void InputPrefix()
        {
            ForegroundColor = ConsoleColor.Yellow;
            Write("INMATNING: ");
            ForegroundColor = ConsoleColor.White;
        }
        #endregion

        #region UsedOnStartUp
        private static void StartUp()
        {
            UISetup();
            garageManager.Setup();
            WindowHeight += 5;

            bool isReadyToStart = false;
            while (!isReadyToStart)
            {
                Clear();
                Introduction();
                DisplayMenu();
                string startUpChoice = RecieveUserString();
                string message = "";

                if (startUpChoice == "1")
                {
                    garageManager.ReadUIInfo(ChoiceID.CreateGarage, null, out message);
                    isReadyToStart = true;
                }
                else if (startUpChoice == "2")
                {
                    garageManager.ReadUIInfo(ChoiceID.LoadGarage, null, out message);
                    isReadyToStart = true;
                }
            }

            currentMenu = MenuID.Main;
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
            garageManager = new GarageManager();
            currentMenu = MenuID.StartUp;

            startUpChoices = new List<string>();
            mainChoices = new List<string>();
            addVehicleChoices = new List<string>();
            filterChoices = new List<string>();

            startUpChoices.Add("Skapa ett nytt garage");
            startUpChoices.Add("Ladda ett sparat garage");

            mainChoices.Add("Parkera ett fordon");
            mainChoices.Add("Hämta ut ett fordon");
            mainChoices.Add("Lista alla fordon");
            mainChoices.Add("Lista mopeder");
            mainChoices.Add("Lista motorcyklar");
            mainChoices.Add("Lista bilar");
            mainChoices.Add("Lista bussar");
            mainChoices.Add("Lista lastbilar");
            mainChoices.Add("Lista efter filter");
            mainChoices.Add("Stäng av programmet");

            addVehicleChoices.Add("Parkera en moped (klass 1)");
            addVehicleChoices.Add("Parkera en moped (klass 2)");
            addVehicleChoices.Add("Parkera en motorcykel");
            addVehicleChoices.Add("Parkera en bil");
            addVehicleChoices.Add("Parkera en buss");
            addVehicleChoices.Add("Parkera en lastbil");
            addVehicleChoices.Add("Gå tillbaka");

            filterChoices.Add("Sök med registreringsnummer");
            filterChoices.Add("Sök med färg");
            filterChoices.Add("Sök med antal hjul");
            filterChoices.Add("Sök med antal säten");
            filterChoices.Add("Sök med bensintyp");
            filterChoices.Add("Sök med storlek");
            filterChoices.Add("Sök med märke");
            filterChoices.Add("Sök med årsmodell");
            filterChoices.Add("Sök med kvittonummer");
            // Moped
            filterChoices.Add("Sök med klass");
            filterChoices.Add("Sök med hjälmförvaring");
            // Motorcycle
            filterChoices.Add("Sök med viktklass");
            filterChoices.Add("Sök med Typ");
            // Car
            filterChoices.Add("Sök med takräcke");
            filterChoices.Add("Sök med antal dörrar");
            // Bus
            filterChoices.Add("Sök med dubbeldäckare");
            filterChoices.Add("Sök med företag");
            // Truck
            filterChoices.Add("Sök med boggi");
            filterChoices.Add("Sök med sovplats");
            filterChoices.Add("Gå tillbaka");
        }
        #endregion
    }
}
