using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    class Bus  : Vehicle
    {
        public bool BusCompany { get; set; } 
        public bool IsDoubleDeck { get; set; }

        protected override string VehicleType()
        {
            return "Buss";
        }
    }
}
