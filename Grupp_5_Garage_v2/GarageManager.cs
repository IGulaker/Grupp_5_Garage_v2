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

            myGarage.AddVehicle(new Car());
            myGarage.AddVehicle(new Moped());
            myGarage.AddVehicle(new Car());
            myGarage.AddVehicle(new Moped());
            myGarage.AddVehicle(new MotorCycle());
            myGarage.AddVehicle(new Bus());
            myGarage.AddVehicle(new Bus());
            myGarage.AddVehicle(new Car());
            myGarage.AddVehicle(new Truck());
        }

        public string GetVehicleType(int input) => input switch
        {
            1 => myGarage.ListVehicleTypeString<Car>(),
            2 => myGarage.ListVehicleTypeString<Moped>(),
            3 => myGarage.ListVehicleTypeString<MotorCycle>(),
            4 => myGarage.ListVehicleTypeString<Truck>(),
            5 => myGarage.ListVehicleTypeString<Bus>(),
            _ => null,
        };

        public void Setup()
        {

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


    }
}
