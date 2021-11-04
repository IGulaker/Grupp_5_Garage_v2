using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    enum FuelType
    {
        Bensin,
        Diesel,
        Hybrid,
        Gas,
        El
    }
    enum WeightClass
    {
        Lätt,
        Mellan,
        Tung,
    }
    enum MotorCycleType
    {
        Basic,
        Allroad,
        Custom,
        Offroad,
        Sport,
        Touring,
    }
    enum RandomManufacturer
    {
        Volvo,
        Mercedes,
        Volkswagen,
        Fiat,
        BMW,
        Chevrolet,
        Toyota
    }

    enum ChoiceID
    {
        CreateGarage,
        LoadGarage
    }
}