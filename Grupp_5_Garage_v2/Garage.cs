using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    [Serializable]
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public int NumberOfParkingLots { get => numberOfParkingLots; set => numberOfParkingLots = value; }


        private List<T> parkedvehicles = new();
        private List<T> unparkedvehicles = new();
        private int numberOfParkingLots;
        private int SizeOfParkedVehicles { get; set; }

        public IEnumerator<T> GetEnumerator() => parkedvehicles.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => parkedvehicles.GetEnumerator();

        public Garage()
        {
            NumberOfParkingLots = 5000;
            SetCorrectReceiptNumber();

        }

        public void SetCorrectReceiptNumber()
        {
            int nextreceiptnumber = 1000;
            foreach (var item in parkedvehicles)
            {
                if (item.ReceiptNumber > nextreceiptnumber)
                    nextreceiptnumber = item.ReceiptNumber + 1;
            }
            foreach (var item in unparkedvehicles)
            {
                if (item.ReceiptNumber > nextreceiptnumber)
                    nextreceiptnumber = item.ReceiptNumber + 1;
            }
            Vehicle.NextReceiptNumber = nextreceiptnumber;
        }

        public void Add(T value)
        {
            parkedvehicles.Add(value);
        }

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
                output += item.GetBasicInfo() + "\n";
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
            set { unparkedvehicles = value; }
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
                if (!(inVehicle.Size + SizeOfParkedVehicles > NumberOfParkingLots))
                {
                    ParkedVehicles.Add(inVehicle);
                    SizeOfParkedVehicles += inVehicle.Size;
                    return true;
                }
                else
                {
                    errorMessage = $"Garaget är fullt. Kan inte ta emot din {inVehicle.VehicleType}";
                    return false;
                }
            }
            errorMessage = "Kunde inte lägga till fordonet.";
            return false;
        }


        public bool RemoveVehicle(T vehicle, out string errormessage)
        {
            errormessage = "";
            if (vehicle != null)
            {

                parkedvehicles.Remove(vehicle);
                unparkedvehicles.Add(vehicle);
                SizeOfParkedVehicles -= vehicle.Size;
                return true;
            }
            errormessage = "Kunde inte hitta ditt fordon.";
            return false;
        }
    }
}
