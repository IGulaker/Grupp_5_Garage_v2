using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    class GarageManager
    {
        public int ThisIsAnInt { get; set; }
        public Garage myGarage { get; set; }
        public GarageManager()
        {
            myGarage.AddVehicle(new Moped());
        }
        public string GetVehicleType(int input)
        {
            switch (input)
            {
                case 1: myGarage.GetVehicleTypeString<Car>();
                    break;
                case 2: myGarage.GetVehicleTypeString<Moped>();
                    break;
                case 3:myGarage.GetVehicleTypeString<MotorCycle>();
                    break;
                case 4: myGarage.GetVehicleTypeString<Truck>();
                    break;
                case 5: myGarage.GetVehicleTypeString<Bus>();
                    break;
                default:
                    break;
            }
            return null;
        }

        public void SetUp()
        {

        }
        public Garage LoadGarage()
        {
            return 0;
        }
        public void SaveGarage(Garage garage)
        {

        }
        public string SearchVehicle(string input)
        {
            if (input != null)
            {
                myGarage.AddVehicle(input);
            }

            return null;
        }
        public string SearchByColor(string input)
        {
            return null;
        }
        public string Manufacture(string input)
        {
            return null;
        }
        public int SearchByModelYear(int input)
        {
            return 0;
        }
        public int SearchByReceiptNumber(int input)
        {
            return 0;
        }
        public string ConvertToString(List<T> lista)
        {
            return "Convert to string";
        }
        public string CheckRegNr(string regNr)
        {
            SearchVehicle(regNr);

            return null;

        }
    }
}
