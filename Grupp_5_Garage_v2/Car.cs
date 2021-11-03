using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public bool Rails { get; set; }

        protected override string VehicleType => "Bil";

        public Car()
        {
            Random random = new();
            NumberOfDoors = random.Next(2, 5);
            Rails = random.Next(2) == 0;
            Size = 2;
            NumberOfWheels = 4;
        }

        public Car(string regNr, string color, int numberOfWheels, int passengerCapacity, FuelType fuel, string manufacturer, int modelYear, int numberofdoors, bool rails)
                : base(regNr, color, numberOfWheels, passengerCapacity, fuel, manufacturer, modelYear)
        {
            Rails = rails;
            NumberOfDoors = numberofdoors;
            Size = 2;
        }

        public override string ToString() => $"{GetFullInfo()}Antal dörrar: \t{NumberOfDoors}\nTakräcke: \t{(Rails ? "Ja" : "Nej")}";
    }
}
