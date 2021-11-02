using System;

namespace Grupp_5_Garage_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                Vehicle myVehicle = new Vehicle();
                Console.WriteLine();
                Console.WriteLine(myVehicle.GetBasicInfo());
                Console.WriteLine();
                Console.WriteLine(myVehicle.GetFullInfo());
            }
           
        }
    }
}
