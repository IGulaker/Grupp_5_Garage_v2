using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    class Car : Vehicle
    {
        public bool NumberOfDoors { get; set; }
        public bool Rails { get; set; }

        protected override string VehicleType()
        {
            return "Bil";
        }
    }
}
