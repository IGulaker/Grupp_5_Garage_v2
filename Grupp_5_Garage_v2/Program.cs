using System;


namespace Vehicle1
    
{
    class Vehicle
    {
        static void Main(string[] args)
        {
            Car myObj = new Car();
            myObj.CarName = "";

          
        }
    }
    class Car : Vehicle 
    {
        private string CarName;
        public string CarName
        {
            get { return CarName; }
            set { CarName = value}
        }
        
    }

    class Bus : Vehicle 
    {

    }

    class MotorCycle : Vehicle 
    {

    }

    class Truck : Vehicle
    {

    }

    class Moped : Vehicle
    {

    }
}
