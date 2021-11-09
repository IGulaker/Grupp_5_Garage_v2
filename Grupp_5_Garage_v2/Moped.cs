using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    public class Moped : Vehicle
    {
        public bool IsMopedClassTwo { get; set; }

        public bool HasHelmetBox { get; set; }

        public Moped()
        {
            Random random = new();
            IsMopedClassTwo = random.Next(2) == 0;
            HasHelmetBox = random.Next(2) == 0;
            PassengerCapacity = random.Next(2);
            Setup();
        }

        public Moped(string x)
        {
            throw new System.NotImplementedException();
        }

        public bool IsMopedClass
        {
            get => default;
            set
            {
            }
        }

        public bool HasHelmetBox
        {
            get => default;
            set
            {
            }
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}
