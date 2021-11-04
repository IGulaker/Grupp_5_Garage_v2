using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    public class Garage<T> : IEnumerable<T> where T: Vehicle
    {
        public int NumberOfParkingLots { get; set; }

        List<T> parkedVehicles = new List<T>();
        List<T> unParkedVehicles = new List<T>();

        public IEnumerator<T> GetEnumerator()
        {
            return parkedVehicles.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return parkedVehicles.GetEnumerator();
        }


        public void ListVehicles()
        {
            foreach (Vehicle item in parkedVehicles)
            {
                Console.WriteLine(item);
            }
        }

        public List<T> ListTypeOfVehicle(int test)
        {
            List<T> tempList = new List<T>();
            switch (test)
            {
                case 1:
                    foreach (T item in parkedVehicles)
                    {
                        tempList.Add(item);
                        GarageManager garageManager = new GarageManager();
                        garageManager.ConvertToString(tempList);
                    }

                    break;
                default:
                    break;
            }

            return tempList;
        }
        public bool AddVehicle(T vehicleRegNr)
        {
            if (vehicleRegNr != null)
            {
                parkedVehicles.Add(vehicleRegNr);
                return true;
            }
            else
            {
                unParkedVehicles.Add(vehicleRegNr);
            }

            return false;
        }

        public bool RemoveVehicle(T vehicle)
        {
            parkedVehicles.Remove(vehicle);
            unParkedVehicles.Add(vehicle);
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)parkedVehicles).GetEnumerator();
        }
        public string GetVehicleTypeString()
        {
            //GetVehicleType();
            return null;
        }
    }
}
