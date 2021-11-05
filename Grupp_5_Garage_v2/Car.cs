using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle1
{
    class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public bool Rails { get; set; }
        
    }

    public Car()
    {

    }
    public Car( ref  Car)
    {

    }
    public override string ToString()
    {
        return base.ToString();
    }
}
