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
        public Garage<T> Next;
        public T Value;
        public int NumberOfParkingLots { get; set; }
        List<Vehicle> ParkedVehicles = new List<Vehicle>();
        List<Vehicle> UnParkedVehicles = new List<Vehicle>();


        public void ListVehicles()
        {
            foreach (Vehicle item in ParkedVehicles)
            {
                Console.WriteLine(item);
            }
        }

        public List<Vehicle> ListTypeOfVehicle(int test)
        {
            List<Vehicle> tempList = new List<Vehicle>();
            switch (test)
            {
                case 1:
                    foreach (Moped item in ParkedVehicles)
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
        public bool AddVehicle(Vehicle vehicle)
        {
            ParkedVehicles.Add(vehicle);
            return true;
        }

        public bool RemoveVehicle(Vehicle vehicle)
        {
            ParkedVehicles.Remove(vehicle);
            UnParkedVehicles.Add(vehicle);
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)ParkedVehicles).GetEnumerator();
        }
        public string GetVehicleTypeString()
        {
            GetVehicleType();
        }
    }
}
