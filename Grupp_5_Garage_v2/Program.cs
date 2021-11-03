using System;

namespace Grupp_5_Garage_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Skriv in regnummer: ");
                string regnr = Console.ReadLine();
                //OtherMethods.IsValidLicenseNumber(regnr);
                Console.WriteLine(OtherMethods.IsValidLicenseNumber(regnr, out string exeption));
                Console.WriteLine(exeption);
                Console.WriteLine(regnr);
            }
        }
    }
}
