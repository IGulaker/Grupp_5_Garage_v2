using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public int NumberOfParkingLots
        {
            get => default;
            set
            {
                NumberOfParkingLots = value;
            }
        }

        private List<T> parkedvehicles = new();

        public IEnumerator<T> GetEnumerator() => parkedvehicles.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => parkedvehicles.GetEnumerator();

        private List<U> GetVehicleType<U>() where U : T
        {
            List<U> newList = new();

            newList.AddRange(from T vehicle in parkedvehicles
                             where vehicle is U
                             select vehicle as U);

            return newList;
        }

        public string GetVehicleTypeString<U>() where U : T
        {
            List<U> newList = GetVehicleType<U>();

            string output = "";
            foreach (U item in newList)
            {
                output += item + "\n\n";
            }

            return output;
        }


        public List<T> ParkedVehicles
        {
            get { return parkedvehicles; }
        }

        public List<Vehicle> UnparkedVehicle
        {
            get => default;
            set
            {
            }
        }




        public void ListVehicles()
        {
            throw new System.NotImplementedException();
        }

        public void ListTypeOfVehicle()
        {
            throw new System.NotImplementedException();
        }

        public bool AddVehicle(T inVehicle)
        {
            if (inVehicle != null)
            {
                ParkedVehicles.Add(inVehicle);
                return true;
            }
            return false;
        }

        public bool RemoveVehicle()
        {
            throw new System.NotImplementedException();
        }

        public Vehicle SearchVehicle(string regNum)
        {
            throw new System.NotImplementedException();
        }

        public string SearchByColor()
        {
            throw new System.NotImplementedException();
        }

        public void SearchByModelYear(int model)
        {
            throw new System.NotImplementedException();
        }

        public void SearchByManufacturer(string manufacturer)
        {
            throw new System.NotImplementedException();
        }

        public void SearchByReceiptNumber(int receiptNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
