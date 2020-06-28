using System;
using Parking_Garage.Models;

namespace Parking_Garage.Services
{
    public interface IVehicleService
    {
        int InsertVehicle(VehicleModel vehicle);

        void ShowGarage();

        void checkOutVehicle(string plateId);

        Object getGarageStateObj();
    }
}
