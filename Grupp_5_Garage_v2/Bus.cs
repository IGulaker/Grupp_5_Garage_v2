using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle1
{
    class Bus : Vehicle
    {
        public string BusCompany { get; set; }
        public bool IsDoubleDeck { get; set; }
        public Bus()
        {

        }
       

        public Bus(ref Bus)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
