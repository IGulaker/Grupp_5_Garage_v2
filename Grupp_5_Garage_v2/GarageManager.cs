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


        public int ThisIsAnInt { get; set; }

        public GarageManager()
        {
            myGarage = new Garage<Vehicle>();

            myGarage.AddVehicle(new Car());
            myGarage.AddVehicle(new Moped());
            myGarage.AddVehicle(new Car());
        }

        public string GetVehicleTypeString(int input)
        {
            string output = "";

            foreach (Vehicle item in myGarage)
            {

                switch (input)
                {
                    case 1:
                        return myGarage.GetVehicleTypeString<Car>();
                    case 2:
                        return myGarage.GetVehicleTypeString<Moped>();
                    case 3:
                        return myGarage.GetVehicleTypeString<MotorCycle>();
                    default:
                        break;
                }
            }



            return output;
        }



    }
}
