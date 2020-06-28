using System;
using System.Collections;
using System.Collections.Generic;
using Parking_Garage.Models;

namespace Parking_Garage.Services
{
    public class VehicleService : IVehicleService
    {

        public Dictionary<string, VehicleModel> vehiclesInGarage;
        public Dictionary<int, string> slotToPlate;

        public VehicleService()
        {
            this.vehiclesInGarage = new Dictionary<string, VehicleModel>();
            this.slotToPlate = new Dictionary<int, string>();
        }

        public bool InsertVehicle(VehicleModel vehicle)
        {

            if (!vehicle.ticketType.Equals(validateVehicleTicket(vehicle)))
            {
                //TODO: return the currect ticket type
                return false;
            }

            if (insertToSlot(vehicle))
            {
                vehiclesInGarage.Add(vehicle.plateId, vehicle);
                return true;
            }
            return false;
        }

        private bool insertToSlot(VehicleModel vehicle)
        {
            if (vehiclesInGarage.ContainsKey(vehicle.plateId))
            {
                return false;
            }

            switch (vehicle.ticketType)
            {
                case "vip":
                    {
                        for (int i = 1; i <= 10; ++i)
                        {
                            if (!slotToPlate.ContainsKey(i))
                            {
                                slotToPlate.Add(i, vehicle.plateId);
                                return true;
                            }

                            //if (slotToPlate.GetValueOrDefault(i) == null)
                            //{
                            //    slotToPlate.Add(i, vehicle.plateId);
                            //    return true;
                            //}
                        }
                        break; 
                    }
                case "value":
                    {
                        for (int i = 11; i <= 30; ++i)
                        {
                            if (!slotToPlate.ContainsKey(i))
                            {
                                slotToPlate.Add(i, vehicle.plateId);
                                return true;
                            }
                                //if (slotToPlate.GetValueOrDefault(i) == null)
                                //{
                                //    slotToPlate.Add(i, vehicle.plateId);
                                //    return true;
                                //}
                            }
                            break;
                    }
                case "regular":
                    {
                        for (int i = 31; i <= 60; ++i)
                        {
                            if (!slotToPlate.ContainsKey(i))
                            {
                                slotToPlate.Add(i, vehicle.plateId);
                                return true;
                            }
                            //    if (slotToPlate.GetValueOrDefault(i) == null)
                            //{
                            //    slotToPlate.Add(i, vehicle.plateId);
                            //    return true;
                            //}
                        }
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }

            return false;
        }

        private string validateVehicleTicket(VehicleModel vehicle)
        {
            TicketModel ticket = new TicketModel(vehicle.ticketType);

            if (ticket.maxHeight < vehicle.vehicleHeight)
            {
                //TODO: in case size doesnt match
                return null; // false
            }
            if (ticket.maxWidth < vehicle.vehicleWidth)
            {
                //TODO: in case size doesnt match
                return null; // false
            }
            if (ticket.maxlength < vehicle.vehicleLength)
            {
                //TODO: in case size doesnt match
                return null; // false
            }

            return vehicle.ticketType;
        }

        public void ShowGarage()
        {
            foreach (KeyValuePair<int, string> entry in slotToPlate)
            {
                Console.WriteLine("slot: " + entry.Key + ", plateID: " + entry.Value);
            }
        }

        public Object getGarageStateObj()
        {
            return slotToPlate;
        }


        public void checkOutVehicle(string plateId)
        {
            vehiclesInGarage.Remove(plateId);

            foreach(int slot in slotToPlate.Keys)
            {
                if (plateId.Equals(slotToPlate.GetValueOrDefault(slot)))
                {
                    slotToPlate.Remove(slot);
                    break;
                }
            }
        }

    }
}
