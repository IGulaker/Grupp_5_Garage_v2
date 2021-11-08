using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    public class Bus : Vehicle
    {
        public string BusCompany { get; set; }
        public bool IsDoubleDeck { get; set; }

        public Bus()
        {
            Random random = new();
            BusCompany = ((BusCompanies)random.Next(0, Enum.GetNames(typeof(BusCompanies)).Length)).ToString().Replace('_', ' ');
            IsDoubleDeck = random.Next(2) == 0;
            NumberOfWheels = 4;
            PassengerCapacity = (IsDoubleDeck) ? random.Next(60, 82) : random.Next(8, 60);
            Size = (PassengerCapacity > 30) ? 4 : 3;

        }

        public Bus(string regNr, string color, int numberOfWheels, int passengerCapacity, FuelType fuel, string manufacturer, int modelYear, string busCompany, bool isDoubleDeck)
                : base(regNr, color, numberOfWheels, passengerCapacity, fuel, manufacturer, modelYear)
        {
            IsDoubleDeck = isDoubleDeck;
            BusCompany = busCompany;
            if (PassengerCapacity > 60 && !IsDoubleDeck) PassengerCapacity = 60;
            else if (PassengerCapacity > 81 && IsDoubleDeck) PassengerCapacity = 81;
            Size = (PassengerCapacity > 30) ? 4 : 3;
        }

        public override string VehicleType => "Buss";

        public override string ToString() => $"{GetFullInfo()}Bussbolag: \t{BusCompany}\nDubbeldäckare: \t{(IsDoubleDeck ? "Ja" : "Nej")}";
    }
}
