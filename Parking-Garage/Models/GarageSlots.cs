using System;
using System.Collections;
using System.Collections.Generic;

namespace Parking_Garage.Models
{
    public class GarageSlots
    {
        public static Dictionary<string, VehicleModel> vehiclesInGarage;
        public static List<VehicleModel> vip = new List<VehicleModel>(10);
        public static List<VehicleModel> value = new List<VehicleModel>(20);
        public static List<VehicleModel> regular = new List<VehicleModel>(30);

        private GarageSlots()
        {
            vehiclesInGarage = new Dictionary<string, VehicleModel>();
            vip = new List<VehicleModel>(10);
            value = new List<VehicleModel>(20);
            regular = new List<VehicleModel>(30);
        }

        static class HolderClass
        {
            public static GarageSlots instance = new GarageSlots();
        }

        public static GarageSlots getInstance()
        {
            return HolderClass.instance;
        }

        //public bool addToGarage(VehicleModel vehicle) 
        //{
        //    switch (vehicle.getClassType())
        //    {
        //        case 'A':
        //            {
        //                vehiclesInGarage.Add(vehicle.getPlateId(), vehicle);
        //                vip.Add(vehicle);
        //                break;
        //            }
        //        case 'B':
        //            {
        //                vehiclesInGarage.Add(vehicle.getPlateId(), vehicle);
        //                value.Add(vehicle);
        //                break;
        //            }
        //        case 'C':
        //            {
        //                vehiclesInGarage.Add(vehicle.getPlateId(), vehicle);
        //                regular.Add(vehicle);
        //                break;
        //            }
        //    }
        //}
    }
}
