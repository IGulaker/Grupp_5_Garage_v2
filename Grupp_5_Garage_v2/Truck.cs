using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    public class Truck : Vehicle 
    {
        public bool Boogie { get; set; }
        public bool SleepingCabin { get; set; }

        public override string VehicleType => "Lastbil";

        public Truck()
        {
            Random random = new();
            Boogie = random.Next(2) == 0;
            SleepingCabin = random.Next(2) == 0;
            Size = 4;
            NumberOfWheels = random.Next(4,7);
            PassengerCapacity = random.Next(1,9);
        }

        public Truck(string regNr, string color, int numberOfWheels, int passengerCapacity, FuelType fuel, string manufacturer, int modelYear, bool boogie, bool sleepingcabin)
                : base(regNr, color, numberOfWheels, passengerCapacity, fuel, manufacturer, modelYear)
        {
            Boogie = boogie;
            SleepingCabin = sleepingcabin;
            Size = 4;
            if (PassengerCapacity > 9) PassengerCapacity = 9;
        }

        public override string ToString() => $"{GetFullInfo()}Boggi: \t\t{(Boogie ? "Ja" : "Nej")}\nSovkabin: \t{(SleepingCabin ? "Ja" : "Nej")}";
    }
}
