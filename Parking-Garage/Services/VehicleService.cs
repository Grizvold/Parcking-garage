using System;
using System.Collections;
using System.Collections.Generic;
using Parking_Garage.Models;

namespace Parking_Garage.Services
{
    public class VehicleService : IVehicleService
    {
        private Dictionary<string, string> vehicleClass;
        public Dictionary<string, VehicleModel> vehiclesInGarage;
        public Dictionary<int, string> slotToPlate;

        public VehicleService()
        {
            this.vehicleClass = new Dictionary<string, string>();
            this.vehiclesInGarage = new Dictionary<string, VehicleModel>();
            this.slotToPlate = new Dictionary<int, string>();

            initVehicleClass();
        }

        /*
        Motorcycle – Class A
        Private – Class A
        Crossover – Class A
        SUV – Class B
        Van – Class B
        Truck – Class C
        */
        private void initVehicleClass()
        {
            this.vehicleClass.Add("Motorcycle", "A");
            this.vehicleClass.Add("Private", "A");
            this.vehicleClass.Add("Crossover", "A");
            this.vehicleClass.Add("SUV", "B");
            this.vehicleClass.Add("Van", "B");
            this.vehicleClass.Add("Truck", "C");
        }

        public int InsertVehicle(VehicleModel vehicle)
        {
            string newTicketType = validateVehicleTicket(vehicle);
            if (!vehicle.ticketType.Equals(newTicketType))
            {
                TicketModel oldT = new TicketModel(vehicle.ticketType);
                TicketModel newT = new TicketModel(newTicketType);
                return newT.cost - oldT.cost;
            }

            if (insertToSlot(vehicle))
            {
                vehiclesInGarage.Add(vehicle.plateId, vehicle);
                return 0;
            }
            return -1;
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
            switch(vehicle.ticketType)
            {
                case "vip":
                    return vehicle.ticketType;
                case "value":
                    if (!validateTicket(vehicle))
                    {
                        return "vip";
                    }
                    return "value";
                case "regular":
                    if (!validateTicket(vehicle))
                    {
                        vehicle.ticketType = "value";
                        if (!validateTicket(vehicle))
                        {
                            vehicle.ticketType = "regular";
                            return "vip";
                        }
                        vehicle.ticketType = "regular";
                        return "value";
                    }
                    return "regular";

                default:
                    break;
            }

            return null;
        }

        private bool validateTicket(VehicleModel vehicle)
        {
            TicketModel ticket = new TicketModel(vehicle.ticketType);
            string vehicleType = vehicleClass.GetValueOrDefault(vehicle.vehicleType);

            if (!ticket.vehicleClasses.Contains(vehicleType))
            {
                return false;
            }
            if (ticket.maxHeight < vehicle.vehicleHeight)
            {
                return false;
            }

            if (ticket.maxWidth < vehicle.vehicleWidth)
            {
                return false; 
            }

            if (ticket.maxlength < vehicle.vehicleLength)
            {
                return false; 
            }

            return true;
        }

        public Object getGarageStateObj()
        {
            return slotToPlate;
        }


        public bool checkOutVehicle(string plateId)
        {
            if (!vehiclesInGarage.ContainsKey(plateId))
            {
                return false;
            }

            vehiclesInGarage.Remove(plateId);

            foreach(int slot in slotToPlate.Keys)
            {
                if (plateId.Equals(slotToPlate.GetValueOrDefault(slot)))
                {
                    slotToPlate.Remove(slot);
                    break;
                }
            }
            return true;
        }

        //DEBUG
        public void ShowGarage()
        {
            foreach (KeyValuePair<int, string> entry in slotToPlate)
            {
                Console.WriteLine("slot: " + entry.Key + ", plateID: " + entry.Value);
            }
        }

    }
}
