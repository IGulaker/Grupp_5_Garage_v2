using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    class Garage
    {
        public int NumberOfParkingLots
        {
            get => default;
            set
            {
                NumberOfParkingLots = value;
            }
        }

        public List<Vehicle> ParkedVehicles
        {
            get => default;
            set
            {
            }
        }

        public List<Vehicle> UnparkedVehicle
        {
            get => default;
            set
            {
            }
        }

        public void ListVehicles()
        {
            throw new System.NotImplementedException();
        }

        public void ListTypeOfVehicle()
        {
            throw new System.NotImplementedException();
        }

        public bool AddVehicle()
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveVehicle()
        {
            throw new System.NotImplementedException();
        }

        public Vehicle SearchVehicle(string regNum)
        {
            throw new System.NotImplementedException();
        }

        public string SearchByColor()
        {
            throw new System.NotImplementedException();
        }

        public void SearchByModelYear(int model)
        {
            throw new System.NotImplementedException();
        }

        public void SearchByManufacturer(string manufacturer)
        {
            throw new System.NotImplementedException();
        }

        public void SearchByReceiptNumber(int receiptNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
