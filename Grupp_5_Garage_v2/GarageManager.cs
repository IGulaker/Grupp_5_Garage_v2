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

        public void Setup()
        {
            CreateVehicles(500);
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
            XMLUtilities.XMLFileSerialize(AppDomain.CurrentDomain.BaseDirectory + @"\Garage.xml", myGarage);
        }

        public void LoadGarage()
        {
            try
            {
                myGarage = XMLUtilities.XMLFileDeserialize<Garage<Vehicle>>(AppDomain.CurrentDomain.BaseDirectory + @"\Garage.xml");
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
            int randomNumber = r.Next(1, 6);
            bool done = false;
            do
            {
                string message;
                switch (randomNumber)
                {
                    case 1:
                        done = myGarage.AddVehicle(new Car(), out message);
                        break;
                    case 2:
                        done = myGarage.AddVehicle(new Moped(), out message);
                        break;
                    case 3:
                        done = myGarage.AddVehicle(new MotorCycle(), out message);
                        break;
                    case 4:
                        done = myGarage.AddVehicle(new Bus(), out message);
                        break;
                    case 5:
                        done = myGarage.AddVehicle(new Truck(), out message);
                        break;
                }
            } while (!done);

        }

        public string ReadUIInfo(ChoiceID choiceID, string input, out string message)
        {
            message = "";

            switch (choiceID)
            {
                case ChoiceID.CreateGarage:
                    SaveGarage();
                    break;
                case ChoiceID.LoadGarage:
                    LoadGarage();
                    break;
                case ChoiceID.AddVehicle:
                    break;
                case ChoiceID.RemoveVehicle:
                    AddMotorcycle(input, out message);
                    break;
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
                case ChoiceID.ListMotorCycles:
                    return myGarage.ListVehicleTypeString<MotorCycle>();
                default:
                    break;
            }


            return "";
        }

        private bool AddMoped(string input, out string message)
        {
            //1. Set up variables
            string[] ConvertedString = input.Split('_');


            //2. Check to see that we have enough values.
            if (ConvertedString.Length != 9)
            {
                message = "Fel antal skickade värden.";
                return false;
            }

            //3. Convert the values to correct types
            GetBasicValuesConverted(ConvertedString, out string regNr, out string color, out int numberofwheels, out int passengercapacity, out FuelType fuel, out string manufacturer, out int modelyear);
            GetMopedValuesConverted(ConvertedString, out bool ismopedclasstwo, out bool hashelmetbox);

            //4. Do all checks if it can be added.
            return DoesRegNrExist(regNr, out message)
                ? false
                : myGarage.AddVehicle(new Moped(regNr, color, numberofwheels, passengercapacity, fuel, manufacturer, modelyear, ismopedclasstwo, hashelmetbox), out message);
        }

        private bool AddMotorcycle(string input, out string message)
        {
            //1. Set up variables
            string[] ConvertedString = input.Split('_');


            //2. Check to see that we have enough values.
            if (ConvertedString.Length != 9)
            {
                message = "Fel antal skickade värden.";
                return false;
            }

            //3. Convert the values to correct types
            GetBasicValuesConverted(ConvertedString, out string regNr, out string color, out int numberofwheels, out int passengercapacity, out FuelType fuel, out string manufacturer, out int modelyear);
            GetMotorcycleValuesConverted(ConvertedString, out MotorCycleType motorcycletype, out WeightClass weightclass);

            //4. Do all checks if it can be added.
            return DoesRegNrExist(regNr, out message)
                ? false
                : myGarage.AddVehicle(new MotorCycle(regNr, color, numberofwheels, passengercapacity, fuel, manufacturer, modelyear, motorcycletype, weightclass), out message);
        }

        private bool AddTruck(string input, out string message)
        {
            //1. Set up variables
            string[] ConvertedString = input.Split('_');


            //2. Check to see that we have enough values.
            if (ConvertedString.Length != 9)
            {
                message = "Fel antal skickade värden.";
                return false;
            }

            //3. Convert the values to correct types
            GetBasicValuesConverted(ConvertedString, out string regNr, out string color, out int numberofwheels, out int passengercapacity, out FuelType fuel, out string manufacturer, out int modelyear);
            GetTruckValuesConverted(ConvertedString, out bool boogie, out bool sleepingcabin);

            //4. Do all checks if it can be added.
            return DoesRegNrExist(regNr, out message)
                ? false
                : myGarage.AddVehicle(new Truck(regNr, color, numberofwheels, passengercapacity, fuel, manufacturer, modelyear, boogie, sleepingcabin), out message);
        }

        private bool AddCar(string input, out string message)
        {
            //1. Set up variables
            string[] ConvertedString = input.Split('_');

            //2. Check to see that we have enough values.
            if (ConvertedString.Length != 9)
            {
                message = "Fel antal skickade värden.";
                return false;
            }

            //3. Convert the values to correct types
            GetBasicValuesConverted(ConvertedString, out string regNr, out string color, out int numberofwheels, out int passengercapacity, out FuelType fuel, out string manufacturer, out int modelyear);
            GetCarValuesConverted(ConvertedString, out int noofdoors, out bool rails);

            //4. Do all checks if it can be added.
            return DoesRegNrExist(regNr, out message)
                ? false
                : myGarage.AddVehicle(new Car(regNr, color, numberofwheels, passengercapacity, fuel, manufacturer, modelyear, noofdoors, rails), out message);
        }

        private bool AddBus(string input, out string message)
        {
            //1. Set up variables
            string[] ConvertedString = input.Split('_');

            //2. Check to see that we have enough values.
            if (ConvertedString.Length != 9)
            {
                message = "Fel antal skickade värden.";
                return false;
            }


            //3. Convert the values to correct types
            GetBasicValuesConverted(ConvertedString, out string regNr, out string color, out int numberofwheels, out int passengercapacity, out FuelType fuel, out string manufacturer, out int modelyear);
            GetBusValuesConverted(ConvertedString, out string buscompany, out bool isdoubledeck);

            //4. Do all checks if it can be added.
            return DoesRegNrExist(regNr, out message)
                ? false
                : myGarage.AddVehicle(new Bus(regNr, color, numberofwheels, passengercapacity, fuel, manufacturer, modelyear, buscompany, isdoubledeck), out message);
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

        private static void GetCarValuesConverted(string[] convertedstring, out int noofdoors, out bool rails)
        {
            noofdoors = Convert.ToInt32(convertedstring[7]);
            rails = (convertedstring[8] == "J" ? true : false);
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

        public bool DoesRegNrExist(string regNr, out string errorMessage)
        {
            errorMessage = "";

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
                if (item.RegNr.Contains(regNum))
                {
                    outputRegNum += item.GetFullInfo();
                }
            }

            return outputRegNum;
        }

        public string SearchByColor(string inputColor)
        {
            string outputColor = "";

            foreach (Vehicle item in myGarage)
            {
                if (item.Color.Contains(inputColor))
                {
                    outputColor += item.GetFullInfo();
                }
            }
            return outputColor;
        }
    }
}
