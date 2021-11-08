using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Grupp_5_Garage_v2
{
    [XmlInclude(typeof(Moped))]
    [XmlInclude(typeof(Truck))]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(MotorCycle))]
    [XmlInclude(typeof(Bus))]
    public abstract class Vehicle
    {
        private static int nextReceiptNumber = 1000;
        public string RegNr { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public int PassengerCapacity { get; set; }
        public FuelType Fuel { get; set; }
        public int Size { get; set; }
        public string Manufacturer { get; set; }
        public int ModelYear { get; set; }
        public int ReceiptNumber { get; set; }

        public Vehicle()
        {
            Random random = new();
            Fuel = (FuelType)random.Next(0, Enum.GetNames(typeof(FuelType)).Length);
            Color = ((Colors)random.Next(0, Enum.GetNames(typeof(Colors)).Length)).ToString();
            Manufacturer = ((RandomManufacturer)random.Next(0, Enum.GetNames(typeof(RandomManufacturer)).Length)).ToString();
            ModelYear = random.Next(1980, DateTime.Now.Year);
            ReceiptNumber = NextReceiptNumber;
            GetRandomRegNr();
            NextReceiptNumber++;
        }
        public Vehicle(string regNr, string color, int numberOfWheels, int passengerCapacity, FuelType fuel, string manufacturer, int modelYear)
        {
            RegNr = regNr;
            Color = color;
            NumberOfWheels = numberOfWheels;
            PassengerCapacity = passengerCapacity;
            Fuel = fuel;
            Manufacturer = manufacturer;
            ModelYear = modelYear;
            ReceiptNumber = NextReceiptNumber;
            NextReceiptNumber++;

        }
        private void GetRandomRegNr()
        {
            Random random = new();
            for (int i = 0; i < 3; i++)
            {
                char[] unAllowedLetters = { 'i', 'q', 'v' };
                char letter;
                do
                {
                    int num = random.Next(0, 26);
                    letter = (char)('a' + num);
                } while (unAllowedLetters.Contains(letter));
                RegNr += letter.ToString().ToUpper();
            }
            RegNr += random.Next(100).ToString("00");
            if (ModelYear >= 2019 && random.Next(2) == 0)
            {
                int num = random.Next(0, 26);
                char letter = (char)('a' + num);
                RegNr += letter.ToString().ToUpper();
            }
            else RegNr += random.Next(10);
        }
        public string GetBasicInfo()
        {
            return $"\t{RegNr}\t{VehicleType.PadRight(16).Substring(0, 16)} {Manufacturer.PadRight(15).Substring(0, 15)} Kvittonr: {ReceiptNumber}";
        }
        public string GetFullInfo()
        {
            return $"Reg.Nr:\t\t{RegNr}\nMärke:\t\t{Manufacturer}\nFordonstyp:\t{VehicleType}\nFärg:\t\t{Color}\nÅrsmodell:\t{ModelYear}\nDrivmedel:\t{Fuel}" +
                $"\nAntal hjul:\t{NumberOfWheels}\nPassagerare:\t{(PassengerCapacity>0 ? PassengerCapacity : "Inga")}\nKvittonummer:" +
                $"\t{ReceiptNumber}\n";
        }
        abstract protected string VehicleType { get; }
        public static int NextReceiptNumber { get => nextReceiptNumber; set => nextReceiptNumber = value; }
    }
}