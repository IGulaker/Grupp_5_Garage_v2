using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    class Bus : Vehicle
    {
        public string BusCompany { get; set; }
        public bool IsDoubleDeck { get; set; }

        public Bus()
        {
            Random random = new();
            BusCompany = "DSB - Det slumpmässiga bussbolaget";
            IsDoubleDeck = random.Next(2) == 0;
            Size = 4;
            NumberOfWheels = 4;
        }

        public Bus(string regNr, string color, int numberOfWheels, int passengerCapacity, FuelType fuel, string manufacturer, int modelYear, string busCompany, bool isDoubleDeck)
                : base(regNr, color, numberOfWheels, passengerCapacity, fuel, manufacturer, modelYear)
        {
            IsDoubleDeck = isDoubleDeck;
            BusCompany = busCompany;
            Size = 4;
        }

        protected override string VehicleType => "Buss";

        public override string ToString() => $"{GetFullInfo()}Bussbolag: \t{BusCompany}\nDubbeldäckare: \t{(IsDoubleDeck ? "Ja" : "Nej")}";
    }
}
