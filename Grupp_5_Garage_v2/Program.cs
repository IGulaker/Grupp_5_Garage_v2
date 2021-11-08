using System;

namespace Grupp_5_Garage_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Moped moped = new("ABC123", "röd", 2, 2, FuelType.Bensin, "BMW", 1873, false, true);
            Console.WriteLine(moped.GetBasicInfo());
            Console.WriteLine(moped.ToString());
        }
    }
}
