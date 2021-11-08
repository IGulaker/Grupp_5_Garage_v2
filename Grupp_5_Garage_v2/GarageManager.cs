using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    public class GarageManager
    {
        Garage<Vehicle> myGarage;
        public GarageManager()
        {
            myGarage = new Garage<Vehicle>();
        }

        public void Setup(string input, out string message)
        {
            message = "";

            string[] SeparatedString = input.Split("???");

            int garagesize = Convert.ToInt32(SeparatedString[0]);
            int vehiclestocreate = Convert.ToInt32(SeparatedString[1]);

            myGarage.NumberOfParkingLots = garagesize;
            CreateVehicles(vehiclestocreate);



        }

        public string GarageInfo()
        {
            return myGarage.ToString();
        }

        private void CreateVehicles(int numberOfVehiclestoAdd)
        {
            for (int i = 0; i < numberOfVehiclestoAdd; i++)
            {
                CreateRandomVehicle();
            }
        }

        private string SaveGarage()
        {
            XMLUtilities.XMLFileSerialize(AppDomain.CurrentDomain.BaseDirectory + @"\ParkedVehicles.xml", myGarage);
            XMLUtilities.XMLFileSerialize(AppDomain.CurrentDomain.BaseDirectory + @"\UnParkedVehicles.xml", myGarage.UnparkedVehicles);
            XMLUtilities.XMLFileSerialize(AppDomain.CurrentDomain.BaseDirectory + @"\GarageSize.xml", myGarage.NumberOfParkingLots);

            return "Garaget har sparats";
        }

        public string LoadGarage()
        {
            try
            {
                Vehicle.NextReceiptNumber = 1000;
                myGarage = XMLUtilities.XMLFileDeserialize<Garage<Vehicle>>(AppDomain.CurrentDomain.BaseDirectory + @"\ParkedVehicles.xml");
                myGarage.UnparkedVehicles = XMLUtilities.XMLFileDeserialize<List<Vehicle>>(AppDomain.CurrentDomain.BaseDirectory + @"\UnParkedVehicles.xml");
                myGarage.NumberOfParkingLots = XMLUtilities.XMLFileDeserialize<int>(AppDomain.CurrentDomain.BaseDirectory + @"\GarageSize.xml");
                myGarage.SetCorrectReceiptNumberAfterLoading();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "Garaget har laddats!";
        }

        private void CreateRandomVehicle()
        {
            Random r = new();
            int randomNumber = r.Next(1, 100);
            bool done;
            switch (randomNumber)
            {
                case > 0 and <= 51:
                    done = myGarage.AddVehicle(new Car(), out _);
                    break;
                case > 51 and <= 63:
                    done = myGarage.AddVehicle(new Moped(), out _);
                    break;
                case > 63 and <= 75:
                    done = myGarage.AddVehicle(new MotorCycle(), out _);
                    break;
                case > 75 and <= 87:
                    done = myGarage.AddVehicle(new Bus(), out _);
                    break;
                case > 87:
                    done = myGarage.AddVehicle(new Truck(), out _);
                    break;
            }

        }

        public string ReadUIInfo(ChoiceID choiceID, string input, out string message)
        {
            message = "";

            switch (choiceID)
            {
                case ChoiceID.CreateGarage:
                    Setup(input, out message);
                    break;
                case ChoiceID.LoadGarage:
                    return LoadGarage();
                case ChoiceID.SaveGarage:
                    return SaveGarage();
                case ChoiceID.RemoveVehicle:
                    return RemoveVehicle(input.ToUpper(), out message);
                case ChoiceID.ListAllVehicles:
                    return myGarage.ListVehicles(out message);
                case ChoiceID.ListCars:
                    return myGarage.ListVehicleTypeString<Car>(out message);
                case ChoiceID.ListBuses:
                    return myGarage.ListVehicleTypeString<Bus>(out message);
                case ChoiceID.ListTrucks:
                    return myGarage.ListVehicleTypeString<Truck>(out message);
                case ChoiceID.ListMopeds:
                    return myGarage.ListVehicleTypeString<Moped>(out message);
                case ChoiceID.ListMotorcycles:
                    return myGarage.ListVehicleTypeString<MotorCycle>(out message);
                case ChoiceID.CreateCar:
                    return AddCar(input, out message);
                case ChoiceID.CreateBus:
                    return AddBus(input, out message);
                case ChoiceID.CreateMoped1:
                case ChoiceID.CreateMoped:
                case ChoiceID.CreateMoped2:
                    return AddMoped(input, out message);
                case ChoiceID.CreateMotorcycle:
                    return AddMotorcycle(input, out message);
                case ChoiceID.CreateTruck:
                    return AddTruck(input, out message);
                case ChoiceID.SearchByBogie:
                    return SearchByBoogie(input, out message);
                case ChoiceID.SearchByClass:
                    return SearchByClass(input, out message);
                case ChoiceID.SearchByColour:
                    return SearchByColor(input, out message);
                case ChoiceID.SearchByCompany:
                    return SearchByCompany(input, out message);
                case ChoiceID.SearchByDoubleDecker:
                    return SearchByDoubleDecker(input, out message);
                case ChoiceID.SearchByFuelType:
                    return SearchByFuelType(input, out message);
                case ChoiceID.SearchByHelmetBox:
                    return SearchByHelmetBox(input, out message);
                case ChoiceID.SearchByManufacturer:
                    return SearchByManufacturer(input, out message);
                case ChoiceID.SearchByNrOfDoors:
                    return SearchByNrOfDoors(Convert.ToInt32(input), out message);
                case ChoiceID.SearchByNrOfSeats:
                    return SearchByNrOfSeats(Convert.ToInt32(input), out message);
                case ChoiceID.SearchByNrOfWheels:
                    return SearchByNrOfWheels(Convert.ToInt32(input), out message);
                case ChoiceID.SearchByRail:
                    return SearchByRails(input, out message);
                case ChoiceID.SearchByReceieptNr:
                    return SearchByReceiptNumber(Convert.ToInt32(input), out message);
                case ChoiceID.SearchByRegNr:
                    return SearchVehicle(input, out message);
                case ChoiceID.SearchBySleepingCabin:
                    return SearchBySleepingCabin(input, out message);
                case ChoiceID.SearchByType:
                    return SearchByType(input, out message);
                case ChoiceID.SearchByWeightclass:
                    return SearchByWeightclass(input, out message);
                case ChoiceID.SearchByYearModel:
                    return SearchByModelYear(Convert.ToInt32(input), out message);
                case ChoiceID.ShallItParkAgain:
                    return CheckIfRegNrAlreadyExists(input, out message);
                case ChoiceID.ParkAgain:
                    return ParkAgain(input.ToUpper(), out message);
                default:
                    break;
            }


            return "";
        }

        private string ParkAgain(string input, out string message)
        {
            string[] SeparatedString = input.Split("???");

            //1. If first string is "J" park again.
            if (SeparatedString[0] == "J")
            {
                if (myGarage.ReaddVehicle(SeparatedString[1], out message, out string vehicleinfo))
                    return $"Fordonet har parkerat \n\n{vehicleinfo}";                 
            }
            message = "Fordonet har inte parkerat";
            return "";
        }

        private string RemoveVehicle(string input, out string message)
        {
            Vehicle vehicleToRemove = myGarage.GetVehicleWithReceipt(input);

            if (vehicleToRemove == null)
                vehicleToRemove = myGarage.GetVehicleWithRegNr(input);

            switch (vehicleToRemove)
            {
                case null:
                    message = "Hittade inte ditt fordon i vårt garage.";
                    return "";
                default:
                    myGarage.RemoveVehicle(vehicleToRemove, out message);
                    return $"Ditt fordon har nu hämtats ut:\n\n{vehicleToRemove}";
            }
        }

        private string AddMoped(string input, out string message)
        {
            message = "";

            if (input == null)
                return "";
            //1. Set up variables
            string[] ConvertedString = input.Split("???");


            //2. Check to see that we have enough values.
            if (ConvertedString.Length != 9)
            {
                message = "Fel antal skickade värden.";
                return "";
            }

            //3. Convert the values to correct types
            GetBasicValuesConverted(ConvertedString, out string regNr, out string color, out int numberofwheels, out int passengercapacity, out FuelType fuel, out string manufacturer, out int modelyear);
            GetMopedValuesConverted(ConvertedString, out bool ismopedclasstwo, out bool hashelmetbox);

            //4. Do all checks if it can be added.
            return DoesRegNrExist(regNr, out message)
                ? ""
                : myGarage.AddVehicle(new Moped(regNr, color, numberofwheels, passengercapacity, fuel, manufacturer, modelyear, ismopedclasstwo, hashelmetbox), out message)
                ? "Fordonet registrerat"
                : "";


        }

        private string AddMotorcycle(string input, out string message)
        {
            message = "";

            if (input == null)
                return "";
            //1. Set up variables
            string[] ConvertedString = input.Split("???");


            //2. Check to see that we have enough values.
            if (ConvertedString.Length != 9)
            {
                message = "Fel antal skickade värden.";
                return "";
            }

            //3. Convert the values to correct types
            GetBasicValuesConverted(ConvertedString, out string regNr, out string color, out int numberofwheels, out int passengercapacity, out FuelType fuel, out string manufacturer, out int modelyear);
            GetMotorcycleValuesConverted(ConvertedString, out MotorCycleType motorcycletype, out WeightClass weightclass);

            //4. Do all checks if it can be added.
            return DoesRegNrExist(regNr, out message)
                ? ""
                : myGarage.AddVehicle(new MotorCycle(regNr, color, numberofwheels, passengercapacity, fuel, manufacturer, modelyear, motorcycletype, weightclass), out message)
                ? "Fordonet registrerat"
                : "";

        }

        private string AddTruck(string input, out string message)
        {
            message = "";

            if (input == null)
                return "";
            //1. Set up variables
            string[] ConvertedString = input.Split("???");


            //2. Check to see that we have enough values.
            if (ConvertedString.Length != 9)
            {
                message = "Fel antal skickade värden.";
                return "";
            }

            //3. Convert the values to correct types
            GetBasicValuesConverted(ConvertedString, out string regNr, out string color, out int numberofwheels, out int passengercapacity, out FuelType fuel, out string manufacturer, out int modelyear);
            GetTruckValuesConverted(ConvertedString, out bool boogie, out bool sleepingcabin);

            //4. Do all checks if it can be added.
            return DoesRegNrExist(regNr, out message)
                ? ""
                : myGarage.AddVehicle(new Truck(regNr, color, numberofwheels, passengercapacity, fuel, manufacturer, modelyear, boogie, sleepingcabin), out message)
                ? "Fordonet registrerat!"
                : "";

        }

        private string AddCar(string input, out string message)
        {
            message = "";

            if (input == null)
                return "";
            //1. Set up variables
            string[] ConvertedString = input.Split("???");

            //2. Check to see that we have enough values.
            if (ConvertedString.Length != 9)
            {
                message = "Fel antal skickade värden.";
                return "";
            }

            //3. Convert the values to correct types
            GetBasicValuesConverted(ConvertedString, out string regNr, out string color, out int numberofwheels, out int passengercapacity, out FuelType fuel, out string manufacturer, out int modelyear);
            GetCarValuesConverted(ConvertedString, out int noofdoors, out bool rails);

            //4. Do all checks if it can be added.
            return DoesRegNrExist(regNr, out message)
                ? ""
                : myGarage.AddVehicle(new Car(regNr, color, numberofwheels, passengercapacity, fuel, manufacturer, modelyear, noofdoors, rails), out message)
                ? "Fordonet registrerat!"
                : "";
        }

        private string AddBus(string input, out string message)
        {
            message = "";

            if (input == null)
                return "";
            //1. Set up variables
            string[] ConvertedString = input.Split("???");

            //2. Check to see that we have enough values.
            if (ConvertedString.Length != 9)
            {
                message = "Fel antal skickade värden.";
                return "";
            }


            //3. Convert the values to correct types
            GetBasicValuesConverted(ConvertedString, out string regNr, out string color, out int numberofwheels, out int passengercapacity, out FuelType fuel, out string manufacturer, out int modelyear);
            GetBusValuesConverted(ConvertedString, out string buscompany, out bool isdoubledeck);

            //4. Do all checks if it can be added.
            return DoesRegNrExist(regNr, out message)
                ? ""
                : myGarage.AddVehicle(new Bus(regNr, color, numberofwheels, passengercapacity, fuel, manufacturer, modelyear, buscompany, isdoubledeck), out message)
                ? "Fordonet registrerat!"
                : "";
        }

        private string CheckIfRegNrAlreadyExists(string input, out string vehicleinfo)
        {
            if (IsRegNrParked(input.ToUpper(), out vehicleinfo))
                return "Detta fordon har parkerat här förr! \nVill du registrera samma fordon igen?";

            return "";

        }

        private static void GetBusValuesConverted(string[] convertedString, out string buscompany, out bool isdoubledeck)
        {
            buscompany = convertedString[7];
            isdoubledeck = (convertedString[8] == "J");
        }


        private static void GetTruckValuesConverted(string[] convertedString, out bool boogie, out bool sleepingcabin)
        {
            boogie = convertedString[7] == "J";
            sleepingcabin = convertedString[8] == "J";
        }

        private static void GetMopedValuesConverted(string[] convertedString, out bool ismopedclasstwo, out bool hashelmetbox)
        {
            ismopedclasstwo = convertedString[7] == "J";
            hashelmetbox = convertedString[8] == "J";
        }

        private static void GetMotorcycleValuesConverted(string[] convertedString, out MotorCycleType motorcycletype, out WeightClass weightclass)
        {
            motorcycletype = (MotorCycleType)Convert.ToInt32(convertedString[7]);
            weightclass = (WeightClass)Convert.ToInt32(convertedString[8]);
        }

        private static void GetCarValuesConverted(string[] convertedstring, out int noofdoors, out bool rails)
        {
            noofdoors = Convert.ToInt32(convertedstring[7]);
            rails = convertedstring[8] == "J";
        }

        private static void GetBasicValuesConverted(string[] convertedstring, out string regNr, out string color, out int numberofwheels, out int passengercapacity, out FuelType fuel, out string manufacturer, out int modelyear)
        {
            regNr = convertedstring[0];
            color = convertedstring[1];
            numberofwheels = Convert.ToInt32(convertedstring[2]);
            passengercapacity = Convert.ToInt32(convertedstring[3]);
            fuel = (FuelType)Convert.ToInt32(convertedstring[4]);
            manufacturer = convertedstring[5];
            modelyear = Convert.ToInt32(convertedstring[6]);
        }

        private static string IsSearchEmpty(string input) => string.IsNullOrEmpty(input) ? "Hittade ingenting." : "";

        public bool DoesRegNrExist(string regNr, out string errorMessage)
        {
            errorMessage = "";

            //Om inget reg nummer returnera alltid false.
            if (regNr == "******")
                return false;

            foreach (Vehicle item in myGarage)
            {
                if (SearchVehicle(regNr, out errorMessage) != "")
                {
                    errorMessage = "Registreringsnumret finns redan.";
                    return true;
                }
            }
            return false;
        }

        public bool IsRegNrParked(string regNr, out string vehicle)
        {
            vehicle = "";

            //Om inget reg nummer returnera alltid false.
            if (regNr == "******")
                return false;

            foreach (Vehicle item in myGarage.UnparkedVehicles)
            {
                if (item.RegNr == regNr)
                {
                    vehicle = item.ToString();
                    return true;
                }
            }
            return false;
        }
        public string SearchVehicle(string regNum, out string message)
        {
            string outputRegNum = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.RegNr.ToUpper().Contains(regNum.ToUpper()))
                {
                    outputRegNum += item + "\n\n";
                }
            }
            message = IsSearchEmpty(outputRegNum);
            return outputRegNum;
        }

        public string SearchByColor(string inputColor, out string message)
        {
            string outputColor = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.Color.ToUpper().Contains(inputColor.ToUpper()))
                {
                    outputColor += item + "\n\n";
                }
            }

            message = IsSearchEmpty(outputColor);
            return outputColor;
        }

        public string SearchByNrOfWheels(int inputNumberOfWheels, out string message)
        {
            string outputNumberOfWheels = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.NumberOfWheels == inputNumberOfWheels)
                {
                    outputNumberOfWheels += item + "\n\n";
                }
            }

            message = IsSearchEmpty(outputNumberOfWheels);
            return outputNumberOfWheels;
        }
        public string SearchByNrOfSeats(int inputSeats, out string message)
        {
            string outputSeats = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.PassengerCapacity == inputSeats)
                {
                    outputSeats += item + "\n\n";
                }
            }
            message = IsSearchEmpty(outputSeats);
            return outputSeats;
        }
        public string SearchByFuelType(string inputFuelType, out string message)
        {
            string outputFuelType = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.Fuel.ToString().ToUpper().Contains(inputFuelType.ToUpper()))
                {
                    outputFuelType += item + "\n\n";
                }
            }
            message = IsSearchEmpty(outputFuelType);
            return outputFuelType;
        }
        public string SearchByManufacturer(string manufacturer, out string message)
        {
            string outputManufacturer = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.Manufacturer.ToUpper().Contains(manufacturer.ToUpper()))
                {
                    outputManufacturer += item + "\n\n";
                }
            }
            message = IsSearchEmpty(outputManufacturer);
            return outputManufacturer;
        }
        public string SearchByReceiptNumber(int receiptNumber, out string message)
        {
            string outputReceiptNumber = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.ReceiptNumber == receiptNumber)
                {
                    outputReceiptNumber += item + "\n\n";
                }
            }
            message = IsSearchEmpty(outputReceiptNumber);
            return outputReceiptNumber;
        }

        public string SearchByModelYear(int modelYear, out string message)
        {
            string outputModelYear = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.ModelYear == modelYear)
                {
                    outputModelYear += item + "\n\n";
                }
            }
            message = IsSearchEmpty(outputModelYear);
            return outputModelYear;
        }

        // Metoder som tillhör MOPED-KLASSEN
        #region
        public string SearchByClass(string inputClass, out string message)
        {
            string outputClass = "";
            foreach (Vehicle item in myGarage)
            {
                if (item is Moped)
                {
                    if (inputClass == "J")
                    {
                        if ((item as Moped).IsMopedClassTwo)
                        {
                            outputClass += item + "\n\n";
                        }
                    }
                    else
                    {
                        if (!(item as Moped).IsMopedClassTwo)
                        {
                            outputClass += item + "\n\n";
                        }
                    }
                }
            }

            message = IsSearchEmpty(outputClass);
            return outputClass;
        }
        public string SearchByHelmetBox(string inputHelmetBox, out string message)
        {
            string outputHelmetBox = "";
            foreach (Vehicle item in myGarage)
            {
                if (item is Moped)
                {
                    if (inputHelmetBox == "J")
                    {
                        if ((item as Moped).HasHelmetBox)
                        {
                            outputHelmetBox += item + "\n\n";
                        }
                    }
                    else
                    {
                        if (!(item as Moped).HasHelmetBox)
                        {
                            outputHelmetBox += item + "\n\n";
                        }
                    }
                }
            }
            message = IsSearchEmpty(outputHelmetBox);
            return outputHelmetBox;
        }
        #endregion

        // Metoder som tillhör MOTORCYKEL-KLASSEN
        #region
        public string SearchByWeightclass(string inputWeightclass, out string message)
        {
            string outputWeightclass = "";
            foreach (Vehicle item in myGarage)
            {
                if (item is MotorCycle)
                {
                    if ((item as MotorCycle).WeightClass.ToString().ToUpper().Contains(inputWeightclass.ToUpper()))
                        outputWeightclass += item + "\n\n";
                }
            }
            message = IsSearchEmpty(outputWeightclass);
            return outputWeightclass;
        }
        public string SearchByType(string inputMcType, out string message)
        {
            string outputMcType = "";
            foreach (Vehicle item in myGarage)
            {
                if (item is MotorCycle)
                {
                    if ((item as MotorCycle).CycleType.ToString().ToUpper().Contains(inputMcType.ToUpper()))
                    {
                        outputMcType += item + "\n\n";
                    }
                }
            }

            message = IsSearchEmpty(outputMcType);
            return outputMcType;
        }
        #endregion

        // Metoder som tillhör BIL-KLASSEN
        #region
        public string SearchByRails(string inputRails, out string message)
        {
            string outputRails = "";
            foreach (Vehicle item in myGarage)
            {
                if (item is Car)
                {
                    if (inputRails == "J")
                    {
                        if ((item as Car).Rails)
                        {
                            outputRails += item + "\n\n";
                        }
                    }
                    else
                    {
                        if (!(item as Car).Rails)
                        {
                            outputRails += item + "\n\n";
                        }
                    }
                }
            }
            message = IsSearchEmpty(outputRails);
            return outputRails;
        }
        public string SearchByNrOfDoors(int inputNrOfDoors, out string message)
        {
            string outputNrOfDoors = "";
            foreach (Vehicle item in myGarage)
            {
                if (item is Car)
                {
                    if ((item as Car).NumberOfDoors == inputNrOfDoors)
                    {
                        outputNrOfDoors += item + "\n\n";
                    }
                }
            }
            message = IsSearchEmpty(outputNrOfDoors);
            return outputNrOfDoors;
        }
        #endregion

        // Metoder som tillhör BUSS-KLASSEN
        #region
        public string SearchByDoubleDecker(string inputDoubleDecker, out string message)
        {
            string outputDoubleDecker = "";
            foreach (Vehicle item in myGarage)
            {
                if (item is Bus)
                {
                    if (inputDoubleDecker == "J")
                    {
                        if ((item as Bus).IsDoubleDeck)
                        {
                            outputDoubleDecker += item + "\n\n";
                        }
                    }
                    else
                    {
                        if (!(item as Bus).IsDoubleDeck)
                        {
                            outputDoubleDecker += item + "\n\n";
                        }
                    }
                }
            }
            message = IsSearchEmpty(outputDoubleDecker);
            return outputDoubleDecker;
        }
        public string SearchByCompany(string inputCompany, out string message)
        {
            string outputCompany = "";
            foreach (Vehicle item in myGarage)
            {
                if (item is Bus)
                {
                    if ((item as Bus).BusCompany.ToString().ToUpper().Contains(inputCompany.ToUpper()))
                    {
                        outputCompany += item + "\n\n";
                    }
                }
            }

            message = IsSearchEmpty(outputCompany);
            return outputCompany;
        }
        #endregion

        // Metoder som tillhör LASTBIL-KLASSEN
        #region
        public string SearchByBoogie(string inputBoogie, out string message)
        {
            string outputBoogie = "";
            foreach (Vehicle item in myGarage)
            {
                if (item is Truck)
                {
                    if (inputBoogie == "J")
                    {
                        if ((item as Truck).Boogie)
                        {
                            outputBoogie += item + "\n\n";
                        }
                    }
                    else
                    {
                        if (!(item as Truck).Boogie)
                        {
                            outputBoogie += item + "\n\n";
                        }
                    }
                }
            }
            message = IsSearchEmpty(outputBoogie);
            return outputBoogie;
        }
        public string SearchBySleepingCabin(string inputCabin, out string message)
        {
            string outputCabin = "";
            foreach (Vehicle item in myGarage)
            {
                if (item is Truck)
                {
                    if (inputCabin == "J")
                    {
                        if ((item as Truck).SleepingCabin)
                        {
                            outputCabin += item + "\n\n";
                        }
                    }
                    else
                    {
                        if (!(item as Truck).SleepingCabin)
                        {
                            outputCabin += item + "\n\n";
                        }
                    }
                }
            }

            message = IsSearchEmpty(outputCabin);
            return outputCabin;
        }
        #endregion
    }
}
