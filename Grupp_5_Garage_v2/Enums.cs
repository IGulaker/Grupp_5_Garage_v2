using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    public enum FuelType
    {
        Bensin = 1,
        Diesel,
        Hybrid,
        Gas,
        El
    }
    public enum WeightClass
    {
        Lätt = 1,
        Mellan,
        Tung,
    }
    public enum MotorCycleType
    {
        Basic = 1,
        Allroad,
        Custom,
        Offroad,
        Sport,
        Touring,
    }
    public enum RandomManufacturer
    {
        Volvo,
        Mercedes,
        Volkswagen,
        Fiat,
        BMW,
        Chevrolet,
        Toyota
    }

    public enum Colors
    {
        Vit,
        Svart,
        Grå,
        Röd,
        Silver,
        Blå,
        Rosa,
        Grön,
        Orange,
        Gul,
    }

    public enum BusCompanies
    {
        Wallners_Buss,
        Wahlmans_Buss_AB,
        Strömberg_Buss_AB,
        Nettbuss_Stadsbussarna_AB,
        Gunnars_Buss,
        Merresor_Buss,
        Vy_Buss_Stadsbussarna,
        Hedmans_Buss_och_Taxi
    }

    public enum ChoiceID
    {
        CreateGarage,
        LoadGarage,
        RemoveVehicle,

        CreateMoped,
        CreateMoped1, // Används i "Program.cs"
        CreateMoped2, // Används i "Program.cs"
        CreateMotorcycle,
        CreateCar,
        CreateBus,
        CreateTruck,

        ListAllVehicles,
        ListMopeds,
        ListMotorcycles,
        ListCars,
        ListBuses,
        ListTrucks,

        SearchByRegNr,
        SearchByColour,
        SearchByNrOfWheels,
        SearchByNrOfSeats,
        SearchByFuelType,
        SearchByManufacturer,
        SearchByYearModel,
        SearchByReceieptNr,
        // Moped
        SearchByClass,
        SearchByHelmetBox,
        // Motorcycle
        SearchByWeightclass,
        SearchByType,
        // Car
        SearchByRail,
        SearchByNrOfDoors,
        // Bus
        SearchByDoubleDecker,
        SearchByCompany,
        // Truck
        SearchByBogie,
        SearchBySleepingCabin
    }

    public enum MenuID
    {
        StartUp,
        Main,
        AddVehicle,
        GetVehicle,
        CreateVehicle,
        Filter,
        FilterSearch
    }
}