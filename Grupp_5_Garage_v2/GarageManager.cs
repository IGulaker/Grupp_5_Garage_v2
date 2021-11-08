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

        private void CreateVehicles(int numberOfVehiclestoAdd)
        {
            for (int i = 0; i < numberOfVehiclestoAdd; i++)
            {
                CreateRandomVehicle();
                //string sendBus = "TRO623_Mörkblå_4_36_1_Stora Bussbyggarna_1997_X-Trafik_N";
                //AddBus(sendBus, out string heya);
            }
        }

        public void SaveGarage()
        {
            XMLUtilities.XMLFileSerialize(AppDomain.CurrentDomain.BaseDirectory + @"\ParkedVehicles.xml", myGarage);
            XMLUtilities.XMLFileSerialize(AppDomain.CurrentDomain.BaseDirectory + @"\UnParkedVehicles.xml", myGarage.UnparkedVehicles);

        }

        public void LoadGarage()
        {
            try
            {
                Vehicle.NextReceiptNumber = 1000;
                myGarage = XMLUtilities.XMLFileDeserialize<Garage<Vehicle>>(AppDomain.CurrentDomain.BaseDirectory + @"\ParkedVehicles.xml");
                myGarage.UnparkedVehicles = XMLUtilities.XMLFileDeserialize<List<Vehicle>>(AppDomain.CurrentDomain.BaseDirectory + @"\UnParkedVehicles.xml");
                myGarage.SetCorrectReceiptNumber();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }

        private void CreateRandomVehicle()
        {
            Random r = new Random();
            int randomNumber = r.Next(1, 100);
            bool done = false;
            string message;
            switch (randomNumber)
            {
                case > 0 and <= 51:
                    done = myGarage.AddVehicle(new Car(), out message);
                    break;
                case > 51 and <= 63:
                    done = myGarage.AddVehicle(new Moped(), out message);
                    break;
                case > 63 and <= 75:
                    done = myGarage.AddVehicle(new MotorCycle(), out message);
                    break;
                case > 75 and <= 87:
                    done = myGarage.AddVehicle(new Bus(), out message);
                    break;
                case > 87:
                    done = myGarage.AddVehicle(new Truck(), out message);
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
                    break;
                case ChoiceID.RemoveVehicle:
                    return RemoveVehicle(input.ToUpper(), out message);
                case ChoiceID.ListAllVehicles:
                    return myGarage.ListVehicles();
                case ChoiceID.ListCars:
                    return myGarage.ListVehicleTypeString<Car>();
                case ChoiceID.ListBuses:
                    return myGarage.ListVehicleTypeString<Bus>();
                case ChoiceID.ListTrucks:
                    return myGarage.ListVehicleTypeString<Truck>();
                case ChoiceID.ListMopeds:
                    return myGarage.ListVehicleTypeString<Moped>();
                case ChoiceID.ListMotorcycles:
                    return myGarage.ListVehicleTypeString<MotorCycle>();
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
                    return SearchByBoogie(input);
                case ChoiceID.SearchByClass:
                    return SearchByClass(input);
                case ChoiceID.SearchByColour:
                    return SearchByColor(input);
                case ChoiceID.SearchByCompany:
                    return SearchByCompany(input);
                case ChoiceID.SearchByDoubleDecker:
                    return SearchByDoubleDecker(input);
                case ChoiceID.SearchByFuelType:
                    return SearchByFuelType(input);
                case ChoiceID.SearchByHelmetBox:
                    return SearchByHelmetBox(input);
                case ChoiceID.SearchByManufacturer:
                    return SearchByManufacturer(input);
                case ChoiceID.SearchByNrOfDoors:
                    return SearchByNrOfDoors(Convert.ToInt32(input));
                case ChoiceID.SearchByNrOfSeats:
                    return SearchByNrOfSeats(Convert.ToInt32(input));
                case ChoiceID.SearchByNrOfWheels:
                    return SearchByNrOfWheels(Convert.ToInt32(input));
                case ChoiceID.SearchByRail:
                    return SearchByRails(input);
                case ChoiceID.SearchByReceieptNr:
                    return SearchByReceiptNumber(Convert.ToInt32(input));
                case ChoiceID.SearchByRegNr:
                    return SearchVehicle(input);
                case ChoiceID.SearchBySleepingCabin:
                    return SearchBySleepingCabin(input);
                case ChoiceID.SearchByType:
                    return SearchByType(input);
                case ChoiceID.SearchByWeightclass:
                    return SearchByWeightclass(input);
                case ChoiceID.SearchByYearModel:
                    return SearchByModelYear(Convert.ToInt32(input));
                default:
                    break;
            }


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

        private void GetBusValuesConverted(string[] convertedString, out string buscompany, out bool isdoubledeck)
        {
            buscompany = convertedString[7];
            isdoubledeck = (convertedString[8] == "J" ? true : false);
        }


        private void GetTruckValuesConverted(string[] convertedString, out bool boogie, out bool sleepingcabin)
        {
            boogie = (convertedString[7] == "J" ? true : false);
            sleepingcabin = (convertedString[8] == "J" ? true : false);
        }

        private void GetMopedValuesConverted(string[] convertedString, out bool ismopedclasstwo, out bool hashelmetbox)
        {
            ismopedclasstwo = (convertedString[7] == "J" ? true : false);
            hashelmetbox = (convertedString[8] == "J" ? true : false);
        }

        private void GetMotorcycleValuesConverted(string[] convertedString, out MotorCycleType motorcycletype, out WeightClass weightclass)
        {
            motorcycletype = (MotorCycleType)Convert.ToInt32(convertedString[7]);
            weightclass = (WeightClass)Convert.ToInt32(convertedString[8]);
        }

        private void GetCarValuesConverted(string[] convertedstring, out int noofdoors, out bool rails)
        {
            noofdoors = Convert.ToInt32(convertedstring[7]);
            rails = (convertedstring[8] == "J" ? true : false);
        }



        private void GetBasicValuesConverted(string[] convertedstring, out string regNr, out string color, out int numberofwheels, out int passengercapacity, out FuelType fuel, out string manufacturer, out int modelyear)
        {
            regNr = convertedstring[0];
            color = convertedstring[1];
            numberofwheels = Convert.ToInt32(convertedstring[2]);
            passengercapacity = Convert.ToInt32(convertedstring[3]);
            fuel = (FuelType)Convert.ToInt32(convertedstring[4]);
            manufacturer = convertedstring[5];
            modelyear = Convert.ToInt32(convertedstring[6]);
        }

        public bool DoesRegNrExist(string regNr, out string errorMessage)
        {
            errorMessage = "";

            //Om inget reg nummer returnera alltid false.
            if (regNr == "******")
                return false;

            foreach (Vehicle item in myGarage)
            {
                if (SearchVehicle(regNr) != "")
                {
                    errorMessage = "Registreringsnumret finns redan.";
                    return true;
                }
            }
            return false;
        }
        public string SearchVehicle(string regNum)
        {
            string outputRegNum = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.RegNr.ToUpper().Contains(regNum.ToUpper()))
                {
                    outputRegNum += item + "\n\n";
                }
            }
            return outputRegNum;
        }

        public string SearchByColor(string inputColor)
        {
            string outputColor = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.Color.ToUpper().Contains(inputColor.ToUpper()))
                {
                    outputColor += item + "\n\n";
                }
            }
            return outputColor;
        }

        public string SearchByNrOfWheels(int inputNumberOfWheels)
        {
            string outputNumberOfWheels = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.NumberOfWheels == inputNumberOfWheels)
                {
                    outputNumberOfWheels += item + "\n\n";
                }
            }
            return outputNumberOfWheels;
        }
        public string SearchByNrOfSeats(int inputSeats)
        {
            string outputSeats = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.PassengerCapacity == inputSeats)
                {
                    outputSeats += item + "\n\n";
                }
            }
            return outputSeats;
        }
        public string SearchByFuelType(string inputFuelType)
        {
            string outputFuelType = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.Fuel.ToString().ToUpper().Contains(inputFuelType.ToUpper()))
                {
                    outputFuelType += item + "\n\n";
                }
            }
            return outputFuelType;
        }
        public string SearchByManufacturer(string manufacturer)
        {
            string outputManufacturer = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.Manufacturer.ToUpper().Contains(manufacturer.ToUpper()))
                {
                    outputManufacturer += item + "\n\n";
                }
            }
            return outputManufacturer;
        }
        public string SearchByReceiptNumber(int receiptNumber)
        {
            string outputReceiptNumber = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.ReceiptNumber == receiptNumber)
                {
                    outputReceiptNumber += item + "\n\n";
                }
            }
            return outputReceiptNumber;
        }

        public string SearchByModelYear(int modelYear)
        {
            string outputModelYear = "";
            foreach (Vehicle item in myGarage)
            {
                if (item.ModelYear == modelYear)
                {
                    outputModelYear += item + "\n\n";
                }
            }
            return outputModelYear;
        }

        // Metoder som tillhör MOPED-KLASSEN
        #region
        // Måste göras klart med bool
        public string SearchByClass(string inputClass)
        {
            string outputClass = "";
            foreach (Vehicle item in myGarage)
            {
                if (item is Moped)
                {
                    if ((item as Moped).IsMopedClassTwo.ToString().ToUpper().Contains(inputClass.ToUpper()))
                    {
                        outputClass += item + "\n\n";
                    }

                }
            }
            return outputClass;
        }

        // Måste göras klart med bool
        public string SearchByHelmetBox(string inputHelmetBox)
        {
            string outputHelmetBox = "";
            foreach (Vehicle item in myGarage)
            {
                if (item is Moped)
                {
                    if ((item as Moped).HasHelmetBox.ToString().ToUpper().Contains(inputHelmetBox.ToUpper()))
                    {
                        outputHelmetBox += item + "\n\n";
                    }

                }

            }
            return outputHelmetBox;
        }
        #endregion

        // Metoder som tillhör MOTORCYKEL-KLASSEN
        #region
        public string SearchByWeightclass(string inputWeightclass)
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

            return outputWeightclass;
        }
        public string SearchByType(string inputMcType)
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
            return outputMcType;
        }
        #endregion

        // Metoder som tillhör BIL-KLASSEN
        #region
        // Ändra till bool
        public string SearchByRails(string inputRails)
        {
            string outputRails = "";
            foreach (Vehicle item in myGarage)
            {
                if (item is Car)
                {
                    if ((item as Car).Rails.ToString().ToUpper().Contains(inputRails.ToUpper()))
                    {
                        outputRails += item + "\n\n";
                    }

                }
            }
            return outputRails;
        }
        public string SearchByNrOfDoors(int inputNrOfDoors)
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
            return outputNrOfDoors;
        }
        #endregion

        // Metoder som tillhör BUSS-KLASSEN
        #region
        // Ändra till Bool
        public string SearchByDoubleDecker(string inputDoubleDecker)
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
            return outputDoubleDecker;
        }
        public string SearchByCompany(string inputCompany)
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
            return outputCompany;
        }
        #endregion

        // Metoder som tillhör LASTBIL-KLASSEN
        #region
        // Ändra till Bool
        public string SearchByBoogie(string inputBoogie)
        {
            string outputBoogie = "";
            foreach (Vehicle item in myGarage)
            {
                if (item is Truck)
                {
                    if ((item as Truck).Boogie.ToString().ToUpper().Contains(inputBoogie.ToUpper()))
                    {
                        outputBoogie += item + "\n\n";
                    }
                }
            }
            return outputBoogie;
        }
        // Ändra till Bool
        public string SearchBySleepingCabin(string inputCabin)
        {
            string outputCabin = "";
            foreach (Vehicle item in myGarage)
            {
                if (item is Truck)
                {
                    if ((item as Truck).SleepingCabin.ToString().ToUpper().Contains(inputCabin.ToUpper()))
                    {
                        outputCabin += item + "\n\n";
                    }
                }

            }
            return outputCabin;
        }
        #endregion

    }
}
