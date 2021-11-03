using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    internal class Moped : Vehicle
    {
        public bool IsMopedClassTwo { get; set; }

        public bool HasHelmetBox { get; set; }

        public Moped() : base()
        {
            Random random = new();
            IsMopedClassTwo = random.Next(2) == 0;
            HasHelmetBox = random.Next(2) == 0;
            Size = 1;
            NumberOfWheels = 2;
            if (IsMopedClassTwo) RegNr = "*REGISTRERINGSNUMMER SAKNAS*";
        }

        public Moped(string regNr, string color, int numberOfWheels, int passengerCapacity, FuelType fuel, string manufacturer, int modelYear,
            bool isMopedClassTwo, bool hasHelmetBox) 
            : base(regNr, color, numberOfWheels, passengerCapacity, fuel, manufacturer, modelYear)
        {
            IsMopedClassTwo = isMopedClassTwo;
            HasHelmetBox = hasHelmetBox;
            Size = 1;
            if (IsMopedClassTwo) RegNr = "*REGISTRERINGSNUMMER SAKNAS*";
        }

        public override string ToString()
        {
            return $"{this.GetFullInfo()}Hjälmförvaring: {(HasHelmetBox ? "Ja": "Nej")}";
        }

        protected override string VehicleType()
        {
            return $"Moped klass {(IsMopedClassTwo ? "I" : "II" )}";
        }
    }
}
