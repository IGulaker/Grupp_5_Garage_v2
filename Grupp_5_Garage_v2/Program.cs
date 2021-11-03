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

            vehicle = new MotorCycle();
            TypeBasicInfo(vehicle);

            vehicle = new Bus();
            TypeBasicInfo(vehicle);

            vehicle = new Truck();
            TypeBasicInfo(vehicle);

            vehicle = new Moped();
            TypeBasicInfo(vehicle);
        }

        private static void TypeBasicInfo(Vehicle vehicle)
        {
            Console.WriteLine("");
            Console.WriteLine(vehicle.GetBasicInfo());
            Console.WriteLine(vehicle);
        }
    }
}
