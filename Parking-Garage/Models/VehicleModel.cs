using System;
namespace Parking_Garage.Models
{
    public class VehicleModel
    {
        public string plateId { get; set; }
        public string vehicleType { get; set; }
        public string ticketType { get; set; }
        public int vehicleHeight { get; set; }
        public int vehicleWidth { get; set; }
        public int vehicleLength { get; set; }
    }
}
