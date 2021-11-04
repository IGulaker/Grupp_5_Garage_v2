using System;

namespace Grupp_5_Garage_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Moped moped = new("ABC123", "röd", 2, 2, FuelType.Bensin, "BMW", 1873, false, true);
            TypeBasicInfo(moped);

            Vehicle vehicle = new Car();
            TypeBasicInfo(vehicle);
            Console.WriteLine(vehicle.Size);

            vehicle = new MotorCycle();
            TypeBasicInfo(vehicle);
            Console.WriteLine(vehicle.Size);
            vehicle = new Bus("ABC123", "Blå", 6, 187, FuelType.Hybrid, "MAN", 2018, "Busspojken", true);
            TypeBasicInfo(vehicle);
            Console.WriteLine(vehicle.Size);
            vehicle = new Truck();
            TypeBasicInfo(vehicle);
            Console.WriteLine(vehicle.Size);
            vehicle = new Moped();
            TypeBasicInfo(vehicle);
            Console.WriteLine(vehicle.Size);

        }

        private static void TypeBasicInfo(Vehicle vehicle)
        {
            Console.WriteLine("");
            Console.WriteLine(vehicle.GetBasicInfo());
            Console.WriteLine(vehicle);
        }
    }
}
