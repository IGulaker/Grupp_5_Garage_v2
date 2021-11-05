using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle1
{
    class MotorCycle : Vehicle
    {
       public bool CycleType { get; set; }
        public bool WeightClass { get; set; }
    }
    public MotorCycle()
    {

    }
    public MotorCycle(ref MotorCycle)
    {

    }
    public override string ToString()
    {
        return base.ToString();
    }
}
