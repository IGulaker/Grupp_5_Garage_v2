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
            }
        }

        private void CreateRandomVehicle()
        {
            Random r = new Random();
            int randomNumber = r.Next(1, 6);
            string message = "";
            switch (randomNumber)
            {
                case 1:
                    myGarage.AddVehicle(new Car(), out message);
                    break;
                case 2:
                    myGarage.AddVehicle(new Moped(), out message);
                    break;
                case 3:
                    myGarage.AddVehicle(new MotorCycle(), out message);
                    break;
                case 4:
                    myGarage.AddVehicle(new Bus(), out message);
                    break;
                case 5:
                    myGarage.AddVehicle(new Truck(), out message);
                    break;
            }
        }

        public string ReadUIInfo(ChoiceID choiceID, string input, out string message)
        {
            message = "";

            switch (choiceID)
            {
                case ChoiceID.CreateGarage:
                    break;
                case ChoiceID.LoadGarage:
                    break;
                case ChoiceID.AddVehicle:
                    AddVehicle(input, out message);
                    break;
                case ChoiceID.RemoveVehicle:
                    break;
                case ChoiceID.ListAllVehicles:
                    return myGarage.ListVehicles();
                case ChoiceID.ListCars:
                    return myGarage.ListVehicleTypeString<Car>();
                default:
                    break;
            }


            return "";
        }

        private bool AddVehicle(string input, out string message)
        {
            message = "";
            string[] substring = input.Split('_');

            if (substring.Length != 9)
            {
                message = "Fel antal skickade värden.";
                return false;
            }


            //string regNr, string color, int numberOfWheels, int passengerCapacity, FuelType fuel, string manufacturer, int modelYear, int numberofdoors, bool rails

            string regNr, color, manufacturer;
            int numberofwheels, passengercapacity, modelyear;
            int noofdoors;
            bool rails;
            FuelType fuel;
            GetBasicValuesConverted(substring, out regNr, out color, out numberofwheels, out passengercapacity, out fuel, out manufacturer, out modelyear);
            GetCarValuesConverted(substring, out noofdoors, out rails);

            if (DoesRegNrExist(regNr, out message))
                return false;

            if (myGarage.AddVehicle(new Car(regNr, color, numberofwheels, passengercapacity, fuel, manufacturer, modelyear, noofdoors, rails), out string errormessage))
                return true;
            else
            {
                message = errormessage;
                return false;
            }
        }

        private static void GetCarValuesConverted(string[] substring, out int noofdoors, out bool rails)
        {
            noofdoors = Convert.ToInt32(substring[7]);
            rails = (substring[8] == "J" ? true : false);
        }

        private static void GetBasicValuesConverted(string[] substring, out string regNr, out string color, out int numberofwheels, out int passengercapacity, out FuelType fuel, out string manufacturer, out int modelyear)
        {
            regNr = substring[0];
            color = substring[1];
            numberofwheels = Convert.ToInt32(substring[2]);
            passengercapacity = Convert.ToInt32(substring[3]);
            fuel = (FuelType)Convert.ToInt32(substring[4]);
            manufacturer = substring[5];
            modelyear = Convert.ToInt32(substring[6]);
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
