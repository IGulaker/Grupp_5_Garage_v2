using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    class MotorCycle : Vehicle
    {
       public bool CycleType { get; set; }
        public bool WeightClass { get; set; }

        protected override string VehicleType()
        {
            return "Motorcykel";
        }
    }
}
