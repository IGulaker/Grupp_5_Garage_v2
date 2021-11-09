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
        public int NumberOfParkingLots
        {
            get => numberOfParkingLots; set => numberOfParkingLots = value < 10000 ? value : 10000;
        }


        private List<T> parkedvehicles = new();
        private List<T> unparkedvehicles = new();
        private int numberOfParkingLots;
        private int SizeOfParkedVehicles { get; set; }

        public IEnumerator<T> GetEnumerator() => parkedvehicles.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => parkedvehicles.GetEnumerator();

        public Garage()
        {
            NumberOfParkingLots = 5000;

        }

        public bool IsFull() => SizeOfParkedVehicles >= NumberOfParkingLots;

        public void Add(T value)
        {
            parkedvehicles.Add(value);
            //SizeOfParkedVehicles += value.Size;
        }

        public void GetRidOfDuplicateRegNr()
        {
            //Moped är special case så ta dem åt sidan så länge.
            List<T> tempVehicles = (parkedvehicles.Where(item => item.RegNr == "******")).ToList();
            parkedvehicles.RemoveAll(i => i.RegNr == "******");


            parkedvehicles = parkedvehicles.GroupBy(x => x.RegNr)
                .Select(x => x.First())
                .ToList();
            parkedvehicles.AddRange(tempVehicles);
            parkedvehicles = parkedvehicles.OrderBy(x => x.ReceiptNumber).ToList();

        }

        public void SetSize()
        {
            SizeOfParkedVehicles = 0;
            foreach (T item in parkedvehicles)
            {
                SizeOfParkedVehicles += item.Size;
            }
        }

        private List<U> GetVehicleType<U>() where U : T
        {
            List<U> newList = new();

            newList.AddRange(from T vehicle in parkedvehicles
                             where vehicle is U
                             select vehicle as U);

            return newList;
        }

        public int CountVehicle<U>() where U : T => GetVehicleType<U>().Count;

        public string ListVehicleTypeString<U>(out string message) where U : T
        {
            message = "";
            string header = "";
            List<U> newList = GetVehicleType<U>();

            string output = "";
            foreach (U item in newList)
            {
                output += item.GetBasicInfo() + "\n";
            }

            if (string.IsNullOrEmpty(output))
                message = "Hittade inga fordon.";
            else
            {
                //Moped är ett special case
                header = $"\n\t{(newList[0].VehicleType.Contains("Moped") ? "Moped" : newList[0].VehicleType)}: {CountVehicle<U>()} st.\n\n";
            }

            return header + output;
        }

        public void SetCorrectReceiptNumberAfterLoading() => Vehicle.NextReceiptNumber = ParkedVehicles[parkedvehicles.Count - 1].ReceiptNumber + 1;

        public List<T> ParkedVehicles => parkedvehicles;

        public List<T> UnparkedVehicles
        {
            get { return unparkedvehicles; }
            set { unparkedvehicles = value; }
        }



        public string ListVehicles(out string message)
        {
            message = "";
            string output = "";
            foreach (var item in ParkedVehicles)
            {
                output += item.GetBasicInfo() + "\n";
            }

            if (string.IsNullOrEmpty(output))
                message = "Hittade inga fordon.";



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
                    Vehicle.NextReceiptNumber--;
                    errorMessage = $"Garaget är fullt. Kan inte ta emot din {inVehicle.VehicleType}";
                    return false;
                }
            }
            errorMessage = "Kunde inte lägga till fordonet.";
            return false;
        }


        public bool ReaddVehicle(string regnrin, out string errormessage, out string vehicleinfo)
        {
            T vehicle = GetUnparkedVehicleWithRegNr(regnrin);
            errormessage = "";
            vehicleinfo = "";
            if (vehicle != null)
            {
                if (!(vehicle.Size + SizeOfParkedVehicles > NumberOfParkingLots))
                {
                    unparkedvehicles.Remove(vehicle);
                    vehicle.GetNewReceiptNumber();
                    parkedvehicles.Add(vehicle);
                    SizeOfParkedVehicles += vehicle.Size;
                    vehicleinfo = vehicle.ToString();
                    return true;
                }
                else
                {
                    errormessage = $"Garaget är fullt. Kan inte ta emot din {vehicle.VehicleType}";
                    return false;
                }

            }
            errormessage = "Kunde inte hitta ditt fordon.";
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

        public T GetVehicleWithReceipt(string receiptnumber)
        {
            foreach (var item in ParkedVehicles)
            {
                if (item.ReceiptNumber.ToString() == receiptnumber)
                    return item;
            }

            return null;
        }

        public T GetVehicleWithRegNr(string regnr)
        {
            if (regnr == "******")
                return null;

            foreach (var item in ParkedVehicles)
            {
                if (item.RegNr == regnr)
                    return item;
            }

            return null;
        }

        public T GetUnparkedVehicleWithRegNr(string regnr)
        {
            if (regnr == "******")
                return null;

            foreach (var item in UnparkedVehicles)
            {
                if (item.RegNr == regnr)
                    return item;
            }

            return null;
        }

        public override string ToString()
        {
            return $"Garagestorlek: \t\t{NumberOfParkingLots}\nAnvänd storlek: \t{SizeOfParkedVehicles}";
        }
    }
}
