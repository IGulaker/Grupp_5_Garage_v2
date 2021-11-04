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


            //Garage garage = new Garage();
            //var garage1 = new Garage<object>();
            //garage1.AddVehicle(new Moped("BCD123", "Svart", 4, 5, FuelType.Diesel, "Audi", 2000, false, true));
            //garage1.AddVehicle(new Moped("AER123", "Röd", 4, 5, FuelType.Hybrid, "Bmw", 2010, true, false));
            //garage1.ListVehicles();
            //Console.WriteLine(garage1.ListTypeOfVehicle(1)); 

            Garage<Vehicle> garage = new Garage<Vehicle>();
            Moped moped1 = new Moped("ETT123", "Gul", 2, 2, FuelType.Bensin, "Yamaha", 1999, true, false);
            garage.AddVehicle(moped1);
            Moped moped2 = new Moped("TVÅ123", "Vit", 2, 2, FuelType.Bensin, "Suzuki", 1998, false, true);
            garage.AddVehicle(moped2);
            

        }
    }
}
