using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    public class MotorCycle : Vehicle
    {
        public MotorCycleType CycleType { get; set; }
        public WeightClass WeightClass { get; set; }

        public MotorCycle()
        {
            Random random = new();
            CycleType = (MotorCycleType)random.Next(0, Enum.GetNames(typeof(MotorCycleType)).Length);
            WeightClass = (WeightClass)random.Next(0, Enum.GetNames(typeof(WeightClass)).Length);
            Size = 1;
            NumberOfWheels = 2;
            PassengerCapacity = random.Next(2);
        }

        public MotorCycle(string regNr, string color, int numberOfWheels, int passengerCapacity, FuelType fuel, string manufacturer, int modelYear, MotorCycleType cycletype, WeightClass weightclass)
                : base(regNr, color, numberOfWheels, passengerCapacity, fuel, manufacturer, modelYear)
        {
            CycleType = cycletype;
            WeightClass = weightclass;
            Size = 1;
            if (PassengerCapacity > 1) PassengerCapacity = 1;
        }
        protected override string VehicleType => "Motorcykel";
        public override string ToString() => $"{GetFullInfo()}Motorcykelklass:{CycleType}\nViktklass: \t{WeightClass}";
    }
}
