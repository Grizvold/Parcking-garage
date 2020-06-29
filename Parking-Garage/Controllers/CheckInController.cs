using System;
using Parking_Garage.Models;
using Parking_Garage.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IO;

namespace Parking_Garage.Controllers
{
    public class CheckInController : Controller
    {
        // get singleton service instance
        public readonly IVehicleService _vehicleService;

        public CheckInController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody] VehicleModel vehicle)
        {
            var plate_id = vehicle.plateId;

            //Console.WriteLine(vehicle.plateId);
            //Console.WriteLine(vehicle.ticketType);
            //Console.WriteLine(vehicle.vehicleType);
            //Console.WriteLine(vehicle.vehicleHeight);
            //Console.WriteLine(vehicle.vehicleWidth);
            //Console.WriteLine(vehicle.vehicleLength);

            int res = _vehicleService.InsertVehicle(vehicle);

            //_vehicleService.ShowGarage(); //Debug
            IEnumerable<int> responseResult = new List<int> { res };

            if(res != 0)
            {
                //StatusCode = 400;
                return BadRequest(responseResult);
            }
            else
            {
                //StatusCode = 200;
                return Ok(responseResult);
            }
        }
    }
}
