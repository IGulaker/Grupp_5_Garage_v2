// This UI(Program.cs) is created by Isac Gulaker.

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
                        CommunicateWithManager(ChoiceID.RemoveVehicle, RecieveVehicleToRemove());
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
                        currentMenu = MenuID.SaveGarage;
                        QuestionWantToSave();
                        Environment.Exit(0);
                        break;
                    case "S":
                    case "s":
                        currentMenu = MenuID.SaveGarage;
                        QuestionWantToSave();
                        currentMenu = MenuID.Main;
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
                        CommunicateWithManager(ChoiceID.SearchByRegNr, RecieveStringForFiltering(ChoiceID.SearchByRegNr));
                        currentMenu = MenuID.Filter;
                        break;
                    case "2":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByColour, RecieveStringForFiltering(ChoiceID.SearchByColour));
                        currentMenu = MenuID.Filter;
                        break;
                    case "3":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByNrOfWheels, RecieveStringForFiltering(ChoiceID.SearchByNrOfWheels));
                        currentMenu = MenuID.Filter;
                        break;
                    case "4":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByNrOfSeats, RecieveStringForFiltering(ChoiceID.SearchByNrOfSeats));
                        currentMenu = MenuID.Filter;
                        break;
                    case "5":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByFuelType, RecieveStringForFiltering(ChoiceID.SearchByFuelType));
                        currentMenu = MenuID.Filter;
                        break;
                    case "6":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByManufacturer, RecieveStringForFiltering(ChoiceID.SearchByManufacturer));
                        currentMenu = MenuID.Filter;
                        break;
                    case "7":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByYearModel, RecieveStringForFiltering(ChoiceID.SearchByYearModel));
                        currentMenu = MenuID.Filter;
                        break;
                    case "8":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByReceieptNr, RecieveStringForFiltering(ChoiceID.SearchByReceieptNr));
                        currentMenu = MenuID.Filter;
                        break;
                    case "9":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByClass, RecieveStringForFiltering(ChoiceID.SearchByClass));
                        currentMenu = MenuID.Filter;
                        break;
                    case "10":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByHelmetBox, RecieveSpecificBoolValue(ChoiceID.SearchByHelmetBox));
                        currentMenu = MenuID.Filter;
                        break;
                    case "11":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByWeightclass, RecieveStringForFiltering(ChoiceID.SearchByWeightclass));
                        currentMenu = MenuID.Filter;
                        break;
                    case "12":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByType, RecieveStringForFiltering(ChoiceID.SearchByType));
                        currentMenu = MenuID.Filter;
                        break;
                    case "13":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByRail, RecieveSpecificBoolValue(ChoiceID.SearchByRail));
                        currentMenu = MenuID.Filter;
                        break;
                    case "14":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByNrOfDoors, RecieveStringForFiltering(ChoiceID.SearchByNrOfDoors));
                        currentMenu = MenuID.Filter;
                        break;
                    case "15":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByDoubleDecker, RecieveSpecificBoolValue(ChoiceID.SearchByDoubleDecker));
                        currentMenu = MenuID.Filter;
                        break;
                    case "16":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByCompany, RecieveStringForFiltering(ChoiceID.SearchByCompany));
                        currentMenu = MenuID.Filter;
                        break;
                    case "17":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchByBogie, RecieveSpecificBoolValue(ChoiceID.SearchByBogie));
                        currentMenu = MenuID.Filter;
                        break;
                    case "18":
                        currentMenu = MenuID.FilterSearch;
                        CommunicateWithManager(ChoiceID.SearchBySleepingCabin, RecieveSpecificBoolValue(ChoiceID.SearchBySleepingCabin));
                        currentMenu = MenuID.Filter;
                        break;
                    case "19":
                        currentMenu = MenuID.Main;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void QuestionWantToSave()
        {
            Clear();
            WriteHeader();
            AddSeperatorLine();
            InputPrefix();
            string input = RecieveUserBool();

            if (input == "")
            {
                CommunicateWithManager(ChoiceID.SaveGarage, input);
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
                PauseForKeyPress(choiceID);
            }
            else if (output != "")
            {
                DisplayOutput(output, choiceID);
                PauseForKeyPress(choiceID);
            }
        }

        private static string CommunicateWithManager(ChoiceID choiceID, string input, out string vehicleinfo)
        {
            string output = garageManager.ReadUIInfo(choiceID, input, out vehicleinfo);
            if (output != "")
            {
                DisplayOutput(output + "\n\n" + vehicleinfo, choiceID);
            }

            return output;
        }
        #endregion

        #region Input
        private static string RecieveUserString()
        {
            return ReadLine();
        }

        // Returns a string that is used for filtering.
        private static string RecieveStringForFiltering(ChoiceID choiceID)
        {
            Clear();
            WriteSearchStringHeader(choiceID);
            AddSeperatorLine();
            InputPrefix();
            return RecieveUserString();
        }

        private static string RecieveVehicleToRemove()
        {
            Clear();
            WriteHeader();
            AddSeperatorLine();
            InputPrefix();
            return RecieveUserString();
        }

        private static string RecieveUserBool()
        {
            string input = ReadLine();
            if (input != "")
            {
                return input.ToUpper()[0].ToString();
            }
            else return "x";
        }

        private static string RecieveSpecificBoolValue(ChoiceID choiceID)
        {
            Clear();
            WriteSearchBoolHeader(choiceID);
            AddSeperatorLine();
            InputPrefix();
            return RecieveUserBool();
        }

        // Returns a string that will be used for creating a vehicle.
        private static string CreateVehicleToAdd(ChoiceID choiceID, string vehicle)
        {
            string error;
            string vehicleSpecifications;
            string variableSeparator = "???";
            string input;
            bool goToNext = false;

            Clear();
            WriteParkingHeader(vehicle);
            AddSeperatorLine();

            if (choiceID != ChoiceID.CreateMoped2)
            {
                Write("Registreringsnummer: ");
                do
                {
                    input = RecieveUserString();
                    goToNext = InputValidation.IsValidLicenseNumber(input, out error);
                    if (!goToNext)
                    {
                        DisplayError(error);
                        Write("Registreringsnummer: ");
                    }
                } while (!goToNext);

                if (CommunicateWithManager(ChoiceID.ShallItParkAgain, input, out string vehicleinfo) != "")
                {
                    WriteLine("\nSka fordonet parkera igen? (J/N)\n");
                    InputPrefix();
                    string parkeraIgen = RecieveUserBool() + variableSeparator + input;

                    CommunicateWithManager(ChoiceID.ParkAgain, parkeraIgen);

                    return null;
                }

                vehicleSpecifications = input.ToUpper() + variableSeparator;
            }
            else
            {
                vehicleSpecifications = "******";
                vehicleSpecifications += variableSeparator;
            }

            Write("\nFärg: ");
            input = RecieveUserString();
            while (string.IsNullOrEmpty(input))
            {
                DisplayError("Du måste skriva något!");
                Write("\nFärg: ");
                input = RecieveUserString();
            }
            vehicleSpecifications += InputValidation.InitialToUpper(input) + variableSeparator;
            Write("\nAntal hjul: ");
            input = RecieveUserString();
            while ((!int.TryParse(input, out int aNumber)))
            {
                DisplayError("Endast siffor tillåtna!");
                Write("\nAntal hjul: ");
                input = RecieveUserString();
            }
            vehicleSpecifications += input + variableSeparator;
            Write("\nAntal passagerarplatser: ");
            input = RecieveUserString();
            while ((!int.TryParse(input, out int aNumber)))
            {
                DisplayError("Endast siffor tillåtna!");
                Write("\nAntal passagerarplatser: ");
                input = RecieveUserString();
            }
            vehicleSpecifications += input + variableSeparator;

            do
            {
                WriteLine("\nBränsle:");
                WriteLine("1. Bensin");
                WriteLine("2. Diesel");
                WriteLine("3. Hybrid");
                WriteLine("4. Gas");
                WriteLine("5. El");
                Write("Val(1 - 5): ");
                input = RecieveUserString();
                goToNext = InputValidation.IsValidEnum(input, out error, Enum.GetNames(typeof(FuelType)).Length);
                if (!goToNext)
                {
                    DisplayError(error);
                }
            } while (!goToNext);
            vehicleSpecifications += input + variableSeparator;
            Write("\nTillverkare: ");
            input = RecieveUserString();
            while (string.IsNullOrEmpty(input))
            {
                DisplayError("Du måste skriva något!");
                Write("\nTillverkare: ");
                input = RecieveUserString();
            }
            vehicleSpecifications += InputValidation.InitialToUpper(input) + variableSeparator;
            Write("\nÅrsmodell: ");
            do
            {
                input = RecieveUserString();
                goToNext = InputValidation.IsValidModelYearNumber(input, out error, out int modelYear);
                if (!goToNext)
                {
                    DisplayError(error);
                    Write("\nÅrsmodell: ");
                }
                else input = modelYear.ToString();
            } while (!goToNext);
            vehicleSpecifications += input + variableSeparator;

            switch (choiceID)
            {
                case ChoiceID.CreateMoped1:
                    vehicleSpecifications += 'N';
                    vehicleSpecifications += variableSeparator;
                    Write("\nHar den hjälmförvaring? (J/N): ");
                    input = RecieveUserBool();
                    while (string.IsNullOrEmpty(input))
                    {
                        DisplayError("Du måste skriva något!");
                        Write("\nHar den hjälmförvaring? (J/N): ");
                        input = RecieveUserBool();
                    }
                    vehicleSpecifications += input;
                    break;
                case ChoiceID.CreateMoped2:
                    vehicleSpecifications += 'J';
                    vehicleSpecifications += variableSeparator;
                    Write("\nHar den hjälmförvaring? (J/N): ");
                    input = RecieveUserBool();
                    while (string.IsNullOrEmpty(input))
                    {
                        DisplayError("Du måste skriva något!");
                        Write("\nHar den hjälmförvaring? (J/N): ");
                        input = RecieveUserBool();
                    }
                    vehicleSpecifications += input;
                    break;
                case ChoiceID.CreateMotorcycle:
                    do
                    {
                        WriteLine("\nTyp:");
                        WriteLine("1. Basic");
                        WriteLine("2. Allroad");
                        WriteLine("3. Custom");
                        WriteLine("4. Offroad");
                        WriteLine("5. Sport");
                        WriteLine("6. Touring");
                        input = RecieveUserString();
                        goToNext = InputValidation.IsValidEnum(input, out error, Enum.GetNames(typeof(MotorCycleType)).Length);
                        if (!goToNext)
                        {
                            DisplayError(error);
                        }
                    } while (!goToNext);
                    vehicleSpecifications += input + variableSeparator;
                    do
                    {
                        WriteLine("\nViktklass:");
                        WriteLine("1. Lätt");
                        WriteLine("2. Mellan");
                        WriteLine("3. Tung");
                        input = RecieveUserString();
                        goToNext = InputValidation.IsValidEnum(input, out error, Enum.GetNames(typeof(WeightClass)).Length);
                        if (!goToNext)
                        {
                            DisplayError(error);
                        }
                    } while (!goToNext);
                    vehicleSpecifications += input;
                    break;
                case ChoiceID.CreateCar:
                    Write("\nAntal dörrar: ");
                    input = RecieveUserString();
                    while ((!int.TryParse(input, out int aNumber)))
                    {
                        DisplayError("Endast siffor tillåtna!");
                        Write("\nAntal dörrar: ");
                        input = RecieveUserString();
                    }
                    vehicleSpecifications += input + variableSeparator;
                    Write("\nHar den takräcke? (J/N): ");
                    input = RecieveUserBool();
                    while (string.IsNullOrEmpty(input))
                    {
                        DisplayError("Du måste skriva något!");
                        Write("\nHar den takräcke? (J/N): ");
                        input = RecieveUserBool();
                    }
                    vehicleSpecifications += input;
                    break;
                case ChoiceID.CreateBus:
                    Write("\nFöretag: ");
                    input = RecieveUserString();
                    while (string.IsNullOrEmpty(input))
                    {
                        DisplayError("Du måste skriva något!");
                        Write("\nTillverkare: ");
                        input = RecieveUserString();
                    }
                    vehicleSpecifications += InputValidation.InitialToUpper(input) + variableSeparator;
                    Write("\nÄr den en dubbeldäckare? (J/N): ");
                    input = RecieveUserBool();
                    while (string.IsNullOrEmpty(input))
                    {
                        DisplayError("Du måste skriva något!");
                        Write("\nÄr den en dubbeldäckare? (J/N): ");
                        input = RecieveUserBool();
                    }
                    vehicleSpecifications += input;
                    break;
                case ChoiceID.CreateTruck:
                    Write("\nHar den boggi? (J/N): ");
                    input = RecieveUserBool();
                    while (string.IsNullOrEmpty(input))
                    {
                        DisplayError("Du måste skriva något!");
                        Write("\nHar den boggi? (J/N): ");
                        input = RecieveUserBool();
                    }
                    vehicleSpecifications += input + variableSeparator;
                    Write("\nHar den sovplats? (J/N): ");
                    input = RecieveUserBool();
                    while (string.IsNullOrEmpty(input))
                    {
                        DisplayError("Du måste skriva något!");
                        Write("\nHar den sovplats? (J/N): ");
                        input = RecieveUserBool();
                    }
                    vehicleSpecifications += input;
                    break;
                default:
                    break;
            }

            return vehicleSpecifications;
        }

        private static void PauseForKeyPress(ChoiceID choiceID)
        {
            WritePressAnyKey();
            if (choiceID >= ChoiceID.ListAllVehicles && choiceID <= ChoiceID.ListTrucks) SetCursorPosition(0, 0);
            ReadKey();
        }

        private static void WritePressAnyKey()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("\n[TRYCK PÅ VALFRI TANGENT FÖR ATT FORTSÄTTA]");
            ForegroundColor = ConsoleColor.White;
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
            if (currentMenu == MenuID.StartUp || currentMenu == MenuID.CreatingGarage) WriteLine("(START)");
            else if (currentMenu == MenuID.Main) WriteLine($"(HUVUDMENY) \n{garageManager.GarageInfo()}");
            else if (currentMenu == MenuID.AddVehicle || currentMenu == MenuID.CreateVehicle) WriteLine("(PARKERA FORDON)");
            else if (currentMenu == MenuID.GetVehicle) WriteLine("(HÄMTA FORDON)");
            else if (currentMenu == MenuID.Filter || currentMenu == MenuID.FilterSearch) WriteLine("(FILTER)");
            else if (currentMenu == MenuID.SaveGarage) WriteLine("(SPARA GARAGE)");


            if (currentMenu == MenuID.CreatingGarage)
            {
                WriteLine("\nSKAPAR GARAGE.");
                WriteLine("[STORLEK PÅ FORDON: MOPED/MOTORCYKEL = 1, BIL = 2, BUSS = 3/4, LASTBIL = 4]");
            }
            else if (currentMenu != MenuID.GetVehicle && currentMenu != MenuID.FilterSearch && currentMenu != MenuID.SaveGarage)
            {
                WriteLine("\nVAD VILL DU GÖRA?");
                WriteLine("[VÄLJ EN SIFFRA]");
            }
            else if (currentMenu == MenuID.GetVehicle)
            {
                WriteLine("\nHÄR KAN DU HÄMTA UT ETT FORDON.");
                WriteLine("[ANGE KVITTO/REGNUMMER FÖR DITT FORDON]");
            }
            else if (currentMenu == MenuID.FilterSearch)
            {
                WriteLine("\nHÄR KAN DU SÖKA EFTER ETT SPECIFIKT VÄRDE.");
                WriteLine("[MATA IN VÄRDET DU VILL SÖKA EFTER]");
            }
            else if (currentMenu == MenuID.SaveGarage)
            {
                WriteLine("\nVILL DU SPARA DITT GARAGE?");
                WriteLine("[SVARA J/N]");
            }
            ForegroundColor = ConsoleColor.White;
        }

        // Writes out the top text for the CreateVehicle menu.
        private static void WriteParkingHeader(string vehicle)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("(PARKERA FORDON)");
            WriteLine($"\nBESKRIV DIN {vehicle.ToUpper()}.");
            WriteLine("[MATA IN INFORMATION]");
            ForegroundColor = ConsoleColor.White;
        }

        private static void WriteListingHeader()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("\t[REGNR] [FORDON]\t [MÄRKE]\t [KVITTONUMMER]");
            ForegroundColor = ConsoleColor.White;
        }

        private static void WriteSearchStringHeader(ChoiceID choiceID)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("(FILTER)");
            Write("\nSÖK PÅ ");
            switch (choiceID)
            {
                case ChoiceID.SearchByRegNr:
                    Write("FORDONETS REGISTRERINGSNUMMER");
                    break;
                case ChoiceID.SearchByColour:
                    Write("FORDONETS FÄRG");
                    break;
                case ChoiceID.SearchByNrOfWheels:
                    Write("ANTAL HJUL PÅ FORDONET");
                    break;
                case ChoiceID.SearchByNrOfSeats:
                    Write("ANTAL SÄTEN I FORDONET");
                    break;
                case ChoiceID.SearchByFuelType:
                    Write("FORDONETS BRÄNSLE");
                    break;
                case ChoiceID.SearchByManufacturer:
                    Write("FORDONETS TILLVERKARE");
                    break;
                case ChoiceID.SearchByYearModel:
                    Write("FORDONETS ÅRSMODELL");
                    break;
                case ChoiceID.SearchByReceieptNr:
                    Write("FORDONETS KVITTONUMMER");
                    break;
                case ChoiceID.SearchByClass:
                    Write("MOPEDENS KLASS");
                    break;
                case ChoiceID.SearchByWeightclass:
                    Write("MOTORCYKELNS VIKTKLASS");
                    break;
                case ChoiceID.SearchByType:
                    Write("MOTORCYKELNS TYP");
                    break;
                case ChoiceID.SearchByNrOfDoors:
                    Write("ANTAL DÖRRAR PÅ BILEN");
                    break;
                case ChoiceID.SearchByCompany:
                    Write("BUSSENS FÖRETAG");
                    break;
                default:
                    break;
            }
            WriteLine('.');
            WriteLine("[SKRIV IN VÄRDET SOM SKA SÖKAS EFTER]");
            ForegroundColor = ConsoleColor.White;
        }

        private static void WriteSearchBoolHeader(ChoiceID choiceID)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("(FILTER)");
            Write("\nHAR DEN ");
            switch (choiceID)
            {
                case ChoiceID.SearchByHelmetBox:
                    Write("HJÄLMFÖRVARING");
                    break;
                case ChoiceID.SearchByWeightclass:
                    break;
                case ChoiceID.SearchByRail:
                    Write("TAKRÄCKE");
                    break;
                case ChoiceID.SearchByDoubleDecker:
                    Write("TVÅ VÅNINGAR");
                    break;
                case ChoiceID.SearchByBogie:
                    Write("BOGGI");
                    break;
                case ChoiceID.SearchBySleepingCabin:
                    Write("SOVPLATS");
                    break;
                default:
                    break;
            }
            WriteLine('?');
            WriteLine("[SVARA J/N]");
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
                    for (int i = 1; i <= mainChoices.Count; i++)
                    {
                        if (i != mainChoices.Count)
                        {
                            WriteLine($"{i}. {mainChoices[i - 1]}");
                        }
                        else WriteLine($"S. {mainChoices[i - 1]}");
                    }
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
                            case 9:
                                ForegroundColor = ConsoleColor.Yellow;
                                WriteLine("[MOPED]");
                                ForegroundColor = ConsoleColor.White;
                                break;
                            case 11:
                                ForegroundColor = ConsoleColor.Yellow;
                                WriteLine("[MOTORCYKEL]");
                                ForegroundColor = ConsoleColor.White;
                                break;
                            case 13:
                                ForegroundColor = ConsoleColor.Yellow;
                                WriteLine("[BIL]");
                                ForegroundColor = ConsoleColor.White;
                                break;
                            case 15:
                                ForegroundColor = ConsoleColor.Yellow;
                                WriteLine("[BUSS]");
                                ForegroundColor = ConsoleColor.White;
                                break;
                            case 17:
                                ForegroundColor = ConsoleColor.Yellow;
                                WriteLine("[LASTBIL]");
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

        private static void DisplayOutput(string output, ChoiceID choiceID)
        {
            Clear();
            if (choiceID >= ChoiceID.ListAllVehicles && choiceID < ChoiceID.SearchByRegNr)
            {
                WriteListingHeader();
            }
            else if ((int)choiceID >= (int)ChoiceID.CreateMoped && (int)choiceID <= (int)ChoiceID.CreateTruck)
            {
                ForegroundColor = ConsoleColor.Green;
            }
            WriteLine(output);
            ForegroundColor = ConsoleColor.White;
        }

        private static void DisplayError(string error)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\n[ERROR]\n" + error);
            ForegroundColor = ConsoleColor.White;
        }
        #endregion

        #region UsedOnStartUp
        private static void StartUp()
        {
            UISetup();
            WindowHeight += 5;

            bool isReadyToStart = false;
            while (!isReadyToStart)
            {
                Clear();
                Introduction();
                DisplayMenu();
                string startUpChoice = RecieveUserString();

                if (startUpChoice == "1")
                {
                    currentMenu = MenuID.CreatingGarage;
                    CommunicateWithManager(ChoiceID.CreateGarage, CreateGarageToAdd());
                    if (garageManager.IsReadyToStart())
                        isReadyToStart = true;
                    else
                        currentMenu = MenuID.StartUp;
                }
                else if (startUpChoice == "2")
                {
                    CommunicateWithManager(ChoiceID.LoadGarage, null);
                    if (garageManager.IsReadyToStart())
                        isReadyToStart = true;
                }
            }

            currentMenu = MenuID.Main;
        }

        private static string CreateGarageToAdd()
        {
            Clear();
            WriteHeader();
            AddSeperatorLine();
            string garageSpecifications = "";
            string variableSeparator = "???";

            Write("Storlek på garaget: ");
            garageSpecifications += RecieveUserString();
            garageSpecifications += variableSeparator;
            Write("Antal fordon som redan är parkerade: ");
            garageSpecifications += RecieveUserString();

            return garageSpecifications;
        }

        private static void Introduction()
        {
            string tab = "\t\t\t";
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{tab}    ____________________________________________________________             _______");
            WriteLine($"{tab}   |                  GRUPP FEMS GARAGEPROJEKT                  |           |   ____|");
            WriteLine($"|--------------------------|                        SKAPAT AV                           |-----------|  |--------------|");
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
            mainChoices.Add("Spara garaget.");

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
