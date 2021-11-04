using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;


namespace Grupp_5_Garage_v2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Vehicle> lista = new List<Vehicle>();
            for (int i = 1; i < 21; i++)
			{
                switch (i)
	            {
                    case 1 or 6 or 11 or 16:
                       lista.Add(new Car());
                       break;
		            case 2 or 7 or 12 or 17:
                       lista.Add(new Moped());
                       break;
                    case 3 or 8 or 13 or 18:
                       lista.Add(new MotorCycle());
                       break;
                    case 4 or 9 or 14 or 19:
                       lista.Add(new Bus());
                       break;
                    case 5 or 10 or 15 or 20:
                       lista.Add(new Truck());
                       break;
	            }
			}
            //foreach (var item in lista)
            //{
            //    TypeBasicInfo(item);
            //}
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Vehicle>));
            FileStream myfile = File.Create(@"c:\Skola\MyTest.xml");
            writer.Serialize(myfile, lista);
            myfile.Close();
            //List<Vehicle> list2 = new List<Vehicle>();
            
            //StreamReader file2 = new StreamReader(@"c:\Skola\MyTest.xml");
            //list2.Add((Vehicle)writer.Deserialize(file2));
            //file2.Close();
            //foreach (var item in list2)
            //{
            //    TypeBasicInfo(item);
            //}
        }

        private static void TypeBasicInfo(Vehicle vehicle)
        {
            Console.WriteLine("");
           
            Console.WriteLine(vehicle);
            Console.WriteLine("Storlek\t\t"+vehicle.Size);
        }
    }
}
