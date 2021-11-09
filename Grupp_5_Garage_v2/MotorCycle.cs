using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    class MotorCycle : Vehicle
    public class MotorCycle : Vehicle
    {

        {
        }
        protected override string VehicleType => "Motorcykel";
        public override string ToString() => $"{GetFullInfo()}Motorcykelklass:{CycleType}\nViktklass: \t{WeightClass}";
    }
}
