﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle1
{
    class Truck : Vehicle 
    {
        public bool Boogie { get; set; }
        public bool SleepingCabin { get; set; }

    }
    public Truck()
    {

    }
    public Truck( ref Truck)
    {

    }
    public override string ToString()
    {
        return base.ToString();
    }
}
