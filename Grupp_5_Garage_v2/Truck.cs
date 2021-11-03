using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    class Truck : Vehicle 
    {
        public bool Boogie { get; set; }
        public bool SleepingCabin { get; set; }

        protected override string VehicleType()
        {
            return "Lastbil";
        }
    }
}
