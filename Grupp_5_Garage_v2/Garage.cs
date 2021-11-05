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
        private List<T> unparkedvehicles = new();

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

        public string ListVehicleTypeString<U>() where U : T
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

        public List<T> UnparkedVehicles
        {
            get { return unparkedvehicles; }
        }



        public string ListVehicles()
        {
            string output = "";
            foreach (var item in ParkedVehicles)
            {
                output += item.GetBasicInfo() + "\n";
            }
            return output;
        }

        public bool AddVehicle(T inVehicle, out string errorMessage)
        {
            errorMessage = "";
            if (inVehicle != null)
            {
                ParkedVehicles.Add(inVehicle);
                return true;
            }
            return false;
        }


        public string SearchVehicle(string regNum)
        {
            throw new System.NotImplementedException();
        }

        public string SearchByColor()
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveVehicle(T vehicle)
        {

            parkedvehicles.Remove(vehicle);
            unparkedvehicles.Add(vehicle);
            return true;
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
